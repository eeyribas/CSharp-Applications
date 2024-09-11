using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReadFromSerialPortsWithThreads.Classes;

namespace ReadFromSerialPortsWithThreads
{
    public partial class Form1 : Form
    {
        static Barrier barrier = new Barrier(2);

        private Thread thread1;
        private Thread thread2;
        private bool threadState1 = true;
        private bool threadState2 = true;
        private string selectPortName1 = "";
        private string selectPortName2 = "";

        private string firstTimeValue1 = "";
        private string lastTimeValue1 = "";
        private string firstTimeValue2 = "";
        private string lastTimeValue2 = "";

        public Form1()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            groupBox2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            string[] serialPortNames = SerialPort.GetPortNames();
            foreach (string serialPortName in serialPortNames)
            {
                comboBox1.Items.Add(serialPortName);
                comboBox2.Items.Add(serialPortName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectPortName1 = comboBox1.Text;
            label3.Text = selectPortName1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectPortName2 = comboBox2.Text;
            label4.Text = selectPortName2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = selectPortName1;
            SerialPortFunctions.Open(serialPort1, selectPortName1);
            serialPort2.PortName = selectPortName2;
            SerialPortFunctions.Open(serialPort2, selectPortName2);

            if (!serialPort1.IsOpen || !serialPort2.IsOpen)
            {
                groupBox2.Enabled = false;
                label5.Text = "False";
                label5.ForeColor = Color.Red;
            }
            else
            {
                groupBox2.Enabled = true;
                label5.Text = "True";
                label5.ForeColor = Color.Green;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SerialPortFunctions.Close(serialPort1);
            SerialPortFunctions.Close(serialPort2);

            groupBox2.Enabled = false;
            label5.Text = "X";
            label5.ForeColor = Color.Black;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            int dataLenght = 300;
            int[] readData1 = new int[dataLenght];
            int[] readData2 = new int[dataLenght];

            threadState1 = true;
            threadState2 = true;
            if ((thread1 != null && thread1.IsAlive == true) || (thread2 != null && thread2.IsAlive == true))
                return;
            thread1 = new Thread(() => Process1(serialPort1, dataLenght, readData1));
            thread2 = new Thread(() => Process2(serialPort2, dataLenght, readData2));
            thread1.Start();
            thread2.Start();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            threadState1 = false;
            threadState2 = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SerialPortFunctions.Close(serialPort1);
            SerialPortFunctions.Close(serialPort2);

            Application.Exit();
        }

        private void Process1(SerialPort serialPort, int dataLenght, int[] readData)
        {
            while (true)
            {
                if (threadState1 == true)
                {
                    firstTimeValue1 = DateTime.Now.ToString("HH:mm:ss.fff");
                    SetLabel(label9, firstTimeValue1);

                    readData = SerialPortFunctions.ReadData(serialPort, "1", dataLenght);
                    for (int i = 0; i < dataLenght; i++)
                        SetListBox(listBox1, readData[i]);

                    lastTimeValue1 = DateTime.Now.ToString("HH:mm:ss.fff");
                    SetLabel(label12, lastTimeValue1);

                    barrier.SignalAndWait();
                }
                else
                {
                    break;
                }
            }
        }

        private void Process2(SerialPort serialPort, int dataLenght, int[] readData)
        {
            while (true)
            {
                if (threadState2 == true)
                {
                    firstTimeValue2 = DateTime.Now.ToString("HH:mm:ss.fff");
                    SetLabel(label11, firstTimeValue2);

                    readData = SerialPortFunctions.ReadData(serialPort, "1", dataLenght);
                    for (int i = 0; i < dataLenght; i++)
                        SetListBox(listBox2, readData[i]);

                    lastTimeValue2 = DateTime.Now.ToString("HH:mm:ss.fff");
                    SetLabel(label13, lastTimeValue2);

                    if (firstTimeValue1 == firstTimeValue2)
                    {
                        SetLabel(label16, "0");
                    }
                    else
                    {
                        SetLabel(label16, "1");
                        SetListBox(listBox3, 1);
                    }

                    if (lastTimeValue1 == lastTimeValue2)
                    {
                        SetLabel(label17, "0");
                    }
                    else
                    {
                        SetLabel(label17, "1");
                        SetListBox(listBox4, 1);
                    }

                    barrier.SignalAndWait();
                }
                else
                {
                    break;
                }
            }
        }

        delegate void SetListBoxCallback(ListBox lb, int value);
        private void SetListBox(ListBox lb, int value)
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

        private void _SetListBox(ListBox lb, int value)
        {
            try
            {
                lb.Items.Insert(0, value);
            }
            catch { }
        }

        delegate void SetLabelCallback(Label ab, string text);
        private void SetLabel(Label ab, string text)
        {
            try
            {
                if (ab.InvokeRequired)
                {
                    SetLabelCallback d = new SetLabelCallback(_SetLabel);
                    ab.Invoke(d, new object[] { ab, text });
                }
                else
                {
                    _SetLabel(ab, text);
                }
            }
            catch { }
        }

        private void _SetLabel(Label ab, string text)
        {
            try
            {
                ab.Text = text;
            }
            catch { }
        }
    }
}
