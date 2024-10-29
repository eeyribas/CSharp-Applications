using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPCommDerivedFromComm.DataPackets;

namespace TCPCommDerivedFromComm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<byte> sendData = new List<byte>();
            sendData.Add(5);
            sendData.Add(8);

            TCPSendData tcpSendData = new TCPSendData();
            tcpSendData.TCPSend(0, sendData);
        }
        
        public void TCPConnected()
        {
            TextLabel(label2, "Connect");
        }

        public void TCPNotConnected()
        {
            TextLabel(label2, "Disconnect");
        }

        public void TCPReceiveData(byte[] receiveData)
        {
            TextLabel(label3, Encoding.ASCII.GetString(receiveData));
        }

        delegate void TextLabelCallback(Label lb, string text);
        public static void TextLabel(Label lb, string text)
        {
            try
            {
                if (lb.InvokeRequired)
                {
                    TextLabelCallback d = new TextLabelCallback(_TextLabel);
                    lb.Invoke(d, new object[] { lb, text });
                }
                else
                {
                    _TextLabel(lb, text);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private static void _TextLabel(Label lb, string text)
        {
            try
            {
                lb.Text = text;
            }
            catch (Exception ex)
            {
            }
        }
    }
}
