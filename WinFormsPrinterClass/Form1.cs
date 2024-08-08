using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsPrinterClass
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }
        //直接选择打印机调用
       /* private void button1_Click(object sender, EventArgs e)
        {
      string s = "^XA^LH30,30n^FO20,10^ADN,90,50^AD^FDHello World^FSn^XZ";
            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings = new PrinterSettings();
            if (DialogResult.OK == pd.ShowDialog(this))
            {
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, s);
            } 
        }*/

        private void Form1_Load(object sender, EventArgs e)
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

        private void button2_Connect_Click(object sender, EventArgs e)
        {

            IPEndPoint printerClient = new IPEndPoint(IPAddress.Parse(textBox_ip.Text), 9100);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(textBox_ip.Text, 9100);
            if (socket.Connected)
            {
                richTextBox1.Text = "打印机连接成功";

            }

        }


        /// <summary>
        /// 获取打印机ip地址,并打印内容
        /// </summary>
        private Regex rxIP = new Regex("((?:(?:25[0-5]|2[0-4]\\d|((1\\d{2})|([1-9]?\\d)))\\.){3}(?:25[0-5]|2[0-4]\\d|((1\\d{2})|([1-9]?\\d))))");
        private string prtContent = null;
        string result;
        private string PrintLabel(string printerName)
        {
            TcpClient tcpClient = null;
            StreamWriter streamWriter = null;
            //  StringReader lineReader = null;
            if (!printerName.StartsWith("TSC"))
            {
              
            
                bool flag = this.rxIP.IsMatch(printerName);
                if (flag)
                {
                   
                    string[] array = printerName.Split(new char[]
                    {
                    ':'
                    });
                    string hostname = array[0];
                    int port = 9100;
                    bool flag2 = array.Length > 1;
                    if (flag2)
                    {
                        port = int.Parse(array[1]);
                    }
                    try
                    {
                        tcpClient = new TcpClient();
                        tcpClient.Connect(hostname, port);
                        streamWriter = new StreamWriter(tcpClient.GetStream());
                        streamWriter.Write(this.prtContent);
                        streamWriter.Flush();
                        result = "OK";
                        return result;

                    }
                    catch (Exception ex2)
                    {
                        Exception ex = ex2;
                        result = ex.Message;
                        return result;
                    }
                    finally
                    {
                        bool flag3 = streamWriter != null;
                        if (flag3)
                        {
                            streamWriter.Close();
                            streamWriter.Dispose();
                        }
                        bool flag4 = tcpClient != null;
                        if (flag4)
                        {
                            tcpClient.Close();
                        }
                    }

                }
                 
            }
            else
            {
               /* streamWriter = new StreamWriter(printerName, false, System.Text.Encoding.UTF8);
                streamWriter.Write(this.prtContent);
                streamWriter.Flush();
                RawPrinterHelper.SendStringToPrinter(printerName, this.prtContent);
                result = "OK";*/
                 
            }


            return result;
        }



        private void PrintBtn_Click(object sender, EventArgs e)
        {
           // string printerName = textBox_ip.Text.Trim();
            string AssetNo = textBox1_AssetNo.Text.Trim();
            string MaterialNo = textBox2_MaterialNo.Text.Trim();
            string Model = textBox3_Model.Text.Trim();
            //printAssetLabel(printerName, AssetNo, MaterialNo, Model);
          

             //获取选中的打印机名称
            string selectedPrinter = comboBox_printer.SelectedItem.ToString();
            
            //使用选中的打印机名称进行打印操作
            /* PrintDocument print = new PrintDocument();
             print.PrinterSettings.PrinterName = selectedPrinter;*/
            try
            {
               string result=  printAssetLabel(selectedPrinter, AssetNo, MaterialNo, Model);
                if (result == "OK")
                {
                    richTextBox1.Text = "打印成功！";
                }
                 
            }
            catch (Exception ex)
            {
                MessageBox.Show("打印出错:" + ex, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        public string printAssetLabel(string printerName, string assetNo, string materialNo, string model)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("SIZE 70mm,30mm");
            stringBuilder.AppendLine("GAP 2mm,0mm");
            stringBuilder.AppendLine("DIRECTION 1");
            stringBuilder.AppendLine("CLS");
            stringBuilder.AppendLine("TEXT 200,189,\"FONT001\",0,2,2,\"规格型号\"");
            stringBuilder.AppendLine("TEXT 199,141,\"FONT001\",0,2,2,\"物资编号\"");
            stringBuilder.AppendLine("TEXT 197,90,\"FONT001\",0,2,2,\"资产编号\"");
            stringBuilder.AppendLine("TEXT 305,87,\"FONT001\",0,2,2,\"" + assetNo + "\"");
            stringBuilder.AppendLine("TEXT 305,138,\"FONT001\",0,2,2,\"" + materialNo + "\"");
            stringBuilder.AppendLine("TEXT 305,189,\"FONT001\",0,2,2,\"" + model + "\"");
            stringBuilder.AppendLine("PRINT 1,1");
            //stringBuilder.Append("\n");
            this.prtContent = stringBuilder.ToString();
            return this.PrintLabel(printerName);
        }


    }
}