using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppOpenGl.Event
{
    public class RotationEventArgs : EventArgs
    {
        public char Axis { get; }
        public double Angle { get; }

        public RotationEventArgs(char axis, double angle)
        {
            Axis = axis;
            Angle = angle;
        }
    }
}
