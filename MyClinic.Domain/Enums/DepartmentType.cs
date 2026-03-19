using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClinic.Domain.Common;

namespace MyClinic.Domain.Enums
{
    public class DepartmentType:BaseEntity
    {
        public enum Department
        {
            GeneralMedicine,
            Pediatrics,
            Dermatology,
            Cardiology,
            Orthopedics,
            Neurology,
            Gynecology,
            Psychiatry,
            ENT,
            Ophthalmology
        }
    }
}
