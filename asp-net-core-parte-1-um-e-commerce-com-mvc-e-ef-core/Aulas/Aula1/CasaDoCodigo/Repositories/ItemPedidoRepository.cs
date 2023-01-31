using CasaDoCodigo.Models;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(AppDbContext context) : base(context)
        {
        }

        public void UpdateQuantidade(ItemPedido itemPedido)
        {
            var itemPedidoDb =
            dbSet
                .Where(ip => ip.Id == itemPedido.Id)
                .SingleOrDefault();

            if (itemPedidoDb != null)
            {
                itemPedidoDb.AtualizaQuantidade(itemPedido.Quantidade);

                _context.SaveChanges();
            }
        }
    }
}
