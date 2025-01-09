using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolboxProperties.ToolboxProperty
{
    public class ButtonMethods
    {
        public void EnableAndBackColor(Button button, bool enableState, Color backColor)
        {
            DelegatedMethods.EnableButton(button, enableState);
            DelegatedMethods.BackColorButton(button, backColor);
        }
    }
}
