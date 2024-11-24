using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DelegatedMethods
{
    public static class DelegatedMethods
    {
        delegate void ClearListBoxCallback(ListBox listBox);
        public static void ClearListBox(ListBox listBox)
        {
            if (listBox.InvokeRequired)
            {
                ClearListBoxCallback d = new ClearListBoxCallback(_ClearListBox);
                listBox.Invoke(d, new object[] { listBox });
            }
            else
            {
                _ClearListBox(listBox);
            }
        }

        private static void _ClearListBox(ListBox listBox)
        {
            listBox.Items.Clear();
        }

        delegate void AddItemToListBoxCallback(ListBox listBox, string item);
        public static void AddItemToListBox(ListBox listBox, string item)
        {
            if (listBox.InvokeRequired)
            {
                AddItemToListBoxCallback d = new AddItemToListBoxCallback(_AddItemToListBox);
                listBox.Invoke(d, new object[] { listBox, item });
            }
            else
            {
                _AddItemToListBox(listBox, item);
            }
        }

        private static void _AddItemToListBox(ListBox listBox, string item)
        {
            listBox.Items.Add(item);
        }

        delegate void AddItemToDataGridViewCallback(DataGridView dataGridView, string[] data, Color backColor, Color foreColor, string tag);
        public static void AddItemToDataGridView(DataGridView dataGridView, string[] data, Color backColor, Color foreColor, string tag)
        {
            if (dataGridView.InvokeRequired)
            {
                AddItemToDataGridViewCallback d = new AddItemToDataGridViewCallback(_AddItemToDataGridView);
                dataGridView.Invoke(d, new object[] { dataGridView, data, backColor, foreColor, tag });
            }
            else
            {
                _AddItemToDataGridView(dataGridView, data, backColor, foreColor, tag);
            }
        }

        private static void _AddItemToDataGridView(DataGridView dataGridView, string[] data, Color backColor, Color foreColor, string tag)
        {
            dataGridView.Rows.Add(data);
            dataGridView.Rows[dataGridView.Rows.Count - 1].DefaultCellStyle.BackColor = backColor;
            dataGridView.Rows[dataGridView.Rows.Count - 1].DefaultCellStyle.ForeColor = foreColor;
            dataGridView.Rows[dataGridView.Rows.Count - 1].Tag = tag;
        }

        delegate void SetImageCallback(PictureBox _pictureBox, Image _image);
        public static void SetImage(PictureBox _pictureBox, Image _image)
        {
            if (_pictureBox.InvokeRequired)
            {
                SetImageCallback d = new SetImageCallback(_SetImage);
                _pictureBox.Invoke(d, new object[] { _pictureBox, _image });
            }
            else
            {
                _SetImage(_pictureBox, _image);
            }
        }

        private static void _SetImage(PictureBox _pictureBox, Image _image)
        {
            if (_pictureBox.Image != null)
                _pictureBox.Image.Dispose();

            _pictureBox.Image = _image;
        }

        delegate void SetControlBackForeColorsCallBack(Control control, Color backColor, Color foreColor);
        public static void SetControlBackForeColors(Control control, Color backColor, Color foreColor)
        {
            if (control != null)
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
        }

        private static void _SetControlBackForeColors(Control control, Color backColor, Color foreColor)
        {
            control.BackColor = backColor;
            control.ForeColor = foreColor;
            control.Update();
        }

        delegate void SetLabelCallback(Label lb, string text);
        public static void SetLabelText(Label lb, string text)
        {
            if (lb != null)
            {
                if (lb.InvokeRequired)
                {
                    SetLabelCallback d = new SetLabelCallback(_SetLabelText);
                    lb.Invoke(d, new object[] { lb, text });
                }
                else
                {
                    _SetLabelText(lb, text);
                }
            }
        }

        private static void _SetLabelText(Label lb, string text)
        {
            lb.Text = text;
            lb.Update();
        }

        delegate void SetLabelTextWithColorCallback(Label lb, string text, Color backColor, Color foreColor);
        public static void SetLabelText(Label lb, string text, Color backColor, Color foreColor)
        {
            if (lb.InvokeRequired)
            {
                SetLabelTextWithColorCallback d = new SetLabelTextWithColorCallback(_SetLabelText);
                lb.Invoke(d, new object[] { lb, text, backColor, foreColor });
            }
            else
            {
                _SetLabelText(lb, text, backColor, foreColor);
            }
        }

        private static void _SetLabelText(Label lb, string text, Color backColor, Color foreColor)
        {
            lb.Text = text;
            lb.BackColor = backColor;
            lb.ForeColor = foreColor;
        }

        delegate void SetControlVisibleCallback(Control control, bool status);
        public static void SetVisible(Control control, bool status)
        {
            if (control.InvokeRequired)
            {
                SetControlVisibleCallback d = new SetControlVisibleCallback(_SetVisible);
                control.Invoke(d, new object[] { control, status });
            }
            else
            {
                _SetVisible(control, status);
            }
        }

        private static void _SetVisible(Control control, bool status)
        {
            control.Visible = status;
        }

        delegate void SetControlEnableCallback(Control control, bool status);
        public static void SetEnable(Control control, bool status)
        {
            if (control.InvokeRequired)
            {
                SetControlEnableCallback d = new SetControlEnableCallback(_SetEnable);
                control.Invoke(d, new object[] { control, status });
            }
            else
            {
                _SetEnable(control, status);
            }
        }

        private static void _SetEnable(Control control, bool status)
        {
            control.Enabled = status;
        }

        delegate void SetControlBackColorCallback(Control control, Color backColor);
        public static void SetControlBackColor(Control control, Color backColor)
        {
            if (control.InvokeRequired)
            {
                SetControlBackColorCallback d = new SetControlBackColorCallback(_SetBackColor);
                control.Invoke(d, new object[] { control, backColor });
            }
            else
            {
                _SetBackColor(control, backColor);
            }
        }

        private static void _SetBackColor(Control control, Color backColor)
        {
            control.BackColor = backColor;
        }

        delegate void SetChartPointListAddCallback(Chart chart, int seriesIndex, List<KeyValuePair<string, double>> values);
        public static void ChartPointListAdd(Chart chart, int seriesIndex, List<KeyValuePair<string, double>> values)
        {
            if (chart.InvokeRequired)
            {
                SetChartPointListAddCallback d = new SetChartPointListAddCallback(InsertChartPointListAdd);
                chart.Invoke(d, new object[] { chart, seriesIndex, values });
            }
            else
            {
                InsertChartPointListAdd(chart, seriesIndex, values);
            }
        }

        private static void InsertChartPointListAdd(Chart chart, int seriesIndex, List<KeyValuePair<string, double>> values)
        {
            int itemCount = values.Count;
            for (int itemIndex = 0; itemIndex < itemCount; itemIndex++)
                chart.Series[seriesIndex].Points.AddXY(values[itemIndex].Key, values[itemIndex].Value);

            chart.ChartAreas[0].AxisX.Interval = chart.Series[seriesIndex].Points.Count / 50;
        }

        delegate void SetChartDataBindXYCallback(Chart chart, int seriesIndex, List<string> keys, List<double> data);
        public static void SetChartDataBindXY(Chart chart, int seriesIndex, List<string> keys, List<double> data)
        {
            if (chart.InvokeRequired)
            {
                SetChartDataBindXYCallback d = new SetChartDataBindXYCallback(_SetChartDataBindXY);
                chart.Invoke(d, new object[] { chart, seriesIndex, keys, data });
            }
            else
            {
                _SetChartDataBindXY(chart, seriesIndex, keys, data);
            }
        }

        private static void _SetChartDataBindXY(Chart chart, int seriesIndex, List<string> keys, List<double> data)
        {
            if (seriesIndex < chart.Series.Count)
                chart.Series[seriesIndex].Points.DataBindXY(keys, data);
        }

        delegate void SetChartDataBindYCallback(Chart chart, int seriesIndex, List<double> data, bool setDataToAllSeries = false);
        public static void SetChartDataBindY(Chart chart, int seriesIndex, List<double> data, bool setDataToAllSeries = false)
        {
            if (chart.InvokeRequired)
            {
                SetChartDataBindYCallback d = new SetChartDataBindYCallback(_SetChartDataBindY);
                chart.Invoke(d, new object[] { chart, seriesIndex, data, setDataToAllSeries });
            }
            else
            {
                _SetChartDataBindY(chart, seriesIndex, data, setDataToAllSeries);
            }
        }

        private static void _SetChartDataBindY(Chart chart, int seriesIndex, List<double> data, bool setDataToAllSeries = false)
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

        delegate void SetAddControlToFormCallback(Control baseConrol, Control control);
        public static void AddControlToForm(Control baseConrol, Control control)
        {
            if (baseConrol.InvokeRequired)
            {
                SetAddControlToFormCallback d = new SetAddControlToFormCallback(_AddControlToForm);
                baseConrol.Invoke(d, new object[] { baseConrol, control });
            }
            else
            {
                _AddControlToForm(baseConrol, control);
            }
        }

        private static void _AddControlToForm(Control baseConrol, Control control)
        {
            baseConrol.Controls.Add(control);
        }

        delegate void SetControlBringtToFrontCallback(Control control);
        public static void ControlBringtToFront(Control control)
        {
            if (control.InvokeRequired)
            {
                SetControlBringtToFrontCallback d = new SetControlBringtToFrontCallback(_ControlBringtToFront);
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

        delegate void SetControlSendToBackCallback(Control control);
        public static void ControlSendToBack(Control control)
        {
            if (control.InvokeRequired)
            {
                SetControlSendToBackCallback d = new SetControlSendToBackCallback(_ControlSendToBack);
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

        delegate void SetProgressCallback(ProgressBar progBar, int percentage);
        public static void SetProgressValue(ProgressBar progBar, int percentage)
        {
            if (progBar.InvokeRequired)
            {
                SetProgressCallback d = new SetProgressCallback(_SetProgressValue);
                progBar.Invoke(d, new object[] { progBar, percentage });
            }
            else
            {
                _SetProgressValue(progBar, percentage);
            }
        }

        private static void _SetProgressValue(ProgressBar progBar, int percentage)
        {
            if (percentage > 0)
                progBar.Value = percentage;

            if (percentage >= 1 && percentage <= 99)
            {
                if (progBar.Visible == false)
                    progBar.Visible = true;
            }
            else
            {
                if (progBar.Visible == true)
                    progBar.Visible = false;
            }

            progBar.Refresh();
        }
    }
}
