namespace WinFormsPrinterClass
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            groupBox2 = new GroupBox();
            textBox3_Model = new TextBox();
            textBox2_MaterialNo = new TextBox();
            textBox1_AssetNo = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            comboBox_printer = new ComboBox();
            label1 = new Label();
            ExeclToDataGridBtn = new Button();
            dataGridView1 = new DataGridView();
            select = new DataGridViewCheckBoxColumn();
            openFileDialog1 = new OpenFileDialog();
            labelPageInfo = new Label();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            label5 = new Label();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(266, 15);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "打印";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox3_Model);
            groupBox2.Controls.Add(textBox2_MaterialNo);
            groupBox2.Controls.Add(textBox1_AssetNo);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(12, 47);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(423, 114);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "固资标签表单";
            // 
            // textBox3_Model
            // 
            textBox3_Model.Location = new Point(99, 86);
            textBox3_Model.Name = "textBox3_Model";
            textBox3_Model.ReadOnly = true;
            textBox3_Model.Size = new Size(140, 23);
            textBox3_Model.TabIndex = 9;
            // 
            // textBox2_MaterialNo
            // 
            textBox2_MaterialNo.Location = new Point(99, 19);
            textBox2_MaterialNo.Name = "textBox2_MaterialNo";
            textBox2_MaterialNo.Size = new Size(140, 23);
            textBox2_MaterialNo.TabIndex = 8;
            textBox2_MaterialNo.TextChanged += textBox2_MaterialNo_TextChanged;
            textBox2_MaterialNo.KeyDown += textBox2_MaterialNo_KeyDown;
            // 
            // textBox1_AssetNo
            // 
            textBox1_AssetNo.Location = new Point(99, 52);
            textBox1_AssetNo.Name = "textBox1_AssetNo";
            textBox1_AssetNo.ReadOnly = true;
            textBox1_AssetNo.Size = new Size(140, 23);
            textBox1_AssetNo.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft YaHei UI", 12F);
            label4.Location = new Point(15, 85);
            label4.Name = "label4";
            label4.Size = new Size(78, 21);
            label4.TabIndex = 7;
            label4.Text = "规格型号:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 12F);
            label3.Location = new Point(15, 19);
            label3.Name = "label3";
            label3.Size = new Size(78, 21);
            label3.TabIndex = 6;
            label3.Text = "物资编号:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 12F);
            label2.Location = new Point(15, 54);
            label2.Name = "label2";
            label2.Size = new Size(78, 21);
            label2.TabIndex = 5;
            label2.Text = "资产编号:";
            // 
            // comboBox_printer
            // 
            comboBox_printer.FormattingEnabled = true;
            comboBox_printer.Location = new Point(111, 16);
            comboBox_printer.Name = "comboBox_printer";
            comboBox_printer.Size = new Size(139, 25);
            comboBox_printer.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 12F);
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(94, 21);
            label1.TabIndex = 9;
            label1.Text = "选中打印机:";
            // 
            // ExeclToDataGridBtn
            // 
            ExeclToDataGridBtn.Location = new Point(12, 167);
            ExeclToDataGridBtn.Name = "ExeclToDataGridBtn";
            ExeclToDataGridBtn.Size = new Size(75, 23);
            ExeclToDataGridBtn.TabIndex = 11;
            ExeclToDataGridBtn.Text = "导入";
            ExeclToDataGridBtn.UseVisualStyleBackColor = true;
            ExeclToDataGridBtn.Click += ExeclToDataGridBtn_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { select });
            dataGridView1.Location = new Point(12, 199);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(423, 292);
            dataGridView1.TabIndex = 12;
           /* dataGridView1.RowsAdded += dataGridView1_RowsAdded;
            dataGridView1.Scroll += dataGridView1_Scroll;*/
            // 
            // select
            // 
            select.HeaderText = "";
            select.Name = "select";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // labelPageInfo
            // 
            labelPageInfo.AutoSize = true;
            labelPageInfo.Location = new Point(325, 501);
            labelPageInfo.Name = "labelPageInfo";
            labelPageInfo.Size = new Size(43, 17);
            labelPageInfo.TabIndex = 13;
            labelPageInfo.Text = "label1";
            // 
            // button2
            // 
            button2.Location = new Point(286, 497);
            button2.Name = "button2";
            button2.Size = new Size(33, 23);
            button2.TabIndex = 14;
            button2.Text = "<";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(363, 497);
            button3.Name = "button3";
            button3.Size = new Size(33, 23);
            button3.TabIndex = 15;
            button3.Text = ">";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(247, 497);
            button4.Name = "button4";
            button4.Size = new Size(33, 23);
            button4.TabIndex = 16;
            button4.Text = "《";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(402, 497);
            button5.Name = "button5";
            button5.Size = new Size(33, 23);
            button5.TabIndex = 17;
            button5.Text = "》";
            button5.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 501);
            label5.Name = "label5";
            label5.Size = new Size(43, 17);
            label5.TabIndex = 18;
            label5.Text = "label5";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(446, 523);
            Controls.Add(label5);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(labelPageInfo);
            Controls.Add(dataGridView1);
            Controls.Add(ExeclToDataGridBtn);
            Controls.Add(label1);
            Controls.Add(comboBox_printer);
            Controls.Add(groupBox2);
            Controls.Add(button1);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private GroupBox groupBox2;
        private TextBox textBox3_Model;
        private TextBox textBox2_MaterialNo;
        private TextBox textBox1_AssetNo;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox comboBox_printer;
        private Label label1;
        private Button ExeclToDataGridBtn;
        private DataGridView dataGridView1;
        private OpenFileDialog openFileDialog1;
        private DataGridViewCheckBoxColumn select;
        private Label labelPageInfo;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Label label5;
    }
}