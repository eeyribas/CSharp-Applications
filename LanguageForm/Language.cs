using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageForm
{
    public class Language
    {
        public string Selection { get; set; }

        public Language()
        {
            Selection = "TR";
        }

        public void Write()
        {
            try
            {
                File.WriteAllText("Language.json", Newtonsoft.Json.JsonConvert.SerializeObject(Shared.language));
            }
            catch (Exception ex)
            {
            }
        }

        public void Read()
        {
            try
            {
                if (File.Exists("Language.json"))
                {
                    Shared.language = Newtonsoft.Json.JsonConvert.DeserializeObject<Language>(File.ReadAllText("Language.json"));
                }
                else
                {
                    Write();
                    Shared.language = Newtonsoft.Json.JsonConvert.DeserializeObject<Language>(File.ReadAllText("Language.json"));
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
