# Trabalhando com Arrays e Coleções

## Array
- Sintaxe declaração
    ````cs
    int[] idades = new int[5];
    ````
- Vetor em .net sempre começa com indice zero
    ````cs
    idades[0] = 30;
    idades[1] = 21;
    idades[2] = 22;
    idades[3] = 23;
    idades[4] = 24;
    ````
- Lenght: retorna o tamanho da array
    ````cs
    double acumulador = 0;
    for (int i = 0; i < array.Length; i++)
    {
        int idade = array[i];
        acumulador += idade;
    }
    ````
## Para saber mais: outras formas de inicialização de um Array

- Como vimos, os arrays, ou vetores, são um agrupamento de elementos que armazenamos em uma sequência, sendo o primeiro elemento do array o índice zero. Normalmente, quando criamos uma estrutura deste tipo, temos que definir sua dimensão, que pode ser única ou multidimensional. Vamos a um exemplo de um array de uma dimensão:

    ````cs 
    int[] numeros = new int[10];
    ````

- Podemos ter ainda um array com mais de uma dimensão, como por exemplo:

    ````cs
    int[,] numeros = new int[3,3];
    ````

- Depois de entender como criar arrays, é importante entender que eles são tipos por referência, daí a palavra reservada new na sua declaração. Mas afinal, quais as formas que temos para iniciar esse tipo de estrutura? Primeiramente temos que lembrar que para manipular os arrays, vamos utilizar seus índices, e que todo array em C# inicia no 0.

- Na forma mais básica de se declarar e inicializar um array temos: ````string[] palavras = new string[10]```` e para inserir valores recorremos à: ````palavras[0]="André````.". Neste exemplo primeiro é declarado o array e depois inserimos os elementos em cada índice. Mas podemos também podemos declará-lo e iniciá-lo por exemplo:
    ````cs
    string [] palavras= new string[5] {"André","Jose","Andressa","Neia","Sarah"}`;
    ````
- Podemos também omitir o número de elementos como no exemplo:
    ````cs
    double[] valores={2.6,9.7,7.5,1.8};
    ````
Estas são algumas das formas que temos para definir um array usando o C#. Para saber ainda mais vamos deixar aqui o link da documentação oficial da Microsoft<a href="https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/arrays/"> Matrizes Guia de Programação em C#.</a>

## Classe Array 
````cs
Array amostra = Array.CreateInstance(typeof(double), 5);
amostra.SetValue(5.9, 0);
amostra.SetValue(1.8, 1);
amostra.SetValue(7.1, 2);
amostra.SetValue(10, 3);
amostra.SetValue(6.9, 4);`
````

- utilizar a super classe Array que define todos os arrays da linguagem C#, trazendo uma série de propriedades e métodos. Conseguimos, por exemplo, identificar o tamanho de um vetor, cloná-lo e ordená-lo. Assim, temos muito mais flexibilidade ao trabalhar com arrays.

- ao criar um array usando a classe Array, utilizamos o método .CreateInstance() em que passamos o tipo e o tamanho do array, porém vale ressaltar que a estrutura ````Array amostra = Array.CreateInstance(typeof(double), 5)```` é equivalente a ````Array amostra = new double[5]````. Podemos trocá-las no nosso código e ele continuará funcionando normalmente

- Sitaxe simples 
int []= {10, 58, 36, 47 };

## Para saber mais: classe Array

- A classe Array é a superclasse de onde todas as instâncias de array do C# herdam seus atributos e métodos. Dentre as características desta classe temos:

- Pode possuir uma ou mais dimensões.
- Tem um tamanho fixo.
- Suporta acesso por índices.

- Como vimos, podemos criar uma instância da classe usando a sintaxe mais simplificada int[] valores = new int[10] ou usar o método CreateInstance por exemplo: Array pesquisa = Array.CreateInstance(typeof(double), 6);

- Para adicionar elementos ao vetor podemos usar o método SetValue que recebe dois parâmetros: o elemento e o índice, onde o elemento será “setado”. Temos um exemplo: pesquisa.SetValue(9.1,1);

As principais propriedades e métodos disponibilizados pela classe Array apresentamos na tabela abaixo:

