using ExcelReader.Classes;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelReader
{
    public partial class Form1 : Form
    {
        private Thread thread;
        private Form2 form2 = new Form2();
        private List<DataPacket> dataPackets = new List<DataPacket>();
        List<DataPacket> orderDataPackets = new List<DataPacket>();
        private string fileName = "";
        private string fileSafeName = "";
        private int readDataCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Rectangle resolution = Screen.PrimaryScreen.Bounds;
                if (resolution.Width == 1366 && resolution.Height == 768)
                    Bounds = Screen.PrimaryScreen.WorkingArea;
            }
            catch (Exception ex)
            {
                WriteWithDateInfo("LogFile.txt", "Error : " + ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel File |*.xlsx";
                openFileDialog.ShowDialog();
                fileName = openFileDialog.FileName;
                string[] fileSafeNameArray = openFileDialog.SafeFileName.Split('.');
                fileSafeName = fileSafeNameArray[0];
                label1.Text = "File name = " + fileSafeName;

                if (thread != null && thread.IsAlive)
                    return;
                thread = new Thread(() => Process());
                thread.Start();
                form2.ShowDialog();
            }
            catch (Exception ex)
            {
                WriteWithDateInfo("LogFile.txt", "Error : " + ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView.Rows.Clear();
                dataPackets.Clear();
            }
            catch (Exception ex)
            {
                WriteWithDateInfo("LogFile.txt", "Error : " + ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                WriteExcel();
            }
            catch (Exception ex)
            {
                WriteWithDateInfo("LogFile.txt", "Error : " + ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = dataGridView.CurrentCell.RowIndex;
                if (selectedIndex > -1)
                {
                    dataGridView.Rows.RemoveAt(selectedIndex);
                    dataGridView.Refresh();
                }
            }
            catch (Exception ex)
            {
                WriteWithDateInfo("LogFile.txt", "Error : " + ex.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                WriteWithDateInfo("LogFile.txt", "Error : " + ex.ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (Shared.processInfo.Value != 0)
                    Shared.processInfo.Key.Kill();
            }
            catch (Exception ex)
            {
                WriteWithDateInfo("LogFile.txt", "Error : " + ex.ToString());
            }
        }

        private void Process()
        {
            try
            {
                List<DataPacket> tmpDataPackets = ReadExcel(fileName);
                for (int i = 0; i < tmpDataPackets.Count; i++)
                {
                    tmpDataPackets[i].fileName = fileSafeName;
                    dataPackets.Add(tmpDataPackets[i]);
                }

                if (dataPackets.Count > 0)
                {
                    orderDataPackets.Clear();
                    orderDataPackets = AlignmentOrder(dataPackets);
                    WriteDataGridView(orderDataPackets);
                }

                int dataPacketCount = dataPackets.Count - readDataCount;
                TextLabel(label2, "Read Data Count : " + dataPacketCount.ToString());
                readDataCount = dataPackets.Count;
                TextLabel(label3, "Sum Data Count : " + readDataCount.ToString());
                CloseForm(form2);
            }
            catch (Exception ex)
            {
                WriteWithDateInfo("LogFile.txt", "Error : " + ex.ToString());
            }
        }

        private List<DataPacket> ReadExcel(string fileName)
        {
            List<DataPacket> dataPackets = new List<DataPacket>();

            try
            {
                List<string> rowList = new List<string>();
                ISheet sheet;
                using (var stream = new FileStream(fileName, FileMode.Open))
                {
                    stream.Position = 0;
                    XSSFWorkbook xssWorkbook = new XSSFWorkbook(stream);
                    sheet = xssWorkbook.GetSheetAt(0);
                    IRow headerRow = sheet.GetRow(0);
                    int cellCount = headerRow.LastCellNum;
                    for (int i = sheet.FirstRowNum; i <= sheet.LastRowNum; i++)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue;
                        if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (row.GetCell(j) != null)
                            {
                                if (!string.IsNullOrEmpty(row.GetCell(j).ToString()) && !string.IsNullOrWhiteSpace(row.GetCell(j).ToString()))
                                    rowList.Add(row.GetCell(j).ToString());
                            }
                        }

                        if (rowList.Count > 0)
                        {
                            DataPacket dataPacket = new DataPacket();
                            for (int k = 0; k < rowList.Count; k++)
                                dataPacket.data.Add(rowList[k]);
                            dataPackets.Add(dataPacket);
                        }
                        rowList.Clear();
                    }
                }

                TextLabel(label4, "Excel read...");
            }
            catch (Exception ex)
            {
                WriteWithDateInfo("LogFile.txt", "Error : " + ex.ToString());
            }

            return dataPackets;
        }

        private void WriteExcel()
        {
            try
            {
                using (var fs = new FileStream("Result.xlsx", FileMode.Create, FileAccess.Write))
                {
                    IWorkbook workbook = new XSSFWorkbook();
                    ISheet excelSheet = workbook.CreateSheet("Sheet1");
                    IRow row = excelSheet.CreateRow(0);
                    int rowIndex = 1;
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        row = excelSheet.CreateRow(rowIndex);
                        int cellIndex = 0;
                        for (int j = 0; j < dataGridView.Columns.Count; j++)
                        {
                            string data = (string)dataGridView.Rows[i].Cells[j].Value;
                            if (data == "")
                                data = " ";

                            row.CreateCell(cellIndex).SetCellValue(data);
                            cellIndex++;
                        }
                        rowIndex++;
                    }
                    workbook.Write(fs);
                }

                label4.Text = "Excel exported...";
            }
            catch (Exception ex)
            {
                WriteWithDateInfo("LogFile.txt", "Error : " + ex.ToString());
            }
        }

        private void WriteDataGridView(List<DataPacket> tmpDataPackets)
        {
            try
            {
                ClearDGW(dataGridView);
                if (tmpDataPackets.Count > 0)
                {
                    for (int i = 0; i < tmpDataPackets.Count; i++)
                    {
                        string[] row = new string[tmpDataPackets[i].data.Count + 1];
                        for (int j = 0; j < tmpDataPackets[i].data.Count; j++)
                            row[j] = tmpDataPackets[i].data[j];

                        row[tmpDataPackets[i].data.Count] = tmpDataPackets[i].fileName;
                        AddDGW(dataGridView, row);
                    }
                }
            }
            catch (Exception ex)
            {
                WriteWithDateInfo("LogFile.txt", "Error : " + ex.ToString());
            }
        }

        private List<DataPacket> AlignmentOrder(List<DataPacket> oDataPackets)
        {
            List<DataPacket> tmpOrderDataPackets = new List<DataPacket>();

            try
            {
                List<DataPacket> tmp = new List<DataPacket>();
                if (oDataPackets.Count > 0)
                {
                    for (int i = 0; i < oDataPackets.Count; i++)
                        tmp.Add(oDataPackets[i]);

                    int count = tmp.Count;
                    while (count > 0)
                    {
                        List<int> id = new List<int>();
                        for (int i = 0; i < count; i++)
                        {
                            if (tmp[0].data[0] == tmp[i].data[0] || tmp[0].data[0].Contains(tmp[i].data[0]) || tmp[i].data[0].Contains(tmp[0].data[0]))
                                id.Add(i);
                        }

                        for (int i = 0; i < id.Count; i++)
                            tmpOrderDataPackets.Add(tmp[id[i]]);

                        for (int i = id.Count - 1; i >= 0; i--)
                        {
                            count--;
                            tmp.RemoveAt(id[i]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WriteWithDateInfo("LogFile.txt", "Error : " + ex.ToString());
            }

            return tmpOrderDataPackets;
        }

        delegate void TextLabelCallback(Label lb, string text);
        public void TextLabel(Label lb, string text)
        {
            try
            {
                if (lb.InvokeRequired)
                {
                    TextLabelCallback d = new TextLabelCallback(_TextLabel);
                    lb.Invoke(d, new object[] { lb, text });
                }
                else
                {
                    _TextLabel(lb, text);
                }
            }
            catch (Exception ex)
            {
                WriteWithDateInfo("LogFile.txt", "Error : " + ex.ToString());
            }
        }

        private void _TextLabel(Label lb, string text)
        {
            try
            {
                lb.Text = text;
            }
            catch (Exception ex)
            {
                WriteWithDateInfo("LogFile.txt", "Error : " + ex.ToString());
            }
        }

        delegate void ClearDGWCallback(DataGridView lb);
        public void ClearDGW(DataGridView lb)
        {
            try
            {
                if (lb.InvokeRequired)
                {
                    ClearDGWCallback d = new ClearDGWCallback(_ClearDGW);
                    lb.Invoke(d, new object[] { lb });
                }
                else
                {
                    _ClearDGW(lb);
                }
            }
            catch (Exception ex)
            {
                WriteWithDateInfo("LogFile.txt", "Error : " + ex.ToString());
            }
        }

        private void _ClearDGW(DataGridView lb)
        {
            try
            {
                lb.Rows.Clear();
            }
            catch (Exception ex)
            {
                WriteWithDateInfo("LogFile.txt", "Error : " + ex.ToString());
            }
        }

        delegate void AddDGWCallback(DataGridView lb, string[] row);
        public void AddDGW(DataGridView lb, string[] row)
        {
            try
            {
                if (lb.InvokeRequired)
                {
                    AddDGWCallback d = new AddDGWCallback(_AddDGW);
                    lb.Invoke(d, new object[] { lb, row });
                }
                else
                {
                    _AddDGW(lb, row);
                }
            }
            catch (Exception ex)
            {
                WriteWithDateInfo("LogFile.txt", "Error : " + ex.ToString());
            }
        }

        private void _AddDGW(DataGridView lb, string[] row)
        {
            try
            {
                lb.Rows.Add(row);
            }
            catch (Exception ex)
            {
                WriteWithDateInfo("LogFile.txt", "Error : " + ex.ToString());
            }
        }

        delegate void CloseFormCallback(Form lb);
        public void CloseForm(Form lb)
        {
            try
            {
                if (lb.InvokeRequired)
                {
                    CloseFormCallback d = new CloseFormCallback(_CloseForm);
                    lb.Invoke(d, new object[] { lb });
                }
                else
                {
                    _CloseForm(lb);
                }
            }
            catch (Exception ex)
            {
                WriteWithDateInfo("LogFile.txt", "Error : " + ex.ToString());
            }
        }

        private void _CloseForm(Form form)
        {
            try
            {
                form.Close();
            }
            catch (Exception ex)
            {
                WriteWithDateInfo("LogFile.txt", "Error : " + ex.ToString());
            }
        }

        public void WriteWithDateInfo(string filePath, string text)
        {
            using (StreamWriter w = File.AppendText(filePath))
            {
                if (text != null)
                {
                    string dateTime = DateTime.Now.ToString("yyyy/MM/dd/HH:mm:ss", CultureInfo.InvariantCulture);
                    string message = dateTime + " " + text;
                    w.WriteLine(message);
                }
            }
        }
    }
}
