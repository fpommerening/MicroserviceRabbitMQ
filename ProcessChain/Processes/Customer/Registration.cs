using System;
using System.Threading.Tasks;
using EasyNetQ;
using FP.MsRmq.ProcessChain.Contracts;
using FP.MsRmq.ProcessChain.Contracts.Common;
using FP.MsRmq.ProcessChain.Data;
using FP.MsRmq.ProcessChain.Data.Objects;

namespace FP.MsRmq.ProcessChain.Processes.Customer
{
    public class Registration : BusinessProcessBase
    {
        private CustomerRepository _customerRepository;

        public Registration(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        protected override IDisposable CreateSubscription(IBus bus)
        {
            return bus.SubscribeAsync<ProcessRequest>("Registration", OnMessageRequest, c => c.WithTopic("Registration"));
        }

        public async Task OnMessageRequest(ProcessRequest processRequest)
        {
            var msg = (MsRmq.ProcessChain.Contracts.Customer.Registration) processRequest.Message;

            Message result = null;

            var mappedRegistation = new BOCustomer();

            var denial = Denial.Create("Kunde kenn ich schon :-(", processRequest.MessageId);
            await StartProcess("MessageDispatcher", denial, processRequest.SenderId).ConfigureAwait(false);

            //if (await _customerRepository.CustomerExists(mappedRegistation))
            //{
            //    result = Denial.Create("Der Kunden ist bereits vorhanden", msg.Id);
            //}
            //else
            //{
            //    result = Confirmation.Create(msg.Id);
            //}
            //await StartProcess("MessageDispatcher", result, processRequest.SenderId);
        }
    }
}
