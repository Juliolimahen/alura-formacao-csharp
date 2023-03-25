namespace CollectionsCSharpConsultaSequenciaDeElementos;

internal class Mes //: IComparable<Mes>
{
    public Mes(string nome, int dias)
    {
        Nome = nome;
        Dias = dias;
    }

    public string Nome { get; private set; }
    public int Dias { get; private set; }

    //public int CompareTo(Mes? other)
    //{
    //    return this.Nome.CompareTo(other.Nome);
    //}

    public override string ToString()
    {
        return $"{Nome} - {Dias}";
    }
}