﻿// See https://aka.ms/new-console-template for more information
using ByteBanckADM.Funcionarios;
using ByteBanckADM.Funcionarios.Utilitarios;
using ByteBanckADM.SistemaInterno;


CalcularBonificacao();
UsarSistema();

void CalcularBonificacao()
{
    GerenciadorDeBonificacao gb = new GerenciadorDeBonificacao();
    Designer pedro = new Designer("123.445.567-12");
    pedro.Nome = "Pedro";

    Diretor paula = new Diretor("987.654.321-12");
    paula.Nome = "Paula";

    Auxiliar igor = new Auxiliar("159.753.398-04");
    igor.Nome = "Igor";

    GerenteDeContas camila = new GerenteDeContas("987.423.334-33");
    camila.Nome = "Camila";

    GerenteDeContas julio = new GerenteDeContas("987.423.334-33");
    camila.Nome = "Julio";

    gb.Registrar(pedro);
    gb.Registrar(paula);
    gb.Registrar(igor);
    gb.Registrar(camila);
    gb.Registrar(julio);

    Console.WriteLine("Totakl de Bonificação: " + gb.GetBonificacao());
}

void UsarSistema()
{
    SistemaInterno sistemaInterno = new SistemaInterno();

    Diretor roberta = new Diretor("987.654.321-12");
    roberta.Nome = "Roberta";
    roberta.Senha = "1234";

    GerenteDeContas ursula = new GerenteDeContas("159.753.398-04");
    ursula.Nome = "Ursula";
    ursula.Senha = "1234";

    if (sistemaInterno.Logar(ursula, "1234"))
    {
        Console.WriteLine("bem-vido ao sistema, " + ursula.Nome);
    }
    else
    {
        Console.WriteLine("senha incorreta");
    }
    if (sistemaInterno.Logar(roberta, "134"))
    {
        Console.WriteLine("bem-vido ao sistema " + roberta.Nome);
    }
    else
    {
        Console.WriteLine("senha incorreta");
    }
}
