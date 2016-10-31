using System;

namespace FP.MsRMQ.PicFlow.Contracts.Messages
{
    public class AuthenticationResponse
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string User { get; set; }

        public bool IsValid { get; set; }
    }
}
