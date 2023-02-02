using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace CasaDoCodigo.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly IHttpContextAccessor _contextAcessor;
        private readonly IItemPedidoRepository _itemPedidoRepository;
        private readonly ICadastroRepository _cadastroRepository;

        public PedidoRepository(AppDbContext context, IHttpContextAccessor contextAccessor, IItemPedidoRepository itemPedidoRepository, ICadastroRepository cadastroRepository) : base(context)
        {
            _contextAcessor = contextAccessor;
            _itemPedidoRepository = itemPedidoRepository;
            _cadastroRepository = cadastroRepository;
        }

        public async Task AddItem(string codigo)
        {
            var produto = await _context.Set<Produto>()
                            .Where(p => p.Codigo == codigo)
                            .SingleOrDefaultAsync();

            if (produto == null)
            {
                throw new ArgumentException("Produto não encontrado");
            }

            var pedido = await GetPedido();

            var itemPedido = await _context.Set<ItemPedido>()
                                .Where(i => i.Produto.Codigo == codigo
                                        && i.Pedido.Id == pedido.Id)
                                .SingleOrDefaultAsync();

            if (itemPedido == null)
            {
                itemPedido = new ItemPedido(pedido, produto, 1, produto.Preco);

                await _context.Set<ItemPedido>()
                    .AddAsync(itemPedido);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<Pedido> GetPedido()
        {
            var pedidoId = GetPedidoId();
            var pedido =
                await dbSet
                .Include(p => p.Itens)
                    .ThenInclude(i => i.Produto)
                .Include(p => p.Cadastro)
                .Where(p => p.Id == pedidoId)
                .SingleOrDefaultAsync();

            if (pedido == null)
            {
                pedido = new Pedido();
                dbSet.Add(pedido);
                await _context.SaveChangesAsync();
                SetPedidoId(pedido.Id);
            }

            return pedido;
        }

        private int? GetPedidoId()
        {
            return _contextAcessor.HttpContext.Session.GetInt32("pedidoId");
        }

        private void SetPedidoId(int pedidoId)
        {
            _contextAcessor.HttpContext.Session.SetInt32("pedidoId", pedidoId);
        }

        public async Task<UpdateQuantidadeResponse> UpdateQuantidade(ItemPedido itemPedido)
        {
            var itemPedidoDB = await _itemPedidoRepository.GetItemPedido(itemPedido.Id);

            if (itemPedidoDB != null)
            {
                itemPedidoDB.AtualizaQuantidade(itemPedido.Quantidade);

                if (itemPedido.Quantidade == 0)
                {
                    await _itemPedidoRepository.RemoveItemPedido(itemPedido.Id);
                }

                await _context.SaveChangesAsync();

                var pedido = await GetPedido();
                var carrinhoViewModel = new CarrinhoViewModel(pedido.Itens);

                return new UpdateQuantidadeResponse(itemPedidoDB, carrinhoViewModel);
            }

            throw new ArgumentException("ItemPedido não encontrado");
        }

        public async Task<Pedido> UpdateCadastro(Cadastro cadastro)
        {
            var pedido = await GetPedido();
            await _cadastroRepository.Update(pedido.Cadastro.Id, cadastro);
            return pedido;
        }
    }
}
