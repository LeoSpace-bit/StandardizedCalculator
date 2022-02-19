using Microsoft.CSharp;
using StandardizedCalculator.NonlinearEquation;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
            //#region SystemOfEquations (1)

            //var mat = new double[4, 5]
            //{
            //    { 4.8,  12.5,   -6.3,  -9.7,    3.5     },
            //    { 22,  -31.7,   12.4,  -8.7,    4.6     },
            //    { 15,   21.1,   -4.5,   14.4,   15      },
            //    { 8.6, -14.4,   6.2,    2.8,   -1.2     }
            //};

            //double[] array = new SystemOfEquations.GaussMethod(mat).Calculate();
            //var values = string.Empty;
            //for (int i = 0, d = 1; i < array.Length; i++, d++)
            //{
            //    values += ($"x{d}: {array[i]}{Environment.NewLine}");
            //}
            //MessageBox.Show(values);

            //#endregion

            //#region Integral (2)

            ////ans = 0.446 // монте карло --> метод симпсона | 5.6s | 
            //double f(double x) => (Math.Sqrt(0.4 * x + 1.7)) / (1.5 * x + Math.Sqrt(x * x + 1.3));

            //double answer = new Integration.MonteCarloMethod().Calculate(f, 1.2, 2.6, 100000);

            //MessageBox.Show($"{answer}");

            //#endregion

            //#region Combine method (3)
            //var equation = new Equation
            //(
            //    precision: 5,
            //    function: (x, precision) => Math.Round(2 * Math.Sin(x) - 2 - x, precision),
            //    firstDerivative: (x, precision) => Math.Round(2 * Math.Cos(x) - 1, precision),
            //    secondDerivatives: (x, precision) => Math.Round(-2 * Math.Sin(x), precision)
            //);

            //CombinedMethod combinedMethod = new CombinedMethod(equation);
            //var x = combinedMethod.Calculate(-10, 10, Math.Pow(10, -equation.Precision));

            //MessageBox.Show($"x = {x} | Ec/ans = {equation.Precision}");
            //#endregion


        }
    }
}
