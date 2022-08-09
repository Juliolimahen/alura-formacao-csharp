namespace Alura.Loja.Testes.ConsoleApp
{
    public class PromocaoProduto
    {
        public PromocaoProduto() { }

        public int ProdutoId { get; set; }
        public int PromacaoId { get; set; }
        public Produto Produto { get; set; }
        public Promocao promacao { get; set; }
    }
}
