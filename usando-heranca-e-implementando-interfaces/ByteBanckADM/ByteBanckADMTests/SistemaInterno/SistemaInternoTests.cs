using Microsoft.VisualStudio.TestTools.UnitTesting;
using ByteBanckADM.SistemaInterno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBanckADM.Funcionarios;

namespace ByteBanckADM.SistemaInterno.Tests
{
    [TestClass()]
    public class SistemaInternoTests
    {
        private string usuario = "julio";
        private string senha = "1234";
        private const string SENHA_INSERIDA = "1234";
        private Diretor diretor = new Diretor("123.456.789-00");

        public SistemaInternoTests()
        {
            diretor.Nome = usuario;
            diretor.Senha = senha;
        }

        [TestMethod()]
        public void LogarTest()
        {
            Assert.IsTrue(diretor.Autenticar(SENHA_INSERIDA));
        }
    }
}