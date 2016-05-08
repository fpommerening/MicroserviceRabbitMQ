using System;
using System.Threading.Tasks;
using EasyNetQ;
using FP.MsRmq.ProcessChain.Contracts;
using FP.MsRmq.ProcessChain.Contracts.Common;
using FP.MsRmq.ProcessChain.Contracts.Customer;
using FP.MsRmq.ProcessChain.Contracts.Invoic;
using Newtonsoft.Json;

namespace FP.MsRmq.ProcessChain.Processes.Messages
{
    public class MessageRouter : BusinessProcessBase
    {
        protected override IDisposable CreateSubscription(IBus bus)
        {
            return bus.SubscribeAsync<ProcessRequest>("MessageRouter", OnMessage, c => c.WithTopic("MessageRouter"));
        }

        private async Task OnMessage(ProcessRequest processRequest)
        {
            var rawMessage = processRequest.Message as RawMessage;
            if (rawMessage == null)
            {
                Console.WriteLine("NULL");
            }
            var msg = JsonConvert.DeserializeObject<Message>(rawMessage.Value);

            if (msg.Type == "Invoic")
            {
                InvoicMessage inovicMsg = null;
                if (JsonHelper.IsValid<Bill>(rawMessage.Value))
                {
                    inovicMsg = JsonConvert.DeserializeObject<Bill>(rawMessage.Value);
                }
                else if (JsonHelper.IsValid<Reversal>(rawMessage.Value))
                {
                    inovicMsg = JsonConvert.DeserializeObject<Reversal>(rawMessage.Value);
                }
                await StartProcess("InvoicRouter", inovicMsg, processRequest.SenderId);
            }
            else if (msg.Type == "Customer")
            {
                var customerMsg = JsonConvert.DeserializeObject<Registration>(rawMessage.Value);
                await StartProcess("CustomerRouter", customerMsg, processRequest.SenderId);
            }
            else
            {
                throw new NotSupportedException(string.Format("Message type {0} is not supported", msg.Type));
            }
        }
    }
}
