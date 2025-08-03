using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadedSerialPortMonitor.Classes
{
    class SerialPortFunctions
    {
        public static void Open(SerialPort serialPort, string selectPortName)
        {
            serialPort.PortName = selectPortName;
            serialPort.BaudRate = 9600;
            serialPort.Parity = Parity.None;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            serialPort.Handshake = Handshake.None;

            serialPort.Open();
        }

        public static void Close(SerialPort serialPort)
        {
            serialPort.Close();
        }

        public static int[] ReadData(SerialPort serialPort, string sendData, int dataLenght)
        {
            int[] readDataArray = new int[dataLenght];

            serialPort.Write(sendData);
            for (int i = 0; i < dataLenght; i++)
            {
                string readDataString = serialPort.ReadLine();
                readDataArray[i] = Convert.ToInt32(readDataString);
            }

            return readDataArray;
        }
    }
}
