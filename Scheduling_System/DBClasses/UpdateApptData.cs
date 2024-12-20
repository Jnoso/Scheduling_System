using MySql.Data.MySqlClient;
using Scheduling_System.CalendarClasses;
using Scheduling_System.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling_System.DBClasses
{
    internal class UpdateApptData
    {
        public void UpdateAppointmentTable(int appointmentID, int customerId, string type, string description, DateTime startDate, DateTime endDate)
        {
            DateTime utcStartDate = startDate.ToUniversalTime();
            DateTime utcEndDate = endDate.ToUniversalTime();

            int userId = UserLogin.UserId;

            string query = "UPDATE appointment set customerId = @customerId, userId = @userId, description = @description, type = @type, start = @startDate, end = @endDate WHERE appointmentId = @appointmentId";

            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn))
            {
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@startDate", utcStartDate);
                cmd.Parameters.AddWithValue("@endDate", utcEndDate);
                cmd.Parameters.AddWithValue("@appointmentId", appointmentID);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
