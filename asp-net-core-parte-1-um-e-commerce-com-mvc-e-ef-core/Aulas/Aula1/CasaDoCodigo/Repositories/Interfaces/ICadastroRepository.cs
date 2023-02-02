using CasaDoCodigo.Models;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface ICadastroRepository
    {
        Task<Cadastro> Update(int cadastroId, Cadastro novoCadastro);
    }
}