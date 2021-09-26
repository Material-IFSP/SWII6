using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoPratico01.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace TrabalhoPratico01
{
  public class ControladoraLivro
  {
    public List<Livro> Livros { get; set; }

    public ControladoraLivro()
    {
      var livros = JsonConvert.DeserializeObject<List<Livro>>(
        File.ReadAllText(
          Path.Combine(Directory.GetCurrentDirectory(), "livros.json")
        )
      );

      this.Livros = livros;
    }

    public Task NomeLivro(HttpContext httpContext)
    {
      Livro livro = this.Livros.First();

      var html = File.ReadAllText(Path.Combine(
        Directory.GetCurrentDirectory(),
        "Paginas",
        "NomeLivro.html"
      ));

      html = html.Replace("#NOME_LIVRO", livro.Nome);

      return httpContext.Response.WriteAsync(html);
    }

    public Task ToStringResultado(HttpContext httpContext)
    {
      Livro livro = this.Livros.First();

      var html = File.ReadAllText(Path.Combine(
        Directory.GetCurrentDirectory(),
        "Paginas",
        "ToString.html"
      ));

      html = html.Replace("#RESULTADO", livro.ToString());

      return httpContext.Response.WriteAsync(html);
    }

    public Task NomesAutores(HttpContext httpContext)
    {
      Livro livro = this.Livros.First();

      var html = File.ReadAllText(Path.Combine(
        Directory.GetCurrentDirectory(),
        "Paginas",
        "NomesAutores.html"
      ));

      html = html.Replace("#RESULTADO", livro.NomesAutores());

      return httpContext.Response.WriteAsync(html);
    }

    public Task ApresentarLivro(HttpContext httpContext)
    {
      Livro livro = this.Livros.First();

      var html = File.ReadAllText(Path.Combine(
        Directory.GetCurrentDirectory(),
        "Paginas",
        "ApresentarLivro.html"
      ));

      html = html.Replace("#LIVRO", livro.Nome);

      string autoresLista = "";

      foreach (var autor in livro.Autores)
      {
        autoresLista += "<li>" + autor.Nome + "</li>";
      }

      html = html.Replace("#RESULTADO", livro.NomesAutores());
      html = html.Replace("#AUTORES", autoresLista);

      return httpContext.Response.WriteAsync(html);
    }
  }
}