using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling_System.CalendarClasses
{
    internal class DgvAppointment
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DgvAppointment(int id, string name, string type, string description, DateTime startDate, DateTime endDate)
        {
            ID = id;
            Name = name;
            Type = type;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
