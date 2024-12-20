using MySql.Data.MySqlClient;
using Scheduling_System.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling_System.DBClasses
{
    internal class CustomerInfoQuery
    {

        //Query Customer Info using CustomerId
        public Customerdb CustomerIDQuery (int customerId)
        {
            string query = @"
                SELECT
                    customer.customerName,
                    address.address,
                    address.phone,
                    city.city,
                    country.country
                FROM
                    customer
                INNER JOIN address ON customer.addressId = address.addressId
                INNER JOIN city ON address.cityId = city.cityId
                INNER JOIN country ON city.countryId = country.countryId
                WHERE customer.customerId = @customerId";

            Customerdb customerInformation = null;

            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn))
            {
                cmd.Parameters.AddWithValue("@customerId", customerId);

                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            customerInformation = new Customerdb
                            {
                                CustomerName = reader["customerName"].ToString(),
                                Address = reader["address"].ToString(),
                                PhoneNumber = reader["phone"].ToString(),
                                City = reader["city"].ToString(),
                                Country = reader["country"].ToString()
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error retrieving customer information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return customerInformation;
        }

        //Query all Primary Key for Customer
        public CustomerKeyDb CustomerKeyQuery(int customerId)
        {
            string query = @"
                SELECT
                    country.countryId,
                    city.cityId,
                    address.addressId
                FROM
                    customer
                INNER JOIN address ON customer.addressId = address.addressId
                INNER JOIN city ON address.cityId = city.cityId
                INNER JOIN country ON city.countryId = country.countryId
                WHERE customer.customerId = @customerId";

            CustomerKeyDb customerPrimaryKey = null;

            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn))
            {
                cmd.Parameters.AddWithValue("@customerId", customerId);

                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            customerPrimaryKey = new CustomerKeyDb
                            {
                                CountryID = Convert.ToInt32(reader["countryId"]),
                                CityID = Convert.ToInt32(reader["countryId"]),
                                AddressID = Convert.ToInt32(reader["addressId"])
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error retrieving customer key", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return customerPrimaryKey;
        }

        //Query to see if customer table has customer
        public bool CheckCustomerTable()
        {
            bool exist = false;
            string query = @"SELECT customerId FROM customer";

            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn))
            {
                var firstData = cmd.ExecuteScalar();

                if (firstData != null)
                {
                    return exist = true;
                }

                return exist;
            }
        }

        //Query Customer Name from Customer Table
        public List<string> CustomerName()
        {
            List<string> customers = new List<string>();

            string query = @"SELECT customerName FROM customer";

            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn))
            {
                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(reader["customerName"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error retrieving customer name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return customers;
        }
    }
}
