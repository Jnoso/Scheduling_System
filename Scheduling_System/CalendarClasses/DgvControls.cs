using MySql.Data.MySqlClient;
using Scheduling_System.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling_System.CalendarClasses
{
    internal class DgvControls
    {
        public static BindingList<DgvAppointment> dgvAppointment = new BindingList<DgvAppointment>();

        //Adds to dgvAppointment List
        public static void AppointmentAdd (DgvAppointment appointment)
        {
            dgvAppointment.Add(appointment);
        }

        //Modify to dgvAppointment List
        public static void AppointmentUpdate (int appointmentID, string customerName, string type, string description, DateTime startDate, DateTime endDate)
        {
            for (int i = 0; i <dgvAppointment.Count; i++)
            {
                if (dgvAppointment[i].ID == appointmentID)
                {
                    dgvAppointment[i].Name = customerName;
                    dgvAppointment[i].Type = type;
                    dgvAppointment[i].Description = description;
                    dgvAppointment[i].StartDate = startDate;
                    dgvAppointment[i].EndDate = endDate;
                }
            }
        }

        //Delete to dgvAppointment List
        public static void AppointmentDelete (int appointmentID)
        {
            var appointmentToRemove = dgvAppointment.FirstOrDefault(x => x.ID == appointmentID);
            if(appointmentToRemove != null)
            {
                dgvAppointment.Remove(appointmentToRemove);
            }
        }

        //Initialize Appointment DGV
        public static void InitializeAppointDGV()
        {
            string query = @"
                SELECT
                    appointment.appointmentId,
                    customer.customerName,
                    appointment.type,
                    appointment.description,
                    appointment.start,
                    appointment.end
                FROM
                    appointment
                INNER JOIN customer ON appointment.customerId = customer.customerId";

            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn))
            {
                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            int id = Convert.ToInt32(reader["appointmentId"]);
                            string customerName = reader["customerName"].ToString();
                            string type = reader["type"].ToString();
                            string description = reader["description"].ToString();
                            DateTime start = DateTime.Parse(reader["start"].ToString());
                            DateTime localStart = TimeZoneInfo.ConvertTimeFromUtc(start, TimeZoneInfo.Local);
                            DateTime end = DateTime.Parse(reader["end"].ToString());
                            DateTime localEnd = TimeZoneInfo.ConvertTimeFromUtc(end, TimeZoneInfo.Local);

                            var dgvData = new DgvAppointment(id, customerName, type, description, localStart, localEnd);
                            AppointmentAdd(dgvData);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error loading to Calendar DGV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
