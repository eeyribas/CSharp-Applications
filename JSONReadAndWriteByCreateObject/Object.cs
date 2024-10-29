using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONReadAndWriteByCreateObject
{
    public class Object
    {
        public int Value1 { get; set; }
        public double Value2 { get; set; }
        public bool Value3 { get; set; }

        public Object()
        {
            try
            {
                Value1 = 6;
                Value2 = 8.97;
                Value3 = true;
            }
            catch (Exception ex)
            {
            }
        }

        public void Write()
        {
            try
            {
                File.WriteAllText(Shared.jsonPath.jsonName, Newtonsoft.Json.JsonConvert.SerializeObject(Shared.obj));
            }
            catch (Exception ex)
            {
            }
        }

        public void Read()
        {
            try
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
            catch (Exception ex)
            {
            }
        }
    }
}
