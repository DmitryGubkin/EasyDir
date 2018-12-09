using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace EasyDir
{
    class CCMRC : System.Windows.Forms.ProfessionalColorTable // Custom Contex Menu Render Colors
    {
        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(45, 45, 48); }
        }

        public override Color MenuItemBorder
        {
            get { return Color.FromArgb(37, 37, 38); }
        }

    }
}
