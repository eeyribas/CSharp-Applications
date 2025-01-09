using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentQueue
{
    public class Data
    {
        public int value1;
        public double value2;
        public bool state;

        public Data()
        {
            value1 = 0;
            value2 = 0;
            state = false;
        }
    }

    public class ConcurrentQueueClass
    {
        private ConcurrentQueue<Data> concurrentQueues = new ConcurrentQueue<Data>();

        public ConcurrentQueueClass()
        {
            Clear();
        }

        public void AddData(Data data)
        {
            concurrentQueues.Enqueue(data);
        }

        public Data GetData()
        {
            Data data = new Data();
            if (concurrentQueues.Count > 0)
            {
                concurrentQueues.TryDequeue(out data);
                data.state = true;
                return data;
            }

            data.state = false;

            return data;
        }

        public void Clear()
        {
            while (concurrentQueues.TryDequeue(out Data item))
            { }
        }
    }
}
