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
            tabPageDebug = new TabPage();
            tabControl2 = new TabControl();
            tabPage4 = new TabPage();
            tabPageLn = new TabPage();
            tabControl3 = new TabControl();
            tabPage1 = new TabPage();
            tabPageAOutX = new TabPage();
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
            groupBox3 = new GroupBox();
            lambdaTextBox = new TextBox();
            label7 = new Label();
            nTextBox = new TextBox();
            label8 = new Label();
            tabControl4 = new TabControl();
            tabPage2 = new TabPage();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabControl1.SuspendLayout();
            tabPageDebug.SuspendLayout();
            tabControl2.SuspendLayout();
            tabPage4.SuspendLayout();
            tabPageLn.SuspendLayout();
            tabControl3.SuspendLayout();
            tabPageAOutX.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            tabControl4.SuspendLayout();
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
            startServerBtn.Location = new Point(954, 114);
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
            dataGridView1.Location = new Point(6, 6);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1393, 315);
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
            tabControl1.Controls.Add(tabPageDebug);
            tabControl1.Controls.Add(tabPageLn);
            tabControl1.Controls.Add(tabPageAOutX);
            tabControl1.Location = new Point(12, 149);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1436, 416);
            tabControl1.TabIndex = 3;
            // 
            // tabPageDebug
            // 
            tabPageDebug.BackColor = SystemColors.Control;
            tabPageDebug.Controls.Add(tabControl2);
            tabPageDebug.Location = new Point(4, 29);
            tabPageDebug.Name = "tabPageDebug";
            tabPageDebug.Padding = new Padding(3);
            tabPageDebug.Size = new Size(1428, 383);
            tabPageDebug.TabIndex = 0;
            tabPageDebug.Text = "Отладка";
            // 
            // tabControl2
            // 
            tabControl2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl2.Controls.Add(tabPage4);
            tabControl2.Location = new Point(9, 17);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(1413, 360);
            tabControl2.TabIndex = 3;
            // 
            // tabPage4
            // 
            tabPage4.BackColor = SystemColors.Control;
            tabPage4.Controls.Add(dataGridView1);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1405, 327);
            tabPage4.TabIndex = 0;
            tabPage4.Text = "tabPage4";
            // 
            // tabPageLn
            // 
            tabPageLn.BackColor = SystemColors.Control;
            tabPageLn.Controls.Add(tabControl3);
            tabPageLn.Location = new Point(4, 29);
            tabPageLn.Name = "tabPageLn";
            tabPageLn.Padding = new Padding(3);
            tabPageLn.Size = new Size(1428, 383);
            tabPageLn.TabIndex = 1;
            tabPageLn.Text = "L(n)";
            // 
            // tabControl3
            // 
            tabControl3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl3.Controls.Add(tabPage1);
            tabControl3.Location = new Point(9, 17);
            tabControl3.Name = "tabControl3";
            tabControl3.SelectedIndex = 0;
            tabControl3.Size = new Size(1413, 360);
            tabControl3.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.Control;
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1405, 327);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            // 
            // tabPageAOutX
            // 
            tabPageAOutX.BackColor = SystemColors.Control;
            tabPageAOutX.Controls.Add(tabControl4);
            tabPageAOutX.Location = new Point(4, 29);
            tabPageAOutX.Name = "tabPageAOutX";
            tabPageAOutX.Padding = new Padding(3);
            tabPageAOutX.Size = new Size(1428, 383);
            tabPageAOutX.TabIndex = 2;
            tabPageAOutX.Text = "A_Out(X)";
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
            tsMaxTextBox.Location = new Point(954, 44);
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
            label5.Location = new Point(954, 10);
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
            buildChartsBtn.Location = new Point(1243, 114);
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
            label6.Location = new Point(1203, 12);
            label6.Name = "label6";
            label6.Size = new Size(201, 20);
            label6.TabIndex = 4;
            label6.Text = "Количество экспериментов";
            // 
            // experimentCountTextBox
            // 
            experimentCountTextBox.Location = new Point(1203, 43);
            experimentCountTextBox.Name = "experimentCountTextBox";
            experimentCountTextBox.PlaceholderText = "Количество экспериментов";
            experimentCountTextBox.Size = new Size(210, 27);
            experimentCountTextBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lambdaTextBox);
            groupBox3.Controls.Add(label7);
            groupBox3.Location = new Point(693, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(206, 107);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Распределение Пуассона";
            // 
            // lambdaTextBox
            // 
            lambdaTextBox.Location = new Point(13, 64);
            lambdaTextBox.Name = "lambdaTextBox";
            lambdaTextBox.PlaceholderText = "λ";
            lambdaTextBox.Size = new Size(125, 27);
            lambdaTextBox.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(13, 38);
            label7.Name = "label7";
            label7.Size = new Size(16, 20);
            label7.TabIndex = 4;
            label7.Text = "λ";
            // 
            // nTextBox
            // 
            nTextBox.Location = new Point(611, 129);
            nTextBox.Name = "nTextBox";
            nTextBox.PlaceholderText = "n";
            nTextBox.Size = new Size(125, 27);
            nTextBox.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(358, 132);
            label8.Name = "label8";
            label8.Size = new Size(236, 20);
            label8.TabIndex = 4;
            label8.Text = "Количество вершин в графе Star";
            // 
            // tabControl4
            // 
            tabControl4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl4.Controls.Add(tabPage2);
            tabControl4.Location = new Point(8, 11);
            tabControl4.Name = "tabControl4";
            tabControl4.SelectedIndex = 0;
            tabControl4.Size = new Size(1413, 360);
            tabControl4.TabIndex = 1;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = SystemColors.Control;
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1405, 327);
            tabPage2.TabIndex = 0;
            tabPage2.Text = "tabPage2";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1460, 577);
            Controls.Add(nTextBox);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label6);
            Controls.Add(label8);
            Controls.Add(label5);
            Controls.Add(tabControl1);
            Controls.Add(buildChartsBtn);
            Controls.Add(startServerBtn);
            Controls.Add(experimentCountTextBox);
            Controls.Add(tsMaxTextBox);
            Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPageDebug.ResumeLayout(false);
            tabControl2.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            tabPageLn.ResumeLayout(false);
            tabControl3.ResumeLayout(false);
            tabPageAOutX.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            tabControl4.ResumeLayout(false);
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
        private TabPage tabPageDebug;
        private TabPage tabPageLn;
        private TabPage tabPageAOutX;
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
        private GroupBox groupBox3;
        private TextBox lambdaTextBox;
        private Label label7;
        private TextBox nTextBox;
        private Label label8;
        private TabControl tabControl2;
        private TabPage tabPage4;
        private TabControl tabControl3;
        private TabPage tabPage1;
        private TabControl tabControl4;
        private TabPage tabPage2;
    }
}
