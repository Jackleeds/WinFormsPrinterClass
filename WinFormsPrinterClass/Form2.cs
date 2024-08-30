 
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                string selectedPrinter = comboBox_printer.SelectedItem.ToString();
                TSCLIB_DLL.openport(selectedPrinter);
                TSCLIB_DLL.sendcommand("SIZE 70mm,30mm\n");
                TSCLIB_DLL.sendcommand("GAP 2mm,0mm\n");
                TSCLIB_DLL.sendcommand("DIRECTION 1\n");
                TSCLIB_DLL.sendcommand("CLS\n");
                TSCLIB_DLL.sendcommand("TEXT 145,169,\"FONT001\",0,2,2,\"规格型号:\"");
                TSCLIB_DLL.sendcommand("TEXT 145,118,\"FONT001\",0,2,2,\"物资编号:\"");
                TSCLIB_DLL.sendcommand("TEXT 145,70,\"FONT001\",0,2,2,\"资产编号:\"");
                TSCLIB_DLL.sendcommand("TEXT 275,70,\"1\",0,2,2,\"" + assetNo + "\"");
                TSCLIB_DLL.sendcommand("TEXT 275,118,\"1\",0,2,2,\"" + materialNo + "\"");
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
                                       
        
    }
}
