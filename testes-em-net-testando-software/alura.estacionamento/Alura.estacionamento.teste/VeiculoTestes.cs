using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.estacionamento.teste
{
    public class VeiculoTestes : IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper _saidaConsoleTeste;

        public VeiculoTestes(ITestOutputHelper saidaConsoleTeste)
        {
            _saidaConsoleTeste = saidaConsoleTeste;
            _saidaConsoleTeste.WriteLine("Construtor Invocado.");
            veiculo = new Veiculo();
        }

        //Possibilidade de definir um nome pro teste
        [Fact]
        //[Trait("Funcionalidade", "Acelerar")]
        public void TestarVeiculoAcelerarComParametro10()
        {
            //Arrange
            // var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);

            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        //[Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrearComParametro10()
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Frear(10);

            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(Skip = "Teste ainda não implementado. Ignorar.")]
        public void ValidaNomeProprietario()
        {

        }

        //Método de teste que passa um objeto, meneira mais correta para grande quantidade de dados 
        [Theory]
        [ClassData(typeof(Veiculo))]
        public void TestaFichaDeInformacaDoVeiculo(Veiculo modelo)
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);
            modelo.Acelerar(10);

            //Assert
            Assert.Equal(modelo.VelocidadeAtual, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void FichaDeDadosVeiculo()
        {
            //Arrange 
            //var carro = new Veiculo();
            veiculo.Proprietario = "Carlos SIlva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Placa = "Zap-7419";
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Variante";

            //Act
            string dados = veiculo.ToString();

            //Assert 
            //verifica se contêm 
            Assert.Contains("Ficha do veículo: ", dados);
        }

        [Fact]
        public void TestarNomePropriedadeVeiculoComMenosDeTresCaracteres()
        {
            //Arrange
            string nomeProprietario = "Ab";

            //Assert
            Assert.Throws<System.FormatException>(
            //Act
            () => new Veiculo(nomeProprietario));
        }

        [Fact]
        public void TestaMensagemDeExcecaoDoQuartoCaractereDaPlaca()
        {
            //Arrange
            string placa = "ASDF8888";

            //Act
            var mensagem = Assert.Throws<System.FormatException>(
                () => new Veiculo().Placa = placa);

            //Assert
            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
        }

        public void Dispose()
        {
            _saidaConsoleTeste.WriteLine("Dispose Invocado.");
        }
    }
}