using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsCSharpObjectList;

class Curso
{
    private List<Aula> aulas;
    private string nome;
    private string instrutor;

    public Curso(string nome, string instrutor)
    {
        this.nome = nome;
        this.instrutor = instrutor;
        this.aulas = new List<Aula>();
    }

    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    //Protegendo lista contra acessos externos
    public IList<Aula> Aulas
    {
        get { return new ReadOnlyCollection<Aula>(aulas); }
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
        return $"Curso: {nome}, Tempo: {TempoTotal}, Aulas:{string.Join(", ",aulas)}";
    }
}
