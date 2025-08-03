using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace SystemInformation
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

        public double DriveUsagePercent(string driveName)
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.Name == driveName)
                {
                    double usage = 100 - (100.0 * drive.AvailableFreeSpace / drive.TotalSize);
                    
                    return usage;
                }
            }

            return -1;
        }

        public double RamUsage()
        {
            double usedRatio = -1;
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();
            foreach (ManagementObject result in results)
            {
                double totalMemory = Convert.ToDouble(result["TotalVisibleMemorySize"]);
                double freeMemory = Convert.ToDouble(result["FreePhysicalMemory"]);
                usedRatio = ((totalMemory - freeMemory) / totalMemory) * 100;
            }

            return usedRatio;
        }
    }
}
