﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardizedCalculator.Integration
{
    internal class MonteCarloMethod
    {
        public double Calculate(Func<double, double> function, double a, double b, int n)
        {
            GenerateRandomValues(a, b, n, out double[] uValues);

            double accumulator = 0;

            foreach (var item in uValues)
            {
                accumulator += function(item);
            }

            return (b - a) / n * accumulator;
        }

        private void GenerateRandomValues(double a, double b, int n, out double[] uValues)
        {
            var values = new List<double>();
            Random random = new Random();

            while (values.Count < n)
            {
                var value = random.NextDouble() * (b - a) + a;
                if (!values.Contains(value))
                {
                    values.Add(value);
                }
            }

            uValues = values.ToArray();
        }



    }
}
