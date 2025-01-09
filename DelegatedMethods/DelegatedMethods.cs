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
        delegate void DataBindXYIntArrayChartCallback(Chart chart, int series, int[] xPoint, int[] yPoint);
        public static void DataBindXYIntArrayChart(Chart chart, int series, int[] xPoint, int[] yPoint)
        {
            if (chart.InvokeRequired)
            {
                DataBindXYIntArrayChartCallback d = new DataBindXYIntArrayChartCallback(_DataBindXYIntArrayChart);
                chart.Invoke(d, new object[] { chart, series, xPoint, yPoint });
            }
            else
            {
                _DataBindXYIntArrayChart(chart, series, xPoint, yPoint);
            }
        }

        private static void _DataBindXYIntArrayChart(Chart chart, int series, int[] xPoint, int[] yPoint)
        {
            chart.Series[series].Points.DataBindXY(xPoint, yPoint);
        }

        delegate void DataBindXYDoubleListChartCallback(Chart chart, int series, List<double> yValues, List<double> xValues);
        public static void DataBindXYDoubleListChart(Chart chart, int series, List<double> yValues, List<double> xValues)
        {
            if (chart.InvokeRequired)
            {
                DataBindXYDoubleListChartCallback d = new DataBindXYDoubleListChartCallback(_DataBindXYDoubleListChart);
                chart.Invoke(d, new object[] { chart, series, yValues, xValues });
            }
            else
            {
                _DataBindXYDoubleListChart(chart, series, yValues, xValues);
            }
        }

        private static void _DataBindXYDoubleListChart(Chart chart, int series, List<double> yValues, List<double> xValues)
        {
            chart.Series[series].Points.DataBindXY(xValues, yValues);
        }

        delegate void AddXYChartCallback(Chart chart, int series, double xPoint, double yPoint);
        public static void AddXYChart(Chart chart, int series, double xPoint, double yPoint)
        {
            if (chart.InvokeRequired)
            {
                AddXYChartCallback d = new AddXYChartCallback(_AddXYChart);
                chart.Invoke(d, new object[] { chart, series, xPoint, yPoint });
            }
            else
            {
                _AddXYChart(chart, series, xPoint, yPoint);
            }
        }

        private static void _AddXYChart(Chart chart, int series, double xPoint, double yPoint)
        {
            chart.Series[series].Points.AddXY(Math.Round(xPoint, 2), Math.Round(yPoint, 2));
        }

        delegate void AxisYMaximumChartCallback(Chart chart, double yMax);
        public static void AxisYMaximumChart(Chart chart, double yMax)
        {
            if (chart.InvokeRequired)
            {
                AxisYMaximumChartCallback d = new AxisYMaximumChartCallback(_AxisYMaximumChart);
                chart.Invoke(d, new object[] { chart, yMax });
            }
            else
            {
                _AxisYMaximumChart(chart, yMax);
            }
        }

        private static void _AxisYMaximumChart(Chart chart, double yMax)
        {
            chart.ChartAreas[0].AxisY.Maximum = yMax;
        }

        delegate void AxisYMinimumChartCallback(Chart chart, double yMin);
        public static void AxisYMinimumChart(Chart chart, double yMin)
        {
            if (chart.InvokeRequired)
            {
                AxisYMinimumChartCallback d = new AxisYMinimumChartCallback(_AxisYMinimumChart);
                chart.Invoke(d, new object[] { chart, yMin });
            }
            else
            {
                _AxisYMinimumChart(chart, yMin);
            }
        }

        private static void _AxisYMinimumChart(Chart chart, double yMin)
        {
            chart.ChartAreas[0].AxisY.Minimum = yMin;
        }

        delegate void AxisYIntervalChartCallback(Chart chart, double value);
        public static void AxisYIntervalChart(Chart chart, double value)
        {
            if (chart.InvokeRequired)
            {
                AxisYIntervalChartCallback d = new AxisYIntervalChartCallback(_AxisYIntervalChart);
                chart.Invoke(d, new object[] { chart, value });
            }
            else
            {
                _AxisYIntervalChart(chart, value);
            }
        }

        private static void _AxisYIntervalChart(Chart chart, double value)
        {
            chart.ChartAreas[0].AxisY.Interval = value;
        }

        delegate void AxisXMaximumChartCallback(Chart chart, double xMax);
        public static void AxisXMaximumChart(Chart chart, double xMax)
        {
            if (chart.InvokeRequired)
            {
                AxisXMaximumChartCallback d = new AxisXMaximumChartCallback(_AxisXMaximumChart);
                chart.Invoke(d, new object[] { chart, xMax });
            }
            else
            {
                _AxisXMaximumChart(chart, xMax);
            }
        }

        private static void _AxisXMaximumChart(Chart chart, double xMax)
        {
            chart.ChartAreas[0].AxisX.Maximum = xMax;
        }

        delegate void AxisXMinimumChartCallback(Chart chart, double xMin);
        public static void AxisXMinimumChart(Chart chart, double xMin)
        {
            if (chart.InvokeRequired)
            {
                AxisXMinimumChartCallback d = new AxisXMinimumChartCallback(_AxisXMinimumChart);
                chart.Invoke(d, new object[] { chart, xMin });
            }
            else
            {
                _AxisXMinimumChart(chart, xMin);
            }
        }

        private static void _AxisXMinimumChart(Chart chart, double xMin)
        {
            chart.ChartAreas[0].AxisX.Minimum = xMin;
        }

        delegate void AxisXIntervalChartCallback(Chart chart, double value);
        public static void AxisXIntervalChart(Chart chart, double value)
        {
            if (chart.InvokeRequired)
            {
                AxisXIntervalChartCallback d = new AxisXIntervalChartCallback(_AxisXIntervalChart);
                chart.Invoke(d, new object[] { chart, value });
            }
            else
            {
                _AxisXIntervalChart(chart, value);
            }
        }

        private static void _AxisXIntervalChart(Chart chart, double value)
        {
            chart.ChartAreas[0].AxisX.Interval = value;
        }

        delegate void PositionChartCallback(Chart chart, Chart positionCh);
        public static void PositionChart(Chart chart, Chart positionCh)
        {
            if (chart.InvokeRequired)
            {
                PositionChartCallback d = new PositionChartCallback(_PositionChart);
                chart.Invoke(d, new object[] { chart, positionCh });
            }
            else
            {
                _PositionChart(chart, positionCh);
            }
        }

        private static void _PositionChart(Chart chart, Chart positionCh)
        {
            chart.ChartAreas[0].Position = positionCh.ChartAreas[0].Position;
        }

        delegate void ZoomInOutConfigChartAreaCallback(Chart chart);
        public static void ZoomInOutConfigChartArea(Chart chart)
        {
            if (chart.InvokeRequired)
            {
                ZoomInOutConfigChartAreaCallback d = new ZoomInOutConfigChartAreaCallback(_ZoomInOutConfigChartArea);
                chart.Invoke(d, new object[] { chart });
            }
            else
            {
                _ZoomInOutConfigChartArea(chart);
            }
        }

        private static void _ZoomInOutConfigChartArea(Chart chart)
        {
            chart.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart.ChartAreas[0].CursorX.SelectionColor = Color.LightSteelBlue;
            chart.ChartAreas[0].CursorX.LineDashStyle = ChartDashStyle.Dash;
            chart.ChartAreas[0].AxisX.ScaleView.Zoomable = false;
            chart.ChartAreas[0].AxisY.ScaleView.Zoomable = false;

            chart.ChartAreas[0].Position.Auto = false;
            chart.ChartAreas[0].Position.Height = 100F;
            chart.ChartAreas[0].Position.Width = 100F;
        }

        delegate void ClearChartCallback(Chart chart, int series);
        public static void ClearChart(Chart chart, int series)
        {
            if (chart.InvokeRequired)
            {
                ClearChartCallback d = new ClearChartCallback(_ClearChart);
                chart.Invoke(d, new object[] { chart, series });
            }
            else
            {
                _ClearChart(chart, series);
            }
        }

        private static void _ClearChart(Chart chart, int series)
        {
            chart.Series[series].Points.Clear();
        }

        delegate void DataBindYDoubleArrayChartCallback(Chart chart, int seriesIndex, List<double> data, bool setDataToAllSeries = false);
        public static void DataBindYDoubleArrayChart(Chart chart, int seriesIndex, List<double> data, bool setDataToAllSeries = false)
        {
            if (chart.InvokeRequired)
            {
                DataBindYDoubleArrayChartCallback d = new DataBindYDoubleArrayChartCallback(_DataBindYDoubleArrayChart);
                chart.Invoke(d, new object[] { chart, seriesIndex, data, setDataToAllSeries });
            }
            else
            {
                _DataBindYDoubleArrayChart(chart, seriesIndex, data, setDataToAllSeries);
            }
        }

        private static void _DataBindYDoubleArrayChart(Chart chart, int seriesIndex, List<double> data, bool setDataToAllSeries = false)
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

        delegate void ImagePictureBoxCallback(PictureBox pictureBox, Image img);
        public static void ImagePictureBox(PictureBox pictureBox, Image img)
        {
            if (pictureBox.InvokeRequired)
            {
                ImagePictureBoxCallback d = new ImagePictureBoxCallback(_ImagePictureBox);
                pictureBox.Invoke(d, new object[] { pictureBox, img });
            }
            else
            {
                _ImagePictureBox(pictureBox, img);
            }
        }

        private static void _ImagePictureBox(PictureBox pictureBox, Image img)
        {
            pictureBox.Image = img;
        }

        delegate void EnablePictureBoxCallback(PictureBox pictureBox, bool state);
        public static void EnablePictureBox(PictureBox pictureBox, bool state)
        {
            if (pictureBox.InvokeRequired)
            {
                EnablePictureBoxCallback d = new EnablePictureBoxCallback(_EnablePictureBox);
                pictureBox.Invoke(d, new object[] { pictureBox, state });
            }
            else
            {
                _EnablePictureBox(pictureBox, state);
            }
        }

        private static void _EnablePictureBox(PictureBox pictureBox, bool state)
        {
            pictureBox.Enabled = state;
        }

        delegate void EnableLabelCallback(Label label, bool state);
        public static void EnableLabel(Label label, bool state)
        {
            if (label.InvokeRequired)
            {
                EnableLabelCallback d = new EnableLabelCallback(_EnableLabel);
                label.Invoke(d, new object[] { label, state });
            }
            else
            {
                _EnableLabel(label, state);
            }
        }

        private static void _EnableLabel(Label label, bool state)
        {
            label.Enabled = state;
        }

        delegate void BackColorLabelCallback(Label label, int r, int g, int b);
        public static void BackColorLabel(Label label, int r, int g, int b)
        {
            if (label.InvokeRequired)
            {
                BackColorLabelCallback d = new BackColorLabelCallback(_BackColorLabel);
                label.Invoke(d, new object[] { label, r, g, b });
            }
            else
            {
                _BackColorLabel(label, r, g, b);
            }
        }

        private static void _BackColorLabel(Label label, int r, int g, int b)
        {
            label.BackColor = Color.FromArgb(r, g, b);
        }

        delegate void TextLabelCallback(Label label, string text);
        public static void TextLabel(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                TextLabelCallback d = new TextLabelCallback(_TextLabel);
                label.Invoke(d, new object[] { label, text });
            }
            else
            {
                _TextLabel(label, text);
            }
        }

        private static void _TextLabel(Label label, string text)
        {
            label.Text = text;
        }

        delegate void ImageLabelCallback(Label label, Image image);
        public static void ImageLabel(Label label, Image image)
        {
            if (label.InvokeRequired)
            {
                ImageLabelCallback d = new ImageLabelCallback(_ImageLabel);
                label.Invoke(d, new object[] { label, image });
            }
            else
            {
                _ImageLabel(label, image);
            }
        }

        private static void _ImageLabel(Label label, Image image)
        {
            label.Image = image;
        }

        delegate void BackColorAndForeColorLabelCallback(Label label, string text, Color backColor, Color foreColor);
        public static void BackColorAndForeColorLabel(Label label, string text, Color backColor, Color foreColor)
        {
            if (label.InvokeRequired)
            {
                BackColorAndForeColorLabelCallback d = new BackColorAndForeColorLabelCallback(_BackColorAndForeColorLabel);
                label.Invoke(d, new object[] { label, text, backColor, foreColor });
            }
            else
            {
                _BackColorAndForeColorLabel(label, text, backColor, foreColor);
            }
        }

        private static void _BackColorAndForeColorLabel(Label label, string text, Color backColor, Color foreColor)
        {
            label.Text = text;
            label.BackColor = backColor;
            label.ForeColor = foreColor;
        }

        delegate void TextTextBoxCallback(TextBox textBox, string text);
        public static void TextTextBox(TextBox textBox, string text)
        {
            if (textBox.InvokeRequired)
            {
                TextTextBoxCallback d = new TextTextBoxCallback(_TextTextBox);
                textBox.Invoke(d, new object[] { textBox, text });
            }
            else
            {
                _TextTextBox(textBox, text);
            }
        }

        private static void _TextTextBox(TextBox textBox, string text)
        {
            textBox.Text = text;
        }

        delegate void EnableTextBoxCallback(TextBox textBox, bool state);
        public static void EnableTextBox(TextBox textBox, bool state)
        {
            if (textBox.InvokeRequired)
            {
                EnableTextBoxCallback d = new EnableTextBoxCallback(_EnableTextBox);
                textBox.Invoke(d, new object[] { textBox, state });
            }
            else
            {
                _EnableTextBox(textBox, state);
            }
        }

        private static void _EnableTextBox(TextBox textBox, bool state)
        {
            textBox.Enabled = state;
        }

        delegate void ClearTextBoxCallback(TextBox textBox);
        public static void ClearTextBox(TextBox textBox)
        {
            if (textBox.InvokeRequired)
            {
                ClearTextBoxCallback d = new ClearTextBoxCallback(_ClearTextBox);
                textBox.Invoke(d, new object[] { textBox });
            }
            else
            {
                _ClearTextBox(textBox);
            }
        }

        private static void _ClearTextBox(TextBox textBox)
        {
            textBox.Clear();
        }

        delegate void EnableButtonCallback(Button button, bool state);
        public static void EnableButton(Button button, bool state)
        {
            if (button.InvokeRequired)
            {
                EnableButtonCallback d = new EnableButtonCallback(_EnableButton);
                button.Invoke(d, new object[] { button, state });
            }
            else
            {
                _EnableButton(button, state);
            }
        }

        private static void _EnableButton(Button button, bool state)
        {
            button.Enabled = state;
        }

        delegate void BackColorButtonCallback(Button button, Color color);
        public static void BackColorButton(Button button, Color color)
        {
            if (button.InvokeRequired)
            {
                BackColorButtonCallback d = new BackColorButtonCallback(_BackColorButton);
                button.Invoke(d, new object[] { button, color });
            }
            else
            {
                _BackColorButton(button, color);
            }
        }

        private static void _BackColorButton(Button button, Color color)
        {
            button.BackColor = color;
        }

        delegate void TextButtonCallback(Button button, string text);
        public static void TextButton(Button button, string text)
        {
            if (button.InvokeRequired)
            {
                TextButtonCallback d = new TextButtonCallback(_TextButton);
                button.Invoke(d, new object[] { button, text });
            }
            else
            {
                _TextButton(button, text);
            }
        }

        private static void _TextButton(Button button, string text)
        {
            button.Text = text;
        }

        delegate void SelectedIndexComboBoxCallback(ComboBox comboBox, int index);
        public static void SelectedIndexComboBox(ComboBox comboBox, int index)
        {
            if (comboBox.InvokeRequired)
            {
                SelectedIndexComboBoxCallback d = new SelectedIndexComboBoxCallback(_SelectedIndexComboBox);
                comboBox.Invoke(d, new object[] { comboBox, index });
            }
            else
            {
                _SelectedIndexComboBox(comboBox, index);
            }
        }

        private static void _SelectedIndexComboBox(ComboBox comboBox, int index)
        {
            comboBox.SelectedIndex = index;
        }

        delegate void EnableComboBoxCallback(ComboBox comboBox, bool state);
        public static void EnableComboBox(ComboBox comboBox, bool state)
        {
            if (comboBox.InvokeRequired)
            {
                EnableComboBoxCallback d = new EnableComboBoxCallback(_EnableComboBox);
                comboBox.Invoke(d, new object[] { comboBox, state });
            }
            else
            {
                _EnableComboBox(comboBox, state);
            }
        }

        private static void _EnableComboBox(ComboBox comboBox, bool state)
        {
            comboBox.Enabled = state;
        }

        delegate void AddItemComboBoxCallback(ComboBox comboBox, string item);
        public static void AddItemComboBox(ComboBox comboBox, string item)
        {
            if (comboBox.InvokeRequired)
            {
                AddItemComboBoxCallback d = new AddItemComboBoxCallback(_AddItemComboBox);
                comboBox.Invoke(d, new object[] { comboBox, item });
            }
            else
            {
                _AddItemComboBox(comboBox, item);
            }
        }

        private static void _AddItemComboBox(ComboBox comboBox, string item)
        {
            comboBox.Items.Add(item);
        }

        delegate void ClearComboBoxCallback(ComboBox comboBox);
        public static void ClearComboBox(ComboBox comboBox)
        {
            if (comboBox.InvokeRequired)
            {
                ClearComboBoxCallback d = new ClearComboBoxCallback(_ClearComboBox);
                comboBox.Invoke(d, new object[] { comboBox });
            }
            else
            {
                _ClearComboBox(comboBox);
            }
        }

        private static void _ClearComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();
        }

        delegate void EnableTabControlCallback(TabControl tabControl, bool state);
        public static void EnableTabControl(TabControl tabControl, bool state)
        {
            if (tabControl.InvokeRequired)
            {
                EnableTabControlCallback d = new EnableTabControlCallback(_EnableTabControl);
                tabControl.Invoke(d, new object[] { tabControl, state });
            }
            else
            {
                _EnableTabControl(tabControl, state);
            }
        }

        private static void _EnableTabControl(TabControl tabControl, bool state)
        {
            tabControl.Enabled = state;
        }

        delegate void TextGroupBoxCallback(GroupBox groupBox, string text);
        public static void TextGroupBox(GroupBox groupBox, string text)
        {
            if (groupBox.InvokeRequired)
            {
                TextGroupBoxCallback d = new TextGroupBoxCallback(_TextGroupBox);
                groupBox.Invoke(d, new object[] { groupBox, text });
            }
            else
            {
                _TextGroupBox(groupBox, text);
            }
        }

        private static void _TextGroupBox(GroupBox groupBox, string text)
        {
            groupBox.Text = text;
        }

        delegate void AddItemListBoxCallback(ListBox listBox, string item);
        public static void AddItemListBox(ListBox listBox, string item)
        {
            if (listBox.InvokeRequired)
            {
                AddItemListBoxCallback d = new AddItemListBoxCallback(_AddItemListBox);
                listBox.Invoke(d, new object[] { listBox, item });
            }
            else
            {
                _AddItemListBox(listBox, item);
            }
        }

        private static void _AddItemListBox(ListBox listBox, string item)
        {
            listBox.Items.Add(item);
        }

        delegate void EnableListBoxCallback(ListBox listBox, bool state);
        public static void EnableListBox(ListBox listBox, bool state)
        {
            if (listBox.InvokeRequired)
            {
                EnableListBoxCallback d = new EnableListBoxCallback(_EnableListBox);
                listBox.Invoke(d, new object[] { listBox, state });
            }
            else
            {
                _EnableListBox(listBox, state);
            }
        }

        private static void _EnableListBox(ListBox listBox, bool state)
        {
            listBox.Enabled = state;
        }

        delegate void SelectedIndexListBoxCallback(ListBox listBox, int index);
        public static void SelectedIndexListBox(ListBox listBox, int index)
        {
            if (listBox.InvokeRequired)
            {
                SelectedIndexListBoxCallback d = new SelectedIndexListBoxCallback(_SelectedIndexListBox);
                listBox.Invoke(d, new object[] { listBox, index });
            }
            else
            {
                _SelectedIndexListBox(listBox, index);
            }
        }

        private static void _SelectedIndexListBox(ListBox listBox, int index)
        {
            listBox.SelectedIndex = index;
        }

        delegate void ClearItemsListBoxCallback(ListBox listBox);
        public static void ClearItemsListBox(ListBox listBox)
        {
            if (listBox.InvokeRequired)
            {
                ClearItemsListBoxCallback d = new ClearItemsListBoxCallback(_ClearItemsListBox);
                listBox.Invoke(d, new object[] { listBox });
            }
            else
            {
                _ClearItemsListBox(listBox);
            }
        }

        private static void _ClearItemsListBox(ListBox listBox)
        {
            listBox.Items.Clear();
        }

        delegate void AddRowDataGridViewCallback(DataGridView dataGridView, string[] data, Color backColor, Color foreColor, string tag);
        public static void AddRowDataGridView(DataGridView dataGridView, string[] data, Color backColor, Color foreColor, string tag)
        {
            if (dataGridView.InvokeRequired)
            {
                AddRowDataGridViewCallback d = new AddRowDataGridViewCallback(_AddRowDataGridView);
                dataGridView.Invoke(d, new object[] { dataGridView, data, backColor, foreColor, tag });
            }
            else
            {
                _AddRowDataGridView(dataGridView, data, backColor, foreColor, tag);
            }
        }

        private static void _AddRowDataGridView(DataGridView dataGridView, string[] data, Color backColor, Color foreColor, string tag)
        {
            dataGridView.Rows.Add(data);
            dataGridView.Rows[dataGridView.Rows.Count - 1].DefaultCellStyle.BackColor = backColor;
            dataGridView.Rows[dataGridView.Rows.Count - 1].DefaultCellStyle.ForeColor = foreColor;
            dataGridView.Rows[dataGridView.Rows.Count - 1].Tag = tag;
        }

        delegate void BackColorAndForeColorControlCallBack(Control control, Color backColor, Color foreColor);
        public static void BackColorAndForeColorControl(Control control, Color backColor, Color foreColor)
        {
            if (control != null)
            {
                if (control.InvokeRequired)
                {
                    BackColorAndForeColorControlCallBack d = new BackColorAndForeColorControlCallBack(_BackColorAndForeColorControl);
                    control.Invoke(d, new object[] { control, backColor, foreColor });
                }
                else
                {
                    _BackColorAndForeColorControl(control, backColor, foreColor);
                }
            }
        }

        private static void _BackColorAndForeColorControl(Control control, Color backColor, Color foreColor)
        {
            control.BackColor = backColor;
            control.ForeColor = foreColor;
            control.Update();
        }

        delegate void VisibleControlCallback(Control control, bool state);
        public static void VisibleControl(Control control, bool state)
        {
            if (control.InvokeRequired)
            {
                VisibleControlCallback d = new VisibleControlCallback(_VisibleControl);
                control.Invoke(d, new object[] { control, state });
            }
            else
            {
                _VisibleControl(control, state);
            }
        }

        private static void _VisibleControl(Control control, bool state)
        {
            control.Visible = state;
        }

        delegate void EnableControlCallback(Control control, bool state);
        public static void EnableControl(Control control, bool state)
        {
            if (control.InvokeRequired)
            {
                EnableControlCallback d = new EnableControlCallback(_EnableControl);
                control.Invoke(d, new object[] { control, state });
            }
            else
            {
                _EnableControl(control, state);
            }
        }

        private static void _EnableControl(Control control, bool state)
        {
            control.Enabled = state;
        }

        delegate void BackColorControlCallback(Control control, Color backColor);
        public static void BackColorControl(Control control, Color backColor)
        {
            if (control.InvokeRequired)
            {
                BackColorControlCallback d = new BackColorControlCallback(_BackColorControl);
                control.Invoke(d, new object[] { control, backColor });
            }
            else
            {
                _BackColorControl(control, backColor);
            }
        }

        private static void _BackColorControl(Control control, Color backColor)
        {
            control.BackColor = backColor;
        }

        delegate void AddControlInControlCallback(Control baseControl, Control control);
        public static void AddControlInControl(Control baseControl, Control control)
        {
            if (baseControl.InvokeRequired)
            {
                AddControlInControlCallback d = new AddControlInControlCallback(_AddControlInControl);
                baseControl.Invoke(d, new object[] { baseControl, control });
            }
            else
            {
                _AddControlInControl(baseControl, control);
            }
        }

        private static void _AddControlInControl(Control baseControl, Control control)
        {
            baseControl.Controls.Add(control);
        }

        delegate void BringToFrontControlCallback(Control control);
        public static void BringToFrontControl(Control control)
        {
            if (control.InvokeRequired)
            {
                BringToFrontControlCallback d = new BringToFrontControlCallback(_BringToFrontControl);
                control.Invoke(d, new object[] { control });
            }
            else
            {
                _BringToFrontControl(control);
            }
        }

        private static void _BringToFrontControl(Control control)
        {
            control.BringToFront();
        }

        delegate void SendToBackControlCallback(Control control);
        public static void SendToBackControl(Control control)
        {
            if (control.InvokeRequired)
            {
                SendToBackControlCallback d = new SendToBackControlCallback(_SendToBackControl);
                control.Invoke(d, new object[] { control });
            }
            else
            {
                _SendToBackControl(control);
            }
        }

        private static void _SendToBackControl(Control control)
        {
            control.SendToBack();
        }

        delegate void SetValueProgressCallback(ProgressBar progressBar, int percentage);
        public static void SetValueProgress(ProgressBar progressBar, int percentage)
        {
            if (progressBar.InvokeRequired)
            {
                SetValueProgressCallback d = new SetValueProgressCallback(_SetValueProgress);
                progressBar.Invoke(d, new object[] { progressBar, percentage });
            }
            else
            {
                _SetValueProgress(progressBar, percentage);
            }
        }

        private static void _SetValueProgress(ProgressBar progressBar, int percentage)
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
