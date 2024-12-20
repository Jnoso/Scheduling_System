using MySql.Data.MySqlClient;
using Scheduling_System.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Scheduling_System.DBClasses
{
    internal class UpdateCustomerData
    {
        TextInfo textinfo = CultureInfo.CurrentCulture.TextInfo;
        AddCustomerData addCustomerData = new AddCustomerData();

        public int AddressTableData(string address, int cityID, string phoneNum, out string addressName, out string phone)
        {
            string formattedAddress = addCustomerData.CapitalizeAddress(address);

            //Checks Address exists with CityID.
            //Checks phone already exists in existing address
            //Inserts Address with CityID if it does not exist
            string query = "SELECT addressId FROM address WHERE address = @address AND cityId = @cityId";

            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn))
            {
                cmd.Parameters.AddWithValue("@address", formattedAddress);
                cmd.Parameters.AddWithValue("@cityId", cityID);
                cmd.Parameters.AddWithValue("@phone", phoneNum);

                object addressIdData = cmd.ExecuteScalar();

                if (addressIdData != null)
                {
                    int addressID = Convert.ToInt32(addressIdData);

                    //Verify user input phone to database phone
                    query = "SELECT phone FROM address WHERE addressId = @addressId";

                    cmd.Parameters.AddWithValue("@addressId", addressID);
                    cmd.CommandText = query;

                    object dbPhone = cmd.ExecuteScalar();
                    string dbPhoneNum = dbPhone.ToString();

                    string dbPhoneNumDigit = Regex.Replace(dbPhoneNum, @"[^0-9]+", "");
                    string inputPhoneNumDigit = Regex.Replace(phoneNum, @"[^0-9]+", "");

                    if (dbPhoneNumDigit != inputPhoneNumDigit)
                    {
                        string updateQuery = "UPDATE address SET phone = @phone WHERE addressId = @addressId";
                        cmd.CommandText = updateQuery;
                        cmd.ExecuteNonQuery();
                    }
                    addressName = formattedAddress;
                    phone = phoneNum;
                    return addressID;
                    
                }

                query = "INSERT INTO address VALUES (NULL, @address, '', @cityId, '00000', @phone, NOW(), 'user', NOW(), 'info');" +
                    "SELECT LAST_INSERT_ID();";
                cmd.CommandText = query;

                int newAddressID = Convert.ToInt32(cmd.ExecuteScalar());
                addressName = formattedAddress;
                phone = phoneNum;
                return newAddressID;
            }
        }

        public string CustomerTableData(int customerID, string customerName, int addressId)
        {
            var formattedName = customerName.Trim().ToLower();
            formattedName = textinfo.ToTitleCase(formattedName);

            string query = "UPDATE customer set addressId = @addressId, customerName = @customerName WHERE customerId = @customerId";

            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn))
            {
                cmd.Parameters.AddWithValue("customerId", customerID);
                cmd.Parameters.AddWithValue("@customerName", formattedName);
                cmd.Parameters.AddWithValue("@addressId", addressId);
                cmd.ExecuteNonQuery();

                return formattedName;
            }
        }
    }
}
