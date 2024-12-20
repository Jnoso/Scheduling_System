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
    internal class DeleteApptData
    {
        public void DeleteFromSQLandDGV(int appointmentID)
        {
            string query = @"DELETE from appointment WHERE appointmentId = @appointmentId";

            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn))
            {
                cmd.Parameters.AddWithValue("@appointmentId", appointmentID);
                cmd.ExecuteNonQuery();
            }

            DgvControls.AppointmentDelete(appointmentID);
        }
    }
}
