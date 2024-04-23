namespace ComputerNets1
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
            aTextBox = new TextBox();
            bTextBox = new TextBox();
            startServerBtn = new Button();
            dataGridView1 = new DataGridView();
            typeCol = new DataGridViewTextBoxColumn();
            tauCol = new DataGridViewTextBoxColumn();
            sigmaCol = new DataGridViewTextBoxColumn();
            t1Col = new DataGridViewTextBoxColumn();
            t2Col = new DataGridViewTextBoxColumn();
            kCol = new DataGridViewTextBoxColumn();
            lCol = new DataGridViewTextBoxColumn();
            tsCol = new DataGridViewTextBoxColumn();
            descCol = new DataGridViewTextBoxColumn();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            expectationTextBox = new TextBox();
            deviationTextBox = new TextBox();
            tsMaxTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            buildChartsBtn = new Button();
            label6 = new Label();
            experimentCountTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // aTextBox
            // 
            aTextBox.Location = new Point(13, 64);
            aTextBox.Name = "aTextBox";
            aTextBox.PlaceholderText = "a";
            aTextBox.Size = new Size(125, 27);
            aTextBox.TabIndex = 0;
            // 
            // bTextBox
            // 
            bTextBox.Location = new Point(173, 64);
            bTextBox.Name = "bTextBox";
            bTextBox.PlaceholderText = "b";
            bTextBox.Size = new Size(125, 27);
            bTextBox.TabIndex = 0;
            // 
            // startServerBtn
            // 
            startServerBtn.Location = new Point(952, 44);
            startServerBtn.Name = "startServerBtn";
            startServerBtn.Size = new Size(170, 29);
            startServerBtn.TabIndex = 1;
            startServerBtn.Text = "Запуск сервера";
            startServerBtn.UseVisualStyleBackColor = true;
            startServerBtn.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { typeCol, tauCol, sigmaCol, t1Col, t2Col, kCol, lCol, tsCol, descCol });
            dataGridView1.Location = new Point(6, 24);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1180, 353);
            dataGridView1.TabIndex = 2;
            // 
            // typeCol
            // 
            typeCol.HeaderText = "Type";
            typeCol.MinimumWidth = 6;
            typeCol.Name = "typeCol";
            typeCol.ReadOnly = true;
            // 
            // tauCol
            // 
            tauCol.HeaderText = "Tau";
            tauCol.MinimumWidth = 6;
            tauCol.Name = "tauCol";
            tauCol.ReadOnly = true;
            // 
            // sigmaCol
            // 
            sigmaCol.HeaderText = "Sigma";
            sigmaCol.MinimumWidth = 6;
            sigmaCol.Name = "sigmaCol";
            sigmaCol.ReadOnly = true;
            // 
            // t1Col
            // 
            t1Col.HeaderText = "T1";
            t1Col.MinimumWidth = 6;
            t1Col.Name = "t1Col";
            t1Col.ReadOnly = true;
            // 
            // t2Col
            // 
            t2Col.HeaderText = "T2";
            t2Col.MinimumWidth = 6;
            t2Col.Name = "t2Col";
            t2Col.ReadOnly = true;
            // 
            // kCol
            // 
            kCol.HeaderText = "K";
            kCol.MinimumWidth = 6;
            kCol.Name = "kCol";
            kCol.ReadOnly = true;
            // 
            // lCol
            // 
            lCol.HeaderText = "L";
            lCol.MinimumWidth = 6;
            lCol.Name = "lCol";
            lCol.ReadOnly = true;
            // 
            // tsCol
            // 
            tsCol.HeaderText = "TS";
            tsCol.MinimumWidth = 6;
            tsCol.Name = "tsCol";
            tsCol.ReadOnly = true;
            // 
            // descCol
            // 
            descCol.HeaderText = "Description";
            descCol.MinimumWidth = 6;
            descCol.Name = "descCol";
            descCol.ReadOnly = true;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(12, 149);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1200, 416);
            tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.Control;
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1192, 383);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Отладка";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = SystemColors.Control;
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1192, 383);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "L(n)";
            // 
            // tabPage3
            // 
            tabPage3.BackColor = SystemColors.Control;
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1192, 383);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "A_Out(X)";
            // 
            // expectationTextBox
            // 
            expectationTextBox.Location = new Point(13, 64);
            expectationTextBox.Name = "expectationTextBox";
            expectationTextBox.PlaceholderText = "μ";
            expectationTextBox.Size = new Size(125, 27);
            expectationTextBox.TabIndex = 0;
            // 
            // deviationTextBox
            // 
            deviationTextBox.Location = new Point(173, 64);
            deviationTextBox.Name = "deviationTextBox";
            deviationTextBox.PlaceholderText = "σ";
            deviationTextBox.Size = new Size(125, 27);
            deviationTextBox.TabIndex = 0;
            // 
            // tsMaxTextBox
            // 
            tsMaxTextBox.Location = new Point(703, 46);
            tsMaxTextBox.Name = "tsMaxTextBox";
            tsMaxTextBox.PlaceholderText = "Время работы сервера";
            tsMaxTextBox.Size = new Size(210, 27);
            tsMaxTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 38);
            label1.Name = "label1";
            label1.Size = new Size(119, 20);
            label1.TabIndex = 4;
            label1.Text = "Начало отрезка";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(173, 41);
            label2.Name = "label2";
            label2.Size = new Size(111, 20);
            label2.TabIndex = 4;
            label2.Text = "Конец отрезка";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 38);
            label3.Name = "label3";
            label3.Size = new Size(18, 20);
            label3.TabIndex = 4;
            label3.Text = "μ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(173, 41);
            label4.Name = "label4";
            label4.Size = new Size(18, 20);
            label4.TabIndex = 4;
            label4.Text = "σ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(703, 12);
            label5.Name = "label5";
            label5.Size = new Size(171, 20);
            label5.TabIndex = 4;
            label5.Text = "Время работы сервера";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(bTextBox);
            groupBox1.Controls.Add(aTextBox);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(312, 107);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Равномерное распределение";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(deviationTextBox);
            groupBox2.Controls.Add(expectationTextBox);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(358, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(312, 107);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Распределение |Gauss|";
            // 
            // buildChartsBtn
            // 
            buildChartsBtn.Location = new Point(952, 116);
            buildChartsBtn.Name = "buildChartsBtn";
            buildChartsBtn.Size = new Size(170, 29);
            buildChartsBtn.TabIndex = 1;
            buildChartsBtn.Text = "Построить графики";
            buildChartsBtn.UseVisualStyleBackColor = true;
            buildChartsBtn.Click += buildChartsBtn_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(703, 90);
            label6.Name = "label6";
            label6.Size = new Size(201, 20);
            label6.TabIndex = 4;
            label6.Text = "Количество экспериментов";
            // 
            // experimentCountTextBox
            // 
            experimentCountTextBox.Location = new Point(703, 116);
            experimentCountTextBox.Name = "experimentCountTextBox";
            experimentCountTextBox.PlaceholderText = "Количество экспериментов";
            experimentCountTextBox.Size = new Size(210, 27);
            experimentCountTextBox.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1224, 577);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(tabControl1);
            Controls.Add(buildChartsBtn);
            Controls.Add(startServerBtn);
            Controls.Add(experimentCountTextBox);
            Controls.Add(tsMaxTextBox);
            Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox aTextBox;
        private TextBox bTextBox;
        private Button startServerBtn;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn typeCol;
        private DataGridViewTextBoxColumn tauCol;
        private DataGridViewTextBoxColumn sigmaCol;
        private DataGridViewTextBoxColumn t1Col;
        private DataGridViewTextBoxColumn t2Col;
        private DataGridViewTextBoxColumn kCol;
        private DataGridViewTextBoxColumn lCol;
        private DataGridViewTextBoxColumn tsCol;
        private DataGridViewTextBoxColumn descCol;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TextBox expectationTextBox;
        private TextBox deviationTextBox;
        private TextBox tsMaxTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button buildChartsBtn;
        private Label label6;
        private TextBox experimentCountTextBox;
    }
}
