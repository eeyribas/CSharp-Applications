using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPCommDerivedFromComm.Common;

namespace TCPCommDerivedFromComm.DataPackets
{
    public class TCPSendData
    {
        public void TCPSend(int clientIndex, List<byte> communicationData)
        {
            try
            {
                List<byte> sendData = new List<byte>();
                for (int i = 0; i < communicationData.Count; i++)
                    sendData.Add(communicationData[i]);

                Shared.communication.Send(clientIndex, sendData);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
