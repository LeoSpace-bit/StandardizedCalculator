using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StandardizedCalculator.NonlinearEquation
{
    internal class CombinedMethod
    {
        public Equation Equation { get; private set; }

        public CombinedMethod(Equation equation)
        {
            Equation = equation;
        }

        /// <summary>
        /// Finds the intersection with the x-axis on a range
        /// </summary>
        /// <param name="start">Range start value</param>
        /// <param name="end">Range end value</param>
        /// <param name="precision">Precision of response (input example: 0.00001)</param>
        /// <returns>The value that intersects the x-axis at 0 in the specified range</returns>
        public double Calculate(double start, double end, double precision)
        {
            do
            {
                if ( Equation.Function(start, Equation.Precision) * Equation.SecondDerivatives(start, Equation.Precision) < 0)
                {
                    start -=  Equation.Function(start, Equation.Precision) * (start - end) / (Equation.Function(start, Equation.Precision) - Equation.Function(end, Equation.Precision));
                }
                else if ( Equation.Function(start, Equation.Precision) * Equation.SecondDerivatives(start, Equation.Precision) > 0)
                {
                    start -= Equation.Function(start, Equation.Precision) / Equation.FirstDerivative(start, Equation.Precision);
                }


                if (Equation.Function(end, Equation.Precision) * Equation.SecondDerivatives(end, Equation.Precision) < 0)
                {
                    end -= Equation.Function(end, Equation.Precision) * (end - start) / (Equation.Function(end, Equation.Precision) - Equation.Function(start, Equation.Precision));
                }
                else if (Equation.Function(end, Equation.Precision) * Equation.SecondDerivatives(end, Equation.Precision) > 0)
                {
                    end -= Equation.Function(end, Equation.Precision) / Equation.FirstDerivative(end, Equation.Precision);
                }

            } while (Math.Abs(start - end) > 2 * precision);

            return Math.Round((start + end) / 2, Equation.Precision);

        }

    }
}
