using Org.BouncyCastle.Asn1.Mozilla;
using Scheduling_System.DBClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling_System.CalendarClasses
{
    internal class ReportsControl
    {
        ApptInfoQuery apptInfoQuery = new ApptInfoQuery();

        public void DisplayApptType(Reports report)
        {
            var reportSummary = apptInfoQuery.GetApptType();

            report.RptTextBox.Clear();

            //Lambda Expression to loop through the query list
            //Converts month number to month Name
            //And append it to the richtextbox field
            reportSummary.ForEach(i =>
            {
                string month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i.Month);
                report.RptTextBox.AppendText($"Type: {i.Type}, Month: {month}, Count: {i.Count}\n");
            });
        }

        public void DisplayUserSchedule(Reports report)
        {
            var userSchedule = apptInfoQuery.GetUserSchedule();

            report.RptTextBox.Clear();

            //Lambda Expression to Group the userSchedule list by UserId
            var groupedSchedule = userSchedule.GroupBy(appt => appt.UserId);

            int previoususerId = 0;

            foreach(var group in groupedSchedule)
            {
                int userId = group.Key;
                report.RptTextBox.AppendText($"User: {userId}");
                
                foreach(var appt in group)
                {
                    if (previoususerId != userId)
                    {
                        report.RptTextBox.AppendText($" UserName: {appt.UserName}\nStart: {appt.Start} End: {appt.End}\n");
                        previoususerId = userId;
                    }
                    else
                    {
                        report.RptTextBox.AppendText($"Start: {appt.Start} End: {appt.End}\n");
                    }
                }
                report.RptTextBox.AppendText("\n");
            }
        }

        public void DisplayCustomerSchedule(Reports report)
        {
            var usertoCustomer = apptInfoQuery.GetUserToCustomer();

            report.RptTextBox.Clear();

            //Lambda expression to loop through the aggregate list
            //to print to textbox
            usertoCustomer.ForEach(i => report.RptTextBox.AppendText($"UserId: {i.UserId},    UserName: {i.UserName},    No. of Unique Customers with Appointment to User: {i.Count}\n"));
        }
    }
}
