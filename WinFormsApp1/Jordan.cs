using System;
using System.Globalization;
using System.IO;
using System.Text;

public static class Jordan
{
    public static StringBuilder protocol = new StringBuilder();

    // Один крок Жорданового виключення
    public static double[,] JordanStep(double[,] matrix, int r, int s, ref string[] rowVars, ref string[] colVars)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        double ars = matrix[r, s];
        if (Math.Abs(ars) < 1e-12)
            throw new Exception("Розв’язувальний елемент дорівнює нулю");

        protocol.AppendLine($"Крок Жорданового виключення №{r + 1}");
        protocol.AppendLine($"Розв’язувальний елемент a[{r + 1},{s + 1}] = {ars.ToString("F2", CultureInfo.GetCultureInfo("uk-UA"))}");

        double[,] next = new double[n, m];

        // 1. Розв’язувальний елемент ставимо 1
        next[r, s] = 1;

        // 2. Елементи розв’язувального рядка (крім ars) змінюють знак
        for (int j = 0; j < m; j++)
        {
            if (j != s)
                next[r, j] = -matrix[r, j];
        }

        // 3. Елементи розв’язувального стовпця (крім ars) залишаються без змін
        for (int i = 0; i < n; i++)
        {
            if (i != r)
                next[i, s] = matrix[i, s];
        }

        // 4. Інші елементи розраховують за формулою bij = aij*ars - ais*arj
        for (int i = 0; i < n; i++)
        {
            if (i == r) continue;
            for (int j = 0; j < m; j++)
            {
                if (j == s) continue;
                next[i, j] = matrix[i, j] * ars - matrix[i, s] * matrix[r, j];
            }
        }

        // 5. Ділимо всі елементи на ars
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                next[i, j] /= ars;

        // 6. Міняємо місцями змінні у "шапці" (наприклад, змінні рядка і стовпця)
        string temp = rowVars[r];
        rowVars[r] = colVars[s];
        colVars[s] = temp;

        protocol.AppendLine("Матриця після жорданового виключення:");
        AppendMatrix(next);

        protocol.AppendLine($"Змінені змінні у шапці:");
        protocol.AppendLine($"Рядок {r + 1}: {rowVars[r]}");
        protocol.AppendLine($"Стовпець {s + 1}: {colVars[s]}");
        protocol.AppendLine();

        return next;
    }


    public static double[,] InvertMatrix(double[,] input)
    {
        int n = input.GetLength(0);
        if (input.GetLength(1) != n)
            throw new ArgumentException("Матриця має бути квадратною.");

        protocol.AppendLine("Початкова матриця A:");
        AppendMatrix(input);

        // Формуємо розширену матрицю [A | I]
        double[,] matrix = new double[n, 2 * n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                matrix[i, j] = input[i, j];

            matrix[i, n + i] = 1;
        }

        // Ініціалізація змінних "шапки"
        string[] rowVars = new string[n];
        string[] colVars = new string[2 * n];
        for (int i = 0; i < n; i++)
            rowVars[i] = $"x{i + 1}";
        for (int j = 0; j < 2 * n; j++)
            colVars[j] = j < n ? $"y{j + 1}" : $"e{j - n + 1}";

        protocol.AppendLine("Початкова розширена матриця [A | I]:");
        AppendMatrix(matrix);

        // Застосування послідовного жорданового виключення
        for (int i = 0; i < n; i++)
        {
            int r = i; // поточний рядок
            int s = i; // головна діагональ

            matrix = JordanStep(matrix, r, s, ref rowVars, ref colVars);
        }

        // Отримуємо праву частину розширеної матриці (це обернена)
        double[,] inverse = new double[n, n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                inverse[i, j] = matrix[i, j + n];

        protocol.AppendLine("Обернена матриця A^(-1):");
        AppendMatrix(inverse);

        return inverse;
    }


    // Додати матрицю до протоколу
    private static void AppendMatrix(double[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            string line = "";
            for (int j = 0; j < cols; j++)
                line += $"{matrix[i, j],10:F3}";
            protocol.AppendLine(line);
        }
        protocol.AppendLine();
    }



    // Запис протоколу в файл
    public static void SaveProtocol(string path)
    {
        File.WriteAllText(path, protocol.ToString(), Encoding.UTF8);
    }
}
