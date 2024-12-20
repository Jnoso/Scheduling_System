using Scheduling_System.Classes;
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
    public partial class ScheduleSystem : Form
    {
        private Calendar calendarUserControl;
        private CustomerRecord customerRecordUserControl;

        public ScheduleSystem()
        {
            InitializeComponent();

            //Adds both user control to panel
            customerRecordUserControl = new CustomerRecord();
            calendarUserControl = new Calendar();
            userControlSwitch.AddControltoPanel(customerRecordUserControl, splitContainer1.Panel2);
            userControlSwitch.AddControltoPanel(calendarUserControl, splitContainer1.Panel2);

            //Initially shows Customer Records User Control
            calendarUserControl.Visible = false;
            customerRecordUserControl.Visible = true;

        }

        //Select customer record user control
        private void customerButton_CheckedChanged(object sender, EventArgs e)
        {
            if(customerButton.Checked)
            {
                customerRecordUserControl.Visible = true;
                calendarUserControl.Visible = false;
                label1.Text = "Customer Record";
            }
        }

        //Select calendar record user control
        private void calendarButton_CheckedChanged(object sender, EventArgs e)
        {
            if(calendarButton.Checked)
            {
                customerRecordUserControl.Visible = false;
                calendarUserControl.Visible = true;
                label1.Text = "Calendar";
            }
        }


        //When this window is closed, disconnect from database
        private void ScheduleSystem_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
