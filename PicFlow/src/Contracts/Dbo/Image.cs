using System;

namespace FP.MsRMQ.PicFlow.Contracts.Dbo
{
    public class Image
    {
        public Guid Id { get; set; }

        public Byte[] Data { get; set; }

        public int Resolution { get; set; }
    }
}
