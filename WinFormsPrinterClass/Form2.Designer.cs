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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            button1 = new Button();
            groupBox2 = new GroupBox();
            selectMaterialCode = new Button();
            textBox2_MaterialNo = new TextBox();
            label3 = new Label();
            comboBox_printer = new ComboBox();
            label1 = new Label();
            ExeclToDataGridBtn = new Button();
            openFileDialog1 = new OpenFileDialog();
            dataGridView1 = new DataGridView();
            select = new DataGridViewCheckBoxColumn();
            Assets_Code = new DataGridViewTextBoxColumn();
            Material_Code = new DataGridViewTextBoxColumn();
            Material_Name = new DataGridViewTextBoxColumn();
            MaterialModel = new DataGridViewTextBoxColumn();
            btnPrevious = new Button();
            btnNext = new Button();
            labelPageInfo = new Label();
            btnQuery = new Button();
            labeltotalRecords = new Label();
            linkLabel_ExcelupLoad = new LinkLabel();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(256, 9);
            button1.Name = "button1";
            button1.Size = new Size(75, 36);
            button1.TabIndex = 0;
            button1.Text = "打印";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(selectMaterialCode);
            groupBox2.Controls.Add(textBox2_MaterialNo);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(12, 47);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(715, 66);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "固资标签表单";
            // 
            // selectMaterialCode
            // 
            selectMaterialCode.Location = new Point(622, 17);
            selectMaterialCode.Name = "selectMaterialCode";
            selectMaterialCode.Size = new Size(87, 33);
            selectMaterialCode.TabIndex = 9;
            selectMaterialCode.Text = "查询";
            selectMaterialCode.UseVisualStyleBackColor = true;
            selectMaterialCode.Click += selectMaterialCode_Click;
            // 
            // textBox2_MaterialNo
            // 
            textBox2_MaterialNo.Location = new Point(85, 22);
            textBox2_MaterialNo.Name = "textBox2_MaterialNo";
            textBox2_MaterialNo.Size = new Size(531, 23);
            textBox2_MaterialNo.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 12F);
            label3.Location = new Point(6, 21);
            label3.Name = "label3";
            label3.Size = new Size(78, 21);
            label3.TabIndex = 6;
            label3.Text = "物资编号:";
            // 
            // comboBox_printer
            // 
            comboBox_printer.DropDownStyle = ComboBoxStyle.DropDownList;
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
            label1.Text = "选择打印机:";
            // 
            // ExeclToDataGridBtn
            // 
            ExeclToDataGridBtn.Location = new Point(337, 9);
            ExeclToDataGridBtn.Name = "ExeclToDataGridBtn";
            ExeclToDataGridBtn.Size = new Size(75, 36);
            ExeclToDataGridBtn.TabIndex = 11;
            ExeclToDataGridBtn.Text = "Excel导入";
            ExeclToDataGridBtn.UseVisualStyleBackColor = true;
            ExeclToDataGridBtn.Click += ExeclToDataGridBtn_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft YaHei UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { select, Assets_Code, Material_Code, Material_Name, MaterialModel });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Microsoft YaHei UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.Location = new Point(11, 119);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView1.Size = new Size(716, 524);
            dataGridView1.TabIndex = 12;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // select
            // 
            select.FalseValue = "false";
            select.FillWeight = 25.38071F;
            select.HeaderText = "";
            select.Name = "select";
            select.Resizable = DataGridViewTriState.True;
            select.TrueValue = "true";
            // 
            // Assets_Code
            // 
            Assets_Code.DataPropertyName = "Assets_Code";
            Assets_Code.FillWeight = 118.654823F;
            Assets_Code.HeaderText = "资产编码";
            Assets_Code.Name = "Assets_Code";
            Assets_Code.ReadOnly = true;
            // 
            // Material_Code
            // 
            Material_Code.DataPropertyName = "Material_Code";
            Material_Code.FillWeight = 118.654823F;
            Material_Code.HeaderText = "物资编号";
            Material_Code.Name = "Material_Code";
            Material_Code.ReadOnly = true;
            // 
            // Material_Name
            // 
            Material_Name.DataPropertyName = "Material_Name";
            Material_Name.FillWeight = 118.654823F;
            Material_Name.HeaderText = "物资名称";
            Material_Name.Name = "Material_Name";
            Material_Name.ReadOnly = true;
            // 
            // MaterialModel
            // 
            MaterialModel.DataPropertyName = "MaterialModel";
            MaterialModel.FillWeight = 118.654823F;
            MaterialModel.HeaderText = "规格型号";
            MaterialModel.Name = "MaterialModel";
            MaterialModel.ReadOnly = true;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(245, 649);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(75, 23);
            btnPrevious.TabIndex = 15;
            btnPrevious.Text = "上一页";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(436, 649);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(75, 23);
            btnNext.TabIndex = 16;
            btnNext.Text = "下一页";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // labelPageInfo
            // 
            labelPageInfo.AutoSize = true;
            labelPageInfo.Location = new Point(326, 652);
            labelPageInfo.Name = "labelPageInfo";
            labelPageInfo.Size = new Size(104, 17);
            labelPageInfo.TabIndex = 17;
            labelPageInfo.Text = "page/totalPages";
            // 
            // btnQuery
            // 
            btnQuery.Location = new Point(21, 649);
            btnQuery.Name = "btnQuery";
            btnQuery.Size = new Size(75, 23);
            btnQuery.TabIndex = 14;
            btnQuery.Text = "刷新";
            btnQuery.UseVisualStyleBackColor = true;
            btnQuery.Click += btnQuery_Click;
            // 
            // labeltotalRecords
            // 
            labeltotalRecords.AutoSize = true;
            labeltotalRecords.Location = new Point(634, 652);
            labeltotalRecords.Name = "labeltotalRecords";
            labeltotalRecords.Size = new Size(82, 17);
            labeltotalRecords.TabIndex = 18;
            labeltotalRecords.Text = "totalRecords";
            // 
            // linkLabel_ExcelupLoad
            // 
            linkLabel_ExcelupLoad.AutoSize = true;
            linkLabel_ExcelupLoad.Location = new Point(418, 27);
            linkLabel_ExcelupLoad.Name = "linkLabel_ExcelupLoad";
            linkLabel_ExcelupLoad.Size = new Size(92, 17);
            linkLabel_ExcelupLoad.TabIndex = 19;
            linkLabel_ExcelupLoad.TabStop = true;
            linkLabel_ExcelupLoad.Text = "请下载明细模版";
            linkLabel_ExcelupLoad.Click += linkLabel_ExcelupLoad_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(739, 672);
            Controls.Add(linkLabel_ExcelupLoad);
            Controls.Add(dataGridView1);
            Controls.Add(labeltotalRecords);
            Controls.Add(labelPageInfo);
            Controls.Add(btnNext);
            Controls.Add(btnPrevious);
            Controls.Add(btnQuery);
            Controls.Add(ExeclToDataGridBtn);
            Controls.Add(label1);
            Controls.Add(comboBox_printer);
            Controls.Add(groupBox2);
            Controls.Add(button1);
            Name = "Form2";
            Text = "刷新";
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
        private TextBox textBox2_MaterialNo;
        private Label label3;
        private ComboBox comboBox_printer;
        private Label label1;
        private Button ExeclToDataGridBtn;
        private OpenFileDialog openFileDialog1;
        private Button selectMaterialCode;
        private DataGridView dataGridView1;
        private DataGridViewCheckBoxColumn select;
        private DataGridViewTextBoxColumn Assets_Code;
        private DataGridViewTextBoxColumn Material_Code;
        private DataGridViewTextBoxColumn Material_Name;
        private DataGridViewTextBoxColumn MaterialModel;
        private Button btnPrevious;
        private Button btnNext;
        private Label labelPageInfo;
        private Button btnQuery;
        private Label labeltotalRecords;
        private LinkLabel linkLabel_ExcelupLoad;
    }
}