using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClinic.Application.DTOs;
using MyClinic.Application.Interfaces;
using MyClinic.Domain.Entities;
using MyClinic.Domain.Interfaces;

namespace MyClinic.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;

        public AppointmentService(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(AppointmentDto dto)
        {
            var appointment = new Appointment
            {
                Name = dto.Name,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Department = dto.Department,
                AppointmentDate = dto.AppointmentDate,
                DoctorName = dto.DoctorName,
                Message = dto.Message

            };
            await _repository.AddAsync(appointment);

        }

        public async Task UpdateAsync(int id, AppointmentDto dto)
        {
            var appointment = await _repository.GetByIdAsync(id);

            if (appointment == null)
            {
                throw new Exception("Appointment not found");
            }

                appointment.Name = dto.Name;
                appointment.Email = dto.Email;
                appointment.PhoneNumber = dto.PhoneNumber;
                appointment.Department = dto.Department;
                appointment.AppointmentDate = dto.AppointmentDate;
                appointment.DoctorName = dto.DoctorName;
                appointment.Message = dto.Message;

                await _repository.UpdateAsync(appointment);
            
        }


        public async Task DeleteAsync(int id)
        {
            var appointment = await _repository.GetByIdAsync(id);

            if (appointment == null)
            {
                throw new Exception("Appointment not found");
            }
            await _repository.DeleteAsync(id);

        }

        public async Task<IEnumerable<AppointmentDto>> GetAllAsync()
        {
            var appointments = await _repository.GetAllAsync();
            

            var result = appointments.Select(a => new AppointmentDto
            {
                Name = a.Name,
                Email = a.Email,
                PhoneNumber = a.PhoneNumber,
                Department = a.Department,
                AppointmentDate = a.AppointmentDate,
                DoctorName = a.DoctorName,
                Message = a.Message
            });
            return result;
        }


        public async Task<AppointmentDto?> GetByIdAsync(int id)
        {
            var appointment = await _repository.GetByIdAsync(id);

            if (appointment == null)
            {
                return null;
            }
            var result = new AppointmentDto
            {
                Name = appointment.Name,
                Email = appointment.Email,
                PhoneNumber = appointment.PhoneNumber,
                Department = appointment.Department,
                AppointmentDate = appointment.AppointmentDate,
                DoctorName = appointment.DoctorName,
                Message = appointment.Message
            };
            return result;
        }

    }
}
