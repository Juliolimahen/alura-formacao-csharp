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