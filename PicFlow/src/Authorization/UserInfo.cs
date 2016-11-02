using System;

namespace FP.MsRMQ.PicFlow.Authorization
{
    public class UserInfo
    {
        public bool IsValid { get; set; }

        public string User { get; set; }

        public Guid Id { get; set; }
    }
}
