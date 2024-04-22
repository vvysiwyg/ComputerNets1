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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 34);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "a";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(143, 34);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "b";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(285, 34);
            button1.Name = "button1";
            button1.Size = new Size(125, 29);
            button1.TabIndex = 1;
            button1.Text = "Test";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
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
            dataGridView1.Size = new Size(1180, 288);
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
            tabControl1.Location = new Point(12, 87);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1200, 351);
            tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.Control;
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1192, 318);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Отладка";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = SystemColors.Control;
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1192, 318);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "L(n)";
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1192, 318);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "A_Out(X)";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1224, 450);
            Controls.Add(tabControl1);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
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
    }
}
