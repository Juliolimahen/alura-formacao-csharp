using System.Collections.Generic;

namespace CasaDoCodigo.Models
{
    public interface ICatalogo
    {
        List<Livro> GetLivros();
    }
}