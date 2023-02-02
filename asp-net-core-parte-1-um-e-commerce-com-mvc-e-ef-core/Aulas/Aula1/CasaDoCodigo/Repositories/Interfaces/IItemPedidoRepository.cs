using CasaDoCodigo.Models;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface IItemPedidoRepository
    {
        Task<ItemPedido> GetItemPedido(int itemPedidoId);
        Task RemoveItemPedido(int itemPedidoId);
    }
}