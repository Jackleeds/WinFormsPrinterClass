using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsPrinterClass.DLL
{
    //定义触发单击事件的委托
    public delegate void datagridviewcheckboxHeaderEventHander(object sender, datagridviewCheckboxHeaderEventArgs e);
    public class datagridviewCheckboxHeaderEventArgs: EventArgs
    {
        private bool checkedState = false;

        public bool CheckedState
        {
            get { return checkedState; }
            set { checkedState = value; }
        }
    }
}
