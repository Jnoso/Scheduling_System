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
    internal class CheckApptTime
    {
        ApptInfoQuery apptInfoQuery = new ApptInfoQuery();

        public bool compareDateTime (DateTime startDate, DateTime endDate)
        {
            bool invalid = true;

            if (startDate >= endDate)
            {
                return invalid;
            }
            else if (startDate < DateTime.Now)
            {
                return invalid;
            }

            return invalid = false;
        }

        //Check business hours
        public bool CheckBusinessHours (DateTime startDate, DateTime endDate)
        {
            bool invalid = true;
            var est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

            var estStartDate = TimeZoneInfo.ConvertTime(startDate, est);
            string estStartDay = estStartDate.DayOfWeek.ToString();
            var estEndDate = TimeZoneInfo.ConvertTime(endDate, est);
            string estEndDay = estEndDate.DayOfWeek.ToString();

            if (estStartDay == "Saturday" || estEndDay == "Saturday" )
            {
                return invalid;
            }
            else if(estStartDay == "Sunday" || estEndDay =="Sunday")
            {
                return invalid;
            }

            if ((estStartDate.TimeOfDay < new TimeSpan(9,0,0)) || (estStartDate.TimeOfDay > new TimeSpan(17,0,0)))
            {
                return invalid;
            }
            else if ((estEndDate.TimeOfDay < new TimeSpan(9,0,0)) || (estEndDate.TimeOfDay > new TimeSpan(17,0,0)))
            {
                return invalid;
            }

            return invalid = false;
        }

        //Check overlapping appointments
        public bool checkOverlapping (DateTime startDateInput, DateTime endDateInput)
        {
            bool invalid = true;
            int userId = UserLogin.UserId;

            DateTime utcStartDateInput = startDateInput.ToUniversalTime();
            DateTime utcEndDateInput = endDateInput.ToUniversalTime();
            

            //Query of StartDate and EndDate for userId
            var allUserAppointment = apptInfoQuery.ApptTimes(userId);

            foreach( var appt in allUserAppointment)
            {
                if (utcStartDateInput < appt.End && utcEndDateInput > appt.Start)
                {
                    MessageBox.Show("Appointment overlaps with existing appointment", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return invalid;
                }
            }

            return invalid = false;
        }

        public bool checkOverlappingUpdate(DateTime startDateInput, DateTime endDateInput, int appointmentID)
        {
            bool invalid = true;
            int userId = UserLogin.UserId;

            DateTime utcStartDateInput = startDateInput.ToUniversalTime();
            DateTime utcEndDateInput = endDateInput.ToUniversalTime();


            //Query of StartDate and EndDate for userId except the appointmentID being modified
            var allUserAppointment = apptInfoQuery.ApptTimesUpdate(userId, appointmentID);

            //Checks all appointment for user except the appointment being modified
            foreach (var appt in allUserAppointment)
            {
                if (utcStartDateInput < appt.End && utcEndDateInput > appt.Start)
                {
                    MessageBox.Show("Appointment overlaps with existing appointment", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return invalid;
                }
            }

            return invalid = false;
        }
    }
}
