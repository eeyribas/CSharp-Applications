using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.Classes
{
    public class SystemInfo
    {
        public List<int> ProcessID(string appName)
        {
            List<int> processes = new List<int>();
            Process[] processlist = Process.GetProcesses();
            foreach (Process pr in processlist)
            {
                if (pr.ProcessName.StartsWith(appName))
                    processes.Add(pr.Id);
            }

            return processes;
        }
    }
}
