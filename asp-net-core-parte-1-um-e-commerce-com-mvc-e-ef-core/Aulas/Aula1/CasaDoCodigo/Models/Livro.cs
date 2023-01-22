namespace CasaDoCodigo.Models
{
    public class Livro
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public Livro(string id, string nome, decimal preco)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
        }
    }
}
