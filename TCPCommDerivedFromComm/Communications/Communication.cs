using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPCommDerivedFromComm.Communications
{
    public class Communication
    {
        public List<string> ipAddressList = new List<string>();
        public int Port { get; set; }

        public Communication()
        {
            try
            {
                ipAddressList.Clear();
                Port = 65432;
            }
            catch (Exception ex)
            {
            }
        }

        public virtual void Setup() { }
        public virtual void Send(int clientNo, List<byte> sendData) { }
        public virtual void Close() { }
    }
}
