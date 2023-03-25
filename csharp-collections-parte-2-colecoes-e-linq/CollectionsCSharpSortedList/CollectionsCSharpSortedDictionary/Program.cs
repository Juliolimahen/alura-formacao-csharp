namespace CollectionsCSharpSortedDictionary;

class Program
{
    static void Main(string[] args)
    {

        //Nova coleção, SortedList
        IDictionary<string, Aluno> sorted
            = new SortedDictionary<string, Aluno>();

        sorted.Add("VT", new Aluno("Vanessa", 34672));
        sorted.Add("AL", new Aluno("Ana", 34673));
        sorted.Add("RN", new Aluno("Rafael", 34674));
        sorted.Add("WM", new Aluno("Wanderson", 34675));

        Imprimir(sorted);
    }

    private static void Imprimir(IDictionary<string, Aluno> alunos)
    {
        Console.WriteLine();
        foreach (var item in alunos)
        {
            Console.WriteLine(item);
        }
    }
}
