namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button_find_rank = new Button();
            button_find_inverse_matrix = new Button();
            button_generate = new Button();
            button_calculate = new Button();
            checkBox_matrix_A = new CheckBox();
            checkBox_matrix_B = new CheckBox();
            radioButton_first = new RadioButton();
            textBox_rank = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            domainUpDown_rows = new DomainUpDown();
            domainUpDown_cols = new DomainUpDown();
            textBox_matri_A = new TextBox();
            textBox_matri_B = new TextBox();
            textBox_matri_Inverted = new TextBox();
            textBox_matri_X = new TextBox();
            button_protokol_obernen = new Button();
            button_protokol_find_rank = new Button();
            button_protokol_slau = new Button();
            SuspendLayout();
            // 
            // button_find_rank
            // 
            button_find_rank.Location = new Point(300, 283);
            button_find_rank.Name = "button_find_rank";
            button_find_rank.Size = new Size(251, 37);
            button_find_rank.TabIndex = 0;
            button_find_rank.Text = "Знайти ранг матриці";
            button_find_rank.UseVisualStyleBackColor = true;
            button_find_rank.Click += button_find_rank_Click;
            // 
            // button_find_inverse_matrix
            // 
            button_find_inverse_matrix.Location = new Point(316, 516);
            button_find_inverse_matrix.Name = "button_find_inverse_matrix";
            button_find_inverse_matrix.Size = new Size(224, 44);
            button_find_inverse_matrix.TabIndex = 1;
            button_find_inverse_matrix.Text = "Знайти обернену матрицю";
            button_find_inverse_matrix.UseVisualStyleBackColor = true;
            button_find_inverse_matrix.Click += button_find_inverse_matrix_Click;
            // 
            // button_generate
            // 
            button_generate.Location = new Point(342, 112);
            button_generate.Name = "button_generate";
            button_generate.Size = new Size(209, 35);
            button_generate.TabIndex = 2;
            button_generate.Text = "Згенерувати";
            button_generate.UseVisualStyleBackColor = true;
            button_generate.Click += button_generate_Click;
            // 
            // button_calculate
            // 
            button_calculate.Location = new Point(12, 360);
            button_calculate.Name = "button_calculate";
            button_calculate.Size = new Size(157, 35);
            button_calculate.TabIndex = 3;
            button_calculate.Text = "Обчислити СЛАУ";
            button_calculate.UseVisualStyleBackColor = true;
            button_calculate.Click += button_calculate_Click;
            // 
            // checkBox_matrix_A
            // 
            checkBox_matrix_A.AutoSize = true;
            checkBox_matrix_A.Checked = true;
            checkBox_matrix_A.CheckState = CheckState.Checked;
            checkBox_matrix_A.Location = new Point(342, 153);
            checkBox_matrix_A.Name = "checkBox_matrix_A";
            checkBox_matrix_A.Size = new Size(105, 24);
            checkBox_matrix_A.TabIndex = 4;
            checkBox_matrix_A.Text = "матриця А";
            checkBox_matrix_A.UseVisualStyleBackColor = true;
            checkBox_matrix_A.CheckedChanged += checkBox_matrix_A_CheckedChanged;
            // 
            // checkBox_matrix_B
            // 
            checkBox_matrix_B.AutoSize = true;
            checkBox_matrix_B.Location = new Point(342, 192);
            checkBox_matrix_B.Name = "checkBox_matrix_B";
            checkBox_matrix_B.Size = new Size(104, 24);
            checkBox_matrix_B.TabIndex = 5;
            checkBox_matrix_B.Text = "матриця B";
            checkBox_matrix_B.UseVisualStyleBackColor = true;
            checkBox_matrix_B.CheckedChanged += checkBox_matrix_B_CheckedChanged;
            // 
            // radioButton_first
            // 
            radioButton_first.AutoSize = true;
            radioButton_first.Checked = true;
            radioButton_first.Location = new Point(12, 427);
            radioButton_first.Name = "radioButton_first";
            radioButton_first.Size = new Size(121, 24);
            radioButton_first.TabIndex = 7;
            radioButton_first.TabStop = true;
            radioButton_first.Text = "1-м методом";
            radioButton_first.UseVisualStyleBackColor = true;
            // 
            // textBox_rank
            // 
            textBox_rank.Location = new Point(150, 288);
            textBox_rank.Name = "textBox_rank";
            textBox_rank.ReadOnly = true;
            textBox_rank.Size = new Size(125, 27);
            textBox_rank.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 295);
            label1.Name = "label1";
            label1.Size = new Size(103, 20);
            label1.TabIndex = 13;
            label1.Text = "Ранг матриці:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(188, 367);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 14;
            label2.Text = "Матриця X:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 22);
            label3.Name = "label3";
            label3.Size = new Size(88, 20);
            label3.TabIndex = 15;
            label3.Text = "Матриця A:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(211, 22);
            label4.Name = "label4";
            label4.Size = new Size(87, 20);
            label4.TabIndex = 16;
            label4.Text = "Матриця B:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(342, 46);
            label5.Name = "label5";
            label5.Size = new Size(52, 20);
            label5.TabIndex = 17;
            label5.Text = "Рядки:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(474, 46);
            label6.Name = "label6";
            label6.Size = new Size(66, 20);
            label6.TabIndex = 18;
            label6.Text = "Стовбці:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(300, 345);
            label7.Name = "label7";
            label7.Size = new Size(147, 20);
            label7.TabIndex = 19;
            label7.Text = "Обернена матриця:";
            // 
            // domainUpDown_rows
            // 
            domainUpDown_rows.Items.Add("1");
            domainUpDown_rows.Items.Add("2");
            domainUpDown_rows.Items.Add("3");
            domainUpDown_rows.Items.Add("4");
            domainUpDown_rows.Items.Add("5");
            domainUpDown_rows.Items.Add("6");
            domainUpDown_rows.Items.Add("7");
            domainUpDown_rows.Items.Add("8");
            domainUpDown_rows.Items.Add("9");
            domainUpDown_rows.Items.Add("10");
            domainUpDown_rows.Location = new Point(342, 79);
            domainUpDown_rows.Name = "domainUpDown_rows";
            domainUpDown_rows.Size = new Size(84, 27);
            domainUpDown_rows.TabIndex = 24;
            // 
            // domainUpDown_cols
            // 
            domainUpDown_cols.Items.Add("1");
            domainUpDown_cols.Items.Add("2");
            domainUpDown_cols.Items.Add("3");
            domainUpDown_cols.Items.Add("4");
            domainUpDown_cols.Items.Add("5");
            domainUpDown_cols.Items.Add("6");
            domainUpDown_cols.Items.Add("7");
            domainUpDown_cols.Items.Add("8");
            domainUpDown_cols.Items.Add("9");
            domainUpDown_cols.Items.Add("10");
            domainUpDown_cols.Location = new Point(474, 79);
            domainUpDown_cols.Name = "domainUpDown_cols";
            domainUpDown_cols.Size = new Size(84, 27);
            domainUpDown_cols.TabIndex = 25;
            // 
            // textBox_matri_A
            // 
            textBox_matri_A.Location = new Point(12, 55);
            textBox_matri_A.Multiline = true;
            textBox_matri_A.Name = "textBox_matri_A";
            textBox_matri_A.ScrollBars = ScrollBars.Both;
            textBox_matri_A.Size = new Size(165, 122);
            textBox_matri_A.TabIndex = 26;
            // 
            // textBox_matri_B
            // 
            textBox_matri_B.Location = new Point(200, 55);
            textBox_matri_B.Multiline = true;
            textBox_matri_B.Name = "textBox_matri_B";
            textBox_matri_B.ScrollBars = ScrollBars.Both;
            textBox_matri_B.Size = new Size(110, 122);
            textBox_matri_B.TabIndex = 27;
            // 
            // textBox_matri_Inverted
            // 
            textBox_matri_Inverted.Location = new Point(299, 367);
            textBox_matri_Inverted.Multiline = true;
            textBox_matri_Inverted.Name = "textBox_matri_Inverted";
            textBox_matri_Inverted.ScrollBars = ScrollBars.Both;
            textBox_matri_Inverted.Size = new Size(252, 143);
            textBox_matri_Inverted.TabIndex = 28;
            // 
            // textBox_matri_X
            // 
            textBox_matri_X.Location = new Point(200, 391);
            textBox_matri_X.Multiline = true;
            textBox_matri_X.Name = "textBox_matri_X";
            textBox_matri_X.Size = new Size(63, 184);
            textBox_matri_X.TabIndex = 29;
            // 
            // button_protokol_obernen
            // 
            button_protokol_obernen.Location = new Point(12, 189);
            button_protokol_obernen.Name = "button_protokol_obernen";
            button_protokol_obernen.Size = new Size(251, 29);
            button_protokol_obernen.TabIndex = 30;
            button_protokol_obernen.Text = "Протокол пошуку оберненої \r\n";
            button_protokol_obernen.UseVisualStyleBackColor = true;
            button_protokol_obernen.Click += button_protokol_obernen_Click;
            // 
            // button_protokol_find_rank
            // 
            button_protokol_find_rank.Location = new Point(12, 236);
            button_protokol_find_rank.Name = "button_protokol_find_rank";
            button_protokol_find_rank.Size = new Size(251, 29);
            button_protokol_find_rank.TabIndex = 31;
            button_protokol_find_rank.Text = "Протокол пошуку рангу ";
            button_protokol_find_rank.UseVisualStyleBackColor = true;
            button_protokol_find_rank.Click += button_protokol_find_rank_Click;
            // 
            // button_protokol_slau
            // 
            button_protokol_slau.Location = new Point(292, 236);
            button_protokol_slau.Name = "button_protokol_slau";
            button_protokol_slau.Size = new Size(259, 29);
            button_protokol_slau.TabIndex = 32;
            button_protokol_slau.Text = "Протокол обчислення СЛАУ";
            button_protokol_slau.UseVisualStyleBackColor = true;
            button_protokol_slau.Click += button_protokol_slau_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(570, 578);
            Controls.Add(button_protokol_slau);
            Controls.Add(button_protokol_find_rank);
            Controls.Add(button_protokol_obernen);
            Controls.Add(textBox_matri_X);
            Controls.Add(textBox_matri_Inverted);
            Controls.Add(textBox_matri_B);
            Controls.Add(textBox_matri_A);
            Controls.Add(domainUpDown_cols);
            Controls.Add(domainUpDown_rows);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox_rank);
            Controls.Add(radioButton_first);
            Controls.Add(checkBox_matrix_B);
            Controls.Add(checkBox_matrix_A);
            Controls.Add(button_calculate);
            Controls.Add(button_generate);
            Controls.Add(button_find_inverse_matrix);
            Controls.Add(button_find_rank);
            Name = "Form1";
            Text = "Lab_1_1_Horbach_633p";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_find_rank;
        private Button button_find_inverse_matrix;
        private Button button_generate;
        private Button button_calculate;
        private CheckBox checkBox_matrix_A;
        private CheckBox checkBox_matrix_B;
        private RadioButton radioButton_first;
        private TextBox textBox_rank;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private ListBox listBox1;
        private ListBox listBox2;
        private DomainUpDown domainUpDown_rows;
        private DomainUpDown domainUpDown_cols;
        private TextBox textBox_matri_A;
        private TextBox textBox_matri_B;
        private TextBox textBox_matri_Inverted;
        private TextBox textBox_matri_X;
        private Button button_protokol_obernen;
        private Button button2;
        private Button button_protokol_find_rank;
        private Button button_protokol_slau;
    }
}
