using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Scheduling_System.DBClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling_System.Classes
{
    internal class CustomerControl
    {
        private AddCustomerData checkTableandAdd = new AddCustomerData();
        private UpdateCustomerData updateCustomerData = new UpdateCustomerData();
        private DeleteCustomerData deleteCustomerData = new DeleteCustomerData();
        private CustomerInfoQuery customerInfoQuery = new CustomerInfoQuery();

        //Methods for customerRecord User Control Validation
        //Methods for populating datagridview

        //Text Field Validation
        public bool TxtFieldValidate (string name, string address, string city, string country, string phone)
        {
            bool validate = false;
            List<string> textInput = new List<string> { name, address, city, country, phone };
            textInput = textInput.Select(input => input?.Trim()).ToList();

            //Validate text fields.
            //Iterate through each text on list textInput
            foreach (string input in textInput)
            {
                //Checks if fields are empty
                if (string.IsNullOrWhiteSpace(input))
                {
                    MessageBox.Show("Please fill in all fields", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return validate;
                }

                //Checks phone number field
                if (input == phone)
                {
                    //Checks that correct number formatted symbols are input.
                    foreach (char c in input)
                    {
                        if (c == '-' || char.IsDigit(c))
                        {
                            continue;
                        }
                        else
                        {
                            MessageBox.Show("Please add dash and digits only. No letters or unvalid symbols in phone number", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return validate;
                        }
                    }

                    //Checks length of numbers
                    var clean = Regex.Replace(input, @"[^0-9]+", "");
                    if (clean.Length < 7)
                    {
                        MessageBox.Show("Please have at least 7 digits in phone number", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return validate;
                    }
                }
            }
            //Once Validation is complete
            validate = true;
            return validate;
        }

        //Adds form text fields to SQL Database
        //Updates DGV on the Windows Form
        public void AddtoSQLandDGV (string name, string address, string city, string country, string phone, CustomerRecord customerRecord)
        {
            string countryName;
            string cityName;
            string addressName;
            string phoneNum;
            string customerName;
            int customerId;
            //Calls AddCustomerData Class methods
            //Checks if Customer Information is in database
            //Insert Data as needed
            try
            {
                int countryId = checkTableandAdd.CountryTableData(country, out countryName);

                int cityId = checkTableandAdd.CityTableData(city, countryId, out cityName);

                int addressId = checkTableandAdd.AddressTableData(address, cityId, phone, out addressName, out phoneNum);

                customerId = checkTableandAdd.CustomerTableData(name, addressId, out customerName);

                //Call Method to Insert into DGV
                checkTableandAdd.AddtoDGV(customerId, customerName, addressName, cityName, countryName, phoneNum);

                MessageBox.Show("Customer information is added");

                customerRecord.Txt_CustomerName.Clear();
                customerRecord.Txt_Address.Clear();
                customerRecord.Txt_City.Clear();
                customerRecord.Txt_PhoneNum.Clear();
                customerRecord.Txt_Country.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Adding to Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Fill Update Form TextBoxes
        public void FillUpdateTextBox(int customerId, CustomerUpdate customerupdate)
        {
            var queryResult = customerInfoQuery.CustomerIDQuery(customerId);

            customerupdate.Txt_CustomerName.Text = queryResult.CustomerName;
            customerupdate.Txt_Address.Text = queryResult.Address;
            customerupdate.Txt_PhoneNum.Text = queryResult.PhoneNumber;
            customerupdate.Txt_City.Text = queryResult.City;
            customerupdate.Txt_Country.Text = queryResult.Country;
        }

        //Updates database using the Update Form Text Fields
        public void UpdatetoSQLandDGV(int customerId, string name, string address, string city, string country, string phone, CustomerUpdate customerupdate, CustomerRecord customerRecord)
        {
            //Initialize these variables to be used to store modified data.
            string countryName;
            string cityName;
            string addressName;
            string phoneNum;
            string customerName;

            try
            {
                int countryID = checkTableandAdd.CountryTableData(country, out countryName);

                int cityID = checkTableandAdd.CityTableData(city, countryID, out cityName);

                int addressID = updateCustomerData.AddressTableData(address, cityID, phone, out addressName, out phoneNum);

                customerName = updateCustomerData.CustomerTableData(customerId, name, addressID);

                DgvCustomerData.CustomerUpdate(customerId, customerName, addressName, phoneNum, cityName, countryName);

                customerupdate.Close();

                var dgv = customerRecord.DgvCustomer;
                dgv.ClearSelection();
                dgv.Refresh();

                MessageBox.Show("Customer information has been updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Updating to Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //When delete btn is pressed
        public void DeletetoSqlandDGV (int customerId)
        {
            var queryResult = customerInfoQuery.CustomerKeyQuery(customerId);

            if (queryResult == null) { return; }

            int addressID = queryResult.AddressID;

            //Delete method
            deleteCustomerData.deleteFromSQLandDGV(customerId, addressID);
        }

    }
}
