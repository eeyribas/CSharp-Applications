using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolboxProperties.ToolboxProperty
{
    public class ComboBoxMethods
    {
        public int SelectedIndexValue(int comboboxIndex, int arrayIndex)
        {
            int index = comboboxIndex;
            if (index >= 0 && index < arrayIndex)
                return index;

            return -1;
        }
    }
}
