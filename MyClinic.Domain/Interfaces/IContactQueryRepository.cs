using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClinic.Domain.Entities;

namespace MyClinic.Domain.Interfaces
{
    public interface IContactQueryRepository
    {
        Task<ContactQuery> AddAsync(ContactQuery contactQuery);
        Task<ContactQuery> UpdateAsync(ContactQuery entity);
        Task<ContactQuery> GetByIdAsync(int id);
        Task<IEnumerable<ContactQuery>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
    }
}
