using Microsoft.AspNetCore.Mvc;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TP02.DAO;
using TP02.Models;

namespace TP02.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly CategoriasDAO _categoriasDAO;

        public CategoriaController(CategoriasDAO categoriasDAO)
        {
            this._categoriasDAO = categoriasDAO;
        }

        [HttpGet]
        public async Task<ActionResult> CriaOsMockAiChifrudokkkkk()
        {
            var random = new Random();

            for (int i = 0; i < 10; i++)
            {
                int id;
                var RandomText = await GenerateRandomTextv2();

                do
                    id = random.Next();
                while (this._categoriasDAO.ListarPorId(id) != null);

                string idFormatado = id.ToString().PadLeft(3, '0');

                this._categoriasDAO.Adicionar(new CategoriaDoProduto()
                {
                    Id = id,
                    Nome = $"Categoria {idFormatado}",
                    Descricao = $"{RandomText} - {idFormatado}"
                });
            }

            return Ok("Tá mockado filhão, agora abre a rota index ai :D");
        }

        public IActionResult Index()
        {
            var categorias = this._categoriasDAO.Listar();

            ViewBag.Categorias = categorias;

            return View();
        }

        public async Task<string> GenerateRandomText()
        {
            var client = new HttpClient();
            string lcoResult = "Descrição da categoria"; 
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://montanaflynn-lorem-text-generator.p.rapidapi.com/word?count=5"),
                Headers =
            {
                { "x-rapidapi-host", "montanaflynn-lorem-text-generator.p.rapidapi.com" },
                { "x-rapidapi-key", "9a1c53f974msh947cae6ec8b88f9p1c9dbdjsn1193fc6f5860" },
            },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                lcoResult = await response.Content.ReadAsStringAsync();
                Console.WriteLine(lcoResult);
            }

            if(!String.IsNullOrEmpty(lcoResult)){
                return lcoResult;
            }
            
            return "Descrição da categoria"; 
        }

        public async Task<string> GenerateRandomTextv2()
        {
            var randomizerText = RandomizerFactory.GetRandomizer(new FieldOptionsText { UseNumber = false, UseSpecial = false });
            var text = "";
            for (int i = 0; i < 3; i++)
            {
                string TextAux = randomizerText.Generate();  
                text = text + ' ' + TextAux;
            }
            return text; 
        }

    }
}
