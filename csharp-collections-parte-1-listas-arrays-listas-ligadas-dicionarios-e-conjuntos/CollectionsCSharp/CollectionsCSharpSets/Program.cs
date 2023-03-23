
namespace CollectionsCSharpSets;


class Program
{
    static void Main(string[] args)
    {
        Curso curso = new Curso("C# Coleções", "Marcelo Oliverira");

        curso.Adiciona(new Aula("Trabalhando com listas", 21));
        curso.Adiciona(new Aula("Criando uma Aula", 20));
        curso.Adiciona(new Aula("Modelando com Coleções", 24));

        Aluno a1 = new Aluno("Vanessa Tonini", 34672);
        Aluno a2 = new Aluno("Ana Losnak", 34673);
        Aluno a3 = new Aluno("Rafel Nercessian", 34675);

        // gerar matricula

        curso.Matricula(a1);
        curso.Matricula(a2);
        curso.Matricula(a3);

        //Imprimindo os alunos matriculados
        Console.WriteLine("Imprimindo os alunos matriculados");

        foreach (var aluno in curso.Alunos)
        {
            Console.WriteLine(aluno);
        }

        Console.WriteLine($"O aluno a1 {a1.Nome} está matriculado?");

        //Criar método, para verifcar se está matriculado
        Console.WriteLine(curso.EstaMatriculado(a1));

        Aluno tonini = new Aluno("Vanessa Tonini", 34672);

        Console.WriteLine("Tonini está matriculada? " + curso.EstaMatriculado(tonini));

        Console.WriteLine("Quem é o aluno com matrícula 34672");

        //Implementando busca matriculado,
        Aluno aluno34672 = curso.BuscaMatriculado(34672);

        //Imprimindo
        Console.WriteLine("Aluno 34672 " + aluno34672);

        //Quem é o aluno 5618?
        Console.WriteLine("Quem é o aluno 5618?");
        Console.WriteLine(curso.BuscaMatriculado(5618));

        //Matricular novo aluno
        Aluno fabio = new Aluno("Fabio Melo", 34672);
        //curso.Matricula(fabio);

        //Substitui aluno
        curso.Substitui(fabio);

        Console.WriteLine("Quem é o aluno com matrícula 34672");
        Console.WriteLine(curso.BuscaMatriculado(34672));
    }

    private static void OperacoesComConjuntos()
    {
        // Sets = conjuntos
        // Duas propiedades do set 
        //1. Não permite duplicidade 
        //2. Os elementos não são mantidos em ordem específica

        // Declarando set de alunos

        ISet<string> alunos = new HashSet<string>();

        alunos.Add("Vanessa Tonini");
        alunos.Add("Ana Losnak");
        alunos.Add("Rafael Nercessian");

        //Imprimindo 
        Console.WriteLine(alunos);
        Console.WriteLine(string.Join(", ", alunos));

        //Adicionando Alunos
        alunos.Add("Priscilla Stuani");
        alunos.Add("Rafael Rollo");
        alunos.Add("Fabio Gushiken");

        //Imprimindo 
        Console.WriteLine(string.Join(", ", alunos));

        //removendo ana, adcinando marcelo
        alunos.Remove("Ana Losnak");
        alunos.Add("Marcelo Oliveira");

        //Imprimindo 
        Console.WriteLine(string.Join(", ", alunos));

        //Vantagem de usar conjunto ao invés de uma lista: a vantagem é velocidade de busca, ou seja, desempenho.  
        //Desvantagem: consumo de memória. 

        //Ordenando um hash set 
        //é necessário copiar os item para uma lista para poder usar o método sort 

        List<string> alunosEmLista = new List<string>(alunos);

        alunosEmLista.Sort();

        Console.WriteLine(string.Join(", ", alunosEmLista));
    }
}