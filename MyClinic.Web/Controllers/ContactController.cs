using Microsoft.AspNetCore.Mvc;
using MyClinic.Application.DTOs;
using MyClinic.Application.Interfaces;

namespace MyClinic.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactQueryService _contactQueryService;

        public ContactController(IContactQueryService contactQueryService)
        {
            _contactQueryService = contactQueryService;
        }

        // GET: Contact Us page
        [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }

        // POST: Contact Us form submit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactUs(ContactQueryDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            await _contactQueryService.CreateAsync(dto);

            TempData["Success"] = "Thank you! Your query has been submitted.";
            return RedirectToAction(nameof(ContactUs));
        }
    }
}
