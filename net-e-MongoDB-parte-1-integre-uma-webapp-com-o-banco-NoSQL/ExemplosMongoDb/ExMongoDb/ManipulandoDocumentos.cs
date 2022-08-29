using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace ExemplosMongoDb
{
    public class ManipulandoDocumentos
    {
        public async Task MainASync(string[] args)
        {
            var doc = new BsonDocument
           {
               { "Título", "Guerra dos Tronos"}
           };

            doc.Add("Autor", "George R R Martin");
            doc.Add("Ano", 1999);
            doc.Add("Páginas", 856);

            var assuntoArray = new BsonArray { };
            assuntoArray.Add("Fantasia");
            assuntoArray.Add("Ação");
            doc.Add("Assunto", assuntoArray);

            Console.WriteLine(doc);
        }
    }
}
