using System.Threading.Tasks;
using EasyNetQ;
using FP.MsRMQ.PicFlow.Contracts.Messages;

namespace FP.MsRMQ.PicFlow.WebApp.Modules
{
    public class MessageRepository
    {
        private readonly IBus _bus = null;

        public MessageRepository(IBus bus)
        {
            _bus = bus;
        }

        public Task SendImageProcessingJob(ImageProcessingJob job)
        {
            return _bus.PublishAsync(job);
        }

        public Task SendUploadJob(ImageUploadJob job)
        {
            return _bus.PublishAsync(job);
        }
    }
}
