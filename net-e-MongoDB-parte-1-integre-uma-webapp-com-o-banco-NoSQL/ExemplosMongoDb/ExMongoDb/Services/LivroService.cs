using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExemplosMongoDb.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ExemplosMongoDb
{
    public class LivroService : IDisposable
    {
        public string stringConexao;
        public LivroService()
        {
            stringConexao = "mongodb://localhost:27017";
        }

        public void Dispose() { }

        public void Main(string[] args)
        {
            Task t = MainASync(args);
            Console.WriteLine();
            Console.WriteLine("Press enter");
            Console.ReadLine();
        }

        public async Task MainASync(string[] args)
        {
            List<string> lista = new List<string>();
            lista.Add("Ficção Ciêntifica");
            lista.Add("Terror");
            lista.Add("Ação");

            var livro = new Livro()
            {
                Título = "Sob a redoma",
                Autor = "Stepahn King",
                Ano = 2012,
                Páginas = 669,
                Assunto = lista
            };

            Console.WriteLine(livro);

            //acesso ao servidor do mongoDb

            IMongoClient client = new MongoClient(stringConexao);

            //acesso ao banco de dados 
            IMongoDatabase bancoDados = client.GetDatabase("Biblioteca");

            IMongoCollection<Livro> colecao = bancoDados.GetCollection<Livro>("Livros");

            //incluindo documento

            await colecao.InsertOneAsync(livro);

            Console.WriteLine("Documento Incluido");
        }
    }
}
