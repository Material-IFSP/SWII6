using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web_TP_Final.Models;

namespace Web_TP_Final.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Produto> produtoList = new List<Produto>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/v1/produtos"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    produtoList = JsonConvert.DeserializeObject<List<Produto>>(apiResponse);
                }
            }
            return View(produtoList);
        }

        public ViewResult AddProduto() => View();

        [HttpPost]
        public async Task<IActionResult> AddProduto(Produto produto)
        {
            Produto newProduto = new Produto();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(produto), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:5001/api/v1/produtos", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    newProduto = JsonConvert.DeserializeObject<Produto>(apiResponse);
                }
            }
            return View(newProduto);
        }     
        public async Task<IActionResult> DeleteProduto(int id)
        {

            using (var client = new HttpClient())
            {
            
                HttpResponseMessage responseMessage = await
                client.DeleteAsync(String.Format("{0}/{1}", "https://localhost:5001/api/v1/produtos", id));
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
           
        }

        public async Task<IActionResult> UpdateProdutoById(int id)
        {
            Produto produto = new Produto();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/v1/produtos/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    produto = JsonConvert.DeserializeObject<Produto>(apiResponse);
                }
            }
            return View(produto);
        }

        public async Task<IActionResult> UpdateProduto(int id, Produto produto)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(produto), Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage responseMessage = await httpClient.PutAsync("https://localhost:5001/api/v1/produtos/" + produto.Id, content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
}
