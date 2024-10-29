using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TCPCommDerivedFromComm.Common;
using TCPCommDerivedFromComm.DataPackets;

namespace TCPCommDerivedFromComm.Communications.TCP
{
    public class TCPOperations : Communication
    {
        private TCPReceiveData tcpReceiveData = new TCPReceiveData();
        private readonly TCPClient[] clients = new TCPClient[1];
        private Socket serverSock;
        private int clientNo = 0;

        public override void Setup()
        {
            try
            {
                for (int i = 0; i < clients.Length; i++)
                {
                    clients[i] = new TCPClient();
                }

                serverSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSock.Bind(new IPEndPoint(IPAddress.Any, Port));
                serverSock.Listen(10);
                serverSock.BeginAccept(new AsyncCallback(Accept), null);
            }
            catch (Exception ex)
            {
                Shared.form1.TCPNotConnected();
            }
        }

        private void Accept(IAsyncResult iar)
        {
            try
            {
                serverSock.BeginAccept(new AsyncCallback(Accept), null);

                TcpClient tmpClient = new TcpClient()
                {
                    Client = serverSock.EndAccept(iar)
                };
                IPEndPoint ipep = (IPEndPoint)tmpClient.Client.RemoteEndPoint;

                if (ipAddressList.Contains(ipep.Address.ToString()))
                {
                    clients[clientNo] = new TCPClient()
                    {
                        ClientNo = clientNo,
                        Sock = tmpClient.Client,

                        ReceiverCount = tcpReceiveData.ReceiveTCPDataLength,
                        ReceiverIndex = 0,
                    };

                    clients[clientNo].Sock.BeginReceive(clients[clientNo].ReceiverBuffer, clients[clientNo].ReceiverIndex, clients[clientNo].ReceiverCount, SocketFlags.None, new AsyncCallback(Receive), clients[clientNo]);
                }

                Shared.form1.TCPConnected();
            }
            catch (Exception ex)
            {
                Shared.form1.TCPNotConnected();
            }
        }

        private void Receive(IAsyncResult iar)
        {
            TCPClient tcpClient = (TCPClient)iar.AsyncState;

            try
            {
                int n = tcpClient.Sock.EndReceive(iar);
                tcpClient.ReceiverIndex += n;
                tcpClient.ReceiverCount -= n;

                if (tcpClient.ReceiverIndex == tcpReceiveData.ReceiveTCPDataLength) 
                {
                    Shared.form1.TCPReceiveData(tcpClient.ReceiverBuffer);

                    tcpClient.ReceiverIndex = 0;
                    tcpClient.ReceiverCount = tcpReceiveData.ReceiveTCPDataLength;
                }

                tcpClient.Sock.BeginReceive(tcpClient.ReceiverBuffer, tcpClient.ReceiverIndex, tcpClient.ReceiverCount, SocketFlags.None, new AsyncCallback(Receive), tcpClient);
            }
            catch (Exception ex)
            {
                clients[tcpClient.ClientNo].Sock.Dispose();
                lock (clients)
                {
                    clients[tcpClient.ClientNo] = null;
                }
                Shared.form1.TCPNotConnected();
            }
        }

        public override void Send(int machineNo, List<byte> sendData)
        {
            try
            {
                clients[machineNo].SenderCount = sendData.Count;
                clients[machineNo].SenderIndex = 0;
                clients[machineNo].SenderBuffer = new byte[sendData.Count];

                for (int i = 0; i < clients[machineNo].SenderBuffer.Length; i++)
                {
                    clients[machineNo].SenderBuffer[i] = sendData[i];
                }

                clients[machineNo].Sock.BeginSend(clients[machineNo].SenderBuffer, clients[machineNo].SenderIndex, clients[machineNo].SenderCount, SocketFlags.None, new AsyncCallback(SendAsync), clients[machineNo]);
            }
            catch (Exception ex)
            {
                clients[machineNo].Sock.Dispose();
                lock (clients)
                {
                    clients[machineNo] = null;
                }
                Shared.form1.TCPNotConnected();
            }
        }

        private void SendAsync(IAsyncResult iar)
        {
            TCPClient tcpClient = (TCPClient)iar.AsyncState;

            try
            {
                int n = tcpClient.Sock.EndSend(iar);
                tcpClient.SenderIndex += n;
                tcpClient.SenderCount -= n;

                if (tcpClient.SenderCount != 0)
                {
                    tcpClient.Sock.BeginSend(tcpClient.SenderBuffer, tcpClient.SenderIndex, tcpClient.SenderCount, SocketFlags.None, new AsyncCallback(SendAsync), tcpClient);
                }
            }
            catch (Exception ex)
            {
                clients[tcpClient.ClientNo].Sock.Dispose();
                lock (clients)
                {
                    clients[tcpClient.ClientNo] = null;
                }
                Shared.form1.TCPNotConnected();
            }
        }

        public override void Close()
        {
            try
            {
                lock (clients)
                {
                    clients[0] = null;
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
