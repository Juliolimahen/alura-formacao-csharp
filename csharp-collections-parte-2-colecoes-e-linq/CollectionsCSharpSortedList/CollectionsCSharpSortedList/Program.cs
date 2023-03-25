namespace CollectionsCSharpSortedList;

class Program
{
    static void Main(string[] args)
    {
        //vamos criar um dicionário de alunos 
        //VT, Vanessa, 34672
        //AL, Ana, 34672
        //RN, Rafael,17645
        //WM, Wanderson, 11287
        IDictionary<string, Aluno> alunos
            = new Dictionary<string, Aluno>();

        alunos.Add("VT", new Aluno("Vanessa", 34672));
        alunos.Add("AL", new Aluno("Ana", 34673));
        alunos.Add("RN", new Aluno("Rafael", 34674));
        alunos.Add("WM", new Aluno("Wanderson", 34675));

        Imprimir(alunos);

        //Remover:AL 
        alunos.Remove("AL");

        //Vamos adicionar: MO 
        alunos.Add("MO", new Aluno("Marcelo", 12345));

        Imprimir(alunos);

        //Nova coleção, SortedList
        IDictionary<string, Aluno> sorted
            = new SortedList<string, Aluno>();

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