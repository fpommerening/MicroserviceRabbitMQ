﻿namespace FP.MsRmq.ProcessChain.MarketPartner.Models
{
    public class Request
    {
        public Request()
        {
            UserName = "Spartakiade";
            Password = "SportF3#";
        }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
