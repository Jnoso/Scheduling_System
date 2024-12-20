using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Scheduling_System.Classes;

namespace Scheduling_System.DBClasses
{
    internal class AddCustomerData
    {
        TextInfo textinfo = CultureInfo.CurrentCulture.TextInfo;

        //Check Country exist or Add Country
        //Return countryID and Country Name
        public int CountryTableData (string country, out string countryName)
        {
            //Formats the country input
            var clean = country.Trim().ToLower();
            if (clean == "usa" || clean == "us")
            {
                clean = "us".ToUpper();
            }
            else
            {
                clean = textinfo.ToTitleCase(clean);
            }

            string query = "SELECT countryId FROM country WHERE country = @country";

            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn))
            {
                cmd.Parameters.AddWithValue("@country", clean);
                var firstData = cmd.ExecuteScalar();

                //If a CountryID exist for user input country
                //Return the countryid
                if (firstData != null)
                {
                    int countryID = Convert.ToInt32(firstData);
                    countryName = clean;
                    return countryID;
                }

                //If country does not exist, insert into database
                query = "INSERT INTO country VALUES(NULL, @country, NOW(), 'user', NOW(), 'info');" +
                    "SELECT LAST_INSERT_ID();";

                cmd.CommandText = query;

                int newCountryId = Convert.ToInt32(cmd.ExecuteScalar());
                countryName = clean;
                return newCountryId;
            }
        }

        //Check City exists or Add City
        //Return CityID and City Name
        public int CityTableData(string city, int countryID, out string cityName)
        {
            var formattedCity = city.Trim().ToLower();
            formattedCity = textinfo.ToTitleCase(formattedCity);

            //Checks City exists with CountryID
            //Inserts City with CountryID if it does not exist
            string query = "SELECT cityId FROM city WHERE city = @city AND countryId = @countryId";

            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn))
            {
                cmd.Parameters.AddWithValue("@city", formattedCity);
                cmd.Parameters.AddWithValue("@countryId", countryID);

                object firstData = cmd.ExecuteScalar();

                if (firstData != null)
                {
                    int cityID = Convert.ToInt32(firstData);
                    cityName = formattedCity;
                    return cityID;
                }

                query = "INSERT INTO city VALUES (NULL, @city, @countryId, NOW(), 'user', NOW(), 'info');" +
                    "SELECT LAST_INSERT_ID();";
                cmd.CommandText = query;

                int newCityID = Convert.ToInt32(cmd.ExecuteScalar());
                cityName = formattedCity;
                return newCityID;
            }
        }

        //Check address exists
        //Validates phone number
        //Return Address, phone, and AddressID
        public int AddressTableData(string address, int cityID, string phoneNum, out string addressName, out string phone)
        {
            string formattedAddress = CapitalizeAddress(address);

            //Checks Address exists with CityID.
            //Checks phone already exists in existing address
            //Inserts Address with CityID if it does not exist
            string query = "SELECT addressId FROM address WHERE address = @address AND cityId = @cityId";

            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn))
            {
                cmd.Parameters.AddWithValue("@address", formattedAddress);
                cmd.Parameters.AddWithValue("@cityId", cityID);

                object addressIdData = cmd.ExecuteScalar();

                if (addressIdData != null)
                {
                    int addressID = Convert.ToInt32(addressIdData);
                    addressName = formattedAddress;
                    phone = phoneNum;
                    return addressID;
                }

                cmd.Parameters.AddWithValue("@phone", phoneNum);
                query = "INSERT INTO address VALUES (NULL, @address, '', @cityId, '00000', @phone, NOW(), 'user', NOW(), 'info');" +
                    "SELECT LAST_INSERT_ID();";
                cmd.CommandText = query;

                int newAddressID = Convert.ToInt32(cmd.ExecuteScalar());
                addressName = formattedAddress;
                phone = phoneNum;
                return newAddressID;
            }
        }

        //Check Customer Exists with AddressID, if exist throw exception
        //Insert Customer with AddressID if not exist
        public int CustomerTableData(string customerName, int addressId, out string name)
        {
            var formattedName = customerName.Trim().ToLower();
            formattedName = textinfo.ToTitleCase(formattedName);

            string query = "SELECT customerId FROM customer WHERE customerName = @customerName AND addressId = @addressId";

            using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.conn))
            {
                cmd.Parameters.AddWithValue("@customerName", formattedName);
                cmd.Parameters.AddWithValue("@addressId", addressId);

                object firstData = cmd.ExecuteScalar();

                if (firstData != null)
                {
                    throw new Exception("Customer information already exists.");
                }

                query = "INSERT INTO customer VALUES (NULL, @customerName, @addressId, 1, NOW(), 'user', NOW(), 'info');" +
                    "SELECT LAST_INSERT_ID();";
                cmd.CommandText = query;
                int customerID = Convert.ToInt32(cmd.ExecuteScalar());
                name = formattedName;
                return customerID;
            }
        }

        //Add to DGV
        public void AddtoDGV(int customerID, string customerName, string address, string city, string country, string phoneNum)
        {
            var newCustomer = new DgvCustomer(customerID, customerName, address + " " + city + " " + country, phoneNum);
            DgvCustomerData.CustomerAdd(newCustomer);
        }

        //Formats address data
        public string CapitalizeAddress(string address)
        {
            var lowerAddress = address.Trim().ToLower();

            StringBuilder formattedAddress = new StringBuilder();

            bool capitalizeNext = true;

            foreach (char c in lowerAddress)
            {
                if (char.IsWhiteSpace(c))
                {
                    formattedAddress.Append(c);
                    capitalizeNext = true;
                }
                else if(char.IsDigit(c) || c == '#' || c == '-' || c == '_' || c == '.' || c == '\'')
                {
                    formattedAddress.Append(c);
                    capitalizeNext = false;
                }
                else
                {
                    if(capitalizeNext)
                    {
                        formattedAddress.Append(char.ToUpper(c));
                        capitalizeNext = false;
                        continue;
                    }
                    formattedAddress.Append(c);
                }
            }

            return formattedAddress.ToString();
        }
    }
}
