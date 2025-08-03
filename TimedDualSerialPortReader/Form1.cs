using TimedDualSerialPortReader.Classes;
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

namespace TimedDualSerialPortReader
{
    public partial class Form1 : Form
    {
        private Thread thread1;
        private Thread thread2;
        private bool threadState1 = true;
        private bool threadState2 = true;
        private string selectPortName1 = "";
        private string selectPortName2 = "";

        private int hour1 = 0;
        private int minute1 = 0;
        private int second1 = 0;
        private int millisecond1 = 0;
        private int hour2 = 0;
        private int minute2 = 0;
        private int second2 = 0;
        private int millisecond2 = 0;

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
            listBox3.Items.Clear();
            listBox4.Items.Clear();

            int dataLenght = 300;
            int[] readData1 = new int[dataLenght];
            int[] readData2 = new int[dataLenght];

            threadState1 = true;
            if (thread1 != null && thread1.IsAlive == true)
                return;
            thread1 = new Thread(() => Process1(serialPort1, dataLenght, readData1));
            thread1.Start();

            threadState2 = true;
            if (thread2 != null && thread2.IsAlive == true)
                return;
            thread2 = new Thread(() => Process2(serialPort2, dataLenght, readData2));
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
                    hour1 = DateTime.Now.Hour;
                    minute1 = DateTime.Now.Minute;
                    second1 = DateTime.Now.Second;
                    millisecond1 = DateTime.Now.Millisecond;

                    string firstTimeValue = DateTime.Now.ToString("hh.mm.ss.fff");
                    SetLabel(label9, firstTimeValue);

                    readData = SerialPortFunctions.ReadData(serialPort, "1", dataLenght);
                    for (int i = 0; i < dataLenght; i++)
                        SetIntListBox(listBox1, readData[i]);

                    hour2 = DateTime.Now.Hour;
                    minute2 = DateTime.Now.Minute;
                    second2 = DateTime.Now.Second;
                    millisecond2 = DateTime.Now.Millisecond;

                    string lastTimeValue = DateTime.Now.ToString("hh.mm.ss.fff");
                    SetLabel(label12, lastTimeValue);
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
                    int tmpHour1 = DateTime.Now.Hour;
                    int tmpMinute1 = DateTime.Now.Minute;
                    int tmpSecond1 = DateTime.Now.Second;
                    int tmpMillisecond1 = DateTime.Now.Millisecond;

                    string firstTimeValue = DateTime.Now.ToString("hh.mm.ss.fff");
                    SetLabel(label11, firstTimeValue);

                    readData = SerialPortFunctions.ReadData(serialPort, "1", dataLenght);
                    for (int i = 0; i < dataLenght; i++)
                        SetIntListBox(listBox2, readData[i]);

                    int tmpHour2 = DateTime.Now.Hour;
                    int tmpMinute2 = DateTime.Now.Minute;
                    int tmpSecond2 = DateTime.Now.Second;
                    int tmpMillisecond2 = DateTime.Now.Millisecond;

                    string lastTimeValue = DateTime.Now.ToString("hh.mm.ss.fff");
                    SetLabel(label13, lastTimeValue);

                    int tmpHour3 = tmpHour1 - hour1;
                    int tmpMinute3 = tmpMinute1 - minute1;
                    int tmpSecond3 = tmpSecond1 - second1;
                    int tmpMillisecond3 = tmpMillisecond1 - millisecond1;
                    int result1 = (60 * 60 * 1000 * tmpHour3) + (60 * 1000 * tmpMinute3) + (1000 * tmpSecond3) + tmpMillisecond3;

                    int tmpHour4 = tmpHour2 - hour2;
                    int tmpMinute4 = tmpMinute2 - minute2;
                    int tmpSecond4 = tmpSecond2 - second2;
                    int tmpMillisecond4 = tmpMillisecond2 - millisecond2;
                    int result2 = (60 * 60 * 1000 * tmpHour4) + (60 * 1000 * tmpMinute4) + (1000 * tmpSecond4) + tmpMillisecond4;

                    SetIntListBox(listBox3, result1);
                    SetIntListBox(listBox4, result2);
                }
                else
                {
                    break;
                }
            }
        }

        delegate void SetIntListBoxCallback(ListBox lb, int value);
        private void SetIntListBox(ListBox lb, int value)
        {
            if (lb.InvokeRequired)
            {
                SetIntListBoxCallback d = new SetIntListBoxCallback(_InsertSetIntListBox);
                lb.Invoke(d, new object[] { lb, value });
            }
            else
            {
                _InsertSetIntListBox(lb, value);
            }
        }

        private void _InsertSetIntListBox(ListBox lb, int value)
        {
            lb.Items.Insert(0, value);
        }

        delegate void SetLabelCallback(Label lb, string text);
        private void SetLabel(Label lb, string text)
        {
            if (lb.InvokeRequired)
            {
                SetLabelCallback d = new SetLabelCallback(_InsertSetLabel);
                lb.Invoke(d, new object[] { lb, text });
            }
            else
            {
                _InsertSetLabel(lb, text);
            }
        }

        private void _InsertSetLabel(Label lb, string text)
        {
            lb.Text = text;
        }
    }
}
