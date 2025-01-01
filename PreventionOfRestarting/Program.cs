using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreventionOfRestarting
{
    static class Program
    {
        static Mutex mutex = new Mutex(true, "{4eeb8a02-f180-4f91-b330-7bdf123d30b3}");

        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Shared.Initialize();
                Application.Run(Shared.form1);
            }
            else
            {
                List<int> processIdList = getProcessID("Application");
                if (processIdList.Count != 0)
                {
                    DialogResult dialogResult = MessageBox.Show("App is already running!\nDo you want to shut down the application?", 
                                                "Are you sure!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        for (int i = 0; i < processIdList.Count; i++)
                        {
                            Process process = Process.GetProcessById(processIdList[i]);
                            process.Kill();
                        }
                    }
                }
            }
        }

        static List<int> getProcessID(string appName)
        {
            List<int> processList = new List<int>();
            Process[] processArray = Process.GetProcesses();
            foreach (Process process in processArray)
            {
                if (process.ProcessName.StartsWith(appName))
                    processList.Add(process.Id);
            }

            return processList;
        }
    }
}
