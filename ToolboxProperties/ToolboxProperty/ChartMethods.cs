using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace ToolboxProperties.ToolboxProperty
{
    public class ChartMethods
    {
        private readonly int YAxisIntFactor = 4;

        public KeyValuePair<int, int> SelectionRange(double startX, double endX, List<double> xList)
        {
            KeyValuePair<int, int> selectionRange = new KeyValuePair<int, int>();

            if (startX > endX)
            {
                double tmp = endX;
                endX = startX;
                startX = tmp;
            }

            if ((endX - startX) > 0)
                selectionRange = new KeyValuePair<int, int>(Selection(startX, xList), Selection(endX, xList));
            else
                selectionRange = new KeyValuePair<int, int>(0, xList.Count - 1);

            return selectionRange;
        }

        private int Selection(double x, List<double> xList)
        {
            int xCount = 0;
            double changeValue = Math.Abs(x - xList[0]);
            for (int i = 0; i < xList.Count; i++)
            {
                double value = Math.Abs(x - xList[i]);
                if (value < changeValue)
                {
                    changeValue = value;
                    xCount = i;
                }
            }

            return xCount;
        }

        public void AddPoint(Chart chart, int series, double yMax, double yMin, double yValue, double xValue)
        {
            DelegatedMethods.AxisYMaximumChart(chart, Math.Round(yMax, 2));
            DelegatedMethods.AxisYMinimumChart(chart, Math.Round(yMin, 2));
            DelegatedMethods.AxisYIntervalChart(chart, (Math.Round(yMax, 2) - Math.Round(yMin, 2)) / YAxisIntFactor);

            DelegatedMethods.AddXYChart(chart, series, xValue, yValue);
        }
    }
}
