using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Http;

namespace CasaDoCodigo.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly IHttpContextAccessor _contextAcessor;

        public PedidoRepository(AppDbContext context, IHttpContextAccessor contextAccessor) : base(context)
        {
            _contextAcessor = contextAccessor;
        }

        private int? GetPedidoId()
        {
            return _contextAcessor.HttpContext.Session.GetInt32("pedidoId");
        }

        private void SetPedidoId(int pedidoId)
        {
            _contextAcessor.HttpContext.Session.SetInt32("pedidoId", pedidoId);
        }
    }
}
