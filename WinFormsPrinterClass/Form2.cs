using NPOI.SS.UserModel;

using NPOI.XSSF.UserModel;
using System.Data;
using System.Drawing.Printing;
using WinFormsPrinterClass.DLL;
using DataTable = System.Data.DataTable;

namespace WinFormsPrinterClass
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();


        }
        /// <summary>
        /// 点击打印事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    if (row.Cells[0].Value != null)
                    {
                        if (bool.Parse(row.Cells[0].Value.ToString()) == true)
                        {
                            string assetNo = row.Cells[1].Value.ToString();
                            string materialNo = row.Cells[2].Value.ToString();
                            string model = row.Cells[4].Value.ToString();

                            //获取选中的打印机名称
                            string selectedPrinter = comboBox_printer.Text;

                            TSCLIB_DLL.openport(selectedPrinter);
                            TSCLIB_DLL.sendcommand("SIZE 70mm,30mm\n");
                            TSCLIB_DLL.sendcommand("GAP 2mm,0mm\n");
                            TSCLIB_DLL.sendcommand("DIRECTION 1\n");
                            TSCLIB_DLL.sendcommand("CLS\n");
                            TSCLIB_DLL.sendcommand("TEXT 145,169,\"FONT001\",0,2,2,\"规格型号:\"");
                            TSCLIB_DLL.sendcommand("TEXT 145,118,\"FONT001\",0,2,2,\"物资编号:\"");
                            TSCLIB_DLL.sendcommand("TEXT 145,70,\"FONT001\",0,2,2,\"资产编码:\"");
                            TSCLIB_DLL.sendcommand("TEXT 275,70,\"FONT001\",0,2,2,\"" + assetNo + "\"");
                            TSCLIB_DLL.sendcommand("TEXT 275,118,\"FONT001\",0,2,2,\"" + materialNo + "\"");
                            TSCLIB_DLL.sendcommand("TEXT 275,169,\"FONT001\",0,2,2,\"" + model + "\"");
                            TSCLIB_DLL.sendcommand("\"\n");
                            TSCLIB_DLL.sendcommand("PRINT 1\n");
                            TSCLIB_DLL.closeport();

                        }
                    }

                }

            }
            catch (Exception ex)
            {

                // TODO Auto-generated catch block
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }






        private void Form2_Load(object sender, EventArgs e)
        {
            //初始化DataGridView控件
            InitializeDataGridView();
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


        /// <summary>
        /// 初始化DataGrid视图
        /// </summary>

        private void InitializeDataGridView()
        {

            var ch = new datagridviewCheckboxHeaderCell();
            ch.OnCheckBoxClicked += new datagridviewcheckboxHeaderEventHander(ch_OnCheckBoxClicked);
            var checkboxCol = this.dataGridView1.Columns[0] as DataGridViewCheckBoxColumn;
            checkboxCol.HeaderCell = ch;
            checkboxCol.HeaderCell.Value = string.Empty;
            PageSorter(GetDataTable());
        }

        private DataTable GetDataTable()
        {
            string sql = "select Assets_Code,Material_Code,Material_Name,MaterialModel from [FAMS].[dbo].[MaterialInfo]";
            using (DataSet ds = DataClass.getDataSet(sql, "MaterialInfo"))
            {
                dataTable = ds.Tables[0];
            }
            return dataTable;
        }
        /// <summary>
        /// 加载分页视图
        /// </summary>

        private void LoadPage(DataTable dataTable)
        {
            int totalRecords = dataTable.Rows.Count;//表的总行数
            int totalPages = totalRecords / pageSize;//表的总页数
            if (totalRecords % pageSize > 0) { totalPages++; }

            // 计算起始行和结束行
            int startRow = (currentPage - 1) * pageSize;
            int endRow = pageSize * currentPage;
            if (currentPage == totalPages) endRow = totalRecords;


            DataTable pageData = dataTable.Clone();
            for (int i = startRow; i < endRow; i++)
            {
                pageData.ImportRow(dataTable.Rows[i]);
            }

            // 将分页后的数据绑定到DataGridView
            dataGridView1.DataSource = pageData;
            // 更新分页信息
            labelPageInfo.Text = $"第{currentPage}页/ 共{totalPages}页";
            labeltotalRecords.Text = $"共{totalRecords}条数据";


        }


        /// <summary>
        /// Execl导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExeclToDataGridBtn_Click(object sender, EventArgs e)
        {
            //清空所有行
            dataTable.Rows.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files(*.xls,*.xlsx)|*.xls;*.xlsx";
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



                        // 添加行数据
                        for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                        {
                            IRow row = sheet.GetRow(i);
                            DataRow dataRow = dataTable.NewRow();

                            for (int j = row.FirstCellNum; j < row.LastCellNum; j++)
                            {
                                if (row.GetCell(j) != null)
                                {
                                    dataRow[j] = row.GetCell(j).ToString();
                                }
                            }

                            dataTable.Rows.Add(dataRow);
                        }
                        PageSorter(dataTable);

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
        /// <summary>
        /// 触发复选框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        private void selectMaterialCode_Click(object sender, EventArgs e)
        {
            string materialNo = textBox2_MaterialNo.Text.Trim();
            string[] materialNoText = materialNo.Split(',');

            string output = string.Join(",", materialNoText.Select(f => $"'{f}'"));
            DataRow[] foundRows = dataTable.Select("Material_Code in(" + output + ")");
            dataTable = foundRows.CopyToDataTable();
            PageSorter(dataTable);


        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                DataGridView dgv = (DataGridView)sender;
                DataGridViewCheckBoxCell chkBox = dgv.Rows[e.RowIndex].Cells[0] as DataGridViewCheckBoxCell;

                if (chkBox != null)
                {
                    bool isChecked = Convert.ToBoolean(chkBox.EditedFormattedValue);
                    dgv.Rows[e.RowIndex].Cells[0].Value = isChecked;
                }
                //更新行的颜色
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells[0].Value);
                    row.DefaultCellStyle.BackColor = isSelected ? Color.LightBlue : Color.White;
                }

            }


        }

        /// <summary>
        /// 点击刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnQuery_Click(object sender, EventArgs e)
        {
            PageSorter(dataTable);
        }

        private int currentPage = 1;
        private int pageSize = 20;
        private int totalPages = 0;
        private DataTable dataTable;


        /// <summary>
        /// 当前页
        /// </summary>
        /// <param name="dataTable"></param>
        private void PageSorter(DataTable dataTable)
        {
            int totalRecords = dataTable.Rows.Count;//总记录数
            int totalPages = totalRecords / pageSize;//总页数
            if (totalRecords % pageSize > 0)
            {
                totalPages++;
            }
            LoadPage(dataTable);
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage == 1)
            {
                MessageBox.Show("当前已经是第一页,请点击下一页查看");
                return;
            }

            currentPage--;
            PageSorter(dataTable);


        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage == totalPages)
            {
                MessageBox.Show("已经是最后一页，请点击上一页查看！");
                return;
            }
            // 下一页按钮点击事件


            currentPage++;
            PageSorter(dataTable);


        }

        private void linkLabel_ExcelupLoad_Click(object sender, EventArgs e)
        {
            CreateExcelFile();
        }
         
        private void CreateExcelFile()
        {
            // 创建一个工作簿
            IWorkbook workbook = new XSSFWorkbook();
            // 创建一个工作表
            ISheet sheet = workbook.CreateSheet("Sheet1");
            // 创建行（这里创建第一行）
            IRow row = sheet.CreateRow(0);

            // 创建单元格并添加数据
            ICell cell = row.CreateCell(0);
            cell.SetCellValue("Assets_Code");

            cell = row.CreateCell(1);
            cell.SetCellValue("Material_Code");

            cell = row.CreateCell(2);
            cell.SetCellValue("Material_Name");
            cell = row.CreateCell(3);
            cell.SetCellValue("MaterialModel");
            // 保存Excel文件到桌面
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string excelFileName = "明细模版.xlsx";
            string filePath = Path.Combine(desktopPath, excelFileName);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fileStream);
            }

            MessageBox.Show("Excel file saved to desktop.");
        }

       
     
    }
}

