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

namespace ChartZooming
{
    public partial class Form1 : Form
    {
        private List<Chart> charts = new List<Chart>();
        private List<double> array1 = new List<double>();
        private List<double> array2 = new List<double>();
        private List<double> array3 = new List<double>();
        private List<double> array4 = new List<double>();

        public Form1()
        {
            InitializeComponent();

            charts.Add(chart1);
            charts.Add(chart2);
            charts.Add(chart3);
            charts.Add(chart4);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            charts[0].ChartAreas[0].CursorX.IsUserEnabled = true;
            charts[0].ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            charts[0].ChartAreas[0].CursorX.SelectionColor = Color.LightSteelBlue;
            charts[0].ChartAreas[0].CursorX.LineDashStyle = ChartDashStyle.Dash;
            charts[0].ChartAreas[0].AxisX.ScaleView.Zoomable = false;
            charts[0].ChartAreas[0].AxisY.ScaleView.Zoomable = false;

            for (int i = 0; i < charts.Count; i++)
            {
                charts[i].Series[0].ChartType = SeriesChartType.FastLine;
                charts[i].Series[0].BorderWidth = 4;
                charts[i].ChartAreas[0].Position.Auto = false;
                charts[i].ChartAreas[0].Position.Height = 100F;
                charts[i].ChartAreas[0].Position.Width = 100F;
            }

            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                int value1 = random.Next(0, 20);
                int value2 = random.Next(0, 20);
                int value3 = random.Next(0, 20);

                if (i % random.Next(15, 20) == 0)
                    value1 = random.Next(50, 90);
                if (i % random.Next(15, 20) == 0)
                    value2 = random.Next(50, 90);
                if (i % random.Next(15, 20) == 0)
                    value3 = random.Next(50, 90);

                array1.Add(value1 * value2 * value3);
                array2.Add(value1);
                array3.Add(value2);
                array4.Add(value3);
            }

            charts[0].Series[0].Points.DataBindY(array1);
            charts[1].Series[0].Points.DataBindY(array2);
            charts[2].Series[0].Points.DataBindY(array3);
            charts[3].Series[0].Points.DataBindY(array4);
        }

        private void chart1_SelectionRangeChanged(object sender, CursorEventArgs e)
        {
            double tmpStartX = charts[0].ChartAreas[0].CursorX.SelectionStart;
            double tmpEndX = charts[0].ChartAreas[0].CursorX.SelectionEnd;

            if (tmpStartX > tmpEndX)
            {
                double tmp = tmpEndX;
                tmpEndX = tmpStartX;
                tmpStartX = tmp;
            }

            if (tmpStartX != tmpEndX)
            {
                charts[1].Series[0].Points.Clear();
                charts[2].Series[0].Points.Clear();
                charts[3].Series[0].Points.Clear();
                for (int i = (int)tmpStartX; i <= tmpEndX; i++)
                {
                    charts[1].Series[0].Points.AddXY(i, array2[i]);
                    charts[2].Series[0].Points.AddXY(i, array3[i]);
                    charts[3].Series[0].Points.AddXY(i, array4[i]);
                }
            }
        }

        private void chart1_DoubleClick(object sender, EventArgs e)
        {
            for (int i = 1; i < charts.Count; i++)
                charts[i].Series[0].Points.Clear();

            charts[1].Series[0].Points.DataBindY(array2);
            charts[2].Series[0].Points.DataBindY(array3);
            charts[3].Series[0].Points.DataBindY(array4);
        }
    }
}
