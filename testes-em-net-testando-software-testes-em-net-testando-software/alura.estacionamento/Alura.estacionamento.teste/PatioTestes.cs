using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.estacionamento.teste
{
    public class PatioTestes
    {
        [Fact]
        public void ValidaFaturamento()
        {
            //Arrange
            var veiculo = new Veiculo();
            var estacionamento = new Patio();

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
        public void ValidaFaturamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
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
        public void LocalizaVeiculoNoPatio(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act 
            var consulta = estacionamento.PesquisaVeiculo(placa);

            //Assert
            Assert.Equal(placa, consulta.Placa);
        }
        public void AlterarDadosVEiculos()
        {
            //Arrange
            var veiculo = new Veiculo();
            var estacionamento = new Patio();

            veiculo.Proprietario = "André Silva";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            //Arrange
            var veiculoAlterado = new Veiculo();

            veiculo.Proprietario = "André Silva";
            veiculo.Cor = "preto";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-9999";

            //Act
            Veiculo alterado = estacionamento.AlterarVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }

        [Fact]
        public void DadosVeiculo()
        {
            //Arrange 
            var carro = new Veiculo();
            carro.Proprietario = "Carlos SIlva";
            carro.Tipo = TipoVeiculo.Automovel;
            carro.Placa = "Zap-7419";
            carro.Cor = "Preto";
            carro.Modelo = "Variante";

            //Act
            string dados = carro.ToString();

            //Assert 
            //verifica se contêm 
            Assert.Contains("Ficha do veículo: ", dados);
        }
    }
}
