using AngouriMath.Core;

namespace StandardizedCalculator.NonlinearEquation
{
    public class Equation
    {
        public double Precision { get; }
        public FastExpression Function { get; }
        public FastExpression FirstDerivative { get; }
        public FastExpression SecondDerivatives { get; }

        public Equation(FastExpression function, FastExpression firstDerivative, FastExpression secondDerivatives, double precision = 0.00001)
        {
            Precision = precision;
            Function = function;
            FirstDerivative = firstDerivative;
            SecondDerivatives = secondDerivatives;
        }
    }
}