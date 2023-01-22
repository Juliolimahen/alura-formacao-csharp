using System.Collections.Generic;

namespace CasaDoCodigo.Models
{
    public class Catalogo
    {
        public List<Livro> GetLivros()
        {
            var livros = new List<Livro>();

            livros.Add(new Livro("001", "Arte da Guerra", 30.44m));
            livros.Add(new Livro("002", "Arte de ligar o foda-se", 30.88m));
            livros.Add(new Livro("003", "Como as democracias morrem", 100.44m));

            return livros;
        } 
    }
}
