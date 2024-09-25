using NPOI.SS.Formula.Eval;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Data;
using System.Drawing.Printing;
using WinFormsPrinterClass.DLL;

namespace WinFormsPrinterClass
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string assetNo = textBox1_AssetNo.Text.Trim();
                string materialNo = textBox2_MaterialNo.Text.Trim();
                string model = textBox3_Model.Text.Trim();

                //获取选中的打印机名称
                string selectedPrinter = comboBox_printer.Text;

                TSCLIB_DLL.openport(selectedPrinter);
                TSCLIB_DLL.sendcommand("SIZE 70mm,30mm\n");
                TSCLIB_DLL.sendcommand("GAP 2mm,0mm\n");
                TSCLIB_DLL.sendcommand("DIRECTION 1\n");
                TSCLIB_DLL.sendcommand("CLS\n");
                TSCLIB_DLL.sendcommand("TEXT 145,169,\"FONT001\",0,2,2,\"规格型号:\"");
                TSCLIB_DLL.sendcommand("TEXT 145,118,\"FONT001\",0,2,2,\"物资编号:\"");
                TSCLIB_DLL.sendcommand("TEXT 145,70,\"FONT001\",0,2,2,\"资产编号:\"");
                TSCLIB_DLL.sendcommand("TEXT 275,70,\"FONT001\",0,2,2,\"" + assetNo + "\"");
                TSCLIB_DLL.sendcommand("TEXT 275,118,\"FONT001\",0,2,2,\"" + materialNo + "\"");
                TSCLIB_DLL.sendcommand("TEXT 275,169,\"FONT001\",0,2,2,\"" + model + "\"");
                TSCLIB_DLL.sendcommand("\"\n");
                TSCLIB_DLL.sendcommand("PRINT 1\n");
                TSCLIB_DLL.closeport();



            }

            catch (Exception ex)
            {

                // TODO Auto-generated catch block
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var ch = new datagridviewCheckboxHeaderCell();
            ch.OnCheckBoxClicked += new datagridviewcheckboxHeaderEventHander(ch_OnCheckBoxClicked);
            var checkboxCol = this.dataGridView1.Columns[0] as DataGridViewCheckBoxColumn;
            checkboxCol.HeaderCell = ch;
            checkboxCol.HeaderCell.Value = string.Empty;

            PrintDocument prtdoc = new PrintDocument();
            string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;//获取默认的打印机名

            foreach (string ss in PrinterSettings.InstalledPrinters)
            {
                ///在列表框中列出所有的打印机,
                this.comboBox_printer.Items.Add(ss);
                if (ss == strDefaultPrinter)//把默认打印机设为缺省值
                {
                    comboBox_printer.SelectedIndex = comboBox_printer.Items.IndexOf(ss);
                }
            }

        }
        
        private void ExeclToDataGridBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx";
            openFileDialog.Title = "打开文件";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                string filePath = openFileDialog.FileName;
                try
                {
                    using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        IWorkbook workbook = new XSSFWorkbook(fs);
                        ISheet sheet = workbook.GetSheetAt(0); // 获取第一个工作表

                        DataTable dt = new DataTable();
                        IRow headerRow = sheet.GetRow(0);

                        // 创建列
                        for (int i = 0; i < headerRow.LastCellNum; i++)
                        {
                            dt.Columns.Add(Convert.ToString(headerRow.GetCell(i)));
                        }

                        // 添加行数据
                        for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                        {
                            IRow row = sheet.GetRow(i);
                            DataRow dataRow = dt.NewRow();

                            for (int j = row.FirstCellNum; j < row.LastCellNum; j++)
                            {
                                if (row.GetCell(j) != null)
                                {
                                    dataRow[j] = row.GetCell(j).ToString();
                                }
                            }

                            dt.Rows.Add(dataRow);
                        }
                        dataGridView1.DataSource = dt;

                    }
                    // 把列抬头名称赋值给 列的name
                    string Columns_name = "";
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        Columns_name = dataGridView1.Columns[i].HeaderText;
                        dataGridView1.Columns[i].Name = Columns_name;
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error: " + ex.Message);

                }

            }
            GC.Collect();//强制进行垃圾回收
        }

        private void ch_OnCheckBoxClicked(object sender, datagridviewCheckboxHeaderEventArgs e)
        {

            foreach (DataGridViewRow dgvRow in dataGridView1.Rows)
            {
                if (e.CheckedState)
                {
                    dgvRow.Cells[0].Value = true;
                }
                else
                {
                    dgvRow.Cells[0].Value = false;
                }
            }
        }

        private void textBox2_MaterialNo_KeyDown(object sender, KeyEventArgs e)
        {
            string materialNo = textBox2_MaterialNo.Text.Trim();
            if (e.KeyCode == Keys.Enter)
            {
                string sql = "select Assets_Code,Material_Code,Material_Name from [FAMS].[dbo].[MaterialInfo] where Material_Code='" + materialNo + "'";
                using (DataSet ds = DataClass.getDataSet(sql, "MaterialInfo"))
                {
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("此编号没有数据！");
                    }
                    else
                    {
                        textBox1_AssetNo.Text = ds.Tables[0].Rows[0]["Assets_Code"].ToString();
                        textBox3_Model.Text = ds.Tables[0].Rows[0]["Material_Name"].ToString();

                    }

                }
            }
        }

        private void textBox2_MaterialNo_TextChanged(object sender, EventArgs e)
        {
            if (textBox2_MaterialNo.Text == "")
            {
                textBox1_AssetNo.Clear();
                textBox3_Model.Clear();
            }
        }
       /* private int pageSize = 10; // 每页的行数
        private int currentPage = 0; // 当前页数
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // 当行被添加时，更新每页的行数
            pageSize = e.RowCount;
            int totalPages = (int)Math.Ceiling((double)dataGridView1.RowCount / pageSize);
            // 当添加新行后，可能需要更新分页信息
            labelPageInfo.Text = $"Page {1} of {totalPages}";
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            // 当滚动时，更新当前页数
            int currentPage = dataGridView1.FirstDisplayedScrollingRowIndex / pageSize + 1;
            int totalPages = (int)Math.Ceiling((double)dataGridView1.RowCount / pageSize);
            // 更新分页信息
            labelPageInfo.Text = $"Page {currentPage} of {totalPages}";
            // 当滚动到最后一页时，防止越界
            if (currentPage > totalPages)
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = (totalPages - 1) * pageSize;
            }
        }*/
    }
}
 
