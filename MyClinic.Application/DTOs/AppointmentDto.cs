using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClinic.Domain.Enums;

namespace MyClinic.Application.DTOs
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DepartmentType Department { get; set; } 
        public DateTime AppointmentDate { get; set; }
        public string DoctorName { get; set; } = null!;
        public string Message { get; set; } = null!;
    }
}
