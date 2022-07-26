using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_CaracteresETextos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando projeto 5-caracteres e textos");

            //character
            char primeiraLetra = 'a';
            Console.WriteLine(primeiraLetra);

            // char respeita a tabela ASCII
            primeiraLetra = (char)65;
            Console.WriteLine(primeiraLetra);

            primeiraLetra += (char)1;
            Console.WriteLine(primeiraLetra);

            // string representa o tipo TEXTO
            string titulo = "Alura Cursos de tecnologia" + 2020;

            string cursosProgramacao =
//Usar @ para considerar a string com quebra de linhas(exibir da forma que aparece na IDE)
@"- .NET 
 - JAVA 
 - JavaScript";

            Console.WriteLine(titulo);
            Console.WriteLine(cursosProgramacao);

            Console.WriteLine("Execução finalizada. Tecle enter para sair...");
            Console.ReadLine();
        }
    }
}
