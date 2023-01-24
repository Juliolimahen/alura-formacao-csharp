using CasaDoCodigo.Models;
using System.Collections.Generic;

namespace CasaDoCodigo.Repositories
{
    public interface IProdutoRepository
    {
        IList<Produto> GetProdutos();
        void SaveProdutos(List<Livro> livros);
    }
}