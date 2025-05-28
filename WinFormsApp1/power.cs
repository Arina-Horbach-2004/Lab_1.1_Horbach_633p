using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_Horbach_633p
{
    public static class power
    {
        public static double[,] Power(double[,] matrix, int power)
        {
            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1))
                throw new ArgumentException("Матриця має бути квадратною");

            if (power < 0)
                throw new ArgumentException("Степінь має бути невід’ємним");

            double[,] result = IdentityMatrix(n);
            double[,] temp = (double[,])matrix.Clone();

            while (power > 0)
            {
                if ((power & 1) == 1)
                    result = Multiply(result, temp);
                temp = Multiply(temp, temp);
                power >>= 1;
            }

            return result;
        }

        //Метод виконує множення двох матриць
        public static double[,] Multiply(double[,] a, double[,] b)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            int p = b.GetLength(1);

            double[,] result = new double[n, p];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < p; j++)
                    for (int k = 0; k < m; k++)
                        result[i, j] += a[i, k] * b[k, j];

            return result;
        }


        // одиничну матрицю розміром
        public static double[,] IdentityMatrix(int size)
        {
            double[,] identity = new double[size, size];
            for (int i = 0; i < size; i++)
                identity[i, i] = 1;
            return identity;
        }
    }
}
