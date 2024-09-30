using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppOpenGl.Event
{
    public class OPPEventArgs : EventArgs
    {
        public char Axis { get; }
        public double Focus { get; }

        public OPPEventArgs(char axis, double focus)
        {
            Axis = axis;
            Focus = focus;
        }
    }
}
