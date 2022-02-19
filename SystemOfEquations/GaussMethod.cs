using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardizedCalculator.SystemOfEquations
{
    internal class GaussMethod
    {
        public double[,] Matrix { get; }

        public GaussMethod(double[,] matrix) => Matrix = matrix;

        public double[] Calculate()
        {
            int n = Matrix.GetLength(0);
            double[,] duplicateArray = new double[n, n + 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    duplicateArray[i, j] = Matrix[i, j];
                }
            }

            //Прямой ход (Зануление нижнего левого угла)
            for (int k = 0; k < n; k++) //k-номер строки
            {
                for (int i = 0; i < n + 1; i++)
                {
                    duplicateArray[k, i] = duplicateArray[k, i] / Matrix[k, k];
                }

                for (int i = k + 1; i < n; i++)
                {
                    double factor = duplicateArray[i, k] / duplicateArray[k, k];
                    for (int j = 0; j < n + 1; j++)
                    {
                        duplicateArray[i, j] = duplicateArray[i, j] - duplicateArray[k, j] * factor;
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n + 1; j++)
                    {
                        Matrix[i, j] = duplicateArray[i, j];
                    }
                }
            }

            //Обратный ход (Зануление верхнего правого угла)
            for (int k = n - 1; k > -1; k--)
            {
                for (int i = n; i > -1; i--)
                {
                    duplicateArray[k, i] = duplicateArray[k, i] / Matrix[k, k];
                }

                for (int i = k - 1; i > -1; i--)
                {
                    double factor = duplicateArray[i, k] / duplicateArray[k, k];
                    for (int j = n; j > -1; j--)
                    {
                        duplicateArray[i, j] = duplicateArray[i, j] - duplicateArray[k, j] * factor;
                    }
                }
            }

            //Отделяем от общей матрицы ответы
            var answer = new double[n];
            for (int i = 0; i < n; i++)
            {
                answer[i] = duplicateArray[i, n];
            }

            return answer;
        }
    }
}
