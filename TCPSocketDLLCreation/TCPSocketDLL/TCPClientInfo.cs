using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPSocketDLL
{
    public class TCPClientInfo
    {
        private Socket sock;

        private byte[] bufferReceiver, bufferSend;
        private int indexReceiver, indexSend;
        private int leftReceiver, leftSend;
        private int clientNo;

        public TCPClientInfo()
        {
            bufferReceiver = new byte[6];
        }

        public Socket Sock
        {
            get
            {
                return sock;
            }
            set
            {
                sock = value;
            }
        }

        public byte[] BufferReceiver
        {
            get
            {
                return bufferReceiver;
            }
            set
            {
                bufferReceiver = value;
            }
        }

        public byte[] BufferSend
        {
            get
            {
                return bufferSend;
            }
            set
            {
                bufferSend = value;
            }
        }

        public int IndexReceiver
        {
            get
            {
                return indexReceiver;
            }
            set
            {
                indexReceiver = value;
            }
        }

        public int IndexSend
        {
            get
            {
                return indexSend;
            }
            set
            {
                indexSend = value;
            }
        }

        public int LeftReceiver
        {
            get
            {
                return leftReceiver;
            }
            set
            {
                leftReceiver = value;
            }
        }

        public int LeftSend
        {
            get
            {
                return leftSend;
            }
            set
            {
                leftSend = value;
            }
        }

        public int ClientNo
        {
            get
            {
                return clientNo;
            }
            set
            {
                clientNo = value;
            }
        }
    }
}
