using CasaDoCodigo.Models.ViewModels;

namespace CasaDoCodigo.Models
{
    public class UpdateQuantidadeResponse
    {
        public ItemPedido ItemPedido { get; }
        public CarrinhoViewModel CarrinhoViewModel { get; }

        public UpdateQuantidadeResponse(ItemPedido itemPedido, CarrinhoViewModel carrinhoViewModel)
        {
            ItemPedido = itemPedido;
            CarrinhoViewModel = carrinhoViewModel;
        }
    }
}
