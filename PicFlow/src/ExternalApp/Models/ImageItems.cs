using System.Collections.Generic;

namespace FP.MsRMQ.PicFlow.ExternalApp.Models
{
    public class ImageItems
    {
        public ImageItems()
        {
            Entries = new List<ImageItem>();
            PreviousStartIndex = -1;
            PreviousEndIndex = -1;
            NextStartIndex = -1;
            NextEndIndex = -1;
        }

        public bool ShowPrevious => PreviousStartIndex > -1 && PreviousEndIndex > -1;

        public bool ShowNext => NextStartIndex > -1 && NextEndIndex > -1;

        public int PreviousStartIndex { get; set; }

        public int PreviousEndIndex { get; set; }

        public int CurrentStartIndex { get; set; }

        public int CurrentEndIndex { get; set; }

        public int NextStartIndex { get; set; }

        public int NextEndIndex { get; set; }

        public List<ImageItem> Entries { get; }
    }

}
