using System;

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
                if (Equation.Function.Call(start).Real * Equation.SecondDerivatives.Call(start).Real < 0)
                {
                    start -= Equation.Function.Call(start).Real * (start - end) / (Equation.Function.Call(start).Real - Equation.Function.Call(end).Real);
                }
                else if ( Equation.Function.Call(start).Real * Equation.SecondDerivatives.Call(start).Real > 0)
                {
                    start -= Equation.Function.Call(start).Real / Equation.FirstDerivative.Call(start).Real;
                }


                if (Equation.Function.Call(end).Real * Equation.SecondDerivatives.Call(end).Real < 0)
                {
                    end -= Equation.Function.Call(end).Real * (end - start) / (Equation.Function.Call(end).Real - Equation.Function.Call(start).Real);
                }
                else if (Equation.Function.Call(end).Real * Equation.SecondDerivatives.Call(end).Real > 0)
                {
                    end -= Equation.Function.Call(end).Real / Equation.FirstDerivative.Call(end).Real;
                }

            } while (Math.Abs(start - end) > 2 * precision);

            return Math.Round((start + end) / 2, (int)Math.Abs(Math.Log10(Equation.Precision)));

        }
    }
}