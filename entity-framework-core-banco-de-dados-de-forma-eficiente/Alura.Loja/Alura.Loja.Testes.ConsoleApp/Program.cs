using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
            #region como o entity monta o sql
            //GravarUsandoAdoNet();
            //GravarUsandoEntity();
            //RecuperarProdutos();
            //ExcluirProdutos();
            //RecuperarProdutos();
            //AtualizarProduto();

            //using(var contexto = new LojaContext())
            //{
            //    var produtos = contexto.Produtos.ToList();
            //    foreach (var p in produtos)
            //    {
            //        Console.WriteLine(p);
            //    }

            //    Console.WriteLine("=================");
            //    foreach (var e in contexto.ChangeTracker.Entries())
            //    {
            //        Console.WriteLine(e);
            //    }

            //    var p1 = produtos.Last();
            //    p1.Nome = "007 - O Espiao Que Me Amava";

            //    Console.WriteLine("=================");
            //    foreach (var e in contexto.ChangeTracker.Entries())
            //    {
            //        Console.WriteLine(e.State);
            //    }
            //}
            #endregion
            #region capitulo change tracker
            //using (var contexto = new LojaContext())
            //{

            //var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
            //var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            //loggerFactory.AddProvider(SqlLoggerProvider.Create());

            //var produtos = contexto.Produtos.ToList();
            //foreach (var p in produtos)
            //{
            //    Console.WriteLine(p);
            //}

            //Console.WriteLine("=================");
            //foreach (var e in contexto.ChangeTracker.Entries())
            //{
            //    Console.WriteLine(e);
            //}

            //var p1 = produtos.Last();
            //p1.Nome = "007 - O Espiao Que Me Amava";

            //Console.WriteLine("=================");
            //foreach (var e in contexto.ChangeTracker.Entries())
            //{
            //    Console.WriteLine(e.State);
            //}

            //contexto.SaveChangesAsync();

            //Console.WriteLine("=================");
            //produtos = contexto.Produtos.ToList();
            //foreach (var p in produtos)
            //{
            //    Console.WriteLine(p);
            //}

            //}
            #endregion

            //Compra de 6 pães fraceses
            var paoFraces = new Produto();

            //paoFraces.Id = 1;
            paoFraces.Nome = "Pão Francês";
            paoFraces.PrecoUnitario = 0.40;
            paoFraces.Unidade = "kg";

            var compra = new Compra();
            //compra.Id = 1;
            compra.Quantidade = 2;
            compra.Produto = paoFraces;
            compra.Tipo = "Massas";

            var promocaoDePascoa = new Promocao();
            promocaoDePascoa.Descricao = "Páscoa Feliz";
            promocaoDePascoa.DataInicio = DateTime.Now;
            promocaoDePascoa.DataTermino = DateTime.Now.AddMonths(3);

            //promocaoDePascoa.Produtos.Add(new PromocaoProduto());
            //promocaoDePascoa.Produtos.Add(new Produto());
            //promocaoDePascoa.Produtos.Add(new Produto());

            using (var context = new LojaContext())
            {
                var serviceProvider = context.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                context.Compras.Add(compra);
                context.SaveChanges();
            }
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
            p.Nome = "Harry";
            p.Categoria = "Livros";
            p.PrecoUnitario = 17.89;

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
            p.PrecoUnitario = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }
    }
}
