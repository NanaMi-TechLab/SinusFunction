using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sinus
{
    public class FunctionAnalyzer
    {
        public List<double> GetZeroCrossings(Function function, double from, double to,double step=0.01)
        {
            List<double> zeroPoints = new List<double>();

            double lastX = from;
            double lastY = function.GetValue(from);

            for(double x=from+step; x<=to; x += step)
            {
                double y = function.GetValue(x);

                if(lastY*y<=0 && Math.Abs(lastY - y) > 1e-6)
                {
                    double zeroX = (lastX + x) / 2;
                    zeroPoints.Add(zeroX);
                }

                lastX = x;
                lastY = y;
            }
            return zeroPoints;
        }


    }
}
