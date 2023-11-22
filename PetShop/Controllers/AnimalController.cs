using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using System.Diagnostics;

namespace PetShop.Controllers
{
    public class AnimalController : Controller
    {
        private readonly ILogger<AnimalController> _logger;

        public AnimalController(ILogger<AnimalController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}