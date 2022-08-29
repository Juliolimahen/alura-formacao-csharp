using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemplosMongoDb
{
    public class AcessandoMongoDb
    {
        public async Task MainASync(string[] args)
        {
            try
            {
                var doc = new BsonDocument
           {
               { "Título", "Guerra dos Tronos"}
           };

                doc.Add("Autor", "George R R Martin");
                doc.Add("Ano", 1999);
                doc.Add("Páginas", 856);

                var assuntoArray = new BsonArray();
                assuntoArray.Add("Fantasia");
                assuntoArray.Add("Ação");
                doc.Add("Assunto", assuntoArray);

                Console.WriteLine(doc);

                //acesso ao servidor do mongoDb

                string stringConexao = "mongodb://localhost:27017";

                IMongoClient client = new MongoClient(stringConexao);

                //acesso ao banco de dados 
                IMongoDatabase bancoDados = client.GetDatabase("Biblioteca");

                IMongoCollection<BsonDocument> colecao = bancoDados.GetCollection<BsonDocument>("Livros");

                //incluindo documento

                await colecao.InsertOneAsync(doc);

                Console.WriteLine("Documento Incluido");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
