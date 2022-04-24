using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_CriandoVariaveisPontoFlutuante
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Olá, mundo. 3-Criando variaveis ponto flutuante!");

            double valor;
            valor = 2.56;
            Console.WriteLine(valor);

            //Colocar .0 nos valores double, para não perder infomações, pois ao não colocar
            //é entido como divisão de inteiros e vai retorna um interiro
            //valor = 7/2; errado 

            //certo
            valor = 7.0/2;
            Console.WriteLine(valor);

            Console.WriteLine("A execução acabou. Tecle enter para sair");
            Console.ReadLine();
        }
    }
}
