using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling_System.Classes
{
    internal class DgvCustomer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public DgvCustomer (int dgvCustomerID, string dgvCustomerName, string dgvAddress, string dgvPhoneNumber)
        {
            ID = dgvCustomerID;
            Name = dgvCustomerName;
            Address = dgvAddress;
            Phone = dgvPhoneNumber;
        }
    }
}
