using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_Horbach_633p
{
    public static class LinearSystemSolver
    {
        public static double[] Solve(double[,] A, double[] B)
        {
            int n = A.GetLength(0);
            if (A.GetLength(1) != n || B.Length != n)
                throw new ArgumentException("Невірні розміри матриці або вектора.");

            double[,] inv = Jordan.InvertMatrix(A);
            double[] X = new double[n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    X[i] += inv[i, j] * B[j];

            return X;
        }
    }
}
