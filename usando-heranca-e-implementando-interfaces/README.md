# Usando herança e implementado interfaces C#

## Organização do nosso código
- No .NET temos os namespaces, que têm a mesma função e que estruturam todas as bibliotecas do framework.

## Padrão de Camadas
- A arquitetura de camadas que tem por objetivo uma criação mais modular do software. Dessa forma cada camada assume uma responsabilidade e elas se comunicam para sua aplicação funcionar.
    - <a href="https://cursos.alura.com.br/extra/alura-mais/design-de-codigo-vs-arquitetura-de-software-c640">Design de código vs Arquitetura de software</a>
    - <a href="https://cursos.alura.com.br/extra/alura-mais/domain-driven-design-ddd-o-que-e--c283">Domain-Driven Design (DDD) - O que é?</a>

## Usando o this 
- Com o this eu consigo diferenciar o que é um objeto da classe e o que é parametro

## Polimofismo
- A definição de polimorfismo é que um mesmo comportamento pode acontecer de várias formas, dependendo da lista de parâmetros que ele recebe.

## Sobrecarga de métodos
- Mesmo nome e argumentos diferentes 

Utilizando a herança temos dois tipos básicos de classes:

- Classe base: contém as características que servirão de base para uma outra classe, em algumas literaturas também são chamadas de superclasses.
- Classe derivada: herda as características e comportamentos da classe base. Esse tipo de classe também é conhecida como subclasse.
- <a href="https://cursos.alura.com.br/course/introducao-a-uml">Curso UML introdução: modelagem de soluções</a>


## Herança 
- Na orientação a objetos, a herança é um mecanismo que possibilita que classes compartilhem definições de atributos (propriedades), comportamentos (métodos) e outros membros entre elas

## Classe base
- contém as características que servirão de base para uma outra classe, em algumas literaturas também são chamadas de superclasses

## Classe derivada 
- herda as características e comportamentos da classe base. Esse tipo de classe também é conhecida como subclasse.

    - Recomendação para saber mais sobre UML Curso https://cursos.alura.com.br/course/introducao-a-uml

Palavra reservada base
- Para acessar os recursos da classe base 
- Para chamar um metodo da class base dentro da classe fila sem gerar loop por ter um método na classe filha com o mesmo nome

Ex: 
```cs
 public class Diretor : Funcionario
    {
        public override double getBonificacao()
        {
            //bonificação de 110% reaproveitando os 10% do funcionário + os 100 do diretor
            return salario + base.getBonificacao();
        }
    }
```
## Encapsulamento 

Definir propriedade como sendo da classe e não do objeto
- Adicionar static na método 
Ex:
````cs
public static int totalFuncionarios { get; set; }
````

Definir propriedade como privada para não permitir que seja alterada de forma errada 
````cs 
public static int totalFuncionarios { get; private set; }
````

## Para saber mais: sobre construtores e destrutores

- É possível que você já tenha aprendido que os métodos construtores são métodos especiais que são chamados no momento que criamos um objeto de uma classe concreta. Como regra eles são públicos e possuem o mesmo nome da classe em que estão contidos.

- A partir dos construtores podemos definir valores padrão, limitar a criação de objetos, dentre outras ações. Ao trabalharmos com construtores no C#, devemos nos atentar para:

- Quando não definimos explicitamente um construtor na classe, o .NET vai utilizar o construtor padrão, que tem o mesmo nome da classe e não recebe parâmetros;
Podemos aplicar os modificadores de acesso (visibilidade) aos construtores como private ou protected para a execução de uma tarefa específica ou para não permitir que a classe gere instâncias (objetos);
Quando definimos explicitamente um construtor na classe, ele assume o lugar do construtor padrão;
O construtor também é um método, portanto, podemos aplicar sobrecargas sobre ele. Assim é possível haver mais de um construtor definido em uma mesma classe e cada um deles vai se diferenciar de acordo com sua assinatura (conjunto tipo de retorno e listagem de parâmetros que recebe).

- Em contraposição aos construtores, temos o método destrutor, que é invocado no momento de “destruir” um objeto de uma classe. O método traz algumas características interessantes:

- Uma classe possui somente um método destrutor;
- Diferentemente dos construtores, ele não pode ser herdado nem sobrecarregado;
- Ele é invocado automaticamente;
- Não aplicamos modificadores de acesso ou parâmetrosao destrutor;

Tem o mesmo nome da classe e é precedido do caractere “~”.

Exemplo de código de um método destrutor:
````cs
public class Auxiliar : Funcionario
    {
        public Auxiliar(string cpf):base(cpf,2000)
        {           
        }

        public override void AumentarSalario()
        {
            Salario *= 0.10;
        }

        public override double getBonificacao()
        {
            return Salario * 0.2;
        }

        ~Auxiliar()
        {
            Console.WriteLine("Liberando recursos...");
        }
    }
````

