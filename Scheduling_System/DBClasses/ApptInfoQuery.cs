using MySql.Data.MySqlClient;
using Scheduling_System.CalendarClasses;
using Scheduling_System.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling_System.DBClasses
{
    internal class ApptInfoQuery
    {
        public List<(DateTime Start, DateTime End)> ApptTimes (int userId)
        {
            var userAppointmentTime = new List<(DateTime Start, DateTime End)>();

            string query = @"SELECT start, end FROM appointment WHERE userId = @userId";

            using (MySqlCommand cmd = new MySqlCommand (query, DBConnection.conn))
            {
                cmd.Parameters.AddWithValue("@userId", userId);

                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var start = DateTime.Parse(reader["start"].ToString());
                            var end = DateTime.Parse(reader["end"].ToString());
                            userAppointmentTime.Add((Start: start, End: end ));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error retrieving appointment information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return userAppointmentTime;
        }

        public List<(DateTime Start, DateTime End)> ApptTimesUpdate(int userId, int appointmentId)
        {
            var userAppointmentTime = new List<(DateTime Start, DateTime End)>();

            string query = @"SELECT start, end FROM appointment WHERE userId = @userId AND appointmentId != @appointmentId";

            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn))
            {
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@appointmentId", appointmentId);

                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var start = DateTime.Parse(reader["start"].ToString());
                            var end = DateTime.Parse(reader["end"].ToString());
                            userAppointmentTime.Add((Start: start, End: end));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error retrieving appointment information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return userAppointmentTime;
        }

        //Get all appointment on a specific date
        public List<(int AppointmentID, int UserID, int CustomerID, string Type, DateTime Start, DateTime End)> AppointmentByDay (DateTime startDate)
        {
            var allAppointment = new List<(int AppointmentID, int UserID, int CustomerID, string Type, DateTime Start, DateTime End)>();

            DateTime utcDateTime = startDate.ToUniversalTime();

            string query = @"SELECT appointmentId, userId, customerId, type, start, end FROM appointment WHERE DATE(start) = @start";

            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn))
            {
                cmd.Parameters.AddWithValue("@start", utcDateTime);

                try
                {
                    using(MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            var appointmentID = Convert.ToInt32(reader["appointmentId"]);
                            var userID = Convert.ToInt32(reader["userId"]);
                            var customerID = Convert.ToInt32(reader["customerId"]);
                            string type = reader["type"].ToString();
                            var startUTC = DateTime.Parse(reader["start"].ToString());
                            var start = TimeZoneInfo.ConvertTimeFromUtc(startUTC, TimeZoneInfo.Local);
                            var endUTC = DateTime.Parse(reader["end"].ToString());
                            var end = TimeZoneInfo.ConvertTimeFromUtc(endUTC, TimeZoneInfo.Local);
                            allAppointment.Add((AppointmentID: appointmentID, UserID: userID, CustomerID: customerID, Type: type, Start: start, End: end));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error retrieving appointment information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return allAppointment;
        }


        //For first report getting Appointment Type to Month
        public List<(string Type, int Month, int Count)> GetApptType ()
        {
            var apptType = new List<(string Type, int Month, int Count)>();

            string query = "SELECT type, MONTH(start) AS month, COUNT(*) AS count FROM appointment GROUP BY type, MONTH(start)";

            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn))
            {
                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var type = reader["type"].ToString();
                            var month = Convert.ToInt32(reader["month"]);
                            var count = Convert.ToInt32(reader["count"]);
                            apptType.Add((Type: type, Month: month, Count: count));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error retrieving appointment type count", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return apptType;
        }

        //For second report, getting schedule for each user
        public List<(int UserId, string UserName, DateTime Start, DateTime End)> GetUserSchedule()
        {
            var userSchedule = new List<(int UserId, string UserName, DateTime Start, DateTime End)>();

            string query = "SELECT user.userId, user.userName, appointment.start, appointment.end FROM appointment INNER JOIN user ON appointment.userId = user.userId";

            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn))
            {
                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int userId = Convert.ToInt32(reader["userId"]);
                            string userName = reader["userName"].ToString();
                            DateTime utcStart = Convert.ToDateTime(reader["start"]);
                            DateTime start = TimeZoneInfo.ConvertTimeFromUtc(utcStart, TimeZoneInfo.Local);
                            DateTime utcEnd = Convert.ToDateTime(reader["end"]);
                            DateTime end = TimeZoneInfo.ConvertTimeFromUtc(utcEnd, TimeZoneInfo.Local);
                            userSchedule.Add((UserId: userId, UserName: userName, Start: start, End: end));
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error retrieving user schedule", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return userSchedule;
        }

        //Third report, getting how many unique customers have appointment with user
        public List<(int UserId, string UserName, int Count)> GetUserToCustomer()
        {
            var customerSchedule = new List<(int UserId, string UserName, int Count)>();

            string query = @"SELECT user.userId, user.userName, COUNT(DISTINCT customer.customerId) AS customerCount
                    FROM user
                    INNER JOIN appointment ON user.userId = appointment.userId
                    INNER JOIN customer ON appointment.customerId = customer.customerId
                    GROUP BY user.userId, user.userName";

            using(MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn))
            {
                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int userId = Convert.ToInt32(reader["userId"]);
                            string userName = reader["userName"].ToString();
                            int count = Convert.ToInt32(reader["customerCount"]);
                            customerSchedule.Add((UserId: userId, UserName: userName, Count: count));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error retrieving customer count", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return customerSchedule;
        }

        //Get User appointments
        public List<DateTime> UserAppointmentAlert(int userId)
        {
            var appointmentStart = new List<DateTime>();

            string query = @"SELECT start FROM appointment WHERE userId = @userId";

            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn))
            {
                cmd.Parameters.AddWithValue("@userId", userId);

                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime utcStart = Convert.ToDateTime(reader["start"]);
                            DateTime start = TimeZoneInfo.ConvertTimeFromUtc(utcStart, TimeZoneInfo.Local);
                            appointmentStart.Add(start);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error retrieving Start Appointment Times", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return appointmentStart;
        }
    }
}
