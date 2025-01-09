using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolboxProperties.ToolboxProperty
{
    public class TextBoxMethods
    {
        public int TrimConvInt(string text)
        {
            int value = 0;
            if (text.Trim() != "")
                value = Convert.ToInt32(text.Trim());

            return value;
        }

        public string TrimConvString(string text)
        {
            string value = "";
            if (text.Trim() != "")
                value = text.Trim();

            return value;
        }

        public double TrimConvDouble(string text)
        {
            double value = 0;
            if (text.Trim() != "")
                value = Math.Round(Convert.ToDouble(text.Trim()), 2);

            return value;
        }
    }
}
