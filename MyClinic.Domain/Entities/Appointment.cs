using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClinic.Domain.Common;
using MyClinic.Domain.Enums;

namespace MyClinic.Domain.Entities
{
    public class Appointment : BaseEntity
    {
        public string? Name { get; set; }
        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }
        
        public DepartmentType? Department { get; set; }
        public DateTime AppointmentDate { get; set; }

        public string? DoctorName { get; set; }

        public string? Message { get; set; }

    }
}
