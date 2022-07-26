using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_AtribuicaoDeVariaveis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando projeto 5-atribuição de variaveis");

            int idade = 64;
            int idadeJulio = idade;

            idade = 93;

            Console.WriteLine(idade);
            Console.WriteLine(idadeJulio);

            Console.ReadLine();
        }
    }
}
