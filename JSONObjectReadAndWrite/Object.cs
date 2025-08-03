using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONObjectReadAndWrite
{
    public class Object
    {
        public int Value1 { get; set; }
        public double Value2 { get; set; }
        public bool Value3 { get; set; }

        public Object()
        {
            Value1 = 6;
            Value2 = 8.97;
            Value3 = true;
        }

        public void Write()
        {
            File.WriteAllText(Shared.jsonPath.jsonName, Newtonsoft.Json.JsonConvert.SerializeObject(Shared.obj));
        }

        public void Read()
        {
            if (File.Exists(Shared.jsonPath.jsonName))
            {
                Shared.obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Object>(File.ReadAllText(Shared.jsonPath.jsonName));
            }
            else
            {
                Write();
                Shared.obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Object>(File.ReadAllText(Shared.jsonPath.jsonName));
            }
        }
    }
}
