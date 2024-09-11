using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONReadAndWrite
{
    public class ControlParams
    {
        public static JsonProcess jsonProcess = null;
        public static Form1 form1 = null;

        public static void Initialize()
        {
            jsonProcess = new JsonProcess();
            form1 = new Form1();
        }
    }
}
