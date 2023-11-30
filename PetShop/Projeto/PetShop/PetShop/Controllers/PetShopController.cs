using PetShop.Data;
using PetShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Controllers
{
    public class PetShopController : Controller
    {
        readonly private ApplicationDBContext _db;
        public PetShopController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<PetShopModel> animais = _db.PetShops;
            return View(animais);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(PetShopModel petshop)
        {
            if (ModelState.IsValid)
            {
                _db.PetShops.Add(petshop);
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

            PetShopModel petshop = _db.PetShops.FirstOrDefault(a => a.Id == id);

            if (petshop == null)
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
                _db.PetShops.Update(petshop);
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

            PetShopModel petshop = _db.PetShops.FirstOrDefault(a => a.Id == id);

            if (petshop == null)
            {
                return NotFound();
            }

            return View(petshop);
        }

        [HttpPost]
        public IActionResult Excluir(PetShopModel petshop)
        {
            if (ModelState.IsValid)
            {
                _db.PetShops.Remove(petshop);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
