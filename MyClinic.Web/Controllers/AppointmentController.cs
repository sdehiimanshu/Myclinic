using Microsoft.AspNetCore.Mvc;
using MyClinic.Application.DTOs;
using MyClinic.Application.Interfaces;

namespace MyClinic.Web.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public IActionResult Appointment_Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Appointment_Create(AppointmentDto dto)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine("❌ MODEL ERROR: " + error.ErrorMessage);
                }

                return View(dto);
            }

            await _appointmentService.CreateAsync(dto);

            TempData["Success"] = "Your appointment has been scheduled successfully.";
            return RedirectToAction(nameof(Appointment_Create));
        }

    }
}
