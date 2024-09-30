using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppOpenGl.Event
{
    public class ObliqueShiftEventArgs : EventArgs
    {
        public char Axis1 { get; }
        public char Axis2 { get; }
        public double Factor { get; }

        public ObliqueShiftEventArgs(char axis1, char axis2, double factor)
        {
            Axis1 = axis1;
            Axis2 = axis2;
            Factor = factor;
        }
    }
}
