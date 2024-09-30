using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppOpenGl.Event
{
    public class ParallelTransferEventArgs : EventArgs
    {
        public double CoordinateX { get; }
        public double CoordinateY { get; }
        public double CoordinateZ { get; }

        public ParallelTransferEventArgs(double coordinateX, double coordinateY, double coordinateZ)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            CoordinateZ = coordinateZ;
        }
    }
}
