using System;

namespace FP.MsRMQ.PicFlow.WebApp.Modules
{
    public class AuthUser
    {
        public AuthUser()
        {
            Id = Guid.Empty;
        }

        public Guid Id { get; set; }

        public string User { get; set; }

        public bool IsValid { get; set; }

        public bool IsEmpty()
        {
            return Id == Guid.Empty;
        }
    }
}