using CasaDoCodigo.Models;

namespace CasaDoCodigo.Repositories
{
    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(AppDbContext context) : base(context)
        {
        }

        public void UpdateQuantidade(ItemPedido itemPedido)
        {
            
        }
    }
}
