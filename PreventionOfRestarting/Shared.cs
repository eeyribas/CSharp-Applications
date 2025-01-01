using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreventionOfRestarting
{
    public class Shared
    {
        public static Form1 form1 = null;

        public static void Initialize()
        {
            form1 = new Form1();
        }
    }
}
