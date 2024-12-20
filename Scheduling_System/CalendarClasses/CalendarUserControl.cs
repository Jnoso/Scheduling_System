using Scheduling_System.DBClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling_System.CalendarClasses
{
    internal class CalendarUserControl
    {
        CustomerInfoQuery customerInfoQuery = new CustomerInfoQuery();
        DeleteApptData deleteApptData = new DeleteApptData();
        
        //Check if there are any customers to create appointment
        public bool CheckCustomerExists()
        {
            bool exists = false;

            //Query to check if customer exists
            if (customerInfoQuery.CheckCustomerTable())
            {
                return exists = true;
            }

            return exists;
        }

        public void DeleteFromSQLandDGV (int appointId)
        {
            deleteApptData.DeleteFromSQLandDGV(appointId);
        }


    }
}
