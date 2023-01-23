﻿using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CasaDoCodigo
{
    class DataService : IDataService
    {
        private readonly AppDbContext _context;
        private readonly IProdutoRepository _produtoRepository;

        public DataService(AppDbContext context, IProdutoRepository produtoRepository)
        {
            _context = context;
            _produtoRepository = produtoRepository;
        }

        public void InicializarDb()
        {
            _context.Database.EnsureCreated();

            List<Livro> livros = GetLivros();
            _produtoRepository.SaveProdutos(livros);
        }

        private static List<Livro> GetLivros()
        {
            var json = File.ReadAllText("livros.json");
            var livros = JsonConvert.DeserializeObject<List<Livro>>(json);
            return livros;
        }
    }
}