|Propriedade/Método | Descrição
|---|---|
| GetValue | retorna o conteúdo/valor de um elemento pelo índice |
| GetLength | retorna o números de elementos do array |
| Rank | retorna o número de dimensões de um array |
| CopyTo | cria uma cópia de todos os valores de um array |
| Sort | ordena os valores de um array de forma ascendente |
| Reverse | inverte a ordem de elementos de um array |
| Clone | cria uma cópia do array |
| Length | retorna o número de elementos de um array |
| IndexOf | encontra a primeira ocorrência de um elemento no array |
| LastIndexOf | encontra a última ocorrência de um elemento no array |
| Clear | limpa todas as posições de um array |
| Exists | verifica se existe ou não um elemento no array |

Apresentamos aqui somente algumas das propriedades e métodos disponíveis para instâncias de array, para saber mais recomendamos a leitura da documentação oficial da Microsoft Array Classe.

## Array de objetos

````cs
 var listaDeContas = new ListaDeContasCorrentes();
    listaDeContas.Adicionar(new ContaCorrente(874));
    listaDeContas.Adicionar(new ContaCorrente(884));
````

## Array List
````cs
using System.Collections;

ArrayList listaDeContas = new ArrayList();
````
Qual a vantagem de se usar um Array List
- poder utilizar os métodos já prontos como adicionar, remover, consultar...

## Para saber mais: Collection ArrayList

- A classe de biblioteca do .NET ArrayList é uma implementação evoluída de um array, a classe ArrayList faz parte do namespace System.Collections, e dentre as características desta classe temos:
    - A possibilidade de expandir seus limites por meio da propriedade Capacity.
    - A classe Array já disponibiliza operações de adição, inserção e exclusão de elementos.
    - Como os arrays também tem disponível os métodos de ordenação de elementos Sort e de inversão da ordem por meio do Reverse.

- Uma característica importante da classe ArrayList é a possibilidade de se adicionar qualquer tipo de elemento, uma vez que ela trabalha com tipo da superclasse object da qual todos os tipos do C# derivam.

- Para saber mais sobre as possibilidade de utilização e métodos da classe ArrayList deixamos a recomendação de acesso a documentação da Microsoft <a href="https://docs.microsoft.com/pt-br/dotnet/api/system.collections.arraylist?view=net-6.0">ArrayList Classe</a>.

## List<T>
````cs
List<ContaCorrente> _listaDeContas = new List<ContaCorrente>();
````
- Definir tipo de objetos que podem ser adicionados a lista 
- Restringir qual tipo vai ser adicionado a lista 

Utilizando recurso generico

````cs
Generica<int> g = new Generica<int>();
Generica<int> g1 = new Generica<int>();
var t = 1;
var t1="Teste";
g.MostrarMensagem(t);
g1.MostrarMensagem(t1);

public class Generica<T>
{
    public void MostrarMensagem (T t)
    {
        Console.WriteLine("Mostrar: "+t);
    }
}
````
 - facilita a reutilização da classe 

- A classe ListT é uma versão genérica da classe ArrayList e disponibiliza os comportamentos e propriedades comuns a uma lista de objetos
- A classe ListT possibilita iterar sobre seus elementos como um array usando estruturas como for, while e foreach.
- Com a utilização do generics temos maior segurança pois diminuímos a probabilidade de conversões de tipos em tempo de execução

## Para saber mais: Generics

- O Generics é um recurso da linguagem que permite que possamos personalizar métodos, classes, interfaces e estruturas, podendo inclusive diminuir retrabalho e maximizar o desempenho de uma aplicação proporcionando uma segurança de tipos.

- Desde a versão 2.0 do .NET Framework a plataforma traz esta feature, usando generics conseguimos deixar a definição do tipo para o momento que precisamos de determinado elemento no nosso código, o que em resumo é dizer que a classe ou método possa trabalhar com qualquer tipo. Ok, mas como é isso na prática? Vamos a um exemplo:

````cs
  public class MinhaClasseGenerica<T>
    {
        public T PropriedadeGenerica { get; set; }
        public void ExibirDados(T t)
        {
            Console.WriteLine($"Dado Informado = {t.ToString()}");
            Console.WriteLine($"Tipo = {t.GetType()}");
        }  

    }
````
Note que a classe possui um parâmetro <T> que será substituído pela tipo de quando criamos um objeto desta classe, veja:

