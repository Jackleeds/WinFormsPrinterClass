using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static WinFormsPrinterClass.RawPrinterHelper;

namespace WinFormsPrinterClass
{
    public class RawPrinterHelper
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct DOCINFOW
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pDocName;

            [MarshalAs(UnmanagedType.LPWStr)]
            public string pOutputFile;

            [MarshalAs(UnmanagedType.LPWStr)]
            public string pDataType;
        }

        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterW", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
        public static extern bool OpenPrinter(string src, ref IntPtr hPrinter, long pd);

        [DllImport("winspool.Drv", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterW", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, int level, ref RawPrinterHelper.DOCINFOW pDI);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);


        [DllImport("winspool.Drv", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, out int dwWritten);

       

            public static bool SendStringToPrinter(string szPrinterName, string szString)
    {
        IntPtr pBytes;
        Int32 dwCount;
        // How many characters are in the string?
        dwCount = szString.Length;
        // Assume that the printer is expecting ANSI text, and then convert
        // the string to ANSI text.
        pBytes = Marshal.StringToCoTaskMemAnsi(szString);
        // Send the converted ANSI string to the printer.
        SendBytesToPrinter(szPrinterName, pBytes, dwCount);
        Marshal.FreeCoTaskMem(pBytes);
        return true;
    }

    public static bool SendFileToPrinter(string szPrinterName, string szFileName)
    {
        bool bSuccess = false;

        // Open the file.
        FileStream fs = new FileStream(szFileName, FileMode.Open);
        try
        {
            // Create a BinaryReader on the file.
            BinaryReader br = new BinaryReader(fs, System.Text.Encoding.Default);

            // Dim an array of bytes big enough to hold the file's contents.
            Byte[] bytes = new Byte[fs.Length];

            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);

            int nLength;
            nLength = Convert.ToInt32(fs.Length);

            // Read the contents of the file into the array.
            bytes = br.ReadBytes(nLength);

            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);

            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);

            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);
            return bSuccess;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return bSuccess;
        }
        finally
        {
            if (fs != null)
            {
                fs.Close();
            }
        }
    }

   
        /// <summary>
        /// SendBytesToPrinter()
        /// </summary>
        /// <param name="szPrinterName"></param>
        /// <param name="pBytes"></param>
        /// <param name="dwCount"></param>
        /// <returns></returns>
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwWritten)
        {
            int num = 0;
            IntPtr hPrinter = new IntPtr(0);
            RawPrinterHelper.DOCINFOW dOCINFOA = new RawPrinterHelper.DOCINFOW();
            bool flag = false;
            dOCINFOA.pDocName = "document";
            dOCINFOA.pDataType = "RAW";
            bool flag2 = RawPrinterHelper.OpenPrinter(szPrinterName.Normalize(), ref hPrinter, IntPtr.Zero);
            if (flag2)
            {
                bool flag3 = RawPrinterHelper.StartDocPrinter(hPrinter, 1,ref dOCINFOA);
                if (flag3)
                {
                    bool flag4 = RawPrinterHelper.StartPagePrinter(hPrinter);
                    if (flag4)
                    {
                        flag = RawPrinterHelper.WritePrinter(hPrinter, pBytes, dwWritten,out num);
                        RawPrinterHelper.EndPagePrinter(hPrinter);
                    }
                    RawPrinterHelper.EndDocPrinter(hPrinter);
                }
                RawPrinterHelper.ClosePrinter(hPrinter);
            }
            bool flag5 = !flag;
            if (flag5)
            {
                int lastWin32Error = Marshal.GetLastWin32Error();
                throw new Exception("Print error:" + lastWin32Error);
            }
            return flag;
        }



    }

}

