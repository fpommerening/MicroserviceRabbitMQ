using System;
using System.Threading.Tasks;
using EasyNetQ;
using FP.MsRmq.ProcessChain.Contracts;
using FP.MsRmq.ProcessChain.Contracts.Common;

namespace FP.MsRmq.ProcessChain.Processes.Invoic
{
    public class Reversal : BusinessProcessBase
    {
        protected override IDisposable CreateSubscription(IBus bus)
        {
            return bus.SubscribeAsync<ProcessRequest>("Reversal", OnMessage, c => c.WithTopic("Reversal"));
        }

        private async Task OnMessage(ProcessRequest processRequest)
        {
            var denial = Denial.Create("Storno gibt es nicht :-)",processRequest.MessageId);
            await StartProcess("MessageDispatcher", denial, processRequest.SenderId).ConfigureAwait(false);
        }
    }
}
