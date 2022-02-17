using System;

namespace StandardizedCalculator.NonlinearEquation
{
    public class Equation
    {
        public int Precision { get; }
        public Func<double, int, double> Function { get; }
        public Func<double, int, double> FirstDerivative { get; }
        public Func<double, int, double> SecondDerivatives { get; }

        public Equation(Func<double, int, double> function, Func<double, int, double> firstDerivative, Func<double, int, double> secondDerivatives, int precision = 5)
        {
            Precision = precision;
            Function = function;
            FirstDerivative = firstDerivative;
            SecondDerivatives = secondDerivatives;
        }
    }
}