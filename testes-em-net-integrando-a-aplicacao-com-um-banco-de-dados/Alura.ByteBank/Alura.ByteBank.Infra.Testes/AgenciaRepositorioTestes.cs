using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Alura.ByteBank.Infraestrutura.Testes.Servico;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class AgenciaRepositorioTestes
    {
        //Conceito de inversão de dependência
        private readonly IAgenciaRepositorio _repositorio;
        private ITestOutputHelper SaidaConsoleTeste { get; set; }

        private const int ID_AGENCIA_TESTE_1 = 1;
        private const int ID_AGENCIA_TESTE_2 = 2;

        //Conceito de Injeção de dependência 
        public AgenciaRepositorioTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado");

            //Injetando dependências no construtor
            var servico = new ServiceCollection();
            servico.AddTransient<IAgenciaRepositorio, AgenciaRepositorio>();
            var provedor = servico.BuildServiceProvider();
            _repositorio = provedor.GetService<IAgenciaRepositorio>();
        }

        [Fact]
        public void TestaObterTodosAgencias()
        {
            //Arrange 
            //Act
            List<Agencia> lista = _repositorio.ObterTodos();

            //Assert
            Assert.True(lista.Any());
        }

        [Fact]
        public void TestaObterAgenciaPorId()
        {
            //Arrange
            //Act
            var cliente = _repositorio.ObterPorId(1);

            //Assert
            Assert.NotNull(cliente);

            Assert.Equal(ID_AGENCIA_TESTE_1, cliente.Id);
        }

        [Theory]
        [InlineData(ID_AGENCIA_TESTE_1)]
        [InlineData(ID_AGENCIA_TESTE_2)]
        public void TestaObterAgenciasPorIds(int id)
        {

            //Arrange

            //Act
            var cliente = _repositorio.ObterPorId(id);

            //Assert
            Assert.NotNull(cliente);
        }

        [Fact]
        public void TestaRemoverInformacaoDeterminadaAgencia()
        {
            //Arrange

            //Act 
            var atualizado = _repositorio.Excluir(10);

            //Assert
            Assert.True(atualizado);
        }

        [Fact]
        public void TestaExececaoConsultaPorAgenciaPorId()
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<Exception>(() => _repositorio.ObterPorId(33));
        }

        [Fact]
        public void TesteInsereUmaNovaAgenciaNaBaseDeDadosRepositorio()
        {
            //Arrange            
            string nome = "Agencia Guarapari";
            int numero = 125982;
            Guid identificador = Guid.NewGuid();
            string endereco = "Rua: 7 de Setembro - Centro";

            var agencia = new Agencia()
            {
                Nome = nome,
                Identificador = identificador,
                Endereco = endereco,
                Numero = numero
            };

            //Act
            var retorno = _repositorio.Adicionar(agencia);

            //Assert
            Assert.True(retorno);
        }

        [Fact]
        public void TestaAdicionarAgenciaMock()
        {
            var agencia = new Agencia()
            {
                Nome = "Agencia Irineu",
                Identificador = Guid.NewGuid(),
                Id = 4,
                Endereco = "Rua Arthur Costa",
                Numero = 6497
            };

            var repositorioMock = new ByteBankRepositorio();

            //Act
            var adicionado = repositorioMock.AdicionarAgencia(agencia);

            //Assert 
            Assert.True(adicionado);
        }
        [Fact]
        public void TestaObterAgenciaMock()
        {
            //Arrange 
            var bytebankRepositorioMock = new Mock<IByteBankRepositorio>();
            var mock = bytebankRepositorioMock.Object;

            //Act
            var lista = mock.BuscarAgencias();

            //Assert 
            bytebankRepositorioMock.Verify(b => b.BuscarAgencias());
        }
    }
}
