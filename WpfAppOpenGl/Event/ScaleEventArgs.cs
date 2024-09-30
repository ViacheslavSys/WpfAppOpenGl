using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppOpenGl.Event
{
    public class ScaleEventArgs : EventArgs
    {
        public double ScaleFactor { get; }

        public ScaleEventArgs(double scaleFactor)
        {
            ScaleFactor = scaleFactor;
        }
    }
}
