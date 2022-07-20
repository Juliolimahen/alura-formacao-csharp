// See https://aka.ms/new-console-template for more information
using ByteBanckADM.Funcionarios;
using ByteBanckADM.Funcionarios.Utilitarios;


Funcionario funcionario = new Funcionario("123456767");

funcionario.Nome = "Julio";
funcionario.Salario = 2000.0;
Console.WriteLine("Total de funcionarios: "+Funcionario.totalFuncionarios);

Diretor diretor = new Diretor("98887875465");

diretor.Nome = "Paula";
diretor.Salario = 5000.0;
Console.WriteLine("Total de funcionarios: " + Funcionario.totalFuncionarios);

GerenciadorDeBonificacao gb = new GerenciadorDeBonificacao();

gb.Registrar(diretor);
gb.Registrar(funcionario);

Console.WriteLine("Funcionario: " + funcionario.getBonificacao());
Console.WriteLine("Diretor: " + diretor.getBonificacao());
Console.WriteLine("Bonificação: " + gb.getBonificacao());

funcionario.AumentarSalario();
Console.WriteLine("Novo Salario Func: " + funcionario.Salario);
diretor.AumentarSalario();
Console.WriteLine("Salario Dir: " + diretor.Salario);
