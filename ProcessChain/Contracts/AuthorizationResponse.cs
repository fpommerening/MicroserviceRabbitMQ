using System;

namespace FP.MsRmq.ProcessChain.Contracts
{
    public class AuthorizationResponse
    {
        public bool IsValid { get; set; }

        public Guid Id { get; set; }
    }
}
