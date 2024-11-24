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

namespace DelegatedMethods
{
    public partial class Form1 : Form
    {
        private Thread thread;
        private bool threadState = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            threadState = true;
            if (thread != null && thread.IsAlive == true)
                return;
            thread = new Thread(() => ThreadFunction());
            thread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            threadState = false;
        }

        private void ThreadFunction()
        {
            int value = 0;
            while (true)
            {
                if (threadState == true)
                {
                    DelegatedMethods.SetLabelText(label1, "Value : " + value.ToString());
                    value++;
                    Thread.Sleep(1000);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
