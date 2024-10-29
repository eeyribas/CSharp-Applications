using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPCommDerivedFromComm.Communications;
using TCPCommDerivedFromComm.Communications.TCP;
using TCPCommDerivedFromComm.General;

namespace TCPCommDerivedFromComm.Common
{
    public class Shared
    {
        public static KeyValuePair<Process, int> processInfo = new KeyValuePair<Process, int>();

        public static Form1 form1 = null;
        public static Communication communication = null;

        public static void Initialize()
        {
            try
            {
                SystemInfo systemInfo = new SystemInfo();
                List<int> processIDs = systemInfo.ProcessID(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
                if (processIDs.Count > 0)
                {
                    Process process = Process.GetProcessById(processIDs[0]);
                    processInfo = new KeyValuePair<Process, int>(process, processIDs[0]);
                }

                form1 = new Form1();

                communication = new TCPOperations();
                communication.ipAddressList.Add("10.0.0.24");
                communication.Port = 65432;
                communication.Setup();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
