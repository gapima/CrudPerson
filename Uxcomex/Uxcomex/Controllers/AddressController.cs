using Microsoft.AspNetCore.Mvc;
using Uxcomex.Dto;
using Uxcomex.Models;
using Uxcomex.Services;

namespace Uxcomex.Controllers
{
    public class AddressController : Controller
    {
        private readonly ILogger<AddressController> _logger;
        private readonly AddressService _AddressService;

        public AddressController(ILogger<AddressController> logger, AddressService AddressService)
        {
            _logger = logger;
            _AddressService = AddressService;
        }
        public ActionResult CreateAddress()
        {
            return View();
        }
        public ActionResult UpdateAddress(AddressModel Address)
        {
            return View(Address);
        }
        public async Task Create(AddressDto AddressDto)
        {
            await _AddressService.CreateAddress(AddressDto);

        }
        public async Task<IActionResult> Update(AddressDto AddressDto)
        {
            await _AddressService.UpdateAddress(AddressDto);

            return RedirectToAction("Update");
        }
    }
}
