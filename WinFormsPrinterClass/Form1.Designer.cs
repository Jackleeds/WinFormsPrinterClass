namespace WinFormsPrinterClass
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
            textBox_ip = new TextBox();
            label1 = new Label();
            button2_Connect = new Button();
            richTextBox1 = new RichTextBox();
            label2 = new Label();
            groupBox1 = new GroupBox();
            textBox3_Model = new TextBox();
            textBox2_MaterialNo = new TextBox();
            textBox1_AssetNo = new TextBox();
            label4 = new Label();
            label3 = new Label();
            PrintBtn = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox_ip
            // 
            textBox_ip.Location = new Point(76, 23);
            textBox_ip.Name = "textBox_ip";
            textBox_ip.Size = new Size(149, 23);
            textBox_ip.TabIndex = 1;
            textBox_ip.Text = "10.102.73.39";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 26);
            label1.Name = "label1";
            label1.Size = new Size(58, 17);
            label1.TabIndex = 2;
            label1.Text = "打印机IP:";
            // 
            // button2_Connect
            // 
            button2_Connect.Location = new Point(231, 20);
            button2_Connect.Name = "button2_Connect";
            button2_Connect.Size = new Size(82, 30);
            button2_Connect.TabIndex = 3;
            button2_Connect.Text = "连接";
            button2_Connect.UseVisualStyleBackColor = true;
            button2_Connect.Click += button2_Connect_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 191);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(576, 144);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 12F);
            label2.Location = new Point(15, 28);
            label2.Name = "label2";
            label2.Size = new Size(78, 21);
            label2.TabIndex = 5;
            label2.Text = "资产编号:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox3_Model);
            groupBox1.Controls.Add(textBox2_MaterialNo);
            groupBox1.Controls.Add(textBox1_AssetNo);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 54);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(579, 131);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "固资标签表单";
            // 
            // textBox3_Model
            // 
            textBox3_Model.Location = new Point(99, 95);
            textBox3_Model.Name = "textBox3_Model";
            textBox3_Model.Size = new Size(140, 23);
            textBox3_Model.TabIndex = 9;
            // 
            // textBox2_MaterialNo
            // 
            textBox2_MaterialNo.Location = new Point(99, 59);
            textBox2_MaterialNo.Name = "textBox2_MaterialNo";
            textBox2_MaterialNo.Size = new Size(140, 23);
            textBox2_MaterialNo.TabIndex = 8;
            // 
            // textBox1_AssetNo
            // 
            textBox1_AssetNo.Location = new Point(99, 26);
            textBox1_AssetNo.Name = "textBox1_AssetNo";
            textBox1_AssetNo.Size = new Size(140, 23);
            textBox1_AssetNo.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft YaHei UI", 12F);
            label4.Location = new Point(15, 94);
            label4.Name = "label4";
            label4.Size = new Size(78, 21);
            label4.TabIndex = 7;
            label4.Text = "规格型号:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 12F);
            label3.Location = new Point(15, 59);
            label3.Name = "label3";
            label3.Size = new Size(78, 21);
            label3.TabIndex = 6;
            label3.Text = "物资编号:";
            // 
            // PrintBtn
            // 
            PrintBtn.Location = new Point(319, 20);
            PrintBtn.Name = "PrintBtn";
            PrintBtn.Size = new Size(76, 30);
            PrintBtn.TabIndex = 7;
            PrintBtn.Text = "打印";
            PrintBtn.UseVisualStyleBackColor = true;
            PrintBtn.Click += PrintBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 347);
            Controls.Add(PrintBtn);
            Controls.Add(richTextBox1);
            Controls.Add(button2_Connect);
            Controls.Add(label1);
            Controls.Add(textBox_ip);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "打印系统";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox_ip;
        private Label label1;
        private Button button2_Connect;
        private RichTextBox richTextBox1;
        private Label label2;
        private GroupBox groupBox1;
        private TextBox textBox3_Model;
        private TextBox textBox2_MaterialNo;
        private TextBox textBox1_AssetNo;
        private Label label4;
        private Label label3;
        private Button PrintBtn;
    }
}
