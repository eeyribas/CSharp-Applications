using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogger.Classes
{
    public class FileOperations
    {
        public void Create(string filePath)
        {
            if (!File.Exists(filePath))
            {
                FileStream fs = File.Create(filePath);
                fs.Close();
            }
        }

        public bool Control(string filePath)
        {
            if (!File.Exists(filePath))
                return false;

            return true;
        }

        public void WriteWithDateInfo(string filePath, string text)
        {
            using (StreamWriter streamWriter = File.AppendText(filePath))
            {
                if (text != null)
                {
                    string myDateTime = DateTime.Now.ToString("yyyy/MM/dd/HH:mm:ss", CultureInfo.InvariantCulture);
                    string message = myDateTime + " " + text;
                    streamWriter.WriteLine(message);
                }
            }
        }

        public void Write(string filePath, string text)
        {
            using (StreamWriter streamWriter = File.AppendText(filePath))
            {
                if (text != null)
                    streamWriter.WriteLine(text);
            }
        }

        public List<string> Read(string filePath)
        {
            string[] readData = File.ReadAllLines(filePath);
            List<string> readDataList = new List<string>();
            for (int i = 0; i < readData.Length; i++)
                readDataList.Add(readData[i]);

            return readDataList;
        }
    }
}
