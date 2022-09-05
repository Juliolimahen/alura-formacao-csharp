using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ExemplosMongoDb.Models
{
    public class Livro
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Título { get; set; }
        public string? Autor { get; set; }
        public int Ano { get; set; }
        public int Páginas { get; set; }
        public List<string>? Assunto { get; set; }
    }
}