- Um detalhe importante é que a pessoa que desenvolve a princípio não controla a execução do método destrutor, o que fica sob a responsabilidade do coletor de lixo (garbage collector) do .NET, que identifica o momento mais oportuno para liberar a memória limpando os objetos inutilizados.

- É possível forçar a execução do coletor de lixo usando o comando GC.Collect(), porém fazer chamadas excessivas ao coletor é uma prática pouco recomendada, pois reflete de maneira negativa na performance do programa.

## Para saber mais: coletor de lixo
- Mesmo trabalhando com linguagens orientadas a objetos como C# é importante ter atenção ao consumo de recursos computacionais, como a memória, para nossa máquina continuar com espaço. Quando precisamos criar vários objetos no sistema, por exemplo, eles podem ficar armazenados na memória.

- Mas pode acontecer de executarmos o programa e algum espaço na memória ser liberado. Isso significa que não somos nós quem controlamos explicitamente o armazenamento. Mas então, quem controla? A resposta é o coletor de lixo, ou garbage collector.

- Garbage collector significa coletor de lixo e é um recurso presente na plataforma .NET que forma automática se encarrega de remover da memória os objetos que não estão sendo mais utilizados pela aplicação de forma automática. Isso facilita o trabalho da pessoa que desenvolve porque ela não precisa se preocupar com esse gerenciamento.

- A máquina virtual do .NET, a CLR, fica encarregada de detectar dentro do programa em execução quando um objeto não for mais utilizado e ele será descartado.

## Deixar atributo como obrigatório atráves do método construtor

````cs
public Funcionario(string cpf)
{
totalFuncionarios++;
Cpf = cpf;
}

Dessa forma ao ser instancia, será necessário passar o cpf como atributo

````
Herdando do construtor da classe base:
````cs
public Diretor(string cpf) : base(cpf){}
````

Também é necessário definir como o set da classe pai como privado, para retirar o possibilidade de ser possivel alterar sem ser pelo consrutor 

Ex:
````cs
public string? Cpf { get; private set; }
````

Modificador de acesso Protected
- É utilizado quando quero deixar a possibilidade de ser alterado nas classe herdadas 

## Classe Abstrata 
Ex. 
````cs
public abstract class Funcionario
    {
        public string? Nome { get; set; }
        public string? Cpf { get; private set; }
        public double Salario { get; protected set; }

        public static int totalFuncionarios { get; private set; }

        public Funcionario(string cpf, double salario)
        {
            totalFuncionarios++;
            this.Cpf = cpf;
            this.Salario = salario;
        }
        public abstract double getBonificacao();

        public abstract void AumentarSalario();

    }
````
- Para definir um classe abstrata é necessário adicionar o palavra reservada abstract ao nome da classe
- Quando usar 
    - Quando não é necessário ter um objeto da classe, quando só for necessário definir comportamentos e atibutos que outras classes possam herdar, servindo como base para outras classes derivadas 
- Uma das caracteristicas da classe abstrata é que não é possível criar objeto dela, não permite criar instâncias 
- Uma das formas de informar ao compilador que uma classe deve ser abstrata é usar a palavra reservada abstract
- Por ser um conceito mais genérico, não faz sentido a possibilidade de criar um objeto a partir de uma classe abstrata
- Uma classe abstrata serve como modelo para criação de outras classes. Na classe abstrata podemos explicitar comportamentos e atributos, além de definir a assinatura de métodos que devem ser implementados pelas classes concretas que herdarem dela
- Uma classe abstrata busca representar um conceito, uma ideia. Por isso não faz sentido a possibilidade de se criar um objeto concreto a partir de uma classe abstrata
- Uma classe abstrata pode possuir diversas propriedades, pois tem poucas restrições

## Métodos Abstratos
````cs
public abstract double getBonificacao();
````
- Em um classe abstrata como Funcionario quando desejamos que um método seja de implementação obrigatória definimos uma assinatura, nome de método, com a palavra reservada abstract
- Não deve ser implementado na classe abstrata, só se deve criar as assinaturas dos métodos para serem implementados nas classes derivadas  
- Devem ser criados para obrigar o desenvolvedor implementalos nas classes derivadas, afim de evitar erros
- Métodos abstratos só existem dentro de classes abstratas, não é possível criar métodos abstratos dentro de classes concretas 

Caso queira herdar de uma classe abstrata e não implementar seus métodos, é necessário definar a classe derivada como abstrata também

````cs
 public abstract class Autenticavel : Funcionario
    {
        public Autenticavel(string cpf, double salario) : base(cpf, salario)
        {
        }
        public string Senha { get; set; }
        public bool Autenticar(string senha)
        {
            return this.Senha == senha;
        }
    }
```` 

## Herança múltipla
- O dotnet não implementa herança múltipla 

## Interface 
- Interface só defina contratos, assinaturas
Ex. 
````cs
public interface Autenticavel
    {
        public bool Autenticar(string senha);
    }
