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

namespace ThreadUsage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetListBox(listBox1, "Test Message - No thread");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread thread = new Thread(() => SetListBox(listBox1, "Test Message - Thread: " + i.ToString()));
                thread.Start();
            }
        }

        delegate void SetListBoxCallback(ListBox lb, string value);
        private void SetListBox(ListBox lb, string value)
        {
            try
            {
                if (lb.InvokeRequired)
                {
                    SetListBoxCallback d = new SetListBoxCallback(_SetListBox);
                    lb.Invoke(d, new object[] { lb, value });
                }
                else
                {
                    _SetListBox(lb, value);
                }
            }
            catch { }
        }

        private void _SetListBox(ListBox lb, string value)
        {
            try
            {
                lb.Items.Insert(0, value);
            }
            catch { }
        }
    }
}
