using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelDocument
{
    public class ExcelDoc
    {
        public bool wb;
        public string path;

        private FileStream fileStream;
        private XSSFWorkbook xssFWorkbook;

        private IRow irow;
        private ISheet isheet;
        private IWorkbook iworkbook;

        public void Write(string filePath, string[] excelRowNames, string value1, string value2, double value3, double value4, double value5, double value6)
        {
            if (!CheckFile(filePath))
            {
                List<string> excelRowNameList = new List<string>();
                for (int i = 0; i < excelRowNames.Length; i++)
                    excelRowNameList.Add(excelRowNames[i]);

                WriteData(excelRowNameList);
            }

            List<string> data = new List<string>
            {
                DateTime.Now.ToString("dd/MM/yyyy"),
                DateTime.Now.ToString("HH:mm:ss"),
                value1,
                value2,
                value3.ToString("0.00"),
                value4.ToString("0.00"),
                value5.ToString("0.00"),
                value6.ToString("0.00")
            };

            WriteData(data);
        }

        private bool CheckFile(string filename)
        {
            bool res = false;

            path = filename + ".xlsx";
            if (File.Exists(path))
            {
                using (fileStream = new FileStream(path, FileMode.Open))
                    xssFWorkbook = new XSSFWorkbook(fileStream);

                isheet = xssFWorkbook.GetSheet("Sheet");
                wb = true;
                res = true;
            }
            else
            {
                fileStream = File.Create(path);
                iworkbook = new XSSFWorkbook();
                isheet = iworkbook.CreateSheet("Sheet");
                iworkbook.Write(fileStream);
                wb = false;
                res = false;
            }

            return res;
        }

        private void WriteData(List<string> input)
        {
            fileStream = new FileStream(path, FileMode.Open, FileAccess.Write);
            irow = isheet.CreateRow(isheet.LastRowNum + 1);

            for (int i = 0; i < input.Count; i++)
                irow.CreateCell(i).SetCellValue(input[i]);

            if (wb == true)
                xssFWorkbook.Write(fileStream);
            else
                iworkbook.Write(fileStream);

            fileStream.Close();
        }
    }
}
