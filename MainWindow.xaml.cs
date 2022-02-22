using AngouriMath;
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
using System.Text.RegularExpressions;
using System.Threading;
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

        private void Grid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) => DragMove();
        private void CloseForm_Click(object sender, RoutedEventArgs e) => Close();

        private void NLE_Calculate(object sender, RoutedEventArgs e)
        {
            #region Combine method (3)

            double value = Math.Abs(CheckPrecision(NLQ_precision, 1));

            if (!double.IsNaN(value))
            {
                try
                {
                    var equation = new Equation
                    (
                        precision: (int)Math.Abs(Math.Log10(value)),
                        function: (x, precision) => Math.Round(2 * Math.Sin(x) - 2 - x, precision),
                        firstDerivative: (x, precision) => Math.Round(2 * Math.Cos(x) - 1, precision),
                        secondDerivatives: (x, precision) => Math.Round(-2 * Math.Sin(x), precision)
                    );

                    CombinedMethod combinedMethod = new(equation);

                    double minimum = CheckValue(NLQ_from);
                    double maximum = CheckValue(NLQ_to);

                    NLE_AdditinalText.Visibility = Visibility.Visible;

                    NLE_Answer.Content = $"Ответ: {combinedMethod.Calculate(minimum, maximum, Math.Pow(10, -equation.Precision))}";
                }
                catch (Exception exc)
                {
                    MessageBox.Show($"Ошибка: {exc.Message}");
                }
            }
            #endregion
        }

        private async void Integral_Calculate(object sender, RoutedEventArgs e)
        {
            #region Integral (2)

            I_Calculating.IsEnabled = false;
            I_Answer.Content = "Происходит расчёт";

            if (int.TryParse(I_iteration.Text, out int precision))
            {
                if (double.TryParse(I_a.Text.Replace('.', ','), out double i_a))
                {
                    if (double.TryParse(I_b.Text.Replace('.', ','), out double i_b))
                    {
                        Entity integrand = "x";

                        try
                        {
                            if (!string.IsNullOrWhiteSpace(I_integrand.Text))
                            {
                                integrand = I_integrand.Text;
                            }
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show($"Неверный формат{Environment.NewLine}{exc.Message}");
                        }

                        double answer = await Task.Run(() => new Integration.MonteCarloMethod().Calculate(integrand.Compile("x"), i_a, i_b, precision));

                        I_Answer.Content = $"Ответ: {answer}";
                    }
                    else
                    {
                        MessageBox.Show("Неверный формат значения 'б'");
                    }
                }
                else
                {
                    MessageBox.Show("Неверный формат значения 'а'");
                }
            }
            else
            {
                MessageBox.Show("Неверный формат ввода количества итераций");
            }

            I_Calculating.IsEnabled = true;

            #endregion
        }

        private async void SoE_Calculate(object sender, RoutedEventArgs e)
        {
            #region SystemOfEquations (1)

            SoE_Calculating.IsEnabled = false;
            SoE_Answer.Content = "Происходит расчёт";

            double precision = Math.Abs(CheckPrecision(SoE_precision, 1));

            if (!double.IsNaN(precision))
            {
                try
                {
                    if (double.TryParse(SoE_11.Text.Replace('.', ','), out double x11) && double.TryParse(SoE_12.Text.Replace('.', ','), out double x12) && double.TryParse(SoE_13.Text.Replace('.', ','), out double x13) && double.TryParse(SoE_14.Text.Replace('.', ','), out double x14) && double.TryParse(SoE_1A.Text.Replace('.', ','), out double x1A))
                    {
                        if (double.TryParse(SoE_21.Text.Replace('.', ','), out double x21) && double.TryParse(SoE_22.Text.Replace('.', ','), out double x22) && double.TryParse(SoE_23.Text.Replace('.', ','), out double x23) && double.TryParse(SoE_24.Text.Replace('.', ','), out double x24) && double.TryParse(SoE_2A.Text.Replace('.', ','), out double x2A))
                        {
                            if (double.TryParse(SoE_31.Text.Replace('.', ','), out double x31) && double.TryParse(SoE_32.Text.Replace('.', ','), out double x32) && double.TryParse(SoE_33.Text.Replace('.', ','), out double x33) && double.TryParse(SoE_34.Text.Replace('.', ','), out double x34) && double.TryParse(SoE_3A.Text.Replace('.', ','), out double x3A))
                            {
                                if (double.TryParse(SoE_41.Text.Replace('.', ','), out double x41) && double.TryParse(SoE_42.Text.Replace('.', ','), out double x42) && double.TryParse(SoE_43.Text.Replace('.', ','), out double x43) && double.TryParse(SoE_44.Text.Replace('.', ','), out double x44) && double.TryParse(SoE_4A.Text.Replace('.', ','), out double x4A))
                                {
                                    var matrix = new double[4, 5]
                                    {
                                        { x11, x12, x13, x14, x1A },
                                        { x21, x22, x23, x24, x2A },
                                        { x31, x32, x33, x34, x3A },
                                        { x41, x42, x43, x44, x4A }
                                    };
                                    double[] array = await Task.Run(() => new SystemOfEquations.GaussMethod(matrix).Calculate());
                                    SoE_Answer.Content = $"Ответ: \tx\u2081 = {Math.Round(array[0], (int)Math.Abs(Math.Log10(precision)))}\t\t\tx\u2082 = {Math.Round(array[1], (int)Math.Abs(Math.Log10(precision)))}{ Environment.NewLine}\tx\u2083 = {Math.Round(array[2], (int)Math.Abs(Math.Log10(precision)))}\t\t\tx\u2084 = {Math.Round(array[3], (int)Math.Abs(Math.Log10(precision)))}";
                                }
                                else
                                {
                                    MessageBox.Show("Неверный формат значения в четвёртой строке");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Неверный формат значения в третьей строке");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Неверный формат значения во второй строке");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный формат значения в первой строке");
                    }
                }
                catch (Exception es)
                {
                    Debug.Write(es.Message);
                }
            }

            SoE_Calculating.IsEnabled = true;

            #endregion
        }

        private double CheckValue(TextBox number)
        {
            var text = number.Text.Replace('.', ',');
            try
            {
                return double.Parse(text);
            }
            catch (Exception)
            {
                MessageBox.Show("Неверный формат");
                return double.NaN;
            }
        }

        private double CheckPrecision(TextBox number, double limit)
        {
            var text = number.Text.Replace('.', ',');
            Regex regex = new Regex(@"^-?[0-9][0-9,\.]+$");

            if (regex.IsMatch(text))
            {
                double d = double.Parse(text);
                if (Math.Abs(d) >= limit)
                {
                    MessageBox.Show($"Установлен лимит |x| <= {limit}");
                    return double.NaN;
                }
                return d;
            }
            else
            {
                MessageBox.Show("Неверный формат");
            }
            return double.NaN;
        }

    }
}
