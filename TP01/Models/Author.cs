using ToolerString;

namespace TrabalhoPratico01.Models
{
  public class Autor
  {
    public string Nome { get; set; }
    public string Email { get; set; }
    public char Genero { get; set; }

    public override string ToString() => this.ToolerString();
  }
}