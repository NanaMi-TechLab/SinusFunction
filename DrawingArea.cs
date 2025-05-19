using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace sinus
{
    public class DrawingArea
    {
        private readonly Canvas canvas;

        public DrawingArea(Canvas canvas)
        {
            this.canvas = canvas;
        }

        public void DrawCordinate()
        {
            double width = canvas.ActualWidth;
            double height = canvas.ActualHeight;

            // X-Axis
            canvas.Children.Add(new Line()
            {
                X1 = 0,
                Y1 = height / 2,
                X2 = width,
                Y2 = height / 2,
                Stroke = Brushes.Blue
            });

            // Y-Axis
            canvas.Children.Add(new Line()
            {
                X1 = width / 2,
                Y1 = 0,
                X2 = width / 2,
                Y2 = height,
                Stroke = Brushes.Blue
            });

            // X-Achse-Beschriftung (z. B. -2π bis 2π)
            for (double x = -4 * Math.PI; x <= 4 * Math.PI; x += Math.PI)
            {
                double xPos = (x + Math.PI * 4) * (canvas.ActualWidth / (Math.PI * 8));
                string label = x.ToString("0.##");

                TextBlock text = new TextBlock
                {
                    Text = label,
                    FontSize = 10
                };

                Canvas.SetLeft(text, xPos - 10);
                Canvas.SetTop(text, canvas.ActualHeight / 2 + 5);
                canvas.Children.Add(text);
            }


        }
        //private string FormatPiLabel(double x)
        //{
        //    double tolerance = 0.001;
        //    double pi = Math.PI;

        //    if (Math.Abs(pi) < tolerance)
        //    {
        //        return "0";
        //    }
        //    else if (Math.Abs(x - pi) < tolerance)
        //        return "π";
        //    else if (Math.Abs(x + pi) < tolerance)
        //        return "-π";
        //    else if (Math.Abs(x - 2 * pi) < tolerance)
        //        return "2π";
        //    else if (Math.Abs(x + 2 * pi) < tolerance)
        //        return "-2π";
        //    else if (Math.Abs(x - pi / 2) < tolerance)
        //        return "π/2";
        //    else if (Math.Abs(x + pi / 2) < tolerance)
        //        return "-π/2";
        //    else if (Math.Abs(x - 3 * pi / 2) < tolerance)
        //        return "3π/2";
        //    else if (Math.Abs(x + 3 * pi / 2) < tolerance)
        //        return "-3π/2";

        //    return "";
        //}

        public void DrawingFunction(Function function)
        {
            double width = canvas.ActualWidth;
            double height = canvas.ActualHeight;

            Polyline graph = new Polyline
            {
                Stroke = Brushes.Red,
                StrokeThickness = 2
            };

            for(double x=-Math.PI*4;x<=Math.PI * 4; x += 0.01)
            {
                double y = function.GetValue(x);
                double xPos = (x + Math.PI * 4) * (width / (Math.PI * 8));
                double yPos = (height / 2) - (y * (height / 4));
                graph.Points.Add(new System.Windows.Point(xPos, yPos));
            }
            canvas.Children.Add(graph);
        }

        public void NewDrawing(Function function)
        {
            canvas.Children.Clear();
            DrawCordinate();
            DrawingFunction(function);
            DrawZeroCrossings(function);
        }

        private void DrawZeroCrossings(Function functin)
        {
            var analyzer = new FunctionAnalyzer();
            var zero = analyzer.GetZeroCrossings(functin, -4 * Math.PI, 4 * Math.PI, 0.01);

            double width = canvas.ActualWidth;
            double height = canvas.ActualHeight;

            foreach(double x in zero)
            {
                double xPos = (x + Math.PI * 4) * (width / (Math.PI * 8));
                double yPos = height / 2;

                Ellipse dot = new Ellipse
                {
                    Width = 6,
                    Height = 6,
                    Fill = Brushes.Green
                };
                Canvas.SetLeft(dot, xPos - 3);
                Canvas.SetTop(dot, yPos - 3);
                canvas.Children.Add(dot);

                TextBlock label = new TextBlock
                {
                    Text = $"x ≈ {x:F2}",
                    FontSize = 20,
                    Foreground = Brushes.DarkGreen,
                };
                Canvas.SetLeft(label, xPos - 15);
                Canvas.SetTop(label, yPos + 8);
                canvas.Children.Add(label);

            }
        }
    }
}
