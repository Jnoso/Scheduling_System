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
    public partial class CalendarUpdate : Form
    {
        UpdateApptControl updateApptControl = new UpdateApptControl();
        AddApptControl addApptControl = new AddApptControl();

        private Calendar calendarUserControl;
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

        public CalendarUpdate(Calendar calendar)
        {
            InitializeComponent();

            dgvApptCustomer.DataSource = DgvCustomerData.dgvCustomer;

            updateApptControl.DisplayLocalTimeZone(this);

            calendarUserControl = calendar;
            int appointmentId = (int)calendarUserControl.DgvAppt.CurrentRow.Cells["ID"].Value;

            //Populate form
            updateApptControl.FillUpdateForm(this, appointmentId);
        }

        private void applyAddBtn_Click(object sender, EventArgs e)
        {
            int appointmentId = (int)calendarUserControl.DgvAppt.CurrentRow.Cells["ID"].Value;

            if (dgvApptCustomer.CurrentRow == null || dgvApptCustomer.CurrentRow.Selected == false)
            {
                MessageBox.Show("Please select a customer");
                return;
            }

            bool proceed = false;
            if (updateApptControl.InputValidate(this, appointmentId))
            {
                proceed = true;
            }

            if (proceed)
            {
                updateApptControl.UpdatetoSQLandDGV(this, appointmentId, calendarUserControl);
            }

        }

        private void cancAddBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
