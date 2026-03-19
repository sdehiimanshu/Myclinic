using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClinic.Application.DTOs;

namespace MyClinic.Application.Interfaces
{
    public interface IContactQueryService
    {
        Task CreateAsync(ContactQueryDto dto);
        Task<IEnumerable<ContactQueryDto>> GetAllAsync();
        Task<ContactQueryDto?> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, ContactQueryDto dto);

    }
}
