using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoAdoNet();
            //GravarUsandoEntity();
            //RecuperarProdutos();
            //ExcluirProdutos();
            //RecuperarProdutos();
            AtualizarProduto();
        }

        private static void AtualizarProduto()
        {
            GravarUsandoEntity();
            RecuperarProdutos();
            using (var context = new ProdutoDAOEntity())
            {
                //Pegar o primeiro produto
                Produto primeiro = context.Produtos().First();
                primeiro.Nome = "Cassino Royale Editado";
                context.Atualizar(primeiro);
            }
                RecuperarProdutos();
        }

        private static void ExcluirProdutos()
        {
            using (var context = new ProdutoDAOEntity())
            {
                IList<Produto> produtos = context.Produtos();
                foreach (var item in produtos)
                {
                    context.Remover(item);
                }
            }
        }

        private static void RecuperarProdutos()
        {
            using (var context = new ProdutoDAOEntity())
            {
                IList<Produto> produtos = context.Produtos();
                Console.WriteLine("Foram encontrados {0} produtos", produtos.Count);
                foreach (var item in produtos)
                {
                    Console.WriteLine(item.Nome);
                }
            }
        }

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Cassino Royale";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var context = new ProdutoDAOEntity())
            {
                context.Adicionar(p); //adicionar produtos ao contexto(banco de dados)
            }
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }
    }
}
