using SharedObjects.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharedObjects
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static Mutex mutex = new Mutex(true, "{58eb9a00-f180-4f91-b330-7bdf123d30b4}");
        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                try
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Shared.Initialize();
                    Application.Run(Shared.form1);
                }
                catch
                { }
                finally
                { }
            }
            else
            {
                try
                {
                    SystemInfo systemInfo = new SystemInfo();
                    List<int> processIDToCall = systemInfo.ProcessID("SharedObjects");
                    if (processIDToCall.Count != 0)
                    {
                        DialogResult dialogResult = MessageBox.Show("App is already running!\nDo you want to shut down the application?", "Are you sure!", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            for (int i = 0; i < processIDToCall.Count; i++)
                            {
                                Process p1 = Process.GetProcessById(processIDToCall[i]);
                                p1.Kill();
                            }
                        }
                    }
                }
                catch
                { }
            }
        }
    }
}
