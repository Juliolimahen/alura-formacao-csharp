using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IList<Produto>> GetProdutos()
        {
            return await dbSet.ToListAsync();
        }

        public async Task SaveProdutos(List<Livro> livros)
        {
            foreach (var livro in livros)
            {
                if (!await dbSet.Where(p => p.Codigo == livro.Codigo).AnyAsync())
                {
                    await dbSet.AddAsync(new Produto(livro.Codigo, livro.Nome, livro.Preco));
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}
