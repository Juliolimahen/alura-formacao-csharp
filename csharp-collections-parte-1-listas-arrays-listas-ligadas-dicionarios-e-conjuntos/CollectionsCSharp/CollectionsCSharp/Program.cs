
string aulaIntro = "Introdução às Coleções";
string aulaModelando = "Modelando a Classe Aula";
string aulaSets = "Trabalhando com Conjuntos";

// Primeira forma
string[] aulas = new string[]
{
    aulaIntro,
    aulaModelando,
    aulaSets
};

// Segunda Forma

string[] aulas1 = new string[3];

aulas1[0] = aulaIntro;
aulas1[1] = aulaModelando;
aulas1[2] = aulaSets;

//Pecorrendo array com for
//PercorrendoArrayComFor(aulas1);

//Percorrendo array com forech
//PercorrendoArrayComForeach(aulas);

//IndexOf
Console.WriteLine("Aulas modelando está no indice " + Array.IndexOf(aulas1, aulaModelando));
Console.WriteLine();
Console.WriteLine(Array.LastIndexOf(aulas1, aulaModelando));
Console.WriteLine();
//Método reverse, reverte a ordem do array
Array.Reverse(aulas1);

PercorrendoArrayComFor(aulas1);

Console.WriteLine();

//Voltar para ordem original
Array.Reverse(aulas1);

PercorrendoArrayComFor(aulas1);

Console.WriteLine();

Array.Resize(ref aulas1, 2);

PercorrendoArrayComFor(aulas1);

Console.WriteLine();

Array.Resize(ref aulas1, 3);

PercorrendoArrayComFor(aulas1);

Console.WriteLine();

//Acessar ultima posição do array
aulas1[aulas1.Length - 1] = "conclusão";

PercorrendoArrayComFor(aulas1);

Console.WriteLine();

//Ordernar o Arry
Array.Sort(aulas1);

string[] copia = new string[2];

//Copiar as duas ultimas aulas do array
Array.Copy(aulas1, 1, copia, 0, 2);

PercorrendoArrayComFor(aulas1);

Console.WriteLine();

// Clonar array
// Cast
string[] clone = aulas1.Clone() as string[];

PercorrendoArrayComFor(aulas1);

Console.WriteLine();

Array.Clear(clone, 1, 2);

PercorrendoArrayComFor(clone);

Console.WriteLine();

//Pecorrendo array com for
static void PercorrendoArrayComFor(string[] aulas1)
{
    for (int i = 0; i < aulas1.Length; i++)
    {
        Console.WriteLine(aulas1[i]);
    }
}

//Percorrendo array com forech
static void PercorrendoArrayComForeach(string[] aulas)
{
    foreach (string aulas2 in aulas)
    {
        Console.WriteLine(aulas2);
    }
}