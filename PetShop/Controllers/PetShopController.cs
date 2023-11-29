using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetShop.Data;
using PetShop.Models;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace PetShop.Controllers
{
    public class PetShopController : Controller
    {
        private readonly ILogger<PetShopController> _logger;
        private readonly ApplicationDBContext _dbContext;

        public PetShopController(ILogger<PetShopController> logger, ApplicationDBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var model = _dbContext.PetShops.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(PetShopModel novoPetShop)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dbContext.Add(novoPetShop);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(novoPetShop);
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
            var petshop = _dbContext.PetShops.Find(id);

            if (petshop is null)
            {
                return NotFound();
            }

            return View(petshop);
        }

        [HttpPost]
        public IActionResult Editar(PetShopModel petshop)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Update(petshop);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(petshop);
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var petshop = _dbContext.PetShops.Find(id);

            if (petshop is null)
            {
                return NotFound();
            }

            return View(petshop);
        }

        [HttpPost, ActionName("Excluir")]
        public IActionResult ConfirmarExcluir(int id)
        {
            var petshop = _dbContext.PetShops.Find(id);

            if (petshop is null)
            {
                return NotFound();
            }

            _dbContext.PetShops.Remove(petshop);
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
