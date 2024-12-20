using Scheduling_System.DBClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling_System.CalendarClasses
{
    internal class UpdateApptControl
    {
        CheckApptTime checkApptTime = new CheckApptTime();

        UpdateApptData updateApptData = new UpdateApptData();

        public void DisplayLocalTimeZone(CalendarUpdate calendarUpdate)
        {
            TimeZoneInfo localTimeZone = TimeZoneInfo.Local;

            calendarUpdate.TimeZone1.Text = localTimeZone.ToString();
            calendarUpdate.TimeZone2.Text = localTimeZone.ToString();
        }

        public void FillUpdateForm(CalendarUpdate calendarUpdate, int appointmentId)
        {
            for (int i = 0; i< DgvControls.dgvAppointment.Count; i++)
            {
                if (DgvControls.dgvAppointment[i].ID == appointmentId)
                {
                    calendarUpdate.TypeBox.Text = DgvControls.dgvAppointment[i].Type;
                    calendarUpdate.TextDescription.Text = DgvControls.dgvAppointment[i].Description;
                    DateTime startDate = DgvControls.dgvAppointment[i].StartDate;
                    calendarUpdate.StartTimePicker.Value = DateTime.Today.Add(startDate.TimeOfDay);
                    calendarUpdate.StartDatePicker.Value = (DgvControls.dgvAppointment[i].StartDate).Date;
                    DateTime endDate = DgvControls.dgvAppointment[i].EndDate;
                    calendarUpdate.EndTimePicker.Value = DateTime.Today.Add(endDate.TimeOfDay);
                    calendarUpdate.EndDatePicker.Value = (DgvControls.dgvAppointment[i].EndDate).Date;
                }
            }
        }

        public bool InputValidate(CalendarUpdate calendarUpdate, int appointmentID)
        {
            bool valid = false;
            string type = calendarUpdate.TypeBox.Text;
            DateTime startDate = calendarUpdate.StartDatePicker.Value.Date + calendarUpdate.StartTimePicker.Value.TimeOfDay;
            DateTime endDate = calendarUpdate.EndDatePicker.Value.Date + calendarUpdate.EndTimePicker.Value.TimeOfDay;

            if (string.IsNullOrWhiteSpace(type))
            {
                MessageBox.Show("Please select type of appointment", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return valid;
            }

            //Validate start/end date input
            if (checkApptTime.compareDateTime(startDate, endDate))
            {
                MessageBox.Show("Start Date cannot be after End Date or before current date", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return valid;
            }

            //Checks if in business hours
            if (checkApptTime.CheckBusinessHours(startDate, endDate))
            {
                MessageBox.Show("Appointment is outside EST business hours. Mon-Fri. 9AM-5PM", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return valid;
            }

            //Checks overlapping appointment
            if (checkApptTime.checkOverlappingUpdate(startDate, endDate, appointmentID))
            {
                return valid;
            }

            return valid = true;
        }

        public void UpdatetoSQLandDGV(CalendarUpdate calendarUpdate, int appointmentID, Calendar calendar)
        {
            string customer = (string)calendarUpdate.DgvApptCustomer.CurrentRow.Cells["Name"].Value;
            int customerId = (int)calendarUpdate.DgvApptCustomer.CurrentRow.Cells["ID"].Value;
            string type = calendarUpdate.TypeBox.Text;
            int appointmentid = appointmentID;
            DateTime startDate = calendarUpdate.StartDatePicker.Value.Date + calendarUpdate.StartTimePicker.Value.TimeOfDay;
            DateTime endDate = calendarUpdate.EndDatePicker.Value.Date + calendarUpdate.EndTimePicker.Value.TimeOfDay;

            DateTime utcStartDate = startDate.ToUniversalTime();
            DateTime utcEndDate = endDate.ToUniversalTime();

            try
            {
                updateApptData.UpdateAppointmentTable(appointmentid, customerId, type, calendarUpdate.TextDescription.Text, startDate, endDate);

                DgvControls.AppointmentUpdate(appointmentid, customer, type, calendarUpdate.TextDescription.Text, startDate, endDate);

                calendarUpdate.Close();

                var dgv = calendar.DgvAppt;
                dgv.ClearSelection();
                dgv.Refresh();

                MessageBox.Show("Appointment Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Adding to Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
