using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortComm
{
    public class SerialPortOperations
    {
        private SerialPort serialPort = new SerialPort();

        public void Setup(string portName, int baudRate)
        {
            if (serialPort.IsOpen)
                Close();

            serialPort.PortName = portName;
            serialPort.BaudRate = baudRate;
            serialPort.Parity = Parity.None;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            serialPort.Handshake = Handshake.None;
            serialPort.ReadTimeout = 5000;
            serialPort.WriteTimeout = 5000;
        }

        public bool Open(string portName, int baudRate)
        {
            Setup(portName, baudRate);

            serialPort.Open();
            if (serialPort.IsOpen)
                return true;

            return false;
        }

        public bool IsOpen()
        {
            return serialPort.IsOpen;
        }

        public void Close()
        {
            serialPort.Close();
        }

        public void Write(string sendData)
        {
            serialPort.Write(sendData);
        }

        public byte[] Read(int dataLength)
        {
            byte[] buffer = new byte[dataLength];
            int remainDataLength = dataLength;
            int receiveCount = 0;

            while (remainDataLength > 0)
            {
                int byteCount = serialPort.BytesToRead;
                byte[] tmpBuffer = new byte[byteCount];
                int n = serialPort.Read(tmpBuffer, 0, byteCount);
                if (n > 0)
                {
                    for (int i = 0; i < n; i++)
                    {
                        buffer[receiveCount] = tmpBuffer[i];
                        receiveCount++;
                    }
                    remainDataLength -= n;
                }
            }

            return buffer;
        }

        public byte[] Read(int dataLength, byte lastValue)
        {
            byte[] buffer = new byte[dataLength];
            int remainDataLength = dataLength;
            int receiveCount = 0;
            int n = 0;

            while (remainDataLength > 0)
            {
                n = serialPort.Read(buffer, receiveCount, remainDataLength);
                receiveCount += n;
                remainDataLength -= n;

                if (buffer[receiveCount - 1] == lastValue)
                    break;
            }

            return buffer;
        }
    }
}
