using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyClinic.Application.DTOs;
using MyClinic.Application.Interfaces;

namespace MyClinic.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IContactQueryService _contactQueryService;

        public AdminController(
            IAppointmentService appointmentService,
            IContactQueryService contactQueryService)
        {
            _appointmentService = appointmentService;
            _contactQueryService = contactQueryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Appointments()
        {
            var appointments = await _appointmentService.GetAllAsync();
            return View("~/Views/Appointment/Appointment_List.cshtml", appointments);
        }

        public async Task<IActionResult> ContactQueries()
        {
            var queries = await _contactQueryService.GetAllAsync();
            return View("~/Views/Contact/Contact_List.cshtml", queries);
        }
        public async Task<IActionResult> EditAppointment(int id)
        {
            var appointment = await _appointmentService.GetByIdAsync(id);

            if (appointment == null)
                return NotFound();

            return View("~/Views/Appointment/Appointment_Edit.cshtml", appointment);
        }
        [HttpPost]
        public async Task<IActionResult> EditAppointment(int id, AppointmentDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Appointment/Appointment_Edit.cshtml", dto);
            }

            await _appointmentService.UpdateAsync(id, dto);
            return RedirectToAction("Appointments");
        }
        public async Task<IActionResult> EditContact(int id)
        {
            var query = await _contactQueryService.GetByIdAsync(id);

            if (query == null)
                return NotFound();

            return View("~/Views/Contact/Contact_Edit.cshtml", query);
        }

        [HttpPost]
        public async Task<IActionResult> EditContact(int id, ContactQueryDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Contact/Contact_Edit.cshtml", dto);
            }

            await _contactQueryService.UpdateAsync(id, dto);
            return RedirectToAction("ContactQueries");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            await _appointmentService.DeleteAsync(id);
            return RedirectToAction("Appointments");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _contactQueryService.DeleteAsync(id);
            return RedirectToAction("ContactQueries");
        }

    }
}
