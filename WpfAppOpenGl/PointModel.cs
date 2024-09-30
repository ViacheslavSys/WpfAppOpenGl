using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppOpenGl
{
    public class PointModel
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double H { get; set; }

        public PointModel(double x, double y, double z, double h)
        {
            X = x;
            Y = y;
            Z = z;
            H = h;
        }
        public (double x, double y, double z) GetScaledCoordinates()
        {
            return (X / H, Y / H, Z / H);
        }
    }

}
