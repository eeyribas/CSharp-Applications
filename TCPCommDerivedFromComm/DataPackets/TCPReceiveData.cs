using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPCommDerivedFromComm.DataPackets
{
    public class TCPReceiveData
    {
        public int Value1;
        public double Value2;
        public double Value3;

        public int ReceiveTCPDataLength = 7;

        public TCPReceiveData()
        {

        }

        public TCPReceiveData(byte[] receiveData)
        {
            Value1 = Convert.ToInt32(receiveData[0]);
            Value2 = Convert.ToDouble((receiveData[1] * 100) + receiveData[2] + (receiveData[3] / 100));
            Value3 = Convert.ToDouble((receiveData[4] * 100) + receiveData[5] + (receiveData[6] / 100));
        }
    }
}
