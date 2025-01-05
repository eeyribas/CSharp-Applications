using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataLogger.Classes
{
    public enum DataLogType
    {
        Info = 0,
        Exception = 1
    }

    public class DataLogPacket
    {
        public string log;
    }

    public class DataLog : DataPaths
    {
        private Thread thread;
        private bool State { get; set; }

        private ConcurrentQueue<KeyValuePair<int, DataLogPacket>> dataLogQueue = new ConcurrentQueue<KeyValuePair<int, DataLogPacket>>();

        public DataLog()
        {
            Clear();
        }

        private void Clear()
        {
            State = false;
            while (dataLogQueue.TryDequeue(out KeyValuePair<int, DataLogPacket> item))
            { }
        }

        public void AddLog(int logType, string tmpLog)
        {
            DataLogPacket dataLogPacket = new DataLogPacket
            {
                log = tmpLog
            };

            dataLogQueue.Enqueue(new KeyValuePair<int, DataLogPacket>(logType, dataLogPacket));
        }

        public void Start()
        {
            State = true;

            if (thread != null && thread.IsAlive)
                return;
            thread = new Thread(() => ThreadProcess());
            thread.Start();
        }

        public void Stop()
        {
            State = false;
        }

        private void ThreadProcess()
        {
            while (true)
            {
                if (State)
                {
                    if (dataLogQueue.Count > 0)
                    {
                        for (int i = 0; i < dataLogQueue.Count; i++)
                        {
                            KeyValuePair<int, DataLogPacket> dataLogQ = new KeyValuePair<int, DataLogPacket>();
                            dataLogQueue.TryDequeue(out dataLogQ);

                            if (dataLogQ.Key == (int)DataLogType.Info)
                                fileOperations.WriteWithDateInfo(infoFileTextName, dataLogQ.Value.log);
                            else if (dataLogQ.Key == (int)DataLogType.Exception)
                                fileOperations.WriteWithDateInfo(exceptionFileTextName, dataLogQ.Value.log);
                        }
                    }
                }
                else
                {
                    break;
                }

                Thread.Sleep(5);
            }
        }
    }
}
