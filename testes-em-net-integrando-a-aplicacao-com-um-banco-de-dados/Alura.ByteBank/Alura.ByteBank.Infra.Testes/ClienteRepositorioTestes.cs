using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class ClienteRepositorioTestes
    {
        //Conceito de inversão de dependência
        private readonly IClienteRepositorio _repositorio;

        private const int ID_USUARIO_TESTE_1 = 1;
        private const int ID_USUARIO_TESTE_2 = 2;

        //Conceito de Injeção de dependência 
        public ClienteRepositorioTestes()
        {
            var servico = new ServiceCollection();
            servico.AddTransient<IClienteRepositorio, ClienteRepositorio>();
            var provedor = servico.BuildServiceProvider();
            _repositorio = provedor.GetService<IClienteRepositorio>();
        }

        [Fact]
        public void TestaObterTodosClientes()
        {
            //Arrange 
            //Act
            List<Cliente> lista = _repositorio.ObterTodos();

            //Assert
            Assert.True(lista.Any());
        }

        [Fact]
        public void TestaObterClientePorId()
        {
            //Arrange
            //Act
            var cliente = _repositorio.ObterPorId(1);

            //Assert
            Assert.NotNull(cliente);

            Assert.Equal(ID_USUARIO_TESTE_1, cliente.Id);
        }

        [Theory]
        [InlineData(ID_USUARIO_TESTE_1)]
        [InlineData(ID_USUARIO_TESTE_2)]
        public void TestaObterClientesPorIds(int id)
        {

            //Arrange

            //Act
            var cliente = _repositorio.ObterPorId(id);

            //Assert
            Assert.NotNull(cliente);
        }
    }
}
