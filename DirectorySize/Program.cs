using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectorySize
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\path\to\your\directory";
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            long totalSize = DirectorySize(directoryInfo);
            Console.WriteLine($"Directory Total Size : {totalSize} bayt");
            Console.ReadKey(true);
        }

        public static long DirectorySize(DirectoryInfo directoryInfo)
        {
            long size = 0;

            FileInfo[] fileInfos = directoryInfo.GetFiles();
            foreach (FileInfo fileInfo in fileInfos)
                size += fileInfo.Length;

            DirectoryInfo[] directoryInfos = directoryInfo.GetDirectories();
            foreach (DirectoryInfo dirInfo in directoryInfos)
                size += DirectorySize(dirInfo);

            return size;
        }
    }
}
