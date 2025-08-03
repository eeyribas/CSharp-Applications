using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageForm
{
    public class Shared
    {
        public static Language language = null;
        public static Form1 form1 = null;
        public static LangForm langForm = null;

        public static void Initialize()
        {
            language = new Language();
            language.Read();

            form1 = new Form1();
            langForm = new LangForm();
        }
    }
}
