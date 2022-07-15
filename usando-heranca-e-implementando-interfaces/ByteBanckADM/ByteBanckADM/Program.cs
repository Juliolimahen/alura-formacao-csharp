// See https://aka.ms/new-console-template for more information
using ByteBanckADM.Funcionarios;
using ByteBanckADM.Funcionarios.Utilitarios;



Sorteio sorteio = new Sorteio();

sorteio.getRandomNumber();
int n;
do
{
    switch (sorteio.getRandomNumber())
    {
        case 0:
            Console.WriteLine("corinthians");
            break;
        case 1:
            Console.WriteLine("fortaleza");
            break;
        case 2:
            Console.WriteLine("flamengo");
            break;
        case 3:
            Console.WriteLine("são paulo");
            break;
        case 4:
            Console.WriteLine("america");
            break;
        case 5:
            Console.WriteLine("atletico go");
            break;
        case 6:
            Console.WriteLine("fluminense");
            break;
        case 7:
            Console.WriteLine("athletico pa");
            break;
    }


    Console.WriteLine("Deseja sortear outro time? ");
    n = int.Parse(Console.ReadLine());

}while (n ==1);
