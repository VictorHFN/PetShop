using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetShop.Data;
using PetShop.Models;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace PetShop.Controllers
{
    public class ServicoController : Controller
    {
        private readonly ILogger<ServicoController> _logger;
        private readonly ApplicationDBContext _dbContext;

        public ServicoController(ILogger<ServicoController> logger, ApplicationDBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var model = _dbContext.Servicos.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(ServicoModel novoServico)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dbContext.Add(novoServico);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(novoServico);
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
            var servico = _dbContext.Servicos.Find(id);

            if (servico is null)
            {
                return NotFound();
            }

            return View(servico);
        }

        [HttpPut]
        public IActionResult Editar(ServicoModel servico)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Update(servico);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servico);
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            var servico = _dbContext.Servicos.Find(id);

            if (servico is null)
            {
                return NotFound();
            }

            return View(servico);
        }

        [HttpDelete]
        public IActionResult ConfirmarExcluir(int id)
        {
            var servico = _dbContext.Servicos.Find(id);

            if (servico is null)
            {
                return NotFound();
            }

            _dbContext.Servicos.Remove(servico);
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
