using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetShop.Data;
using PetShop.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace PetShop.Controllers
{
    public class AnimalController : Controller
    {
        private readonly ILogger<AnimalController> _logger;
        private readonly ApplicationDBContext _dbContext; // Adicione a instância do contexto do banco de dados

        public AnimalController(ILogger<AnimalController> logger, ApplicationDBContext dbContext) // Adicione o contexto do banco de dados ao construtor
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            // Aqui você normalmente buscaria dados do modelo do banco de dados ou de outra fonte de dados
            // Por enquanto, vamos criar uma lista de exemplo
            var model = new List<AnimalModel>
            {
                new AnimalModel { Id = 1, Nome = "Cachorro", Raca = "Golden Retriever", Porte = "Médio" },
                new AnimalModel { Id = 2, Nome = "Gato", Raca = "Siamês", Porte = "Pequeno" },
                // Adicione mais animais conforme necessário
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Cadastrar(AnimalModel novoAnimal)
        {
            if (ModelState.IsValid)
            {
                // Adicione o novo animal ao contexto do banco de dados
                _dbContext.Add(novoAnimal);

                // Salve as alterações no banco de dados
                _dbContext.SaveChanges();

                // Redirecione para a página desejada após o cadastro
                return RedirectToAction("Index");
            }

            // Se houver erros de validação, retorne à view para corrigi-los
            return View(novoAnimal);
        }

        // Ação para exibir a página de edição de um animal
        public IActionResult Editar(int id)
        {
            // Aqui você normalmente buscaria os dados do animal pelo ID do banco de dados
            // Por enquanto, vamos criar um modelo de exemplo com base no ID
            var model = new AnimalModel
            {
                Id = id,
                Nome = "Animal de Teste",
                Raca = "Raça de Teste",
                Porte = "Porte de Teste"
            };

            return View(model);
        }

        // Ação para processar o formulário de edição (HTTP POST)
        [HttpPost]
        public IActionResult Editar(AnimalModel animal)
        {
            if (ModelState.IsValid)
            {
                // Atualize o animal no contexto do banco de dados
                _dbContext.Update(animal);

                // Salve as alterações no banco de dados
                _dbContext.SaveChanges();

                // Redirecione para a página desejada após a edição
                return RedirectToAction("Index");
            }

            // Se houver erros de validação, retorne à view para corrigi-los
            return View(animal);
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
