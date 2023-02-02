using CasaDoCodigo.Models;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class CadastroRepository : BaseRepository<Cadastro>, ICadastroRepository
    {
        public CadastroRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<Cadastro> Update(int cadastroId, Cadastro novoCadastro)
        {
            var cadastroDB =
                await dbSet.Where(c => c.Id == cadastroId)
                .SingleOrDefaultAsync();

            if (cadastroDB == null)
            {
                throw new ArgumentNullException("cadastro");
            }

            cadastroDB.Update(novoCadastro);
            await _context.SaveChangesAsync();
            return cadastroDB;
        }
    }
}
