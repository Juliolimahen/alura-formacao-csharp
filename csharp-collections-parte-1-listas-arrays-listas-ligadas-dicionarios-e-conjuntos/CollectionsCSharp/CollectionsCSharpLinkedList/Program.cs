namespace CollectionsCSharpSets;

class Program
{
    static void Main(string[] args)
    {
        //Imagine uma lista de frutas 
        List<string> frutas = new List<string>
        {
            "abacate", "banana", "caqui", "damasco", "figo"
        };

        //Imprimir lista
        //Imprimir(frutas);

        LinkedList<string> dias = new LinkedList<string>();
        var d4 = dias.AddFirst("quarta");

        Console.WriteLine("d4.Value: " + d4.Value);

        //Vamos adicionar segunda, antes de quarta
        var d2 = dias.AddBefore(d4, "segunda");

        Console.WriteLine("d2.Value: " + d2.Value);

        //Vamos adicionar segunda, antes de quarta
        var d3 = dias.AddAfter(d2, "terca");

        Console.WriteLine("d3.Value: " + d3.Value);


        // Perceba que os "ponteiros", ou referências
        // de d2 e d4 foram redimencionados para d3!!
        //Vamos adicionar sexta depois de quarta
        var d6 = dias.AddAfter(d4, "sexta");

        Console.WriteLine("d6.Value: " + d6.Value);

        //Adicionando sabado, depois da sexta
        var d7 = dias.AddAfter(d6, "sábado");

        Console.WriteLine("d7.Value: " + d7.Value);

        //Adicionando quinta, antes da sexta
        var d5 = dias.AddBefore(d6, "quinta");

        Console.WriteLine("d5.Value: " + d5.Value);

        //Adicionando domingo, antes da segunda
        var d1 = dias.AddBefore(d2, "domingo");

        Console.WriteLine("d1.Value: " + d1.Value);

        //Linkedin list não dá suporte ao acesso de índice: dias[0]
        //Por isso podemos fazer um laço foreach mas não um for

        dias.Remove("quarta");

        Imprimir(dias.ToList());
    }

    private static void Imprimir(List<string> frutas)
    {
        Console.Clear();
        foreach (var fruta in frutas)
        {
            Console.WriteLine(fruta);
        }
    }
}