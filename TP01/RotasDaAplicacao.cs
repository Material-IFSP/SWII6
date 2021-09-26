using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace TrabalhoPratico01
{
  public class RotasDaAplicacao
  {
    private Dictionary<string, Func<HttpContext, Task>> Rotas;

    public RotasDaAplicacao()
    {
      this.ConfigurarRotas();
    }

    private void ConfigurarRotas()
    {
      this.Rotas = new Dictionary<string, Func<HttpContext, Task>>();

      ControladoraLivro controladoraLivro = new ControladoraLivro();

      this.Rotas.Add("/livro/NomeLivro", controladoraLivro.NomeLivro);
      this.Rotas.Add("/livro/ToString", controladoraLivro.ToStringResultado);
      this.Rotas.Add("/livro/NomesAutores", controladoraLivro.NomesAutores);
      this.Rotas.Add("/livro/ApresentarLivro", controladoraLivro.ApresentarLivro);
    }

    public Task Roteamento(HttpContext httpContext)
    {
      try
      {
        return this.Rotas[httpContext.Request.Path].Invoke(httpContext);
      }
      catch (System.Exception ex)
      {
        Console.WriteLine(ex);

        return null;
      }
    }
  }
}