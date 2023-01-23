using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    public class Relatorio : IRelatorio
    {
        private readonly Catalogo _catalogo;

        public Relatorio(Catalogo catalogo)
        {
            _catalogo = catalogo;
        }
        public async Task Imprimir(HttpContext context)
        {
            foreach (var livro in _catalogo.GetLivros())
            {
                //await context.Response.WriteAsync($"{livro.Id}, -10}{livro.Nome,50}{livro.Preco,100}");
            }
        }
    }
}
