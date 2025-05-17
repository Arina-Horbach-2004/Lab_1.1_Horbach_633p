using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_Horbach_633p
{
    public static class Matrix_rank
    {
        public static int CalculateRank(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            double[,] temp = (double[,])matrix.Clone();

            int rank = 0;

            for (int r = 0, c = 0; r < rows && c < cols; c++)
            {
                int pivotRow = r;
                for (int i = r + 1; i < rows; i++)
                    if (Math.Abs(temp[i, c]) > Math.Abs(temp[pivotRow, c]))
                        pivotRow = i;

                if (Math.Abs(temp[pivotRow, c]) < 1e-10)
                    continue;

                for (int j = 0; j < cols; j++)
                {
                    double t = temp[r, j];
                    temp[r, j] = temp[pivotRow, j];
                    temp[pivotRow, j] = t;
                }

                for (int i = 0; i < rows; i++)
                {
                    if (i == r) continue;
                    double factor = temp[i, c] / temp[r, c];
                    for (int j = c; j < cols; j++)
                        temp[i, j] -= factor * temp[r, j];
                }

                r++;
                rank++;
            }

            return rank;
        }
    }
}
