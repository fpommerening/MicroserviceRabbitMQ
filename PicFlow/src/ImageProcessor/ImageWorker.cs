using System;
using System.IO;
using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.NonGeneric;
using FP.MsRMQ.PicFlow.Contracts.Dto;
using FP.MsRMQ.PicFlow.Contracts.FileHandler;
using FP.MsRMQ.PicFlow.Contracts.Messages;
using ImageProcessorCore;

namespace FP.MsRMQ.PicFlow.ImageProcessor
{
    public class ImageWorker : IDisposable
    {
        private readonly IBus _bus;
        private IDisposable _subscription;
        private readonly string _imageDbConnectionString;

        public ImageWorker(IBus bus, string imageDbConnectionString)
        {
            _bus = bus;
            _imageDbConnectionString = imageDbConnectionString;
        }

        public void Init()
        {
            _subscription = _bus.SubscribeAsync<ImageProcessingJob>("ImageProcessor", job => WorkImage(job));
        }

        private async Task WorkImage(ImageProcessingJob job)
        {
            var fileHandler = new MongoDbFileHandler(_imageDbConnectionString);
            var sourcefile = await fileHandler.GetMessageObject<DtoImage>(job.Id);

            var outputfile = AddOverlay(sourcefile, job.Overlay, job.Resolution);
            var id = await fileHandler.SaveMessageObject(outputfile);

            foreach (var successor in job.Successors)
            {
                successor.Id = id;
                await _bus.PublishAsync(successor.GetType(), successor);
            }
        }

        private DtoImage AddOverlay(DtoImage sourcefile, string overlayId, int resolution)
        {
            var outputfile = new DtoImage();
            using (var inputstream = new MemoryStream(sourcefile.Data))
            using (var overlay = GetOverlay(overlayId, resolution))
            using (var output = new MemoryStream())
            {
                var imgInput = new Image(inputstream);
                var imgOverlay = new Image(overlay);

                int height = Convert.ToInt32(Math.Sqrt((resolution*1000000)/(((double) imgInput.Height)* (double)imgInput.Width))* (double)imgInput.Height);
                int width = Convert.ToInt32(Math.Sqrt((resolution * 1000000) / (((double)imgInput.Height) * (double)imgInput.Width)) * (double)imgInput.Width);

                int overlaysize = Convert.ToInt32((double) width*0.2);
                int padding = overlaysize + (resolution * 10);

                imgInput.Resize(width, height)
                    .Blend(imgOverlay.Resize(overlaysize, overlaysize).Pad(padding, padding), 80)
                    .Save(output);
                outputfile.Data = output.ToArray();
                outputfile.FileName = sourcefile.FileName;
            }
            return outputfile;
        }

        private FileStream GetOverlay(string overlayId, int resolution)
        {
            var prefix = string.Empty;

            switch (overlayId.ToLowerInvariant())
            {
                case "dos":
                    prefix = "Overlays/DevSpace";
                    break;
                case "sp":
                    prefix = "Overlays/Sparta";
                    break;
                default:
                    throw new NotSupportedException($"the overlay id {overlayId} is not supported");
            }

            if (resolution > 10)
            {
                return File.OpenRead($"{prefix}_10_10.png");
            }
            if (resolution >= 6)
            {
                return File.OpenRead($"{prefix}_7_7.png");
            }
            if (resolution >= 3)
            {
                return File.OpenRead($"{prefix}_5_5.png");
            }
            return File.OpenRead($"{prefix}_3_3.png");
        }

        public void Dispose()
        {
            _subscription?.Dispose();
            _subscription = null;
        }
    }
}
