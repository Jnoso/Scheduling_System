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
    internal class DeleteCustomerData
    {
        public void deleteFromSQLandDGV (int customerID, int addressID)
        {
            //Obtain all appointment associated with customerID
            string apptQuery = @"SELECT appointmentId FROM appointment WHERE customerId = @customerId";

            List<int> appointmentIDList = new List<int>();

            using (MySqlCommand cmd = new MySqlCommand(apptQuery, DBConnection.conn))
            {
                cmd.Parameters.AddWithValue("@customerId", customerID);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        appointmentIDList.Add(Convert.ToInt32(reader["appointmentId"]));
                    }
                }
            }

            //Delete Appointment with related customerID
            string query = @"DELETE from appointment WHERE customerId = @customerId";

            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn))
            {
                cmd.Parameters.AddWithValue("@customerId", customerID);
                cmd.ExecuteNonQuery();

            }

            //Delete from Calendar DGV
            foreach (int i in appointmentIDList)
            {
                DgvControls.AppointmentDelete(i);
            }

            //SELECT CustomerID that will be deleted
            string SELECTquery = @"SELECT customerId FROM customer WHERE addressId = @addressId";

            List<int> customerIDList = new List<int>();

            using (MySqlCommand cmd = new MySqlCommand(SELECTquery, DBConnection.conn))
            {
                cmd.Parameters.AddWithValue("@addressId", addressID);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        customerIDList.Add(Convert.ToInt32(reader["customerId"]));
                    }
                }
            }

            //Delete Customer with related AddressID
            string deleteCustomer = @"DELETE from customer WHERE addressId = @addressId";

            using (MySqlCommand cmd = new MySqlCommand(deleteCustomer, DBConnection.conn))
            {
                cmd.Parameters.AddWithValue("@addressId", addressID);
                cmd.ExecuteNonQuery();
            }


            //Delete Address with related AddressID
            string deleteAddress = @"DELETE from address WHERE addressId = @addressId";

            using (MySqlCommand cmd = new MySqlCommand(deleteAddress, DBConnection.conn))
            {
                cmd.Parameters.AddWithValue("@addressId", addressID);
                cmd.ExecuteNonQuery();
            }

            //Delete from DataGridView
            foreach (int i in customerIDList)
            {
                DgvCustomerData.CustomerDelete(i);
            }
        }
    }
}
