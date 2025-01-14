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
        private readonly PersonService _personService;

        public AddressController(ILogger<AddressController> logger, AddressService AddressService, PersonService personService)
        {
            _logger = logger;
            _AddressService = AddressService;
            _personService = personService;
        }
        public ActionResult CreateAddress()
        {
            return View();
        }
        public ActionResult UpdateAddress(AddressModel Address)
        {
            return View(Address);
        }
        public async Task<IActionResult> Create(AddressDto AddressDto)
        {
            var address = await _AddressService.CreateAddress(AddressDto);
            return RedirectToAction("UpdatePerson", "Person", address);

        }
        public async Task<IActionResult> Update(AddressDto AddressDto)
        {
            var address = await _AddressService.UpdateAddress(AddressDto);

            return RedirectToAction("UpdatePerson", "Person", address);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var address = await _AddressService.GetAddressById(id);
            await _AddressService.DeleteAddress(id);
            var person = await _personService.GetPersonById(address.PersonId);
            return RedirectToAction("UpdatePerson", "Person", person);
        }
    }
}
