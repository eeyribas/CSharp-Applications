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
            File.WriteAllText("Language.json", Newtonsoft.Json.JsonConvert.SerializeObject(Shared.language));
        }

        public void Read()
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
    }
}
