using Scheduling_System.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling_System
{
    public partial class CustomerUpdate : Form
    {
        private CustomerRecord customerUserControl;
        private CustomerControl customerControl = new CustomerControl();

        public TextBox Txt_CustomerName => txt_customerName;
        public TextBox Txt_Address => txt_Address;
        public TextBox Txt_City => txt_City;
        public TextBox Txt_Country => txt_Country;
        public TextBox Txt_PhoneNum => txt_PhoneNum;
        
        public CustomerUpdate(CustomerRecord customerRecord)
        {
            InitializeComponent();
            customerUserControl = customerRecord;

            int customerId = (int)customerUserControl.DgvCustomer.CurrentRow.Cells["ID"].Value;

            customerControl.FillUpdateTextBox(customerId, this);
            
        }

        private void UpdateWindowCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void updateWindowBtn_Click(object sender, EventArgs e)
        {
            bool proceed = false;

            int customerId = (int)customerUserControl.DgvCustomer.CurrentRow.Cells["ID"].Value;

            //Validates text fields
            if (customerControl.TxtFieldValidate(txt_customerName.Text, txt_Address.Text, txt_City.Text, txt_Country.Text, txt_PhoneNum.Text))
            {
                proceed = true;
            }

            //Validation complete update database/dgv
            if (proceed)
            {
                customerControl.UpdatetoSQLandDGV(customerId, txt_customerName.Text, txt_Address.Text, txt_City.Text, txt_Country.Text, txt_PhoneNum.Text, this, customerUserControl);
            }
        }
    }
}
