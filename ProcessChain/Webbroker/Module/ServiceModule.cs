using System;
using System.IO;
using FP.MsRmq.ProcessChain.Contracts;
using FP.MsRmq.ProcessChain.Contracts.Common;
using Nancy;
using Nancy.Security;

namespace FP.MsRmq.ProcessChain.Webbroker.Module
{
    public class ServiceModule : NancyModule
    {
        public ServiceModule(ProcessRepository processRepository)
        {
            Post["/Service/", true] = async (parameter, ct)
                =>
            {
                this.RequiresAuthentication();

                var currentUser = this.Context.CurrentUser as ProcessUserIdentity;
                if(currentUser == null)
                {
                    return HttpStatusCode.BadRequest;
                }

                Context.Request.Body.Position = 0;
                string message;
                using (var sr = new StreamReader(Context.Request.Body))
                {
                    message = await sr.ReadToEndAsync().ConfigureAwait(false);
                }

                var jsonIsValid = JsonHelper.IsValid<Message>(message);
                if (jsonIsValid)
                {
                    await processRepository.StartProcess("MessageRouter",
                        new RawMessage {Id = Guid.NewGuid(), Timestamp = DateTime.UtcNow, Value = message},
                        currentUser.Id);
                }

                return jsonIsValid ? HttpStatusCode.OK : HttpStatusCode.NotExtended;
            };
        }
    }
}
