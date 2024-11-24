using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tar Operations");
            Tar.ExtractTarGz("Example", "/Release");

            Console.ReadKey(true);
        }
    }
}
