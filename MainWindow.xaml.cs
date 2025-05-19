using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sinus
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FunctionsController controller;
        private SineFunction sineFunction;

        public MainWindow()
        {
            InitializeComponent();

            // wait until the window is loaded
            Loaded += (s, e) =>
            {
                var drawingArea = new DrawingArea(DrawingArea);
                sineFunction = new SineFunction();

                controller= new FunctionsController(drawingArea, sineFunction);

                drawingArea.DrawCordinate();
                drawingArea.DrawingFunction(sineFunction);

                AmplitudeSlider.ValueChanged += AmplitudeSlider_ValueChanged;
                AmplitudeBox.KeyDown += AmplitudeBox_KeyDown;

                PeriodeSlider.ValueChanged += PeriodeSlider_ValueChanged;
                PeriodeBox.KeyDown += PeriodeBox_KeyDown;


            };
        }
          private void AmplitudeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double value = e.NewValue;
            AmplitudeBox.Text = value.ToString("F2");
            controller.UpdateAmplitude(value);
        }

        private void AmplitudeBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter && double.TryParse(AmplitudeBox.Text, out double value))
            {
                AmplitudeSlider.Value = value;
            }
        }

        private void PeriodeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double value = e.NewValue;
            PeriodeBox.Text = value.ToString("F2");
            controller.UpdatePeriode(value);
        }

        private void PeriodeBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && double.TryParse(AmplitudeBox.Text, out double value))
            {
                AmplitudeSlider.Value = value;
            }
        }

        
    }

      
}
