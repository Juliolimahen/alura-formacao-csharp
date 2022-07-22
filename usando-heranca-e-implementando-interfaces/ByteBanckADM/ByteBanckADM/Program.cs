// See https://aka.ms/new-console-template for more information
using ByteBanckADM.Funcionarios;
using ByteBanckADM.Funcionarios.Utilitarios;


void CalcularBonificacao()
{
    GerenciadorDeBonificacao gb = new GerenciadorDeBonificacao();
    Designer pedro = new Designer("123.445.567-12");
    pedro.Nome = "Pedro";

    Diretor paula = new Diretor("987.654.321-12");
    paula.Nome = "Paula";

    Auxiliar igor = new Auxiliar("159.753.398-04");
    igor.Nome = "igor";

    GerenteDeContas camila = new GerenteDeContas("987-423-334-33");

}
