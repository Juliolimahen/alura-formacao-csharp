using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CriandoVariaveis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Olá, mundo. 2-Projeto no Visual Studio!");
            int idade;
            idade = 24;
            Console.WriteLine(idade);

            idade = 23;
            Console.WriteLine(idade);

            idade = 10 + 5 * 2;
            Console.WriteLine(idade);

            idade = (10 + 5) * 2;
            //WriteLine escreve e quebra linha 
            Console.WriteLine(idade);

            //contenando texto e variável 
            Console.WriteLine("Sua Idade é " + idade);

            //Write escreve e continua na mesma linha 
            Console.Write(idade);

            Console.WriteLine("A execução acabou. Tecle enter para sair");
            Console.ReadLine();
        }
    }
}
