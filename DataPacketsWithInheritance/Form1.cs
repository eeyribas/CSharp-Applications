using DataPacketsWithInheritance.DataPackets.ReceiveDataPackets;
using DataPacketsWithInheritance.DataPackets.SendDataPackets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataPacketsWithInheritance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] receiveData = new byte[5];
            receiveData[0] = 4;
            receiveData[1] = 8;
            receiveData[2] = 16;
            receiveData[3] = 9;
            receiveData[4] = 6;

            DerivedReceiveData derivedReceiveData = new DerivedReceiveData(receiveData);
            label1.Text = "Value-1 : " + derivedReceiveData.value1.ToString() +
                          "     Value-2 : " + derivedReceiveData.value2.ToString() +
                          "     Value-3 : " + derivedReceiveData.value3.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BaseSendData baseSendData = new BaseSendData();
            baseSendData.Value1 = true;
            baseSendData.Value2 = 10;
            label2.Text = "Value : " + baseSendData.ReturnValue().ToString();
        }
    }
}
