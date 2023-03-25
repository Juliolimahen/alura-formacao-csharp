using System;

namespace CollectionsCSharpConsultas
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Mes> meses = new List<Mes>
            {
                new Mes("Janeiro", 30),
                new Mes("Janeiro", 31),
                new Mes("Fevereiro", 28),
                new Mes("Março", 31),
                new Mes("Abril", 30),
                new Mes("Maio", 31),
                new Mes("Junho", 30),
                new Mes("Julho", 31),
                new Mes("Agosto", 31),
                new Mes("Setembro", 30),
                new Mes("Outubro", 31),
                new Mes("Novembro", 30),
                new Mes("Dezembro", 31)
            };

            //meses.Sort();

            //foreach (var mes in meses)
            //{
            //    if (mes.Dias == 31)
            //    {
            //        Console.WriteLine(mes.Nome.ToUpper());
            //    }
            //}

            //LINQ = Consulta integrada à linguagem 

            IEnumerable<string>
                consulta = meses
                            .Where(m => m.Dias == 31)
                            .OrderBy(m => m.Nome)
                            .Select(m => m.Nome.ToUpper());

            Imprimir(consulta);
        }

        private static void Imprimir(IEnumerable<string> consulta)
        {
            foreach (var item in consulta)
            {
                Console.WriteLine(item);
            }
        }
    }
}