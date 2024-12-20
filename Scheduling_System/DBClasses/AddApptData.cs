using MySql.Data.MySqlClient;
using Scheduling_System.CalendarClasses;
using Scheduling_System.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling_System.DBClasses
{
    internal class AddApptData
    {
        
        public int AppointmentTableUpdate (int customerId, string type, string description, DateTime startDate, DateTime endDate)
        {
            DateTime utcStartDate = startDate.ToUniversalTime();
            DateTime utcEndDate = endDate.ToUniversalTime();

            int userId = UserLogin.UserId;

            string query = "INSERT INTO appointment VALUES (NULL, @customerId, @userId, 'title', @description, 'location', 'contact', @type, 'url', @startDate, @endDate, NOW(), 'user', NOW(), 'info');" +
                "SELECT LAST_INSERT_ID();"; 

            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn))
            {
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@startDate", utcStartDate);
                cmd.Parameters.AddWithValue("@endDate", utcEndDate);

                int appointmentId = Convert.ToInt32(cmd.ExecuteScalar());

                return appointmentId;
            }
        }

        public void AddtoDGV(int appointmentID, string customerName, string type, string description, DateTime startDate, DateTime endDate)
        {
            var newAppointment = new DgvAppointment(appointmentID, customerName, type, description, startDate, endDate);
            DgvControls.AppointmentAdd(newAppointment);
        }
        
    }
}
