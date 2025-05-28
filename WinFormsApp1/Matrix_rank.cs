using System;

namespace Lab_1_Horbach_633p
{
    public static class Matrix_rank
    {
        public static int CalculateRank(double[,] matrix)
        {
            Jordan.protocol.Clear(); // очищаємо перед запуском

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int rank = 0;
            int i = 0;

            string[] rowVars = new string[n];
            string[] colVars = new string[m];
            for (int idx = 0; idx < n; idx++) rowVars[idx] = $"x{idx + 1}";
            for (int idx = 0; idx < m; idx++) colVars[idx] = $"y{idx + 1}";

            double[,] currentMatrix = (double[,])matrix.Clone();

            Jordan.protocol.AppendLine("Початкова матриця:");
            AppendMatrix(currentMatrix);

            while (i < n && i < m)
            {
                Jordan.protocol.AppendLine($"Перевірка a[{i + 1},{i + 1}] = {currentMatrix[i, i]}");

                if (Math.Abs(currentMatrix[i, i]) > 1e-12)
                {
                    currentMatrix = Jordan.JordanStep(currentMatrix, i, i, ref rowVars, ref colVars);
                    rank++;
                }
                i++;
            }

            Jordan.protocol.AppendLine($"Остаточний ранг матриці: {rank}");
            return rank;
        }

        private static void AppendMatrix(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                string row = "";
                for (int j = 0; j < m; j++)
                {
                    row += matrix[i, j].ToString("F2") + "\t";
                }
                Jordan.protocol.AppendLine(row.TrimEnd());
            }
            Jordan.protocol.AppendLine();
        }

    }
}
