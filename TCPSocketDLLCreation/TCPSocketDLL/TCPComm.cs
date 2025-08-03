using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPSocketDLL
{
    public class TCPComm
    {
        private static TCPClientInfo[] tcpClientInfos = new TCPClientInfo[2];
        private static Socket serverSock;
        private static int port;
        private static int clientNo = 0;

        public static string ConnectStatus { get; set; }
        public static ConcurrentQueue<int> queue = new ConcurrentQueue<int>();

        public static void Setup(int portNo)
        {
            port = portNo;
            for (int clientIndex = 0; clientIndex < tcpClientInfos.Length; clientIndex++)
                tcpClientInfos[clientIndex] = new TCPClientInfo();

            serverSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSock.Bind(new IPEndPoint(IPAddress.Any, port));
            serverSock.Listen(10);

            serverSock.BeginAccept(new AsyncCallback(Accept), null);
        }

        private static void Accept(IAsyncResult iar)
        {
            serverSock.BeginAccept(new AsyncCallback(Accept), null);

            TcpClient tcpClient = new TcpClient();
            tcpClient.Client = serverSock.EndAccept(iar);
            IPEndPoint ipep = (IPEndPoint)tcpClient.Client.RemoteEndPoint;
            IPAddress ipa = ipep.Address;
            string ipAddress = ipa.ToString();

            if (ipAddress.StartsWith("10.0.0."))
            {
                tcpClientInfos[clientNo] = new TCPClientInfo();
                tcpClientInfos[clientNo].ClientNo = clientNo;
                tcpClientInfos[clientNo].Sock = tcpClient.Client;
                tcpClientInfos[clientNo].LeftReceiver = 6;
                tcpClientInfos[clientNo].IndexReceiver = 0;

                tcpClientInfos[clientNo].Sock.BeginReceive(tcpClientInfos[clientNo].BufferReceiver, tcpClientInfos[clientNo].IndexReceiver, tcpClientInfos[clientNo].LeftReceiver, 
                                                           SocketFlags.None, new AsyncCallback(Receive), tcpClientInfos[clientNo]);
                clientNo++;

                ConnectStatus = "Connected";
            }
        }

        private static void Receive(IAsyncResult iar)
        {
            TCPClientInfo tcpClientInfo = (TCPClientInfo)iar.AsyncState;
            int n = 0;

            try
            {
                n = tcpClientInfo.Sock.EndReceive(iar);
                tcpClientInfo.IndexReceiver += n;
                tcpClientInfo.LeftReceiver -= n;

                if (tcpClientInfo.LeftReceiver == 0)
                {
                    int value1 = Convert.ToInt32(((tcpClientInfo.BufferReceiver[0] << 24) | (tcpClientInfo.BufferReceiver[1] << 16) | 
                                                 (tcpClientInfo.BufferReceiver[2] << 8) | (tcpClientInfo.BufferReceiver[3])));
                    int value2 = Convert.ToInt32(tcpClientInfo.BufferReceiver[4].ToString());
                    int value3 = Convert.ToInt32(tcpClientInfo.BufferReceiver[5].ToString());

                    queue.Enqueue(value1);
                    queue.Enqueue(value2);
                    queue.Enqueue(value3);

                    tcpClientInfo.IndexReceiver = 0;
                    tcpClientInfo.LeftReceiver = 6;
                }

                tcpClientInfo.Sock.BeginReceive(tcpClientInfo.BufferReceiver, tcpClientInfo.IndexReceiver, tcpClientInfo.LeftReceiver, 
                                                SocketFlags.None, new AsyncCallback(Receive), tcpClientInfo);
            }
            catch (Exception)
            {
                tcpClientInfo.Sock.Dispose();
                lock (tcpClientInfos)
                    tcpClientInfos[tcpClientInfo.ClientNo] = null;
            }
        }

        public static void Clear()
        {
            while (queue.TryDequeue(out int item))
            { }
        }

        public static int Count()
        {
            return Convert.ToInt32(queue.Count);
        }

        public static int GetQueue()
        {
            int value = 0;
            queue.TryDequeue(out value);

            return value;
        }
    }
}
