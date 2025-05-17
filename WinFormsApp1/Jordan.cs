using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab_1_Horbach_633p
{
    public static class Jordan
    {
        public static double[,] InvertMatrix(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            double[,] result = new double[n, n];
            double[,] augmented = new double[n, 2 * n];

            // Формуємо [A | I]
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    augmented[i, j] = matrix[i, j];
                augmented[i, n + i] = 1;
            }

            // Жорданові виключення
            for (int i = 0; i < n; i++)
            {
                double pivot = augmented[i, i];
                if (Math.Abs(pivot) < 1e-10)
                    throw new Exception("Матриця вироджена (не має оберненої)");

                for (int j = 0; j < 2 * n; j++)
                    augmented[i, j] /= pivot;

                for (int k = 0; k < n; k++)
                {
                    if (k == i) continue;
                    double factor = augmented[k, i];
                    for (int j = 0; j < 2 * n; j++)
                        augmented[k, j] -= factor * augmented[i, j];
                }
            }

            // Витягуємо обернену
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    result[i, j] = augmented[i, n + j];

            return result;
        }
    }

}
