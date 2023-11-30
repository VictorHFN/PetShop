using PetShop.Data;
using PetShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Controllers
{
    public class ServicoController : Controller
    {
        readonly private ApplicationDBContext _db;
        public ServicoController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ServicoModel> servicos = _db.Servicos.Include(a => a.PetShop).ToList();
            return View(servicos);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            ViewBag.PetShops = _db.PetShops.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(ServicoModel servico)
        {
            if (ModelState.IsValid)
            {
                _db.Servicos.Add(servico);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PetShops = _db.PetShops.ToList();

            return View(servico);
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            ServicoModel servico = _db.Servicos.Include(a => a.PetShop).FirstOrDefault(a => a.Id == id);

            if (servico == null)
            {
                return NotFound();
            }

            ViewBag.PetShops = _db.PetShops.ToList();

            return View(servico);
        }

        [HttpPost]
        public IActionResult Editar(ServicoModel servico)
        {
            if (ModelState.IsValid)
            {
                _db.Servicos.Update(servico);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PetShops = _db.PetShops.ToList();

            return View(servico);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            ServicoModel servico = _db.Servicos.Include(a => a.PetShop).FirstOrDefault(a => a.Id == id);

            if (servico == null)
            {
                return NotFound();
            }

            ViewBag.PetShops = _db.PetShops.ToList();

            return View(servico);
        }

        [HttpPost]
        public IActionResult Excluir(ServicoModel servico)
        {
            if (ModelState.IsValid)
            {
                _db.Servicos.Remove(servico);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PetShops = _db.PetShops.ToList();

            return View(servico);
        }
    }
}
