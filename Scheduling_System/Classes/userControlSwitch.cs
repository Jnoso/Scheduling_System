using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling_System.Classes
{
    internal class userControlSwitch
    {
        public static void AddControltoPanel(UserControl control, Panel targetpanel)
        {
            control.Dock = DockStyle.Fill;
            targetpanel.Controls.Add(control);
        }
    }
}
