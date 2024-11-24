using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Image Processing Test");
            Bitmap bitmap = new Bitmap(400, 700);
            Bitmap newBitmap = ImageProcessing.ScaleBitmap(bitmap, 200, 350);

            Console.ReadKey(true);
        }
    }
}
