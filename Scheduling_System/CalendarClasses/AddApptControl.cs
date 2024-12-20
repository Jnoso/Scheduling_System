using Google.Protobuf.Reflection;
using Scheduling_System.Classes;
using Scheduling_System.DBClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling_System.CalendarClasses
{
    internal class AddApptControl
    {
        CustomerInfoQuery customerInfoQuery = new CustomerInfoQuery();
        CheckApptTime checkApptTime = new CheckApptTime();
        AddApptData addApptData = new AddApptData();

        //Display local time zone
        public void DisplayLocalTimeZone(CalendarAdd calendarAdd)
        {
            TimeZoneInfo localTimeZone = TimeZoneInfo.Local;

            calendarAdd.TimeZone1.Text = localTimeZone.ToString();
            calendarAdd.TimeZone2.Text = localTimeZone.ToString();
        }

        //Validates all fields are populated and correct
        public bool InputValidate (CalendarAdd calendarAdd)
        {
            bool valid = false;
            string type = calendarAdd.TypeBox.Text;
            DateTime startDate = calendarAdd.StartDatePicker.Value.Date + calendarAdd.StartTimePicker.Value.TimeOfDay;
            DateTime endDate = calendarAdd.EndDatePicker.Value.Date + calendarAdd.EndTimePicker.Value.TimeOfDay;

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
            if (checkApptTime.checkOverlapping(startDate, endDate))
            {
                return valid;
            }

            return valid = true;
        }

        public void AddtoSQLandDGV (CalendarAdd calendarAdd)
        {
            string customer = (string)calendarAdd.DgvApptCustomer.CurrentRow.Cells["Name"].Value;
            int customerId = (int)calendarAdd.DgvApptCustomer.CurrentRow.Cells["ID"].Value;
            string type = calendarAdd.TypeBox.Text;
            DateTime startDate = calendarAdd.StartDatePicker.Value.Date + calendarAdd.StartTimePicker.Value.TimeOfDay;
            DateTime endDate = calendarAdd.EndDatePicker.Value.Date + calendarAdd.EndTimePicker.Value.TimeOfDay;

            DateTime utcStartDate = startDate.ToUniversalTime();
            DateTime utcEndDate = endDate.ToUniversalTime();

            try
            {
                int appointmentID = addApptData.AppointmentTableUpdate(customerId, type, calendarAdd.TextDescription.Text, startDate, endDate);

                addApptData.AddtoDGV(appointmentID, customer, type, calendarAdd.TextDescription.Text, startDate, endDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Adding to Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
