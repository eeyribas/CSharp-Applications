using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SimpleLibrary.Classes
{
    public static class DelegatedMethods
    {
        delegate void ClearListBoxItemsCallback(ListBox listBox);
        public static void ClearListBoxItems(ListBox listBox)
        {
            if (listBox.InvokeRequired)
            {
                ClearListBoxItemsCallback d = new ClearListBoxItemsCallback(_ClearListBoxItems);
                listBox.Invoke(d, new object[] { listBox });
            }
            else
            {
                _ClearListBoxItems(listBox);
            }
        }

        private static void _ClearListBoxItems(ListBox listBox)
        {
            listBox.Items.Clear();
        }

        delegate void AddListBoxItemCallback(ListBox listBox, string item);
        public static void AddListBoxItem(ListBox listBox, string item)
        {
            if (listBox.InvokeRequired)
            {
                AddListBoxItemCallback d = new AddListBoxItemCallback(_AddListBoxItem);
                listBox.Invoke(d, new object[] { listBox, item });
            }
            else
            {
                _AddListBoxItem(listBox, item);
            }
        }

        private static void _AddListBoxItem(ListBox listBox, string item)
        {
            listBox.Items.Add(item);
        }

        delegate void AddDataGridViewRowCallback(DataGridView dataGridView, string[] data, Color backColor, Color foreColor, string tag);
        public static void AddDataGridViewRow(DataGridView dataGridView, string[] data, Color backColor, Color foreColor, string tag)
        {
            if (dataGridView.InvokeRequired)
            {
                AddDataGridViewRowCallback d = new AddDataGridViewRowCallback(_AddDataGridViewRow);
                dataGridView.Invoke(d, new object[] { dataGridView, data, backColor, foreColor, tag });
            }
            else
            {
                _AddDataGridViewRow(dataGridView, data, backColor, foreColor, tag);
            }
        }

        private static void _AddDataGridViewRow(DataGridView dataGridView, string[] data, Color backColor, Color foreColor, string tag)
        {
            dataGridView.Rows.Add(data);
            dataGridView.Rows[dataGridView.Rows.Count - 1].DefaultCellStyle.BackColor = backColor;
            dataGridView.Rows[dataGridView.Rows.Count - 1].DefaultCellStyle.ForeColor = foreColor;
            dataGridView.Rows[dataGridView.Rows.Count - 1].Tag = tag;
        }

        delegate void SetPictureBoxImageCallback(PictureBox pictureBox, Image image);
        public static void SetPictureBoxImage(PictureBox pictureBox, Image image)
        {
            if (pictureBox.InvokeRequired)
            {
                SetPictureBoxImageCallback d = new SetPictureBoxImageCallback(_SetPictureBoxImage);
                pictureBox.Invoke(d, new object[] { pictureBox, image });
            }
            else
            {
                _SetPictureBoxImage(pictureBox, image);
            }
        }

        private static void _SetPictureBoxImage(PictureBox pictureBox, Image image)
        {
            if (pictureBox.Image != null)
                pictureBox.Image.Dispose();

            pictureBox.Image = image;
        }

        delegate void SetControlBackForeColorsCallBack(Control control, Color backColor, Color foreColor);
        public static void SetControlBackForeColors(Control control, Color backColor, Color foreColor)
        {
            if (control.InvokeRequired)
            {
                SetControlBackForeColorsCallBack d = new SetControlBackForeColorsCallBack(_SetControlBackForeColors);
                control.Invoke(d, new object[] { control, backColor, foreColor });
            }
            else
            {
                _SetControlBackForeColors(control, backColor, foreColor);
            }
        }

        private static void _SetControlBackForeColors(Control control, Color backColor, Color foreColor)
        {
            control.BackColor = backColor;
            control.ForeColor = foreColor;
            control.Update();
        }

        delegate void SetLabelTextCallback(Label label, string text);
        public static void SetLabelText(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                SetLabelTextCallback d = new SetLabelTextCallback(_SetLabelText);
                label.Invoke(d, new object[] { label, text });
            }
            else
            {
                _SetLabelText(label, text);
            }
        }

        private static void _SetLabelText(Label label, string text)
        {
            label.Text = text;
            label.Update();
        }

        delegate void SetLabelTextBackForeColorsCallback(Label label, string text, Color backColor, Color foreColor);
        public static void SetLabelTextBackForeColors(Label label, string text, Color backColor, Color foreColor)
        {
            if (label.InvokeRequired)
            {
                SetLabelTextBackForeColorsCallback d = new SetLabelTextBackForeColorsCallback(_SetLabelTextBackForeColors);
                label.Invoke(d, new object[] { label, text, backColor, foreColor });
            }
            else
            {
                _SetLabelTextBackForeColors(label, text, backColor, foreColor);
            }
        }

        private static void _SetLabelTextBackForeColors(Label label, string text, Color backColor, Color foreColor)
        {
            label.Text = text;
            label.BackColor = backColor;
            label.ForeColor = foreColor;
        }

        delegate void SetControlVisibleCallback(Control control, bool status);
        public static void SetControlVisible(Control control, bool status)
        {
            if (control.InvokeRequired)
            {
                SetControlVisibleCallback d = new SetControlVisibleCallback(_SetControlVisible);
                control.Invoke(d, new object[] { control, status });
            }
            else
            {
                _SetControlVisible(control, status);
            }
        }

        private static void _SetControlVisible(Control control, bool status)
        {
            control.Visible = status;
        }

        delegate void SetControlEnableCallback(Control control, bool status);
        public static void SetControlEnable(Control control, bool status)
        {
            if (control.InvokeRequired)
            {
                SetControlEnableCallback d = new SetControlEnableCallback(_SetControlEnable);
                control.Invoke(d, new object[] { control, status });
            }
            else
            {
                _SetControlEnable(control, status);
            }
        }

        private static void _SetControlEnable(Control control, bool status)
        {
            control.Enabled = status;
        }

        delegate void SetControlBackColorCallback(Control control, Color backColor);
        public static void SetControlBackColor(Control control, Color backColor)
        {
            if (control.InvokeRequired)
            {
                SetControlBackColorCallback d = new SetControlBackColorCallback(_SetControlBackColor);
                control.Invoke(d, new object[] { control, backColor });
            }
            else
            {
                _SetControlBackColor(control, backColor);
            }
        }

        private static void _SetControlBackColor(Control control, Color backColor)
        {
            control.BackColor = backColor;
        }

        delegate void AddXYChartPointSeriesCallback(Chart chart, int seriesIndex, List<KeyValuePair<string, double>> values);
        public static void AddXYChartPointSeries(Chart chart, int seriesIndex, List<KeyValuePair<string, double>> values)
        {
            if (chart.InvokeRequired)
            {
                AddXYChartPointSeriesCallback d = new AddXYChartPointSeriesCallback(_AddXYChartPointSeries);
                chart.Invoke(d, new object[] { chart, seriesIndex, values });
            }
            else
            {
                _AddXYChartPointSeries(chart, seriesIndex, values);
            }
        }

        private static void _AddXYChartPointSeries(Chart chart, int seriesIndex, List<KeyValuePair<string, double>> values)
        {
            int itemCount = values.Count;
            for (int itemIndex = 0; itemIndex < itemCount; itemIndex++)
                chart.Series[seriesIndex].Points.AddXY(values[itemIndex].Key, values[itemIndex].Value);

            chart.ChartAreas[0].AxisX.Interval = chart.Series[seriesIndex].Points.Count / 50;
        }

        delegate void DataBindXYChartSeriesPointsCallback(Chart chart, int seriesIndex, List<string> keys, List<double> data);
        public static void DataBindXYChartSeriesPoints(Chart chart, int seriesIndex, List<string> keys, List<double> data)
        {
            if (chart.InvokeRequired)
            {
                DataBindXYChartSeriesPointsCallback d = new DataBindXYChartSeriesPointsCallback(_DataBindXYChartSeriesPoints);
                chart.Invoke(d, new object[] { chart, seriesIndex, keys, data });
            }
            else
            {
                _DataBindXYChartSeriesPoints(chart, seriesIndex, keys, data);
            }
        }

        private static void _DataBindXYChartSeriesPoints(Chart chart, int seriesIndex, List<string> keys, List<double> data)
        {
            if (seriesIndex < chart.Series.Count)
                chart.Series[seriesIndex].Points.DataBindXY(keys, data);
        }

        delegate void DataBindYChartSeriesPointsCallback(Chart chart, int seriesIndex, List<double> data, bool setDataToAllSeries = false);
        public static void DataBindYChartSeriesPoints(Chart chart, int seriesIndex, List<double> data, bool setDataToAllSeries = false)
        {
            if (chart.InvokeRequired)
            {
                DataBindYChartSeriesPointsCallback d = new DataBindYChartSeriesPointsCallback(_DataBindYChartSeriesPoints);
                chart.Invoke(d, new object[] { chart, seriesIndex, data, setDataToAllSeries });
            }
            else
            {
                _DataBindYChartSeriesPoints(chart, seriesIndex, data, setDataToAllSeries);
            }
        }

        private static void _DataBindYChartSeriesPoints(Chart chart, int seriesIndex, List<double> data, bool setDataToAllSeries = false)
        {
            if (setDataToAllSeries)
            {
                for (int seriesNo = 0; seriesNo < chart.Series.Count; seriesNo++)
                    chart.Series[seriesNo].Points.DataBindY(data);
            }
            else
            {
                if (seriesIndex < chart.Series.Count)
                    chart.Series[seriesIndex].Points.DataBindY(data);
            }
        }

        delegate void AddControlCallback(Control baseConrol, Control control);
        public static void AddControl(Control baseConrol, Control control)
        {
            if (baseConrol.InvokeRequired)
            {
                AddControlCallback d = new AddControlCallback(_AddControl);
                baseConrol.Invoke(d, new object[] { baseConrol, control });
            }
            else
            {
                _AddControl(baseConrol, control);
            }
        }

        private static void _AddControl(Control baseConrol, Control control)
        {
            baseConrol.Controls.Add(control);
        }

        delegate void ControlBringtToFrontCallback(Control control);
        public static void ControlBringtToFront(Control control)
        {
            if (control.InvokeRequired)
            {
                ControlBringtToFrontCallback d = new ControlBringtToFrontCallback(_ControlBringtToFront);
                control.Invoke(d, new object[] { control });
            }
            else
            {
                _ControlBringtToFront(control);
            }
        }

        private static void _ControlBringtToFront(Control control)
        {
            control.BringToFront();
        }

        delegate void ControlSendToBackCallback(Control control);
        public static void ControlSendToBack(Control control)
        {
            if (control.InvokeRequired)
            {
                ControlSendToBackCallback d = new ControlSendToBackCallback(_ControlSendToBack);
                control.Invoke(d, new object[] { control });
            }
            else
            {
                _ControlSendToBack(control);
            }
        }

        private static void _ControlSendToBack(Control control)
        {
            control.SendToBack();
        }

        delegate void SetProgressValueCallback(ProgressBar progressBar, int percentage);
        public static void SetProgressValueValue(ProgressBar progressBar, int percentage)
        {
            if (progressBar.InvokeRequired)
            {
                SetProgressValueCallback d = new SetProgressValueCallback(_SetProgressValue);
                progressBar.Invoke(d, new object[] { progressBar, percentage });
            }
            else
            {
                _SetProgressValue(progressBar, percentage);
            }
        }

        private static void _SetProgressValue(ProgressBar progressBar, int percentage)
        {
            if (percentage > 0)
                progressBar.Value = percentage;

            if (percentage >= 1 && percentage <= 99)
            {
                if (progressBar.Visible == false)
                    progressBar.Visible = true;
            }
            else
            {
                if (progressBar.Visible == true)
                    progressBar.Visible = false;
            }

            progressBar.Refresh();
        }
    }
}
