using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPacketsWithInheritance.DataPackets.ReceiveDataPackets
{
    public class BaseReceiveData
    {
        public int value1 = 0;
        public double value2 = 0;
        public double value3 = 0;

        public BaseReceiveData()
        {
            value1 = 5;
            value2 = 6.1;
            value3 = 3.6;
        }
    }
}
