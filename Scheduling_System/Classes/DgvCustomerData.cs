using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling_System.Classes
{
    internal class DgvCustomerData
    {
        public static BindingList<DgvCustomer> dgvCustomer = new BindingList<DgvCustomer>();

        //Adds to dgvCustomer List
        public static void CustomerAdd (DgvCustomer customer)
        {
            dgvCustomer.Add(customer);
        }

        //Update dgvCustomer List
        public static void CustomerUpdate (int customerID, string customerName, string address, string phone, string city, string country)
        {
            for (int i = 0; i < dgvCustomer.Count; i++)
            {
                if (dgvCustomer[i].ID == customerID)
                {
                    dgvCustomer[i].Name = customerName;
                    dgvCustomer[i].Address = address + " " + city + " " + country;
                    dgvCustomer[i].Phone = phone;
                }
            }
        }

        //Delete from dgvCustomer List
        public static void CustomerDelete (int customerID)
        {
            var customerToRemove = dgvCustomer.FirstOrDefault(x => x.ID == customerID);
            if (customerToRemove != null)
            {
                dgvCustomer.Remove(customerToRemove);
                
            }
        }

        //Initialize DGV Data Table
        public static void InitializeCustomerDGV()
        {
            //if(dgvCustomer.Count > 0)
            //{
            //    return;
            //}
            string query = @"
                SELECT
                    customer.customerId,
                    customer.customerName,
                    address.address,
                    address.phone,
                    city.city,
                    country.country
                FROM
                    customer
                INNER JOIN address ON customer.addressId = address.addressId
                INNER JOIN city ON address.cityId = city.cityId
                INNER JOIN country ON city.countryId = country.countryId";

            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn))
            {
                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["customerId"]);
                            string CustomerName = reader["customerName"].ToString();
                            string Address = reader["address"].ToString();
                            string Phone = reader["phone"].ToString();
                            string City = reader["city"].ToString();
                            string Country = reader["country"].ToString();

                            var dgvData = new DgvCustomer(id, CustomerName, Address + " " + City + " " + Country, Phone);
                            CustomerAdd(dgvData);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error loading to DGV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
