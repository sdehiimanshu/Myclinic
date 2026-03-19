using Microsoft.EntityFrameworkCore;
using MyClinic.Domain.Entities;
using MyClinic.Domain.Interfaces;
using MyClinic.Infrastructure.Data;

namespace MyClinic.Infrastructure.Repositories
{
    public class ContactQueryRepository : IContactQueryRepository
    {
        private readonly MyClinicDbContext _context;

        public ContactQueryRepository(MyClinicDbContext context)
        {
            _context = context;
        }

        public async Task<ContactQuery> AddAsync(ContactQuery entity)
        {
            await _context.ContactQueries.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<ContactQuery>> GetAllAsync()
        {
            return await _context.ContactQueries
                                 .OrderByDescending(x => x.CreatedAt)
                                 .ToListAsync();
        }

        public async Task<ContactQuery?> GetByIdAsync(int id)
        {
            return await _context.ContactQueries.FindAsync(id);
        }

        public async Task<ContactQuery> UpdateAsync(ContactQuery entity)
        {
            _context.ContactQueries.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.ContactQueries.FindAsync(id);

            if (entity == null)
                return false;

            _context.ContactQueries.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
