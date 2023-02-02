using CasaDoCodigo.Models;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface IPedidoRepository
    {
        Task<Pedido> GetPedido();
        Task AddItem(string codigo);
        Task<UpdateQuantidadeResponse> UpdateQuantidade(ItemPedido itemPedido);
        Task<Pedido> UpdateCadastro(Cadastro cadastro);
    }
}