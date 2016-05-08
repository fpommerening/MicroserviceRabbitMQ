using System;
using Nancy;

namespace FP.MsRmq.Weblogger
{
    public class ServiceModule : NancyModule
    {
        public ServiceModule()
        {
            Get["/Service/{sessionId}", true] = async (parameter, ct)
                =>
            {
                Guid sessionId = Guid.NewGuid();
                var timestamp = DateTime.UtcNow;
                var remoteHost = Context.Request.UserHostAddress;


                return Response.AsJson(new {Session = sessionId, Timestamp = timestamp, Hostname = Environment.MachineName});
            };

        }
    }
}
