# Trabalhando com Arrays e Coleções

### Array
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
### Para saber mais: outras formas de inicialização de um Array

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

### Classe Array 
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

### Para saber mais: classe Array

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

### Array de objetos


## O que aprendemos? 
- O que são arrays e como esta estrutura de dados é útil para agruparmos em uma única referência vários valores de determinado tipo;
- As sintaxes básicas de definição e inicialização de um array usando C#, entendendo as formas mais utilizadas e simples, que podem conferir dinamismo ao se trabalhar com arrays;
- A percorrer um array a fim de manipulá-lo para inserção de valores em seus índices e também para recuperar uma informação armazenada em determinada posição do array;
- Sobre a classe Array, que é a superclasse da qual todos os arrays de C# herdam seus atributos e propriedades.