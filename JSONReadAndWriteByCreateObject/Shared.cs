using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONReadAndWriteByCreateObject
{
    public class Shared
    {
        public static JsonPath jsonPath = null;
        public static Object obj = null;

        public static void Initialize()
        {
            try
            {
                jsonPath = new JsonPath();
                obj = new Object();
                obj.Read();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
