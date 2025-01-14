using Microsoft.AspNetCore.Mvc;
using Uxcomex.Dto;
using Uxcomex.Models;
using Uxcomex.Services;

namespace Uxcomex.Controllers
{
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        private readonly PersonService _personService;
        private readonly AddressService _addressService;

        public PersonController(ILogger<PersonController> logger, PersonService personService, AddressService addressService)
        {
            _logger = logger;
            _personService = personService;
            _addressService = addressService;
        }
        public async Task<IActionResult> Index()
        {
            var persons = await _personService.GetAllPersons();

            return View(persons);
        }
        public ActionResult CreatePerson()
        {
            return View();
        }
        public ActionResult UpdatePerson(PersonModel person)
        {
            return View(person);
        }
        public async Task<IActionResult> Create(PersonDto personDto)
        {
            var person = await _personService.CreatePerson(personDto);
            return RedirectToAction("UpdatePerson", person);
        }
        public async Task<IActionResult> Update(PersonDto personDto)
        {
            await _personService.UpdatePerson(personDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> GetAllAddressByPersonId(int personId)
        {
            var addresses = await _addressService.GetAllAddressByPersonId(personId);

            return RedirectToAction("UpdatePerson", addresses);
        }
    }
}
