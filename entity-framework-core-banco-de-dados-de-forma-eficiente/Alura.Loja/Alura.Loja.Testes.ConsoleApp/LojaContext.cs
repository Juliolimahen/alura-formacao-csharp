using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Loja.Testes.ConsoleApp
{
    internal class LojaContext : DbContext
    {
        /// <summary>
        /// Propriedade responsável por definir qual classe iremos persistir (Mapear)
        /// </summary>
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Promocao> Promocoes { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        //É executado no evento de criação 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //composição de chaves primarias 
            modelBuilder.Entity<PromocaoProduto>().HasKey(p => new { p.PromocaoId, p.ProdutoId });
            base.OnModelCreating(modelBuilder);

            //Definindo o nome da tabela
            modelBuilder.Entity<Endereco>()
                .ToTable("Enderecos");

            //Criando Propiedade não mapeada 
            modelBuilder
                .Entity<Endereco>()
                .Property<int>("ClienteId");

            //Criando chaves estrageira 
            modelBuilder.Entity<Endereco>()
                .HasKey("ClienteId");
        }


        /// <summary>
        /// Método Responsável por realizar o configuração com o banco de dados
        /// Herdado e subscrito da classe DbContext
        /// Define a string de conexão a ser usada 
        /// Informa qual banco usar e onde se encontra
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DEVPC\\SQLEXPRESS;Initial Catalog=LojaDb;Integrated Security=True");
        }
    }
}