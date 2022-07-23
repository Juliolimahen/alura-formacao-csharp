# Primeiros Passos C#

## Aula 1 

- Entendendo Estrura do csharp

````cs 
using System;

class Programa
{
    static void Main(string[] args)
    {
        Console.WriteLine("Olá, mundo");
        Console.ReadKey();
    }
}
````

## Aula 2
- MSIL - Microsoft Intermediate Language
    - linguagem intermediaria que será compilada pela máquina virtual 
- CLR - Common Language Runtime (máquina virtual)


## Nessa aula introdutória já aprendemos vários assuntos fundamentais sobre C# e, em especial, o mundo .NET.

- Toda aplicação .NET é escrita em uma linguagem compilada para o código intermediário MSIL (Microsoft intermediate language;
- O .NET Framework é uma biblioteca utilizada pelas aplicações .NET;
- Uma aplicação .NET é compilada para o MSIL;
- O código MSIL é executado pela máquina virtual do .NET, a CLR (common language runtime);
- O just-in-time compiler é uma parte da CLR que transforma MSIL em código de máquina, apenas em tempo de execução.

## 

## Nesta aula iniciamos nosso aprendizado com variáveis e tipos primitivos do C#. 

- Os tipos vistos com mais detalhe foram int (número inteiro) e double (número com casa decimal). Usamos esses tipos para fazer operações aritméticas e concatenar com texto.

- Foi possível entender um pouco de type casting, e como podemos passar um valor de um tipo para uma variável de outro. Para alguns casos nós não precisamos fazer nada, pois o casting é implícito. Em outros, precisamos deixar claro para o compilador que sabemos o que estamos fazendo, mostrando entre parênteses o tipo que queremos que seja usado

## Aula 3 

- O C# é case sencitive 
- Durante essa compilação a sintaxe será analisada para que seja possível gerar um executável que seja entendido pela máquina
- Quando o código é compilado sem que nenhum erro seja encontrado ao longo do caminho, um executável é gerado. Quando esse arquivo executável é executado obtemos a saída esperada através da CLR
- Quando o código é compilado sem que nenhum erro seja encontrado ao longo do caminho, um executável é gerado

## Aula 4 

### Convencão para nome de variáves

- No C#, a convenção que utilizamos é a Camel Case. Com ela, se precisarmos escrever um nome com mais de uma palavra, a primeira palavra será começada com uma letra minúscula. Já as palavras seguintes, começarão com letra maiúscula

Ex. 
````cs
int diasDoMes;
diasDoMes = 30;
````
- Assim o nome da variável diasDoMes ficou parecido com as corcovas de um camelo, não acha? Temos o D e o M maiúsculo fazendo alusão às corcovas do camelo, que junto das outras letras minúsculas irão permitir esse efeito

- Artigo sobre nomes e convenções <a href="">Artigo</a>

### Tipos

- int: nos permitem guardar valores inteiros
````cs
int salario = 7000;
````
- double: Esse tipo de variável nos permite armazenar valores que pertencem aos números reais, números com vírgula
````cs
double salario = 7000.75;
 
````
- long: torna possível armazenar valores inteiros de tamanhos maióres 

````cs
// O long é um tipo de variável de 64 bits 
long salario = 1000000000000000;
````

- short: guardar valores menores 16 bit

````cs 
short salario = 15000;
````

- float

````cs 
float altura = 1.70f;
````


### Type Casting
Converter em outros tipo de variáveis 
````cs
double salario;
salario = 3000.15;

int salarioInteiro;

//cast, convertendo double em int 
salarioInteriro = (int)salario;

```` 
- char: permite armazenar apenas 1 caractere 

````cs
char letraA="A";
//Não é possível armazenar um char vázio
//char Espaço=""; 
````

- string permite armazenar varios caracteres 

````cs
string nome = "Irineu";
````

````cs
string cursosProgramacao =
//Usar @ para considerar a string com quebra de linhas(exibir da forma que aparece na IDE)
@"- .NET 
 - JAVA 
 - JavaScript"; 

````

### Atribuição de variáveis 
````cs
internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando projeto 5-atribuição de variaveis");

            //atribuição inicial 
            int idade = 64;
            int idadeJulio = idade;

            //Nova idade 
            idade = 93;
            
            //Vai exibir a ultima atribuição
            Console.WriteLine(idade);
            
            //Vai mostrar a idadeInicial pois a tribuição foi feita antes de atribuir a nova idade 
            Console.WriteLine(idadeJulio);
            Console.ReadLine();
        }
    }
