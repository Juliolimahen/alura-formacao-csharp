
namespace CollectionsCSharpObjectList;

class Program
{
    static void Main(string[] args)
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

    private static void Imprimir(List<Aula> aulas)
    {
        Console.Clear();
        foreach (Aula aula in aulas)
        {
            Console.WriteLine(aula);
        }
    }
}

class Aula : IComparable
{
    private string titulo;
    private int tempo;

    public Aula(string titulo, int tempo)
    {
        this.titulo = titulo;
        this.tempo = tempo;
    }

    public string Titulo { get => titulo; set => titulo = value; }
    public int Tempo { get => tempo; set => tempo = value; }

    public int CompareTo(object? obj)
    {
        Aula that = obj as Aula;
        return this.titulo.CompareTo(that.titulo);
    }

    public override string ToString()
    {
        return $"[título: {Titulo}, tempo: {Tempo} minutos]";
    }
}