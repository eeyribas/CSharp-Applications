using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPacketsWithInheritance.DataPackets.SendDataPackets
{
    public class BaseSendData : ISendData
    {
        DerivedSendData derivedSendData = new DerivedSendData();

        public int Value(int value)
        {
            return derivedSendData.Value(value);
        }

        public bool Value1 { get; set; }
        public int Value2 { get; set; }

        public int ReturnValue()
        {
            if (Value1)
                return Value(Value2);
            else
                return 0;
        }
    }
}
