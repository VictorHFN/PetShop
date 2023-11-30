using PetShop.Data;
using PetShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Controllers
{
    public class ClienteController : Controller
    {
        readonly private ApplicationDBContext _db;
        public ClienteController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ClienteModel> animais = _db.Clientes;
            return View(animais);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                _db.Clientes.Add(cliente);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            ClienteModel cliente = _db.Clientes.FirstOrDefault(a => a.Id == id);

            if (cliente == null)
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
                _db.Clientes.Update(cliente);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            ClienteModel cliente = _db.Clientes.FirstOrDefault(a => a.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        public IActionResult Excluir(ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                _db.Clientes.Remove(cliente);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
