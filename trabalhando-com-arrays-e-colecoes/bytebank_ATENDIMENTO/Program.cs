using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Atendimento;
using bytebank_ATENDIMENTO.bytebank.Util;



Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

new ByteBankAtendimento().AtendimentoCliente();

#region Exemplos teste de Arrays em C#
/*int[] idades = new int[5];


//Arrays multidimensionais 
//int[,] numeros = new int[3, 3];

idades[0] = 30;
idades[1] = 21;
idades[2] = 22;
idades[3] = 23;
idades[4] = 25;

//PercorrerArray(idades);
//var mediaIdades = CacularMediaIdade(idades);
//string mediaIdadesTexto = "Media idade";
//Imprimir(mediaIdadesTexto, mediaIdades);
//PercorrerArrayPalavras();

Array amostra = Array.CreateInstance(typeof(double), 5);
amostra.SetValue(5.9, 0);
amostra.SetValue(1.8, 1);
amostra.SetValue(7.1, 2);
amostra.SetValue(10, 3);
amostra.SetValue(6.9, 4);

//Mediana(amostra);



void Mediana(Array array)
{
    if (array == null || array.Length == 0)
    {
        Console.WriteLine("Array Vazio");
    }

    double[] numerosOrdenados = (double[])array.Clone();
    Array.Sort(numerosOrdenados);

    int tamanho = numerosOrdenados.Length;
    int meio = tamanho / 2;
    double mediana = (tamanho % 2 != 0) ? numerosOrdenados[meio] :
                                                            (numerosOrdenados[meio] + numerosOrdenados[meio - 1]) / 2;
    Console.WriteLine("Mediana = " + mediana);
}

void PercorrerArray(int[] array)
{
    Console.WriteLine($"Tamanho array {array.Length}");

    double acumulador = 0;

    for (int i = 0; i < array.Length; i++)
    {
        int idade = array[i];
        Console.WriteLine("Indice " + i + " idade " + array[i]);
        acumulador += idade;
    }
}
double CacularMediaIdade(int[] array)
{
    double acumulador = 0;
    for (int i = 0; i < array.Length; i++)
    {
        int idade = array[i];
        acumulador += idade;
    }
    double media = acumulador / array.Length;
    return media;
}
void Imprimir(string texto, double valor)
{
    Console.WriteLine("" + texto + " " + valor + ".");
}
void PercorrerArrayPalavras()
{
    string[] palavras = new string[5];
    for (int i = 0; i < palavras.Length; i++)
    {
        Console.Write("Digite uma palavra: ");
        palavras[i] = Console.ReadLine();
    }
    Console.WriteLine("DIgite palavra a ser encontrada: ");
    var busca = Console.ReadLine();

    foreach (var item in palavras)
    {
        if (item.Equals(busca))
        {
            Console.WriteLine(item);
            break;
        }
    }
}
void ArrayDeContasCorrentes()
{
    var listaDeContas = new ListaDeContasCorrentes();
    listaDeContas.Adicionar(new ContaCorrente(874));
    listaDeContas.Adicionar(new ContaCorrente(884));
    listaDeContas.Adicionar(new ContaCorrente(894));
    listaDeContas.Adicionar(new ContaCorrente(884));
    listaDeContas.Adicionar(new ContaCorrente(884));
    listaDeContas.Adicionar(new ContaCorrente(894));
    listaDeContas.Adicionar(new ContaCorrente(894));
}*/
#endregion

#region Exemplos Arrays em C#
//TestaArrayInt();
//TestaBuscarPalavra();


void TestaArrayInt()
{
    int[] idades = new int[5];
    idades[0] = 30;
    idades[1] = 40;
    idades[2] = 17;
    idades[3] = 21;
    idades[4] = 18;

    Console.WriteLine($"Tamanho do Array {idades.Length}");

    int acumulador = 0;
    for (int i = 0; i < idades.Length; i++)
    {
        int idade = idades[i];
        Console.WriteLine($"índice [{i}] = {idade}");
        acumulador += idade;
    }

    int media = acumulador / idades.Length;
    Console.WriteLine($"Média de idades = {media}");
}

void TestaBuscarPalavra()
{
    string[] arrayDePalavras = new string[5];

    for (int i = 0; i < arrayDePalavras.Length; i++)
    {
        Console.Write($"Digite {i + 1}ª Palavra: ");
        arrayDePalavras[i] = Console.ReadLine();
    }

    Console.Write("Digite palavara a ser encontrada: ");
    var busca = Console.ReadLine();

    foreach (string palavra in arrayDePalavras)
    {
        if (palavra.Equals(busca))
        {
            Console.WriteLine($"Palavra encontrada = {busca}.");
            break;
        }
    }

}

