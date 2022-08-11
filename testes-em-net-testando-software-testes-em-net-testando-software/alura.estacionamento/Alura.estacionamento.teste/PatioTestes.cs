using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Alura.estacionamento.teste
{
    public class PatioTestes : IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper _saidaConsoleTeste;
        private Operador operador;

        public PatioTestes(ITestOutputHelper saidaConsoleTeste)
        {
            _saidaConsoleTeste = saidaConsoleTeste;
            _saidaConsoleTeste.WriteLine("Construtor Invocado.");
            veiculo = new Veiculo();
            operador = new Operador();
            operador.Nome = "Pedro irineu";
        }

        [Fact]
        public void ValidaFaturamentoDoEstacionamentoComUmVeiculo()
        {
            //Arrange
            //var veiculo = new Veiculo();
            var estacionamento = new Patio();

            estacionamento.OperadorPatio = operador;

            veiculo.Proprietario = "André Silva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert 
            Assert.Equal(2, faturamento);
        }
        [Theory]
        [InlineData("André Silva", "ASD-1498", "preto", "Gol")]
        [InlineData("José Silva", "ASD-1497", "prata", "Uno")]
        [InlineData("Anderson Silva", "ASD-1499", "braco", "Celta")]
        public void ValidaFaturamentoDoEstacionamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            var estacionamento = new Patio();
            //var veiculo = new Veiculo();
            estacionamento.OperadorPatio = operador;
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }
        [Theory]
        [InlineData("André Silva", "ASD-1498", "preto", "Gol")]
        public void LocalizaVeiculoNoPatioComBaseNoIdDoTicket(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            var estacionamento = new Patio();
            estacionamento.OperadorPatio = operador;

            //var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act 
            var consulta = estacionamento.PesquisaVeiculo(veiculo.IdTicket);

            //Assert
            Assert.Contains("### Ticket EStacionamento Alura ###", consulta.Ticket);
        }

        [Fact]
        public void AlterarDadosVeiculosDoProprioVeiculo()
        {
            //Arrange
            // var veiculo = new Veiculo();
            var estacionamento = new Patio();

            estacionamento.OperadorPatio = operador;

            veiculo.Proprietario = "André Silva";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Arrange
            var veiculoAlterado = new Veiculo();

            veiculoAlterado.Proprietario = "André Silva";
            veiculoAlterado.Cor = "preto";
            veiculoAlterado.Modelo = "Fusca";
            veiculoAlterado.Placa = "asd-9999";

            //Act
            Veiculo alterado = estacionamento.AlterarVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }

        public void Dispose()
        {
            _saidaConsoleTeste.WriteLine("Dispose Invocado.");
        }
    }
}
