using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace sinus
{
    public class FunctionsController
    {
        private readonly DrawingArea drawingArea;
        private readonly SineFunction sineFunction;

        public FunctionsController(DrawingArea drawingArea,SineFunction sineFunction)
        {
            this.drawingArea= drawingArea;
            this.sineFunction = sineFunction;
        }

        public void UpdateAmplitude (double newAmplitude)
        {
            sineFunction.amplitude = newAmplitude;
            drawingArea.NewDrawing(sineFunction);
        }

        public void UpdatePeriode(double newPeriode)
        {
            sineFunction.period = newPeriode;
            drawingArea.NewDrawing(sineFunction);
        }
    }
}
