using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.Classes
{
    public class Shared
    {
        public static KeyValuePair<Process, int> processInfo = new KeyValuePair<Process, int>();

        public static Form1 form1 = null;

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
            }
            catch (Exception ex)
            {
            }
        }
    }
}