```` 
Conveção
- Existe uma boa prática em relação a interface, é recomendado usar o prefixo I no inicio do nome da interface
Ex. 
````cs
public interface IAutenticavel
    {
        public bool Autenticar(string senha);
    }
```` 
- A interface é entendida como um contrato onde especificamos o comportamento que deve ser implementado por determinada classe. Através dela, simulamos o conceito de herança múltipla que não existe implementado no .NET. Conseguimos simular porque agora um “FuncionarioAutenticavel” está herdando de “Funcionario” todas as características e também implementando os comportamentos de outro componente da interface “IAutenticavel”

- A interface é similar a uma classe abstrata, mas só conterá a assinatura dos métodos a serem implementados

### Para saber mais: simulando herança múltipla

- Como vimos no curso, o .NET não implementa a herança múltipla por uma questão de performance. Sendo assim uma construção como public class Desenvolvedor: Funcionario,Diretor na qual buscamos herdar de duas classes, não é possível. Mas usando o recurso das interfaces podemos simular o comportamento.

- Entendendo a interface como um ponto de definição para um grupo de comportamentos, podemos usá-la para simular a utilização de herança múltipla. Vamos ao exemplo do Ornitorrinco:
````cs
 public interface IAves
    {
        bool PossuiBico();
        bool Oviparidade();
    }COPIAR CÓDIGO
Definimos uma interface com características de Aves.

 public interface IMamifero
    {
        bool PresencaDePelos();
        bool GrandulasMamarias();
        bool PresencaDeCauda();
    }
````

- Agora definimos uma interface com as características de um mamífero. Para esse conjunto distinto de características, vamos definir uma classe que se compromete a assinar esses contratos e “herdar” essas características.

````cs
 public class Ornitorrinco : IAves, IMamifero
    {

        private  string _reino = "Animalia";
        private  string _filo = "Chordata";
        private  string _especie = "O.anatinus";
        public string Reino { get { return _reino; } }
        public string Filo { get { return _filo; } }
        public string Especie { get { return _especie; } }

        public bool GrandulasMamarias()
        {
            return true;
        }

        public bool Oviparidade()
        {
            return true;
        }

        public bool PossuiBico()
        {
            return true;
        }

        public bool PresencaDeCauda()
        {
            return true;
        }

        public bool PresencaDePelos()
        {
            return true;
        }
    }
````

- A partir do momento que a classe Ornitorrinco implementa essas duas interfaces e passa a ter os comportamentos “característicos” definidos para uma ave e para um mamífero, podemos dizer que Ornitorrinco herda os comportamentos definidos nas interfaces. Com este exemplo ilustramos a simulação de herança múltipla usando C#.

- Para saber sobre mais possibilidades da utilização de interfaces, recomendamos a leitura:

- Artigo Microsoft : <a href="https://docs.microsoft.com/pt-br/dotnet/csharp/language-reference/keywords/">Palavras-chave C#</a>

- Artigo Microsoft : <a href="https://docs.microsoft.com/pt-br/dotnet/csharp/fundamentals/types/interfaces">Interfaces – definir o comportamento para vários tipos</a>


## Desafio: um contrato para bonificação

- Agora que você já sabe mais sobre interfaces, precisamos refatorar nosso código para transformar a bonificação em uma interface. A classe que assinar a interface irá implementar seu cálculo de bonificação.

- Considere este exercício como opcional, mas ele pode ser muito interessante para colocar em prática o tema interfaces visto na aula. Então, aceita o desafio?.

## O que aprendemos? 

- Na orientação a objetos, a herança é um mecanismo que nos permite reaproveitar código.
- Podemos redefinir um comportamento escrito em uma classe base em uma classe derivada. Assim, ele passará a funcionar de forma específica em uma classe derivada.
- Acessamos definições presentes na classe base usando o operador base.

- Invocamos o construtor da classe base, a partir do construtor da classe derivada.
- Protegemos propriedades usando o operador de visibilidade protected para impedir o acesso direto a uma propriedade de um objeto.
- Utilizamos classes abstratas para definir uma classe que será modelo para criação de novas classes.
- Como usar métodos abstratos para definir como obrigatória a implementação de determinado comportamento em classes derivadas

- Como adicionar uma nova classe à hierarquia de classes já definida com a intenção de atender a uma nova demanda do projeto.
- Avançamos na utilização da herança de classes fazendo uma classe herdar de outra.

- O C# não implementa o conceito de herança múltipla, pois classes muito distintas com métodos de mesmo nome poderiam causar problemas para o compilador definir qual usar na nova instância.
- O funcionamento das interfaces na orientação a objetos, que são contratos que definem comportamentos a serem implementados pelas classes que assinam este contrato.
- Como utilizar o padrão de nomenclatura adotada para nomeação de interfaces, aplicando a convenção que utiliza o prefixo I