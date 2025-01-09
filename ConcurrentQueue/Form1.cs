using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConcurrentQueue
{
    public partial class Form1 : Form
    {
        private ConcurrentQueueClass concurrentQueueClass = new ConcurrentQueueClass();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Data data = new Data();
            data.value1 = Convert.ToInt32(textBox1.Text);
            data.value2 = Convert.ToDouble(textBox2.Text);
            concurrentQueueClass.AddData(data);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Data data = concurrentQueueClass.GetData();
            if (data.state)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add(data.value1.ToString());
                listBox1.Items.Add(data.value2.ToString());
            }
        }
    }
}
