using System.Threading.Tasks;
using FP.MsRMQ.PicFlow.ExternalApp.Data;
using FP.MsRMQ.PicFlow.ExternalApp.Models;
using Nancy;

namespace FP.MsRMQ.PicFlow.ExternalApp.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule(EntryRepository repo)
        {
            Get("/", async args =>
            {

                var model = new ImageItems
                {
                    CurrentStartIndex = 1,
                    CurrentEndIndex = 20,
                };

                var count = await repo.GetEntriesCount();

                if (count > model.CurrentEndIndex)
                {
                    model.NextStartIndex = 21;
                    model.NextEndIndex = 40;
                }

                await CreateEnties(repo, model);

                return View["Home", model];
            });

            Get("/{start}/{end}", async args =>
            {
                int start = args.start;
                int end = args.end;

                var model = new ImageItems
                {
                    CurrentStartIndex = start,
                    CurrentEndIndex = end
                };

                if (start > 21)
                {
                    model.PreviousStartIndex = start - 20;
                    model.PreviousEndIndex = start - 1;
                }
                else if(start > 1)
                {
                    model.PreviousStartIndex = 1;
                    model.PreviousEndIndex = start - 1;
                }

                var count = await repo.GetEntriesCount();

                if (count > model.CurrentEndIndex)
                {
                    model.NextStartIndex = end + 1;
                    model.NextEndIndex = end + 20;
                }
                await CreateEnties(repo, model);
            
                return View["Home", model];
            });

            Get("/images/{entryId}", async args =>
            {
                string entryid = args.entryId;
                var entry = await repo.GetEntryById(entryid);
                if (entry?.Image == null)
                {
                    return HttpStatusCode.NotFound;
                }

                return new ByteArrayResponse(entry.Image, MimeTypes.GetMimeType(entry.Filename));
            } );

            Get("/contact", o => View["Contact"]);
        }

        private static async Task CreateEnties(EntryRepository repo, ImageItems model)
        {
            foreach (var entry in await repo.GetEntries(model.CurrentStartIndex, model.CurrentEndIndex))
            {
                var imageItem = new ImageItem
                {
                    Id = entry.Id.ToString(),
                    Message = entry.Message,
                    Timestamp = entry.Timestamp,
                    UserName = entry.UserName
                };

                model.Entries.Add(imageItem);
            }
        }
    }
}
