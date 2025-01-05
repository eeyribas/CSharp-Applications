using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogger.Classes
{
    public class DataPaths
    {
        public DirectoryOperations directoryOperations = new DirectoryOperations();
        public FileOperations fileOperations = new FileOperations();
        private string directoryName = @"Data Log";
        public string infoFileTextName = "InfoLog.txt";
        public string exceptionFileTextName = "ExceptionLog.txt";

        public DataPaths()
        {
            Control();
        }

        private void Control()
        {
            directoryOperations.Create(directoryName);

            infoFileTextName = Path.Combine(directoryName, infoFileTextName);
            fileOperations.Create(infoFileTextName);

            exceptionFileTextName = Path.Combine(directoryName, exceptionFileTextName);
            fileOperations.Create(exceptionFileTextName);
        }
    }
}