````cs
MinhaClasseGenerica<string> objGenerico = new MinhaClasseGenerica<string>();
objGenerico.ExibirDados("Olá mundo!");


MinhaClasseGenerica<int> objGenerico2 = new MinhaClasseGenerica<int>();
objGenerico2.ExibirDados(3);


Pessoa andre = new Pessoa() { Idade = 18, Nome = "André" };
MinhaClasseGenerica<Pessoa> objGenerico3 = new MinhaClasseGenerica<Pessoa>();
objGenerico3.ExibirDados(andre);


public class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }

    public override string ToString()
    {
        return $"Nome = {this.Nome} com Idade = {this.Idade}";
    }
}
````

Os genéricos oferecem uma série de vantagens como:

- Diminuição de ocorrer erros de conversão de tipos em tempo de execução.
- Melhora no desempenho, os tipos de coleções que usam generics geralmente executam melhor para armazenar e manipular tipos de valor.
- Redução do consumo de memória pois não executam operação de Boxing (converter explicitamente um tipo de valor em um objeto).

Para saber ainda mais sobre os recursos e vantagens na utilização de generics fica a recomendação da documentação oficial da Microsoft <a href="">Generics in .NET.</a>

## Métodos da classe List 

AddRange()
- Adciona uma lista a outra

Clear()
- Usado  para remoção de todos os itens de uma coleção List

## Para saber mais: outras Coleções

Na biblioteca de classes do .NET para trabalharmos com coleções além das já mencionadas Array, ArrayList e List temos uma série de collection igualmente interessante para usarmos no desenvolvimento de nossas aplicações. Abaixo vamos listar mais algumas:

SortedList, nesta coleção trabalhamos com itens ordenados por um conjunto de chave-valor. Algumas características:

- Utilizada para ordenarmos itens sem muito esforço.
- Podemos procurar pro uma chave específica.

A classe SortedList também possui uma versão que aceita generics e fica no namespace System.Collections.Generic. Um exemplo:
````cs
SortedList<int,string> times = new SortedList<int,string>();
times.Add(0, "Flamengo");
times.Add(1, "Santos");
times.Add(2, "Juventus");

foreach (var item in times.Values)
{
    Console.WriteLine(item);
}
````

Stack, esta coleção implementa o conceito de pilha, onde os elementos mais novos são adicionados no topo da pilha, e devem ser retirados nesta ordem. Esta classe também possui uma versão genérica. Exemplo de utilização:
````cs
Stack<string> minhlaPilhaDeLivros = new Stack<string>();
minhlaPilhaDeLivros.Push("Harry Porter e a Ordem da Fênix");
minhlaPilhaDeLivros.Push("A Guerra do Velho.");
minhlaPilhaDeLivros.Push("Protocolo Bluehand");
minhlaPilhaDeLivros.Push("Crise nas Infinitas Terras.");
````

Para encontrarmos o livro que está no topo da pilha usando o método Peek, para remove-lo usamos o método Pop:

````cs
Console.WriteLine(minhlaPilhaDeLivros.Peek());// Retorna o elemento do topo.
Console.WriteLine(minhlaPilhaDeLivros.Pop()); //Remove o elemento do topo
````

Queue, esta coleção por sua vez implementa o conceito de fila, onde os elementos mais novos são os primeiros a serem removidos. Para adicionar um elemento na fila usamos o método Enqueue:
````cs
Queue<string> filaAtenndimento = new Queue<string>();
filaAtenndimento.Enqueue("André Silva");
filaAtenndimento.Enqueue("Lou Ferrigno");
filaAtenndimento.Enqueue("Gal Gadot");
````

Similar ao método Pop para a fila temos o método Dequeue para remover um objeto da fila. Exemplo:
````cs
filaAtendimento.Dequeue();//Remove o primeiro elemento da fila.
````

HashSet, focado em alta performance esta coleção não aceita valores duplicados, para adicionar elementos temos também disponível o método Add:
````cs
HashSet<int> _numeros = new HashSet<int>();
_numeros.Add(0);
_numeros.Add(1);
_numeros.Add(1);
_numeros.Add(1);
````

Para saber quantos elementos a coleção _numeros possui podemos usar a propriedade Count:
````cs
Console.WriteLine(_numeros.Count);// a saída é 2.
````
Para exibirmos o conteúdo podemos percorrer a coleção usando um foreach:

