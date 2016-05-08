using System;
using System.Threading.Tasks;
using EasyNetQ;
using FP.MsRmq.ProcessChain.Contracts;

namespace FP.MsRmq.ProcessChain.Webbroker.Module
{
    public class ProcessRepository
    {
        private IBus _bus;

        public AuthorizationResponse Authorize(string userName, string password)
        {
            var request = new AuthorizationRequest
            {
                UserName = userName,
                Passwort = password,
            };
            var result = GetOrCreateMessageBus().Request<AuthorizationRequest, AuthorizationResponse>(request);
            return result;
        }

        public Task StartProcess(string processName, Message message, Guid senderId)
        {
           var processRequest = ProcessRequest.Create(message, senderId);
           return GetOrCreateMessageBus().PublishAsync(processRequest, processName);
        }

        private IBus GetOrCreateMessageBus() => _bus ?? (_bus = RabbitHutch.CreateBus("host=MyRabbitMQ"));
    }
}
