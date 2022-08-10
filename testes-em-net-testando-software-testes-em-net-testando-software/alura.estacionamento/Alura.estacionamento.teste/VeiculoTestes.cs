using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.estacionamento.teste
{
    public class VeiculoTestes
    {
        //Possibilidade de definir um nome pro teste
        [Fact(DisplayName = "Teste n° 1")]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestarVeiculoAcelerar()
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);

            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrear()
        {
            //Arrange
            var veiculo = new Veiculo();

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
        public void TestaVeiculoClass(Veiculo modelo)
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);
            modelo.Acelerar(10);

            //Assert
            Assert.Equal(modelo.VelocidadeAtual, veiculo.VelocidadeAtual);
        }
    }
}