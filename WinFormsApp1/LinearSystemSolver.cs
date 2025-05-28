using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Lab_1_Horbach_633p
{
    public static class LinearSystemSolver
    {
        // Протокол обчислень
        public static StringBuilder protocol = new StringBuilder();

        public static double[] SolveByInverse(double[,] A, double[] B)
        {
            int n = A.GetLength(0);
            if (A.GetLength(1) != n)
                throw new ArgumentException("Матриця A має бути квадратною.");
            if (B.Length != n)
                throw new ArgumentException("Розмірність вектора B має співпадати з розмірністю матриці A.");

            protocol.Clear();

            protocol.AppendLine("Початок розв’язання системи A * X = B");
            protocol.AppendLine("Матриця A:");
            AppendMatrix(A);

            protocol.AppendLine("Вектор B:");
            AppendVector(B);

            // Копіюємо матрицю, щоб не змінювати оригінал
            double[,] currentMatrix = (double[,])A.Clone();

            // Ініціалізація змінних "шапки"
            string[] rowVars = new string[n];
            string[] colVars = new string[n];
            for (int i = 0; i < n; i++)
            {
                rowVars[i] = $"x{i + 1}";
                colVars[i] = $"y{i + 1}";
            }

            int iStep = 0;
            while (iStep < n)
            {
                protocol.AppendLine($"Крок {iStep + 1}: Розв’язувальний елемент a[{iStep + 1},{iStep + 1}] = {currentMatrix[iStep, iStep].ToString("F4", CultureInfo.InvariantCulture)}");

                if (Math.Abs(currentMatrix[iStep, iStep]) < 1e-12)
                    throw new Exception($"Розв’язувальний елемент a[{iStep + 1},{iStep + 1}] дорівнює нулю або дуже малий. Система не може бути розв’язана цим методом.");

                // Застосовуємо крок Жорданового виключення (ваш код з класу Jordan)
                currentMatrix = Jordan.JordanStep(currentMatrix, iStep, iStep, ref rowVars, ref colVars);

                iStep++;
                AppendMatrix(currentMatrix);
            }

            protocol.AppendLine("Обернена матриця A^(-1):");
            AppendMatrix(currentMatrix);

            // Обчислюємо розв’язок X = A^(-1) * B
            double[] X = MultiplyMatrixVector(currentMatrix, B);

            protocol.AppendLine("Вектор розв’язку X:");
            AppendVector(X);

            return X;
        }

        // Допоміжна функція множення матриці на вектор
        private static double[] MultiplyMatrixVector(double[,] matrix, double[] vector)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (vector.Length != cols)
                throw new ArgumentException("Несумісні розміри матриці і вектора для множення.");

            double[] result = new double[rows];
            for (int i = 0; i < rows; i++)
            {
                double sum = 0;
                for (int j = 0; j < cols; j++)
                {
                    sum += matrix[i, j] * vector[j];
                }
                result[i] = sum;
            }
            return result;
        }

        private static void AppendMatrix(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                string line = "";
                for (int j = 0; j < cols; j++)
                {
                    line += $"{matrix[i, j],10:F4} ";
                }
                protocol.AppendLine(line);
            }
            protocol.AppendLine();
        }

        private static void AppendVector(double[] vector)
        {
            string line = "";
            for (int i = 0; i < vector.Length; i++)
            {
                line += $"{vector[i],10:F4} ";
            }
            protocol.AppendLine(line);
            protocol.AppendLine();
        }
    }
}