using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Uxcomex.Models;
using Uxcomex.Services;

namespace Uxcomex.Controllers
{
    public class PersonController : Controller 
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        public async Task<IActionResult> Index()
        {
            var persons = await _personService.GetAllPersons();
            
            return View(persons);
        }
    }
}
