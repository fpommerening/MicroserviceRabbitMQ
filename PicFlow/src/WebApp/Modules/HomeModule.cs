using System;
using System.Linq;
using FP.MsRMQ.PicFlow.WebApp.Models;
using Nancy;

namespace FP.MsRMQ.PicFlow.WebApp.Modules
{
    public class HomeModule : NancyModule
    {
        

        public HomeModule(ImageRepository imgRepo)
        {
            Get("/", async args =>
            {
                var identity = this.Context.CurrentUser;
                if (identity == null)
                {
                    return View["Login"];
                }
                else
                {
                    var model = new Home {Message = "Herzlich Willkommen"};

                    model.Jobs = await imgRepo.GetProcessingJobs(Guid.Parse(identity.Identity.Name));
                    return View["Home", model];
                }
            });

            Get("/images/{jobId}/{imageId}", async args =>
            {
                var identity = this.Context.CurrentUser;
                if (identity == null)
                {
                    return HttpStatusCode.Unauthorized;
                }
                Guid jobId = Guid.Parse(args.jobId.ToString());
                Guid imageId = Guid.Parse(args.imageId);

                var job = await imgRepo.GetImageJobById(jobId, Guid.Parse(identity.Identity.Name));
                var image = job?.Images.FirstOrDefault(x => x.Id == imageId);
                if (job == null || image == null)
                {
                    return HttpStatusCode.NotFound;
                }

                return new ByteArrayResponse(image.Data, MimeTypes.GetMimeType(job.Filename));
            });

            Get("/contact", args => View["Contact"]);

            Get("/login", args=> View["Login"]);
        }
    }
}
