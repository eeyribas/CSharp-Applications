using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadAndWriteToExcelDataSource
{
    public partial class Form1 : Form
    {
        private double[] array1 = new double[81];
        private double[] array2 = new double[81];

        public object ExcelVersion { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = application.Workbooks.Open(@"Data.xlsx");
            Microsoft.Office.Interop.Excel._Worksheet worksheet = workbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range range = worksheet.UsedRange;

            int rowCount = range.Rows.Count;
            for (int i = 2; i <= rowCount + 1; i++)
            {
                if (range.Cells[i, 1] != null && range.Cells[i, 1].Value2 != null)
                    array1[i - 2] = range.Cells[i, 1].Value2;
            }

            for (int i = 0; i < array1.Length; i++)
                listBox1.Items.Add(array1[i]);

            GC.Collect();
            GC.WaitForPendingFinalizers();
            Marshal.ReleaseComObject(range);
            Marshal.ReleaseComObject(worksheet);

            workbook.Close();
            Marshal.ReleaseComObject(workbook);
            application.Quit();
            Marshal.ReleaseComObject(application);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int value1 = 1;
            int value2 = 2;

            Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
            if (application == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }

            Microsoft.Office.Interop.Excel.Workbook workBook;
            Microsoft.Office.Interop.Excel.Worksheet workSheet;
            object misValue = System.Reflection.Missing.Value;

            workBook = application.Workbooks.Add(misValue);
            workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Worksheets.get_Item(1);
            for (int i = 1; i < array1.Length + 1; i++)
            {
                workSheet.Cells[i, value1] = array1[i - 1];
                workSheet.Cells[i, value2] = array2[i - 1];
            }

            workBook.SaveAs("Data.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, misValue,
            misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            workBook.Close(true, misValue, misValue);
            application.Quit();

            Marshal.ReleaseComObject(workSheet);
            Marshal.ReleaseComObject(workBook);
            Marshal.ReleaseComObject(application);
        }
    }
}
