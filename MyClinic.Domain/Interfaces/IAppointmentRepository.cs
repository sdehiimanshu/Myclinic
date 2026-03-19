using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClinic.Domain.Entities;

namespace MyClinic.Domain.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<Appointment> AddAsync(Appointment  appointment);
        Task<Appointment> UpdateAsync(Appointment entity);
        Task<Appointment> GetByIdAsync(int id);
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<bool> DeleteAsync(int id);


    }
}
