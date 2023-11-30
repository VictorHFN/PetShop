using PetShop.Data;
using PetShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Controllers
{
    public class AnimalController : Controller
    {
        readonly private ApplicationDBContext _db;
        public AnimalController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<AnimalModel> animals = _db.Animais.Include(a => a.Cliente).ToList();
            return View(animals);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            ViewBag.Clientes = _db.Clientes.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(AnimalModel animal)
        {
            if (ModelState.IsValid)
            {
                _db.Animais.Add(animal);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Clientes = _db.Clientes.ToList();

            return View(animal);
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            AnimalModel animal = _db.Animais.Include(a => a.Cliente).FirstOrDefault(a => a.Id == id);

            if (animal == null)
            {
                return NotFound();
            }

            ViewBag.Clientes = _db.Clientes.ToList();

            return View(animal);
        }

        [HttpPost]
        public IActionResult Editar(AnimalModel animal)
        {
            if (ModelState.IsValid)
            {
                _db.Animais.Update(animal);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Clientes = _db.Clientes.ToList();

            return View(animal);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            AnimalModel animal = _db.Animais.Include(a => a.Cliente).FirstOrDefault(a => a.Id == id);

            if (animal == null)
            {
                return NotFound();
            }

            ViewBag.Clientes = _db.Clientes.ToList();

            return View(animal);
        }

        [HttpPost]
        public IActionResult Excluir(AnimalModel animal)
        {
            if (ModelState.IsValid)
            {
                _db.Animais.Remove(animal);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Clientes = _db.Clientes.ToList();

            return View(animal);
        }
    }
}
