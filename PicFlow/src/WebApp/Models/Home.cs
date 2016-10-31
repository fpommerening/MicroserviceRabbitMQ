using System.Collections.Generic;

namespace FP.MsRMQ.PicFlow.WebApp.Models
{
    public class Home
    {
        public Home()
        {
            Jobs = new List<ProcessingJob>();
        }

        public string Message { get; set; }

        public List<ProcessingJob> Jobs { get; set; }
    }
}