````cs
foreach (var item in _numeros)
{
    Console.WriteLine(item);
}
````

Para saber mais sobre as outras coleções do .NET deixamos a recomendação de acesso a documentação da 
<a href="https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/concepts/collections">
Microsoft Coleções (C#)</a>

Implementar a interface IComparable
- Para que seja possivel ordenar a lista 
-Para a utilização do método Sort da classe List é necessário a implementação da interface IComparable, para a classe que define o tipo da lista
````cs
 public class ContaCorrente : IComparable<ContaCorrente> {

    public int CompareTo(ContaCorrente? other)
        {
            throw new NotImplementedException();
        }
 }
 ````
````cs
List<ContaCorrente> _listaDeContas2 = new List<ContaCorrente>()
{
    new ContaCorrente(874,"7988878776-A"),
    new ContaCorrente(874,"7688878776-B"),
    new ContaCorrente(874,"7388878776-C")
};
_listaDeContas.Sort();
````

## Para saber mais: outras Interfaces para coleções

A biblioteca de classes do .NET é rica em recursos que podemos utilizar em conjunto com as coleções dos namespaces System.Collection e 'System.Collecionr.Generics' e para isso a plataforma em sua biblioteca traz uma série de interfaces que nos ajudam a manipular essas coleções, abaixo algumas delas:

| Interface | Breve descrição |
|---|---|
| IList |Contrato que define os principais métodos e propriedades de uma lista como por exemplo: Insert,Item,Contains e Remove. |
| ICollection |	É a interface que define a enumeração, sincronização e tamanho para todas as coleções. |
| IComparer | Define a forma de como comparar dois objetos. |
| IDictionary |	Devolve um conjunto baseado em chave-valor e possibilita a adição e remoção de itens. |

Para saber mais sobre as outras interfaces para manipulação de coleções do .NET deixamos a recomendação de acesso a documentação da Microsoft <a href="https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/concepts/collections">Coleções (C#)</a>

## Linq 

O LINQ (Language Integrated Query) é uma linguagem que permite consultas em uma fonte de dados, como uma lista de objetos (a _listaDeContas, por exemplo), um banco de dados ou um arquivo .xml, por exemplo.

Linq e Lambda
````cs
return _listaDeContas.Where(conta => conta.Titular.Cpf == cpf).FirstOrDefault();
````

Consulta
````cs 
List<ContaCorrente> ConsultaPorAgencia(int numeroAgencia)
{
    var consulta = (
        from conta in _listaDeContas
        where conta.Numero_agencia == numeroAgencia
        select conta).ToList();
    return consulta;
}
````

- O from define a origem dos dados, o where determina o filtro e o select seleciona o objeto daquela coleção. No nosso caso, também usamos o método ToList() para transformar o resultado em uma lista. Esse recurso é bastante interessante para consultarmos coleções de objetos usando C#.

## Para saber mais: LINQ

O LINQ ( Language Integrated Query), é uma linguagem para manipulação de dados que nos foi apresentado no .NET Framework 3.0 e tem por objetivo possibilitar que os programas desenvolvidos na plataforma .NET consigam selecionar dados a partir de origens diversas desde um array, bancos de dados relacionais e até arquivos XML.

Na utilização do LINQ podemos usar duas formas:

Sintaxe de consulta: muito similar as consultas utilizadas em bancos relacionais como SQL e a operação de consulta é dividida em 3 cláusulas: from define a origem dos dados, o where para aplicação dos filtros e do select para a seleção dos dados, veja o exemplo abaixo:

````cs
List<Cliente> clientes = new List<Cliente>(){
          new Cliente(){Nome="José",Cpf="10855522299",Profissao="Dev"},
          new Cliente(){Nome="Maria",Cpf="10477722299",Profissao="Enfermeira"},
          new Cliente(){Nome="Rose",Cpf="10966622299",Profissao="Analista"},
          new Cliente(){Nome="Caio",Cpf="10355722299",Profissao="Entregador"},
          new Cliente(){Nome="Elisa",Cpf="10967422299",Profissao="Motorista"},
          new Cliente(){Nome="João",Cpf="10778122299",Profissao="Atleta"}
};

Cliente? ConsultaCliente(List<Cliente> _clientes, string _cpf)
{

    return (from cliente in _clientes
            where cliente.Cpf == _cpf
            select cliente).FirstOrDefault();

}
````

Outra possibilidade é utilizar métodos LINQ , a maioria de extensão, que permite uma instrução mais concisa, veja o exemplo anterior usando método:
````cs
Cliente? ConsultaCliente2(List<Cliente> _clientes, string _cpf) { 

    return _clientes.Where(x => x.Cpf == _cpf).FirstOrDefault();

}
````

Para saber mais sobre utilização do LINQ deixamos a recomendação de acesso a documentação da Microsoft;

- <a href="https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/concepts/linq/introduction-to-linq-queries">Introdução a consultas LINQ (C#)</a>
- <a href="https://cursos.alura.com.br/course/linq-c-sharp">Curso Entity LinQ parte 1: crie queries poderosas em C#</a>
- <a href="https://cursos.alura.com.br/course/linq-c-sharp-parte-2">Curso Entity LinQ parte 2: Store Procedures e consultas com o LinQPad</a>

## Para saber mais: Guid

O Globally Unique Identifier, mais conhecido como GUID, ele representa um identificador global exclusivo ele é utilizado para as situações que precisamos de uma sequência única que não se repita para toda uma aplicação.

O Guid é um número inteiro de 128 bits que pode gerar ao em torno de 5.316.911.983.139.663.491.615.228.241.121.400.000 combinações possíveis, muita coisa não é mesmo?

Uma representação de um guid df0d718c-06f1-4f22-8628-f825fc1d43e5, no C# temos a struct Guid que permite criar e manipular guids, veja um exemplo:

````cs
Console.WriteLine(Guid.NewGuid().ToString());// saída 826890ce-6206-4144-817c-0c3879d77fae
````

Para saber mais sobre utilização da struct Guid deixamos a recomendação de acesso a documentação da Microsoft 

<a href="https://docs.microsoft.com/pt-br/dotnet/api/system.guid?view=net-6.0">Guid Estrutura (C#)</a>


## O que aprendemos? 
- O que são arrays e como esta estrutura de dados é útil para agruparmos em uma única referência vários valores de determinado tipo;
- As sintaxes básicas de definição e inicialização de um array usando C#, entendendo as formas mais utilizadas e simples, que podem conferir dinamismo ao se trabalhar com arrays;
- A percorrer um array a fim de manipulá-lo para inserção de valores em seus índices e também para recuperar uma informação armazenada em determinada posição do array;
- Sobre a classe Array, que é a superclasse da qual todos os arrays de C# herdam seus atributos e propriedades.

- A utilizar a encapsular a manipulação de um array de objetos em um classe a fim de facilitar a manutenção de uma estrutura de objetos;
- Como utilizar um indexador, que permite que uma classe desenvolvida por você possa ser indexada como um array;
- A utilizar a collection ArrayList, uma classe que permite trabalhar com coleções de objetos e já implementa uma série de métodos para manipulação de um array de objetos.

- A utilizar uma lista genérica de objetos utilizando a classe List, que permite a tipagem de uma lista de objetos e que permite a redução da probabilidade de erros de conversão para a manipulação da lista;
- Sobre métodos disponíveis pela classe List que dinamiza a manipulação de lista de objetos;
- A criar uma classe para tratar as exceções da aplicação e que se faz necessária uma vez que a aplicação em desenvolvimento tem uma interface de interação com o usuário.

- Sobre a interface IComparable, que deve ser implementada pelo tipo de classe que irá tipificar uma lista genérica para usarmos o método Sort;
- Como utilizar o método Remove da classe lista para remoção de um elemento do array de objetos;
- Como implementar a interface de forma tipada IComparable e o método CompareTo para fazer a ordenação da lista de contas correntes;
A criar um algoritmo de busca simples para encontrar um objeto no array de contas correntes.

- A utilizar o método de extensão Where aplicado diretamente a lista de objetos, que permite a simplificação da busca de um elemento na lista;
- Sobre a configuração no arquivo .Csproj que configura o projeto para alertar sobre operações que podem retornar um valor nulo para um objeto;
- A usar a sintaxe de consulta do LINQ que torna o código bem legível e de fácil entendimento;
Como utilizar a estrutura Guid do C# para gerar uma sequência alfanumérica de forma aleatória no sistema.
