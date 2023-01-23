namespace CasaDoCodigo.Models
{
    public class Livro
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public Livro(string id, string nome, decimal preco)
        {
            Codigo = id;
            Nome = nome;
            Preco = preco;
        }
    }
}
