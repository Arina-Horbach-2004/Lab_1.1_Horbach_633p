using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace Lab_1_Horbach_633p
{
    public class MatrixOperations
    {
        public static string GenerateInverseMatrixProtocol(double[,] A)
        {
            int n = A.GetLength(0);
            double[,] augmentedMatrix = new double[n, 2 * n];

            // Створюємо розширену матрицю [A | I]
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    augmentedMatrix[i, j] = A[i, j];
                augmentedMatrix[i, n + i] = 1;
            }

            StringBuilder protocol = new StringBuilder();
            protocol.AppendLine("Протокол обчислення оберненої матриці:");
            protocol.AppendLine("Вхідна матриця:");

            // Виведення початкової матриці
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    protocol.Append($"{A[i, j],6:F2} ");
                protocol.AppendLine();
            }

            // Жорданова елімінація для знаходження оберненої матриці
            for (int i = 0; i < n; i++)
            {
                double pivot = augmentedMatrix[i, i];
                if (Math.Abs(pivot) < 1e-10)
                    throw new Exception("Матриця вироджена (не має оберненої)");

                protocol.AppendLine($"Крок #{i + 1}");
                protocol.AppendLine($"Розв’язувальний елемент: A[{i + 1}, {i + 1}] = {pivot:F2}");

                // Нормалізація
                for (int j = 0; j < 2 * n; j++)
                    augmentedMatrix[i, j] /= pivot;

                // Жорданова елімінація
                for (int k = 0; k < n; k++)
                {
                    if (k == i) continue;
                    double factor = augmentedMatrix[k, i];
                    for (int j = 0; j < 2 * n; j++)
                        augmentedMatrix[k, j] -= factor * augmentedMatrix[i, j];
                }

                protocol.AppendLine("Матриця після виконання ЗЖВ:");
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                        protocol.Append($"{augmentedMatrix[j, k],6:F2} ");
                    protocol.AppendLine();
                }
            }

            // Витягуємо обернену матрицю
            double[,] inverseMatrix = new double[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    inverseMatrix[i, j] = augmentedMatrix[i, n + j];

            // Виведення оберненої матриці
            protocol.AppendLine("Обернена матриця:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    protocol.Append($"{inverseMatrix[i, j],6:F2} ");
                protocol.AppendLine();
            }

            return protocol.ToString();
        }

        // Метод для запису протоколу в файл
        public static void SaveProtocolToFile(string protocol, string filePath)
        {
            try
            {
                // Записуємо протокол в файл
                File.WriteAllText(filePath, protocol);
                Console.WriteLine("Протокол обчислень успішно збережено у файл.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при збереженні файлу: {ex.Message}");
            }
        }
    }
}
