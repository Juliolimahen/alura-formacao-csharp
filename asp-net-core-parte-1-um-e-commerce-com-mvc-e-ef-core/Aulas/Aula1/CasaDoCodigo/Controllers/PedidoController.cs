using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using CasaDoCodigo.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IItemPedidoRepository _itemPedidoRepository;

        public PedidoController(IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository, IItemPedidoRepository itempedidoRepository)
        {
            _produtoRepository = produtoRepository;
            _pedidoRepository = pedidoRepository;
            _itemPedidoRepository = itempedidoRepository;
        }

        public IActionResult Carrossel()
        {
            return View(_produtoRepository.GetProdutos());
        }

        public IActionResult Carrinho(string codigo)
        {
            if (!string.IsNullOrEmpty(codigo))
            {
                _pedidoRepository.AddItem(codigo);
            }

            List<ItemPedido> itens = _pedidoRepository.GetPedido().Itens;
            CarrinhoViewModel carrinhoViewModel = new CarrinhoViewModel(itens);
            return View(carrinhoViewModel);
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Resumo()
        {
            Pedido pedido = _pedidoRepository.GetPedido();
            return View(pedido);
        }

        [HttpPost]
        public void UpdateQuantidade([FromBody] ItemPedido itemPedido)
        {
            _itemPedidoRepository.UpdateQuantidade(itemPedido);
        }
    }
}
