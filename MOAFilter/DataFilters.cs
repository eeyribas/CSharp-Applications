using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOAFilter
{
    public enum DataFilterType
    {
        Normal = 0,
        MOA = 1
    }

    public class DataFilters
    {
        public List<double> Selection(List<double> mainData, int filterType)
        {
            List<double> filterData = new List<double>();

            if (filterType == (int)DataFilterType.Normal)
                filterData = Normal(mainData);
            else if (filterType == (int)DataFilterType.MOA)
                filterData = MOA(mainData);

            return filterData;
        }

        private List<double> Normal(List<double> mainData)
        {
            List<double> filterData = new List<double>();
            for (int i = 0; i < mainData.Count; i++)
                filterData.Add(mainData[i]);

            return filterData;
        }

        private List<double> MOA(List<double> mainData)
        {
            List<double> filterData = new List<double>
            {
                mainData[0],
                mainData[1],
                mainData[2],
                mainData[3]
            };
            // MOA Factor Count = 4
            for (int i = 4; i < mainData.Count; i++)
                filterData.Add((mainData[i - 4] + mainData[i - 3] + mainData[i - 2] + mainData[i - 1] + mainData[i]) / 5);

            return filterData;
        }
    }
}
