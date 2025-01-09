using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ChartSelectionRange
{
    public partial class Form1 : Form
    {
        private KeyValuePair<int, int> selectionRange = new KeyValuePair<int, int>();
        private List<int> yList = new List<int>();
        private List<int> xList = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                yList.Add(random.Next(0, 100));
                xList.Add(i);
            }

            chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].CursorX.SelectionColor = Color.LightSteelBlue;
            chart1.ChartAreas[0].CursorX.LineDashStyle = ChartDashStyle.Dash;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = false;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = false;
            chart1.ChartAreas[0].Position.Auto = false;
            chart1.ChartAreas[0].Position.Height = 100F;
            chart1.ChartAreas[0].Position.Width = 100F;

            DrawChart(chart1, yList, xList, 0, xList.Count); 
        }

        private void chart1_SelectionRangeChanged(object sender, CursorEventArgs e)
        {
            selectionRange = SelectionRange(chart1.ChartAreas[0].CursorX.SelectionStart, chart1.ChartAreas[0].CursorX.SelectionEnd, xList);
            DrawChart(chart1, yList, xList, selectionRange.Key, selectionRange.Value);
        }

        private void chart1_DoubleClick(object sender, EventArgs e)
        {
            DrawChart(chart1, yList, xList, 0, xList.Count);
        }

        private void DrawChart(Chart chart, List<int> yData, List<int> xData, int startIndex, int endIndex)
        {
            chart1.Series[0].Points.Clear();
            for (int i = startIndex; i < endIndex; i++)
                chart1.Series[0].Points.AddXY(xData[i], yData[i]);
        }

        private KeyValuePair<int, int> SelectionRange(double startX, double endX, List<int> xData)
        {
            KeyValuePair<int, int> selectionRange = new KeyValuePair<int, int>();

            if (startX > endX)
            {
                double tmp = endX;
                endX = startX;
                startX = tmp;
            }

            if ((endX - startX) > 0)
                selectionRange = new KeyValuePair<int, int>(Selection(startX, xData), Selection(endX, xData));
            else
                selectionRange = new KeyValuePair<int, int>(0, xData.Count - 1);

            return selectionRange;
        }

        private int Selection(double x, List<int> xData)
        {
            int xCount = 0;
            double changeValue = Math.Abs(x - xData[0]);
            for (int i = 0; i < xData.Count; i++)
            {
                double value = Math.Abs(x - xData[i]);
                if (value < changeValue)
                {
                    changeValue = value;
                    xCount = i;
                }
            }

            return xCount;
        }
    }
}
