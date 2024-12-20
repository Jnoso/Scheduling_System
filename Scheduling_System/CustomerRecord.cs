using Scheduling_System.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling_System
{
    public partial class CustomerRecord : UserControl
    {
        private CustomerControl customerControl = new CustomerControl();

        public TextBox Txt_CustomerName => txt_customerName;
        public TextBox Txt_Address => txt_Address;
        public TextBox Txt_City => txt_City;
        public TextBox Txt_Country => txt_Country;
        public TextBox Txt_PhoneNum => txt_PhoneNum;
        public DataGridView DgvCustomer => dgvCustomer;
        private static bool isInitialized = false;
      
        public CustomerRecord()
        {
            InitializeComponent();

            if(!isInitialized)
            {
                dgvCustomer.DataSource = DgvCustomerData.dgvCustomer;
                DgvCustomerData.InitializeCustomerDGV();
                isInitialized = true;
            }
        }

        //Add text field
        private void btn_Add_Click(object sender, EventArgs e)
        {
            bool proceed = false;
            //Validates text fields
            if (customerControl.TxtFieldValidate(txt_customerName.Text, txt_Address.Text, txt_City.Text, txt_Country.Text, txt_PhoneNum.Text))
            {
                proceed = true;
            }

            //Validation Complete, update database/dgv
            if (proceed)
            {
                customerControl.AddtoSQLandDGV(txt_customerName.Text, txt_Address.Text, txt_City.Text, txt_Country.Text, txt_PhoneNum.Text, this);
            }
        }

        //When user Enters the Phone Text Box Field
        private void Phonetext_Enter(object sender, EventArgs e)
        {
            if (txt_PhoneNum.Text == "e.g. 000-0000")
            {
                txt_PhoneNum.Text = "";
                txt_PhoneNum.ForeColor = Color.Black;
            }
        }

        //When user Leaves the Phone Text Box Field
        private void Phonetext_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_PhoneNum.Text))
            {
                txt_PhoneNum.Text = "e.g. 000-0000";
                txt_PhoneNum.ForeColor = Color.Gray;
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.CurrentRow == null || dgvCustomer.CurrentRow.Selected == false)
            {
                MessageBox.Show("Please select a customer to update");
                return;
            }
            else
            {
                CustomerUpdate customerUpdate = new CustomerUpdate(this);
                customerUpdate.Show();
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {

            if (dgvCustomer.CurrentRow == null || dgvCustomer.CurrentRow.Selected == false)
            {
                MessageBox.Show("Please select a customer to delete");
                return;
            }
            else
            {
                int customerID = (int)DgvCustomer.CurrentRow.Cells["ID"].Value;
                customerControl.DeletetoSqlandDGV(customerID);
                dgvCustomer.ClearSelection();
                dgvCustomer.Refresh();
            }
        }
    }
}
