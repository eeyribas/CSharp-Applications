using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogger.Classes
{
    public class DirectoryOperations
    {
        public void Create(string dirPath)
        {
            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);
        }

        public bool Control(string dirPath)
        {
            if (!Directory.Exists(dirPath))
                return false;

            return true;
        }

        public long Size(string dirPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(dirPath);
            long size = 0;
            foreach (FileInfo fi in directoryInfo.GetFiles("*.*", SearchOption.AllDirectories))
                size += fi.Length;
            size = size / 1000000;

            return size;
        }

        public void Delete(string dirPath)
        {
            if (Directory.Exists(dirPath))
                Directory.Delete(dirPath, true);
        }

        public void Delete(string dirPath, bool rec)
        {
            if (Directory.Exists(dirPath))
                Directory.Delete(dirPath, rec);
        }
    }
}
