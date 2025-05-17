using Lab_1_Horbach_633p;
using System.Text;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button_find_inverse_matrix_Click(object sender, EventArgs e)
        {
            try
            {
                // Зчитуємо текст з textBox_matrix_A
                string[] rows = textBox_matri_A.Text.Trim().Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                int n = rows.Length;
                double[,] matrix = new double[n, n];

                for (int i = 0; i < n; i++)
                {
                    string[] values = rows[i].Trim().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (values.Length != n)
                        throw new Exception("Матриця повинна бути квадратною!");

                    for (int j = 0; j < n; j++)
                        matrix[i, j] = double.Parse(values[j]);
                }

                // Обчислення оберненої
                double[,] inverse = Jordan.InvertMatrix(matrix);

                // Вивід у текстове поле
                textBox_matri_Inverted.Clear();
                for (int i = 0; i < n; i++)
                {
                    string line = "";
                    for (int j = 0; j < n; j++)
                        line += $"{inverse[i, j]:F4} ";
                    textBox_matri_Inverted.AppendText(line.Trim() + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        private void button_find_rank_Click(object sender, EventArgs e)
        {
            try
            {
                // Зчитуємо матрицю з textBox_matrix_A
                string[] rows = textBox_matri_A.Text.Trim().Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                int rowCount = rows.Length;
                int colCount = rows[0].Trim().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
                double[,] matrix = new double[rowCount, colCount];

                for (int i = 0; i < rowCount; i++)
                {
                    string[] values = rows[i].Trim().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (values.Length != colCount)
                        throw new Exception("Усі рядки повинні мати однакову кількість чисел!");

                    for (int j = 0; j < colCount; j++)
                        matrix[i, j] = double.Parse(values[j]);
                }

                // Обчислення рангу
                int rank = Matrix_rank.CalculateRank(matrix);

                // Виведення у textBox_rank
                textBox_rank.Text = rank.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        private void button_calculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Зчитування матриці A
                string[] lines = textBox_matri_A.Lines;
                int n = lines.Length;
                double[,] A = new double[n, n];

                for (int i = 0; i < n; i++)
                {
                    string[] row = lines[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (row.Length != n)
                    {
                        MessageBox.Show("Матриця A має бути квадратною і заповненою правильно.");
                        return;
                    }

                    for (int j = 0; j < n; j++)
                    {
                        A[i, j] = double.Parse(row[j]);
                    }
                }

                // Зчитування вектора B (вертикально)
                string[] bLines = textBox_matri_B.Lines;
                if (bLines.Length != n)
                {
                    MessageBox.Show("Кількість елементів вектора B повинна дорівнювати розміру матриці A.");
                    return;
                }

                double[] B = new double[n];
                for (int i = 0; i < n; i++)
                {
                    B[i] = double.Parse(bLines[i]);
                }

                // Розв’язання системи
                double[,] invA = Jordan.InvertMatrix(A);
                double[] X = new double[n];
                for (int i = 0; i < n; i++)
                {
                    X[i] = 0;
                    for (int j = 0; j < n; j++)
                    {
                        X[i] += invA[i, j] * B[j];
                    }
                }

                // Виведення розв’язку
                textBox_matri_X.Lines = X.Select(x => Math.Round(x).ToString()).ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        private void button_generate_Click(object sender, EventArgs e)
        {
            
            int rows = int.Parse(domainUpDown_rows.Text);
            int cols = int.Parse(domainUpDown_cols.Text);

            Random rand = new Random();
            string result = "";

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result += rand.Next(-10, 11).ToString() + " ";
                }
                result = result.TrimEnd() + Environment.NewLine;
            }

            if (checkBox_matrix_A.Checked)
            {
                textBox_matri_A.Text = result.TrimEnd();
            }
            else if (checkBox_matrix_B.Checked)
            {
                // Генеруємо вертикальний вектор
                string bVector = "";
                for (int i = 0; i < rows; i++)
                {
                    bVector += rand.Next(-10, 11).ToString() + Environment.NewLine;
                }
                textBox_matri_B.Text = bVector.TrimEnd();
            }
            else
            {
                MessageBox.Show("Оберіть, яку матрицю генерувати: A або B.");
            }
        }

        private void button_protokol_obernen_Click(object sender, EventArgs e)
        {
            try
            {
                // Зчитуємо матрицю з textBox_matri_A
                double[,] matrixA = GetMatrixFromTextBox(textBox_matri_A);

                // Генерація протоколу пошуку оберненої матриці
                string protocol = MatrixOperations.GenerateInverseMatrixProtocol(matrixA);


                string filePath = "C:\\Users\\Arina Gorbach\\Desktop\\inverse_matrix_protocol.txt";
                MatrixOperations.SaveProtocolToFile(protocol, filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}");
            }

        }


        private void checkBox_matrix_A_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_matrix_A.Checked)
            {
                checkBox_matrix_B.Checked = false;
            }
        }

        private void checkBox_matrix_B_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_matrix_B.Checked)
            {
                checkBox_matrix_A.Checked = false;
            }
        }

        // Метод для зчитування матриці з textBox
        private double[,] GetMatrixFromTextBox(TextBox textBox)
        {
            string[] lines = textBox.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            int rows = lines.Length;
            int cols = lines[0].Split(' ').Length;

            double[,] matrix = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] elements = lines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = Convert.ToDouble(elements[j]);
                }
            }

            return matrix;
        }

        private void button_protokol_find_rank_Click(object sender, EventArgs e)
        {
            try
            {
                // Зчитуємо матрицю з textBox_matri_A
                double[,] matrixA = GetMatrixFromTextBox(textBox_matri_A);

                // Генерація протоколу пошуку рангу матриці
                string protocol = MatrixOperations.GenerateRankProtocol(matrixA);

                // Виведення протоколу в файл
                string filePath = "C:\\Users\\Arina Gorbach\\Desktop\\rank_matrix_protocol.txt";
                MatrixOperations.SaveProtocolToFile(protocol, filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}");
            }

        }

        private void button_protokol_slau_Click(object sender, EventArgs e)
        {
            try
            {
                // Зчитування матриці A
                double[,] A = GetMatrixFromTextBox(textBox_matri_A);
                int n = A.GetLength(0);

                // Зчитування вектора B
                string[] bLines = textBox_matri_B.Lines;

                double[] B = new double[n];
                for (int i = 0; i < n; i++)
                {
                    B[i] = double.Parse(bLines[i]);
                }

                // Генерація протоколу
                string protocol = MatrixOperations.GenerateSlauProtocolUsingInverse(A, B);

                // Збереження у файл
                string filePath = "C:\\Users\\Arina Gorbach\\Desktop\\slau_protocol.txt";
                MatrixOperations.SaveProtocolToFile(protocol, filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка: {ex.Message}");
            }
        }

        public class MatrixOperations
        {
            public static string GenerateRankProtocol(double[,] matrix)
            {
                int rows = matrix.GetLength(0);
                int cols = matrix.GetLength(1);
                StringBuilder protocol = new StringBuilder();
                protocol.AppendLine("Протокол обчислення рангу матриці:");

                // Виведення початкової матриці
                protocol.AppendLine("Вхідна матриця:");
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                        protocol.Append($"{matrix[i, j],6:F2} ");
                    protocol.AppendLine();
                }

                int rank = 0;
                for (int i = 0; i < rows; i++)
                {
                    // Пошук елементу для обнулення
                    if (Math.Abs(matrix[i, i]) < 1e-10)
                    {
                        for (int j = i + 1; j < rows; j++)
                        {
                            if (Math.Abs(matrix[j, i]) > 1e-10)
                            {
                                // Переміщаємо рядки
                                for (int k = 0; k < cols; k++)
                                {
                                    double temp = matrix[i, k];
                                    matrix[i, k] = matrix[j, k];
                                    matrix[j, k] = temp;
                                }
                                protocol.AppendLine($"Крок #{i + 1}: Перестановка рядків {i + 1} і {j + 1}");
                                break;
                            }
                        }
                    }

                    if (Math.Abs(matrix[i, i]) > 1e-10)
                    {
                        rank++;
                        // Нормалізація рядка
                        double pivot = matrix[i, i];
                        for (int j = 0; j < cols; j++)
                            matrix[i, j] /= pivot;

                        protocol.AppendLine($"Крок #{i + 1}: Розв’язувальний елемент A[{i + 1}, {i + 1}] = {pivot:F2}");
                        protocol.AppendLine("Матриця після нормалізації:");
                        for (int j = 0; j < rows; j++)
                        {
                            for (int k = 0; k < cols; k++)
                                protocol.Append($"{matrix[j, k],6:F2} ");
                            protocol.AppendLine();
                        }

                        // Обнулення елементів в стовпці під розв’язувальним елементом
                        for (int j = i + 1; j < rows; j++)
                        {
                            if (Math.Abs(matrix[j, i]) > 1e-10)
                            {
                                double factor = matrix[j, i];
                                for (int k = 0; k < cols; k++)
                                    matrix[j, k] -= factor * matrix[i, k];
                            }
                        }

                        protocol.AppendLine("Матриця після обнулення елементів:");
                        for (int j = 0; j < rows; j++)
                        {
                            for (int k = 0; k < cols; k++)
                                protocol.Append($"{matrix[j, k],6:F2} ");
                            protocol.AppendLine();
                        }
                    }
                }

                // Виведення рангу
                protocol.AppendLine($"Ранг матриці: {rank}");

                return protocol.ToString();
            }

            public static string GenerateSlauProtocolUsingInverse(double[,] A, double[] B)
            {
                int n = A.GetLength(0);
                StringBuilder protocol = new StringBuilder();

                protocol.AppendLine("Протокол розв’язання СЛАР методом множення на обернену матрицю:");
                protocol.AppendLine();

                // Протокол обчислення оберненої матриці
                protocol.AppendLine(GenerateInverseMatrixProtocol(A));
                protocol.AppendLine();

                // Обчислення оберненої
                double[,] inverse = Jordan.InvertMatrix(A);

                // Вивід вектора B
                protocol.AppendLine("Вектор правих частин B:");
                for (int i = 0; i < n; i++)
                    protocol.AppendLine($"B[{i + 1}] = {B[i]:F2}");

                // Обчислення X = A^(-1) * B
                double[] X = new double[n];
                protocol.AppendLine("\nКроки обчислення розв’язку X = A^(-1) * B:");
                for (int i = 0; i < n; i++)
                {
                    protocol.Append($"X[{i + 1}] = ");
                    for (int j = 0; j < n; j++)
                    {
                        X[i] += inverse[i, j] * B[j];
                        protocol.Append($"{inverse[i, j]:F2} * {B[j]:F2}");
                        if (j < n - 1) protocol.Append(" + ");
                    }
                    protocol.AppendLine($" = {X[i]:F4}");
                }

                // Виведення результату
                protocol.AppendLine("\nРозв’язок СЛАР:");
                for (int i = 0; i < n; i++)
                    protocol.AppendLine($"X[{i + 1}] = {X[i]:F4}");

                return protocol.ToString();
            }



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
}
