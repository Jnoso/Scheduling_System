using Scheduling_System.CalendarClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling_System
{
    public partial class Reports : Form
    {
        ReportsControl reportsControl = new ReportsControl();
        public RichTextBox RptTextBox => rptTextBox;

        public Reports()
        {
            InitializeComponent();

            rptTextBox.Clear();
            if (apptTypeRadio.Checked)
            {
                reportsControl.DisplayApptType(this);
            }
        }

        private void apptTypeRadio_CheckedChanged(object sender, EventArgs e)
        {
            if(apptTypeRadio.Checked)
            {
                rptTextBox.Clear();
                reportsControl.DisplayApptType(this);
            }
        }

        private void userScheduleRadio_CheckedChanged(object sender, EventArgs e)
        {
            if(userScheduleRadio.Checked)
            {
                rptTextBox.Clear();
                reportsControl.DisplayUserSchedule(this);
            }
        }

        private void customerScheduleRadio_CheckedChanged(object sender, EventArgs e)
        {
            if(customerScheduleRadio.Checked)
            {
                rptTextBox.Clear();
                reportsControl.DisplayCustomerSchedule(this);
            }
        }
    }
}
