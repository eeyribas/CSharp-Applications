using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPSocket
{
    public partial class Form1 : Form
    {
        private int portNo = 10050;
        private int dataCount = 3;
        private bool threadState = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TCPSocketDLL.TCPComm.Setup(portNo);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextLabel(label1, "Connection State : " + TCPSocketDLL.TCPComm.ConnectStatus);
            threadState = true;
            Thread thread = new Thread(() => ThreadProcess());
            thread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            threadState = false;
        }

        public void ThreadProcess()
        {
            while (true)
            {
                if (threadState == true)
                {
                    if (TCPSocketDLL.TCPComm.Count() >= dataCount)
                    {
                        AddListBox(listBox1, TCPSocketDLL.TCPComm.GetQueue().ToString());
                        AddListBox(listBox1, TCPSocketDLL.TCPComm.GetQueue().ToString());
                        AddListBox(listBox1, TCPSocketDLL.TCPComm.GetQueue().ToString());
                        AddListBox(listBox1, "--------");
                    }
                    Thread.Sleep(100);
                }
                else
                {
                    break;
                }
            }
        }

        delegate void TextLabelCallback(Label lb, string text);
        private void TextLabel(Label lb, string text)
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

        private void _TextLabel(Label lb, string text)
        {
            lb.Text = text;
        }

        delegate void AddListBoxCallback(ListBox lb, string text);
        private void AddListBox(ListBox lb, string text)
        {
            if (lb.InvokeRequired)
            {
                AddListBoxCallback d = new AddListBoxCallback(_AddListBox);
                lb.Invoke(d, new object[] { lb, text });
            }
            else
            {
                _AddListBox(lb, text);
            }
        }

        private void _AddListBox(ListBox lb, string text)
        {
            lb.Items.Add(text);
        }
    }
}
