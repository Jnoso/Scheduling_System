using Scheduling_System.CalendarClasses;
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
    public partial class CalendarAdd : Form
    {
        AddApptControl addApptControl = new AddApptControl();
        public ComboBox TypeBox => typeBox;
        public TextBox TextDescription => textDescription;
        public Label TimeZone1 => timeZone1;
        public Label TimeZone2 => timeZone2;
        public DateTimePicker StartDatePicker => startDatePicker;
        public DateTimePicker StartTimePicker => startTimePicker;
        public DateTimePicker EndDatePicker => endDatePicker;
        public DateTimePicker EndTimePicker => endTimePicker;

        public DataGridView DgvApptCustomer => dgvApptCustomer;

        private CustomerRecord customerRecord = new CustomerRecord();

        public CalendarAdd()
        {
            InitializeComponent();

            //Call method to populate Customer Dgv
            dgvApptCustomer.DataSource = DgvCustomerData.dgvCustomer;

            //Display local timezone
            addApptControl.DisplayLocalTimeZone(this);
        }

        private void applyAddBtn_Click(object sender, EventArgs e)
        {
            if (dgvApptCustomer.CurrentRow == null || dgvApptCustomer.CurrentRow.Selected == false)
            {
                MessageBox.Show("Please select a customer");
                return;
            }

            bool proceed = false;
            //Check if fields are selected/filled
            if(addApptControl.InputValidate(this))
            {
                proceed = true;
            }

            //Add to SQL and DGV
            if (proceed)
            {
                addApptControl.AddtoSQLandDGV(this);
                textDescription.Clear();
                MessageBox.Show("Appointment Added");
            }
        }

        private void cancAddBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
