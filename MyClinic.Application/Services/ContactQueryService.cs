using MyClinic.Application.DTOs;
using MyClinic.Application.Interfaces;
using MyClinic.Domain.Entities;
using MyClinic.Domain.Interfaces;

namespace MyClinic.Application.Services
{
    public class ContactQueryService : IContactQueryService
    {
        private readonly IContactQueryRepository _repository;

        public ContactQueryService(IContactQueryRepository repository)
        {
            _repository = repository;
        }

        // USER SIDE
        public async Task CreateAsync(ContactQueryDto dto)
        {
            var entity = new ContactQuery
            {
                Name = dto.Name,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Message = dto.Message
            };

            await _repository.AddAsync(entity);
        }

        // ADMIN SIDE
        public async Task<IEnumerable<ContactQueryDto>> GetAllAsync()
        {
            var queries = await _repository.GetAllAsync();

            return queries.Select(q => new ContactQueryDto
            {
                Id = q.Id,
                Name = q.Name,
                Email = q.Email,
                PhoneNumber = q.PhoneNumber,
                Message = q.Message
            });
        }

        public async Task<ContactQueryDto?> GetByIdAsync(int id)
        {
            var query = await _repository.GetByIdAsync(id);

            if (query == null)
                return null;

            return new ContactQueryDto
            {
                Id = query.Id,
                Name = query.Name,
                Email = query.Email,
                PhoneNumber = query.PhoneNumber,
                Message = query.Message
            };
        }

        public async Task UpdateAsync(int id, ContactQueryDto dto)
        {
            var query = await _repository.GetByIdAsync(id);

            if (query == null)
                throw new Exception("Contact query not found");

            query.Name = dto.Name;
            query.Email = dto.Email;
            query.PhoneNumber = dto.PhoneNumber;
            query.Message = dto.Message;

            await _repository.UpdateAsync(query);
        }

        public async Task DeleteAsync(int id)
        {
            var query = await _repository.GetByIdAsync(id);

            if (query == null)
                throw new Exception("Contact query not found");

            await _repository.DeleteAsync(id);
        }
    }
}
