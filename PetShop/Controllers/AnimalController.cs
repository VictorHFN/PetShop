using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetShop.Data;
using PetShop.Models;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace PetShop.Controllers
{
    public class AnimalController : Controller
    {
        private readonly ILogger<AnimalController> _logger;
        private readonly ApplicationDBContext _dbContext;

        public AnimalController(ILogger<AnimalController> logger, ApplicationDBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var model = _dbContext.Animais.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(AnimalModel novoAnimal)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dbContext.Add(novoAnimal);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(novoAnimal);
            }
            catch (Exception ex)
            {
                // Adicione log ou imprima o erro para identificar a causa do problema
                Console.WriteLine(ex.Message);
                throw;
            }
        }    

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var animal = _dbContext.Animais.Find(id);

            if (animal is null)
            {
                return NotFound();
            }

            return View(animal);
        }

        [HttpPost]
        public IActionResult Editar(AnimalModel animal)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Update(animal);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(animal);
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var animal = _dbContext.Animais.Find(id);

            if (animal is null)
            {
                return NotFound();
            }

            return View(animal);
        }

        [HttpPost, ActionName("Excluir")]
        public IActionResult ConfirmarExcluir(int id)
        {
            var animal = _dbContext.Animais.Find(id);

            if (animal is null)
            {
                return NotFound();
            }

            _dbContext.Animais.Remove(animal);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
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