//[5,9][1,8][7,1][10][6,9]
//Array amostra = Array.CreateInstance(typeof(double), 5);
Array amostra = new double[5];
amostra.SetValue(5.9, 0);
amostra.SetValue(1.8, 1);
amostra.SetValue(7.1, 2);
amostra.SetValue(10, 3);
amostra.SetValue(6.9, 4);

///TestaMediana(amostra);

void TestaMediana(Array array)
{
    if ((array == null) || (array.Length == 0))
    {
        Console.WriteLine("Array para cálculo da  mediana está vazio ou nulo.");
    }

    //Mediana
    double[] numerosOrdenados = (double[])array.Clone();

    Array.Sort(numerosOrdenados);
    //[1,8][5,9][6,9][7,1][10]

    int tamanho = numerosOrdenados.Length;
    int meio = tamanho / 2;
    double mediana = (tamanho % 2 != 0) ? numerosOrdenados[meio] : (numerosOrdenados[meio] +
        numerosOrdenados[meio - 1]) / 2;

    Console.WriteLine($"Com base na amostra a mediana = {mediana}.");
}

void TestaArrayDeContasCorrentes()
{

    ListaDeContasCorrentes listaDeContas = new ListaDeContasCorrentes();
    listaDeContas.Adicionar(new ContaCorrente(874, "5679787-A"));
    listaDeContas.Adicionar(new ContaCorrente(874, "4456668-B"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    var contaDoAndre = new ContaCorrente(963, "123456-X");
    listaDeContas.Adicionar(contaDoAndre);
    //listaDeContas.ExibeLista();
    //Console.WriteLine("============");
    //listaDeContas.Remover(contaDoAndre);
    //listaDeContas.ExibeLista();

    for (int i = 0; i < listaDeContas.Tamanho; i++)
    {
        ContaCorrente conta = listaDeContas[i];
        Console.WriteLine($"Indice [{i}] = {conta.Conta}/{conta.Numero_agencia}");
    }

}

//TestaArrayDeContasCorrentes();
#endregion

#region Exemplos de uso do list

List<ContaCorrente> _listaDeContas2 = new List<ContaCorrente>()
{
    new ContaCorrente(874,"7988878776-A"),
    new ContaCorrente(874,"7688878776-B"),
    new ContaCorrente(874,"7388878776-C")
};

List<ContaCorrente> _listaDeContas3 = new List<ContaCorrente>()
{
    new ContaCorrente(874,"765678776-E"),
    new ContaCorrente(874,"79596878776-F"),
    new ContaCorrente(874,"79876778776-G")
};

//_listaDeContas2.AddRange(_listaDeContas3);

//var range = _listaDeContas3.GetRange(0, 3);



//for(int i = 0; i < _listaDeContas2.Count; i++)
//{
//    Console.WriteLine("indice "+i+ "Conta: "+_listaDeContas2[i].Conta);
//}

//range.Reverse();
//for (int i = 0; i <range.Count; i++)
//{
//    Console.WriteLine("indice " + i + "Conta: " +range[i].Conta);
//}

//SortedList<int, string> times = new SortedList<int, string>();
//times.Add(0, "Flamengo");
//times.Add(1, "Santos");
//times.Add(2, "Juventus");

//foreach (var item in times.Values)
//{
//    Console.WriteLine(item);
//}

//Stack<string> minhlaPilhaDeLivros = new Stack<string>();
//minhlaPilhaDeLivros.Push("Harry Porter e a Ordem da Fênix");
//minhlaPilhaDeLivros.Push("A Guerra do Velho.");
//minhlaPilhaDeLivros.Push("Protocolo Bluehand");
//minhlaPilhaDeLivros.Push("Crise nas Infinitas Terras.");

//Console.WriteLine(minhlaPilhaDeLivros.Peek());// Retorna o elemento do topo.
//Console.WriteLine(minhlaPilhaDeLivros.Pop()); //Remove o elemento do topo

//Queue<string> filaAtendimento = new Queue<string>();
//filaAtendimento.Enqueue("André Silva");
//filaAtendimento.Enqueue("Lou Ferrigno");
//filaAtendimento.Enqueue("Gal Gadot");

//foreach (var item in filaAtendimento)
//{
//    Console.WriteLine(item);
//}

//filaAtendimento.Dequeue();//Remove o primeiro elemento da fila.

//foreach (var item in filaAtendimento)
//{
//    Console.WriteLine(item);
//}

//HashSet<int> _numeros = new HashSet<int>();
//_numeros.Add(0);
//_numeros.Add(1);
//_numeros.Add(1);
//_numeros.Add(1);

//Console.WriteLine(_numeros.Count);// a saída é 2.

//foreach (var item in _numeros)
//{
//    Console.WriteLine(item);
//}
//Generica<int> g = new Generica<int>();

//var t = 1;
//g.MostrarMensagem(t);

#endregion



