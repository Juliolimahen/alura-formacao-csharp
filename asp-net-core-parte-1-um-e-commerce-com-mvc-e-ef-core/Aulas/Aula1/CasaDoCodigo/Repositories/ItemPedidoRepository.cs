using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<ItemPedido> GetItemPedido(int itemPedidoId)
        {
            return
                await dbSet
                .Where(ip => ip.Id == itemPedidoId)
                .SingleOrDefaultAsync();
        }

        public async Task RemoveItemPedido(int itemPedidoId)
        {
            dbSet.Remove(await GetItemPedido(itemPedidoId));
        }
    }
}
