
namespace CollectionsCSharpObjectList;

class Program
{
    static void Main(string[] args)
    {
        Curso curso = new Curso("C# Collections", "Marcelo Oliveira");

        ////Code smell, exposição indecente
        //curso.Aulas.Add(new Aula("Trabalhando com listas", 21));

        curso.Adiciona(new Aula("Trabalhando com listas", 21));
        Imprimir(curso.Aulas);

        curso.Adiciona(new Aula("Criando uma Aula", 20));
        curso.Adiciona(new Aula("Modelando com Coleções", 19));

        Imprimir(curso.Aulas);

        //Copiar a lista para outra lista 
        List<Aula> aulasCopia = new List<Aula>(curso.Aulas);

        // Ordernar a copia
        aulasCopia.Sort();
        Imprimir(aulasCopia);

        //Totalizar o tempo do curso
        Console.WriteLine(curso.TempoTotal);

        Console.WriteLine(curso);
    }

    private static void OperacoesComListasDeObjetos()
    {
        var aulaIntro = new Aula("Introdução às Coleções", 20);
        var aulaModelando = new Aula("Modelando a Classe Aula", 18);
        var aulaSets = new Aula("Trabalhando com Conjuntos", 16);

        List<Aula> aulas = new List<Aula>();

        aulas.Add(aulaIntro);
        aulas.Add(aulaModelando);
        aulas.Add(aulaSets);

        Imprimir(aulas);

        aulas.Sort();

        Imprimir(aulas);

        //Lambda para comparar
        aulas.Sort((x, y) => x.Tempo.CompareTo(y.Tempo));

        Imprimir(aulas);
    }

    private static void Imprimir(IList<Aula> aulas)
    {
        Console.Clear();
        foreach (Aula aula in aulas)
        {
            Console.WriteLine(aula);
        }
    }
}