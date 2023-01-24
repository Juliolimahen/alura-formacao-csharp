using CasaDoCodigo.Models;

namespace CasaDoCodigo.Repositories
{
    public class CadastroRepository : BaseRepository<Cadastro>, ICadastroRepository
    {
        public CadastroRepository(AppDbContext context) : base(context)
        {
        }
    }
}
