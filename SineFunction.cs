using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sinus
{
    public class SineFunction:Function
    {
        public double amplitude { get; set; } = 1;
        public double period {  get; set; }=2*Math.PI;
        public override double GetValue(double x)
        {
           return amplitude*Math.Sin((2*Math.PI/period)*x);

        }
    }
}
