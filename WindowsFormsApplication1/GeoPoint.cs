using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class GeoPoint
    {
        public double X;
        public double Y;
                      
        public GeoPoint()
        {
            X = 0;
            Y = 0;
        }

        public GeoPoint(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
