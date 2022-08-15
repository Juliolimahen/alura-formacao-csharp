using Alura.ByteBank.Dados.Contexto;
using System;
using Xunit;

namespace Alura.ByteBank.Infra.Testes
{
    public class ByteBankContextoTestes
    {
        [Fact]
        public void TestaConexaoContextoComBDMySQL()
        {
            //Arrange
            var contexto = new ByteBankContexto();
            bool conectado;

            //Act
            try
            {
                conectado = contexto.Database.CanConnect();
            }
            catch (Exception ex)
            {
                throw new Exception("N�o foi possivel conectar a base de dados. "+ex);
            }

            //Assert
            Assert.True(conectado);
        }
    }
}
