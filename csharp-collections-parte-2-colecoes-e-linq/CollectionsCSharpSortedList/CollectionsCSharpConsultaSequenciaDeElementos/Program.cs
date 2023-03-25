namespace CollectionsCSharpConsultaSequenciaDeElementos;


class Program
{
    static void Main(string[] args)
    {
        List<Mes> meses = new List<Mes>
        {
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

        //Pegar o primeiro trimestre
        var consulta = meses.Take(3);
        Imprimir(consulta);

        //Pegar os meses depois do primeiro trimestre
        var consulta2 = meses.Skip(3);
        Imprimir(consulta2);

        //Pegar os meses do terceiro trimestre 
        var consulta3 = meses.Skip(6).Take(3);
        Imprimir(consulta3);

        //Pegar os meses até que o mês comece com a letra 'S'
        var consulta4 = meses.TakeWhile(m => !m.Nome.StartsWith('S'));
        Imprimir(consulta4);

        //Pular os meses até que o mês comece com a letra 'S'
        var consultas5 = meses.SkipWhile(m => !m.Nome.StartsWith('S'));
        Imprimir(consultas5);
    }

    private static void Imprimir(IEnumerable<Mes> consulta)
    {
        Console.WriteLine();
        foreach (var item in consulta)
        {
            Console.WriteLine(item);
        }
    }
}