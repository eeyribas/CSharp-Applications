using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPacketsWithInheritance.DataPackets.ReceiveDataPackets
{
    public class DerivedReceiveData : BaseReceiveData
    {
        public DerivedReceiveData()
        {

        }

        public DerivedReceiveData(byte[] receiveData)
        {
            value1 = Convert.ToInt32(receiveData[0]);
            value2 = ValueCalc(receiveData, 1);
            value3 = ValueCalc(receiveData, 3);
        }

        private double ValueCalc(byte[] receiverData, int firstByte)
        {
            double value = (Convert.ToDouble(receiverData[firstByte]) * 0.205) + 
                           (Convert.ToDouble(receiverData[firstByte + 1]) / 200);

            return value;
        }
    }
}
