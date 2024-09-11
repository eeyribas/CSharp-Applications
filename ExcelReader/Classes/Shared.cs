using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelReader.Classes
{
    public class Shared
    {
        public static KeyValuePair<Process, int> processInfo = new KeyValuePair<Process, int>();

        public static void Initialize()
        {
            List<int> processIDs = ProcessID(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            if (processIDs.Count > 0)
            {
                Process process = Process.GetProcessById(processIDs[0]);
                processInfo = new KeyValuePair<Process, int>(process, processIDs[0]);
            }
        }

        public static List<int> ProcessID(string appName)
        {
            List<int> processes = new List<int>();
            Process[] processList = Process.GetProcesses();
            foreach (Process process in processList)
            {
                if (process.ProcessName.StartsWith(appName))
                    processes.Add(process.Id);
            }

            return processes;
        }
    }
}
