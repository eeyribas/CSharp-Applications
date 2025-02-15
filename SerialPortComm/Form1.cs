using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialPortComm
{
    public partial class Form1 : Form
    {
        private SerialPortOperations serialPortOperations = new SerialPortOperations();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPortOperations.Setup(textBox1.Text, Convert.ToInt32(textBox2.Text));
            if (!serialPortOperations.IsOpen())
                serialPortOperations.Open(textBox1.Text, Convert.ToInt32(textBox2.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPortOperations.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialPortOperations.Write(textBox3.Text);
            byte[] readData = serialPortOperations.Read(100);
            for (int i = 0; i < readData.Length; i++)
                listBox1.Items.Add(readData[i].ToString());
        }
    }
}
