namespace CollectionsCSharpSortedSet;

class Program
{
    static void Main(string[] args)
    {
        //Conjuntos de Alunos
        ISet<string> alunos = new SortedSet<string>(new CoparadorMinusculo())
        {
            "Vanessa Tonini",
            "Ana Losnak",
            "Rafael Nercessian",
            "Priscila Stuani"
        };

        //adicionar: Rafael Rollo
        alunos.Add("Rafael Rollo");
        //adicionar: Fabio Gushiken
        alunos.Add("Fabio Gushiken");
        //adicionar: Fabio Gushiken
        alunos.Add("Fabio Gushiken");
        //adicionar: FABIO GUSHIKEN
        alunos.Add("FABIO GUSHIKEN");

        Imprimir(alunos);

        ISet<string> outroConjunto = new HashSet<string>(){
            "Vanessa Tonini",
            "Ana Losnak",
            "Rafael Nercessian",
            "Priscila Stuani"
        };

        outroConjunto.Add("Rafael Rollo");
        //adicionar: Fabio Gushiken
        outroConjunto.Add("Fabio Gushiken");
        //adicionar: Fabio Gushiken
        outroConjunto.Add("Fabio Gushiken");
        //adicionar: FABIO GUSHIKEN
        outroConjunto.Add("FABIO GUSHIKEN");

        outroConjunto.Add("Jubileu Gushiken");

        Console.WriteLine();

        //este conjunto é subconjunto de outro? IsSubsetOf
        Console.Write("Este conjunto é subconjunto de outro? ");
        Console.WriteLine(alunos.IsSubsetOf(outroConjunto));

        //este conjunto é superconjunto de outro? IsSupersetOf
        Console.Write("Este conjunto é superconjunto de outro? ");
        Console.WriteLine(alunos.IsSupersetOf(outroConjunto));

        //os conjuntos contêm os mesmo elementos? SetEquals
        Console.Write("Os conjuntos contêm os mesmo elementos? ");
        Console.WriteLine(alunos.SetEquals(outroConjunto));

        //subtrai os elementos da outra coleção que também estão nesse? ExceptWith
        alunos.ExceptWith(outroConjunto);

        Imprimir(alunos);

        //intersecção dos conjuntos - IntersectWith
        alunos.IntersectWith(outroConjunto);

        Imprimir(outroConjunto);

        //somente em um ou outro conjunto - SymmetricExceptWith
        alunos.SymmetricExceptWith(outroConjunto);

        Imprimir(outroConjunto);

        //união de conjuntos - UnionWith
        alunos.UnionWith(outroConjunto);

        Imprimir(alunos);
    }

    private static void Imprimir(ISet<string> alunos)
    {
        Console.WriteLine();

        foreach (var item in alunos)
        {
            Console.WriteLine(item);
        }
    }
}
