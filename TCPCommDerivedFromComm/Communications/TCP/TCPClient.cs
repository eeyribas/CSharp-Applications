using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TCPCommDerivedFromComm.DataPackets;

namespace TCPCommDerivedFromComm.Communications.TCP
{
    public class TCPClient
    {
        public Socket Sock { get; set; }
        public byte[] ReceiverBuffer { get; set; }
        public byte[] SenderBuffer { get; set; }
        public int ReceiverIndex { get; set; }
        public int SenderIndex { get; set; }
        public int ReceiverCount { get; set; }
        public int SenderCount { get; set; }
        public int ClientNo { get; set; }

        public TCPClient()
        {
            try
            {
                TCPReceiveData tcpReceiveData = new TCPReceiveData();

                ReceiverBuffer = new byte[tcpReceiveData.ReceiveTCPDataLength];
                for (int i = 0; i < ReceiverBuffer.Length; i++)
                {
                    ReceiverBuffer[i] = 0;
                }

                ReceiverIndex = 0;
                ReceiverCount = tcpReceiveData.ReceiveTCPDataLength;
            }
            catch (Exception ex)
            {
            }
        }
    }
}
