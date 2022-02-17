using StandardizedCalculator.NonlinearEquation;
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

namespace StandardizedCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var equation = new Equation
            (
                precision: 5,
                function: (x, precision) => Math.Round(2 * Math.Sin(x) - 2 - x, precision),
                firstDerivative: (x, precision) => Math.Round(2 * Math.Cos(x) - 1, precision),
                secondDerivatives: (x, precision) => Math.Round(-2 * Math.Sin(x), precision)
            );

            CombinedMethod combinedMethod = new CombinedMethod(equation);
            var x = combinedMethod.Calculate(-10, 10, Math.Pow(10, -equation.Precision));

            MessageBox.Show($"x = {x} | Ec/ans = {equation.Precision}");

        }
    }
}
