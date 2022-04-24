using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_ConversoesEOutrosTiposNumericos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Olá, mundo. 4-Conversões de valores  e outros tipos numericos!");

            double salario;
            salario = 2000.56;
            Console.WriteLine(salario);

            int salarioInteiro;

            //Fazendo cast (converter um tipo em outro)
            salarioInteiro = (int)salario;
            Console.WriteLine(salarioInteiro);
            
            //Armazena numeros de tamanho de 32 bits 
            int teste = 1300000000;
            Console.WriteLine(teste);

            //Armazena numeros de tamanho de 64 bits 
            long teste1 = 1300000000000000000;
            Console.WriteLine(teste1);

            //Armazena numeros de tamanho de 16 bits 
            short teste2 = 13000;
            Console.WriteLine(teste2);

            //Usa o sufixo f, para o csharp entender que vc realmente queria usar um float ao inves do double(que é mais recomendado)
            float altura = 1.80f;
            Console.WriteLine(altura);

            Console.WriteLine("A execução acabou. Tecle enter para sair");
            Console.ReadLine();
        }
    }
}
