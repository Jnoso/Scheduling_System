using Scheduling_System.CalendarClasses;
using Scheduling_System.Classes;
using Scheduling_System.DBClasses;
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
    public partial class Calendar : UserControl
    {
        public DataGridView DgvAppt => dgvAppt;

        CalendarUserControl calendarUserControl = new CalendarUserControl();
        ApptInfoQuery apptInfoQuery = new ApptInfoQuery();
        private static bool calIsInitialized = false;
        public Calendar()
        {
            InitializeComponent();

            if(!calIsInitialized)
            {
                dgvAppt.DataSource = DgvControls.dgvAppointment;
                DgvControls.InitializeAppointDGV();
                calIsInitialized = true;
            }

            listBoxBtn.Top = listBoxApt.Bottom - 30;
            listBoxBtn.Left = listBoxApt.Right - 100;
        }

        private void addAppointment_Click(object sender, EventArgs e)
        {
            CalendarAdd calendarAdd = new CalendarAdd();
            
            if(calendarUserControl.CheckCustomerExists())
            {
                calendarAdd.Show();
            }
            else
            {
                MessageBox.Show("There are no customers to make an appointment. Please create a customer first");
            }
        }

        private void updateAppointment_Click(object sender, EventArgs e)
        {

            if (dgvAppt.CurrentRow == null || dgvAppt.CurrentRow.Selected == false)
            {
                MessageBox.Show("Please select an appointment to update");
                return;
            }
            else
            {
                CalendarUpdate calendarUpdate = new CalendarUpdate(this);
                calendarUpdate.Show();
            }
        }

        private void delAppointment_Click(object sender, EventArgs e)
        {

            if (dgvAppt.CurrentRow == null || dgvAppt.CurrentRow.Selected == false)
            {
                MessageBox.Show("Please select an appointment to delete");
                return;
            }
            else
            {
                int appointmentID = (int)DgvAppt.CurrentRow.Cells["ID"].Value;

                calendarUserControl.DeleteFromSQLandDGV(appointmentID);
                dgvAppt.ClearSelection();
                dgvAppt.Refresh();
            }
        }

        private void detailBtn_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = datePicker.Value.Date;

            var appointmentList = apptInfoQuery.AppointmentByDay(selectedDate);
            string spaceFive = "     ";
            string spaceTen = "          ";
            string spaceThree = "   ";

            listBoxApt.Items.Clear();
            listBoxApt.Items.Add($"ApptID {spaceThree} UserID {spaceThree} CustomerID {spaceThree} Type {spaceTen}{spaceFive} Start {spaceTen}{spaceTen}{spaceTen}{spaceTen} End");
            foreach (var appt in appointmentList)
            {
                listBoxApt.Items.Add($"{spaceThree} {appt.AppointmentID} {spaceFive}{spaceFive} {appt.UserID} {spaceFive}{spaceFive} {appt.CustomerID} {spaceFive}{spaceFive} {appt.Type} {spaceFive} {appt.Start} {spaceFive} {appt.End}");
            }

            listBoxBtn.Visible = true;
            listBoxApt.Visible = true;
            
        }

        private void listBoxBtn_Click(object sender, EventArgs e)
        {
            listBoxApt.Visible = false;
            listBoxBtn.Visible = false;
        }

        private void reportBtn_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.Show();
        }
    }
}
