
using System.Collections.ObjectModel;

namespace CollectionsCSharpSets;

public class Curso
{
    private IDictionary<int, Aluno> dicionarioAlunos =
        new Dictionary<int, Aluno>();

    private ISet<Aluno> alunos = new HashSet<Aluno>();
    private List<Aula> aulas;
    private string nome;
    private string instrutor;

    public Curso(string nome, string instrutor)
    {
        this.nome = nome;
        this.instrutor = instrutor;
        this.aulas = new List<Aula>();
    }

    public IList<Aluno> Alunos
    {
        get
        {
            return new ReadOnlyCollection<Aluno>(alunos.ToList());
        }
    }

    //Protegendo lista contra acessos externos
    public IList<Aula> Aulas
    {
        get { return new ReadOnlyCollection<Aula>(aulas); }
    }

    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    public string Instrutor
    {
        get { return instrutor; }
        set { instrutor = value; }
    }

    public void Adiciona(Aula aula)
    {
        this.aulas.Add(aula);
    }

    public int TempoTotal
    {
        get
        {
            //Totalizador logica basica

            //int total = 0;
            //foreach (Aula aula in aulas)
            //{
            //    total += aula.Tempo;
            //}
            //return total;

            //Totalizador usando linq
            return aulas.Sum(aula => aula.Tempo);
        }
    }

    public override string ToString()
    {
        return $"Curso: {nome}, Tempo: {TempoTotal}, Aulas:{string.Join(", ", aulas)}";
    }

    public void Matricula(Aluno aluno)
    {
        this.alunos.Add(aluno);
        this.dicionarioAlunos.Add(aluno.NumeroMatricula, aluno);
    }


    public bool EstaMatriculado(Aluno aluno)
    {
        return alunos.Contains(aluno);
    }

    public Aluno BuscaMatriculado(int numeroMatricula)
    {
        #region busca normal
        ////busca normal
        //foreach (var aluno in alunos)
        //{
        //    if (aluno.NumeroMatricula == numeroMatricula)
        //    {
        //        return aluno;
        //    }
        //}

        //throw new Exception("Matrícula não encontrada: " + numeroMatricula);
        #endregion

        Aluno aluno = null;
        this.dicionarioAlunos.TryGetValue(numeroMatricula, out aluno);
        return aluno;
    }

    public void Substitui(Aluno aluno)
    {
        this.dicionarioAlunos[aluno.NumeroMatricula]=aluno;
    }
}
