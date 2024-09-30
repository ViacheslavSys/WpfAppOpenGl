using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppOpenGl
{
    public class SegmentModel
    {
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }

        public SegmentModel(int startIndex, int endIndex)
        {
            StartIndex = startIndex;
            EndIndex = endIndex;
        }
    }
}
