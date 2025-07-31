using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindPeakPointOfTheChart
{
    public partial class Form1 : Form
    {
        private List<int> yAxis = new List<int>();
        private List<int> xAxis = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                yAxis.Add(random.Next(0, 100));
                xAxis.Add(i);
            }

            for (int i = 0; i < yAxis.Count; i++)
                chart1.Series[0].Points.AddXY(xAxis[i], yAxis[i]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();

            List<int> peakIndex = FindPeak(yAxis);
            for (int i = 0; i < peakIndex.Count; i++)
            {
                int index = peakIndex[i];
                chart1.Series[1].Points.AddXY(xAxis[index], yAxis[index]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series[2].Points.Clear();

            List<int> peakFilterIndex = FindPeakFilter(yAxis, Convert.ToInt32(textBox1.Text));
            for (int i = 0; i < peakFilterIndex.Count; i++)
            {
                int index = peakFilterIndex[i];
                chart1.Series[2].Points.AddXY(xAxis[index], yAxis[index]);
            }
        }

        private List<int> FindPeak(List<int> list)
        {
            List<int> indexs = new List<int>();
            if (list[0] > list[1])
                indexs.Add(0);

            for (int i = 1; i < list.Count - 1; i++)
            {
                if (list[i] > list[i - 1] && list[i] >= list[i + 1])
                    indexs.Add(i);
            }

            if (list[list.Count - 1] > list[list.Count - 2])
                indexs.Add(list.Count - 1);

            return indexs;
        }


        private List<int> FindPeakFilter(List<int> list, int filterValue)
        {
            List<int> indexs = new List<int>();
            List<int> indexFilters = new List<int>();
            if (list[0] > list[1])
                indexs.Add(0);

            for (int i = 1; i < list.Count - 1; i++)
            {
                if (list[i] > list[i - 1] && list[i] >= list[i + 1])
                    indexs.Add(i);
            }

            if (list[list.Count - 1] > list[list.Count - 2])
                indexs.Add(list.Count - 1);

            int firstIndex = indexs[0];
            int secondIndex = indexs[1];
            if (list[firstIndex] > (list[secondIndex] + filterValue))
                indexFilters.Add(firstIndex);

            for (int i = 1; i < indexs.Count - 1; i++)
            {
                int previousIndex = indexs[i - 1];
                int tmpIndex = indexs[i];
                int nextIndex = indexs[i + 1];
                if (list[tmpIndex] >= (list[previousIndex] + filterValue) && 
                    list[tmpIndex] > (list[nextIndex] + filterValue))
                    indexFilters.Add(tmpIndex);
            }

            int lastPreviosIndex = indexs[indexs.Count - 2];
            int lastIndex = indexs[indexs.Count - 1];
            if (list[lastIndex] > (list[lastPreviosIndex] + filterValue))
                indexFilters.Add(lastIndex);

            return indexFilters;
        }
    }
}
