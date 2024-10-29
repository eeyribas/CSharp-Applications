using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPacketsWithInheritance.DataPackets.SendDataPackets
{
    public class DerivedSendData : ISendData
    {
        private readonly int SpecValue = 6;

        public int Value(int value)
        {
            return value * SpecValue;
        }
    }
}
