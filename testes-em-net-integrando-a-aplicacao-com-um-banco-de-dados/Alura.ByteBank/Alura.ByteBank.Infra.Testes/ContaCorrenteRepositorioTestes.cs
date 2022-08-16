using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Alura.ByteBank.Infraestrutura.Testes.Servico;
using Alura.ByteBank.Infraestrutura.Testes.Servico.DTO;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class ContaCorrenteRepositorioTestes
    {
        //Conceito de inversão de dependência
        private readonly IContaCorrenteRepositorio _repositorio;

        private const int ID_CONTA_CORRENTE_TESTE_1 = 1;
        private const int ID_CONTA_CORRENTE_TESTE_2 = 2;

        //Conceito de Injeção de dependência 
        public ContaCorrenteRepositorioTestes()
        {
            var servico = new ServiceCollection();
            servico.AddTransient<IContaCorrenteRepositorio, ContaCorrenteRepositorio>();
            var provedor = servico.BuildServiceProvider();
            _repositorio = provedor.GetService<IContaCorrenteRepositorio>();
        }

        [Fact]
        public void TestaObterTodosContaCorrentes()
        {
            //Arrange 
            //Act
            List<ContaCorrente> lista = _repositorio.ObterTodos();

            //Assert
            Assert.True(lista.Any());
        }

        [Fact]
        public void TestaObterContaCorrentePorId()
        {
            //Arrange
            //Act
            var ContaCorrente = _repositorio.ObterPorId(1);

            //Assert
            Assert.NotNull(ContaCorrente);

            Assert.Equal(ID_CONTA_CORRENTE_TESTE_1, ContaCorrente.Id);
        }

        [Theory]
        [InlineData(ID_CONTA_CORRENTE_TESTE_1)]
        [InlineData(ID_CONTA_CORRENTE_TESTE_2)]
        public void TestaObterContaCorrentesPorIds(int id)
        {

            //Arrange

            //Act
            var ContaCorrente = _repositorio.ObterPorId(id);

            //Assert
            Assert.NotNull(ContaCorrente);
        }

        [Fact]
        public void TestaAtualizarSaldoDeterminadaConta()
        {
            var conta = _repositorio.ObterPorId(1);
            double saldoNovo = 15;
            conta.Saldo = saldoNovo;

            var atualizado = _repositorio.Atualizar(1, conta);

            Assert.True(atualizado);
        }

        [Fact]
        public void TestaInserirUmaNovaContaCorrenteNoBancoDeDados()
        {
            var conta = new ContaCorrente()
            {
                Saldo = 10,
                Identificador = Guid.NewGuid(),
                Cliente = new Cliente()
                {
                    Nome = "Irineu Silva",
                    CPF = "486.074.980-45",
                    Identificador = Guid.NewGuid(),
                    Profissao = "Dev",
                    Id = 1
                },
                Agencia = new Agencia()
                {
                    Nome = "Agencia Central Coast City",
                    Identificador = Guid.NewGuid(),
                    Id = 1,
                    Endereco = "Rua das Flores, 25",
                    Numero = 147
                }
            };

            //Act
            var retorno = _repositorio.Adicionar(conta);

            //Assert 
            Assert.True(retorno);
        }

        [Fact]
        public void TestaConsultaPixPorChaveMock()
        {
            //Arange
            var pixRepositorioMock = new Mock<IPixRepositorio>();
            var mock = pixRepositorioMock.Object;

            //Act
            var lista = mock.consultaPix(new Guid("a0b80d53-c0dd-4897-ab90-c0615ad80d5a"));

            //Assert - Verificando o comportamento
            pixRepositorioMock.Verify(b => b.consultaPix(new Guid("a0b80d53-c0dd-4897-ab90-c0615ad80d5a")));
        }

        [Fact]
        public void TestaConsultaTodosPixStub()
        {

            //Arange
            var guid = new Guid("a0b80d53-c0dd-4897-ab90-c0615ad80d5a");
            var pix = new PixDTO() { Chave = guid, Saldo = 10 };

            var pixRepositorioMock = new Mock<IPixRepositorio>();
            pixRepositorioMock.Setup(x => x.consultaPix(It.IsAny<Guid>())).Returns(pix);

            var mock = pixRepositorioMock.Object;

            //Act
            var saldo = mock.consultaPix(guid).Saldo;

            //Assert
            Assert.Equal(10, saldo);
        }

        [Fact]
        public void TestaConsultaPix()
        {
            //Arrenge
            var guid = new Guid("a0b80d53-c0dd-4897-ab90-c0615ad80d5a");
            var pix = new PixDTO { Chave = guid, Saldo = 10 };

            var pixRepositorioMock = new Mock<IPixRepositorio>();
            pixRepositorioMock.Setup(x => x.consultaPix(It.IsAny<Guid>())).Returns((PixDTO)pix);

            var mock = pixRepositorioMock.Object;

            //Act 
            var saldo = mock.consultaPix(guid).Saldo;

            //Assert
            Assert.Equal(10, saldo);
        }
    }
}