````

### Outros tipos de variáveis

- Tipos de variáveis e os valores possíveis que elas podem assumir
<img src="aula-4-variaveis-texto\tipos.png">

- Os tipos listados nessa tabela são conhecidos como tipos primitivos ou value types da linguagem C#. Toda vez que atribuímos um valor para uma variável de um tipo primitivo, o C# copia o valor atribuído para dentro da variável.

- o C# faz conversão implícita de um tipo menor para os tipos "maiores". De inteiro para double, por exemplo. O contrário não é verdade, pois existe perda de dados quando é feita a conversão. Isso acarreta um "type mismatch", mostrando que essa instrução é de tipos incompatíveis.

- Para fazer uma conversão em que pode haver perda de informações, é necessário fazer um type casting. Veja a instrução abaixo:

    ````cs
    int idade = (int) 30.0;
    ````

- No caso acima, está explícito que será feito o cast de double para inteiro. Veja como funciona o cast implícito e explícito na tabela abaixo

<img src="aula-4-variaveis-texto\tipos-conversao.png">

Para comparar cada tipo primitivo de forma mais clara, a tabela abaixo mostra qual o tamanho de cada um.

<img src="aula-4-variaveis-texto\tipos-tamanho.png">
 
## O que aprendemos?

- No mundo .NET você terá sempre o mesmo MSIL que será executado pela máquina virtual CLR de forma independente do sistema operacional. Assim não é preciso reescrever ou adaptar o código para rodar em um outro sistema ou integrar em um projeto escrito com outra linguagem .NET

- Qualquer aplicação escrita em uma linguagem .NET (aquelas que são compiladas para MSIL) podem usar o .NET Framework

- Este é um dos benefícios do .NET Framework e o MSIL, já que quando os utilizamos, todo e qualquer código gerado para .NET pode ser executado em dispositivos que possuam o framework.

- Toda aplicação .NET é escrita em uma linguagem compilada para o código intermediário MSIL (Microsoft intermediate language)
- O .NET Framework é uma biblioteca utilizada pelas aplicações .NET
- Uma aplicação .NET é compilada para o MSIL
- O código MSIL é executado pela máquina virtual do .NET, a CLR (common language runtime)
- O just-in-time compiler é uma parte da CLR que transforma MSIL em código de máquina, apenas em tempo de execução

- Conseguimos escrever um programa em C# utilizando apenas o bloco de notas e podemos imprimir uma mensagem no prompt de comando
- Instalar uma IDE (Ambiente de desenvolvimento integrado), o Visual Studio, irá nos ajudar a desenvolver nossos códigos através de ferramentas disponíveis nela, como reconhecimento de erros
- Utilizar a estrutura dos diretórios do Visual Studio e trabalhar com os diferentes projetos e soluções. Essa IDE irá facilitar nosso trabalho como dev, permitindo o uso de ferramentas como IntelliSense, que pode nos ajudar no preenchimento automático de código

- Declaramos variáveis do tipo int e double, tornando possível armazenar idades e salário, por exemplo;
- Fazer operações aritméticas e concatenar variáveis numéricas com texto, tornando possível escrever frases que unem variáveis de diferentes tipos;
- Como podemos passar um valor de um tipo para uma variável de outro, por meio do conceito de type casting, ou seja, podemos converter variáveis do tipo double para o tipo inteiro, por exemplo

- O conceito e como declarar char e String;
- Como concatenar Strings;
- Variáveis guardam valores e não referências.


