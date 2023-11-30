using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetShop.Data;
using PetShop.Models;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace PetShop.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly ApplicationDBContext _dbContext;

        public ClienteController(ILogger<ClienteController> logger, ApplicationDBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var model = _dbContext.Clientes.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(ClienteModel novoCliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dbContext.Add(novoCliente);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(novoCliente);
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
            var cliente = _dbContext.Clientes.Find(id);

            if (cliente is null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        public IActionResult Editar(ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Update(cliente);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var cliente = _dbContext.Clientes.Find(id);

            if (cliente is null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost, ActionName("Excluir")]
        public IActionResult ConfirmarExcluir(int id)
        {
            var cliente = _dbContext.Clientes.Find(id);

            if (cliente is null)
            {
                return NotFound();
            }

            _dbContext.Clientes.Remove(cliente);
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
