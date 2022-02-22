using AngouriMath.Core;
using System;

namespace StandardizedCalculator.NonlinearEquation
{
    public class EquationOLDBACKUP_TRASH
    {
        public int Precision { get; }
        public Func<double, int, double> Function { get; }
        public Func<double, int, double> FirstDerivative { get; }
        public Func<double, int, double> SecondDerivatives { get; }

        public EquationOLDBACKUP_TRASH(Func<double, int, double> function, Func<double, int, double> firstDerivative, Func<double, int, double> secondDerivatives, int precision = 5)
        {
            Precision = precision;
            Function = function;
            FirstDerivative = firstDerivative;
            SecondDerivatives = secondDerivatives;
        }
    }

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