
string aulaIntro = "Introdução às Coleções";
string aulaModelando = "Modelando a Classe Aula";
string aulaSets = "Trabalhando com Conjuntos";

//Uma lista é um array dinamico
//Ela aumenta e diminui de acordo com a necessidade
List<string> aulas = new List<string>();
//{
//    aulaIntro,
//    aulaModelando,
//    aulaSets
//};

aulas.Add(aulaIntro);
aulas.Add(aulaModelando);
aulas.Add(aulaSets);

Console.WriteLine("Imprimindo com método anônimo");

//Imprimindo com método anônimo
aulas.ForEach(aula =>
{
    Console.WriteLine(aula);
});

Console.WriteLine("\nImprimindo com laço For");

PercorrendoListaComFor(aulas);

Console.WriteLine("\nImprimindo com laço Foreach");

PercorrerListaComForeach(aulas);

Console.WriteLine("\nAcessando aula pelo indice");

Console.WriteLine("A primeira aula é " + aulas[0]);

Console.WriteLine("A última aula é " + aulas[aulas.Count - 1]);

Console.WriteLine("\nAcessando aula pelo método First");

Console.WriteLine("A primeira aula é " + aulas.FirstOrDefault());

Console.WriteLine("\n Acessando aula pelo método Last");

Console.WriteLine("A última aula é " + aulas.LastOrDefault());

//Adicionado aula pelo indice
aulas[0] = "Trabalhando com listas";

PercorrerListaComForeach(aulas);

Console.WriteLine("\nOperações com listas ");

//usar OrDefault para não gerar exceção
Console.WriteLine("A primeira aula 'Trabalhando' é: " +
    aulas.FirstOrDefault(aula => aula.Contains("Trabalhando")));

Console.WriteLine("A ultima aula 'Trabalhando' é: " +
    aulas.LastOrDefault(aula => aula.Contains("Trabalhando")));


Console.WriteLine("\nRevertendo a ordem da lista");

aulas.Reverse();

PercorrerListaComForeach(aulas);

Console.WriteLine("\nRemovando ultimo item");

aulas.RemoveAt(aulas.Count - 1);

PercorrerListaComForeach(aulas);

Console.WriteLine("\nAdicionado a aula 'conclusão'");

aulas.Add("Conclusão");

PercorrerListaComForeach(aulas);

Console.WriteLine("\nOrdenando lista");

aulas.Sort();

PercorrerListaComForeach(aulas);

Console.WriteLine("\nFazendo copia de uma lista ");

List<string> copia = aulas.GetRange(aulas.Count - 2, 2);

PercorrerListaComForeach(copia);

Console.WriteLine("\nClonando lista");

List<string> clone = new List<string>(aulas);

PercorrerListaComForeach(clone);

Console.WriteLine("\nRemovendo dois ultimos itens");

clone.RemoveRange(aulas.Count - 2, 2);

Console.WriteLine();

PercorrerListaComForeach(clone);

static void PercorrerListaComForeach(List<string> aulas)
{
    foreach (string aula in aulas)
    {
        Console.WriteLine(aula);
    }
}

static void PercorrendoListaComFor(List<string> aulas)
{
    for (int i = 0; i < aulas.Count; i++)
    {
        Console.WriteLine(aulas[i]);
    }
}