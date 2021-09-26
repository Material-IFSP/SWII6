using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TrabalhoPratico01.Models;
using ToolerString;

namespace TrabalhoPratico01.Models
{
  public class Livro
  {
    public Livro()
    {
      this.Autores = new List<Autor>();
    }

    public string Nome { get; set; }
    public IList<Autor> Autores { get; set; }
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }

    public string NomesAutores()
    {
      string resultado = this.Autores.First().Nome;

      foreach (var autor in this.Autores.Skip(1))
        resultado += "," + autor.Nome;

      return resultado;
    }

    public override string ToString() => this.ToolerString();
  }
}