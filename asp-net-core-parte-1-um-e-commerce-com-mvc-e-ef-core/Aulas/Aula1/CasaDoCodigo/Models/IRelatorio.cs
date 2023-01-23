using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    public interface IRelatorio
    {
        Task Imprimir(HttpContext context);
    }
}