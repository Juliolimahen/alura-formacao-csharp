using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Util;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

int[] idades = new int[5];


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

ArrayDeContasCorrentes();

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
}