using System;

namespace FP.MsRMQ.PicFlow.Contracts.Messages
{
    public class AuthenticationRequest
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }
    }
}
