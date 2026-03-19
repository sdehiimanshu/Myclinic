using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClinic.Application.DTOs;


namespace MyClinic.Application.Interfaces
{
    public interface IAppointmentService
    {
        Task CreateAsync(AppointmentDto dto);
        Task UpdateAsync(int id, AppointmentDto dto);
        Task DeleteAsync(int id);
        Task<IEnumerable<AppointmentDto>> GetAllAsync();
        Task <AppointmentDto?> GetByIdAsync(int id);
    }
}
