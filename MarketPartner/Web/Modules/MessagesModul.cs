using System;
using FP.MsRmq.ProcessChain.MarketPartner.Models;
using Nancy;

namespace FP.MsRmq.ProcessChain.MarketPartner.Modules
{
    public class MessagesModul : NancyModule
    {
        public MessagesModul(MessageRepository repo)
        {
            Get["/messages"] = x =>
            {
                var model = new MessageOverview
                {
                    LastUpdate = DateTime.Now,
                    Messages = repo.GetMessages()
                };
                return View["messages", model];
            };
        }


    }
}
