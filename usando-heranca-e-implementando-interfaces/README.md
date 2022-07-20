# Usando herança e implementado interfaces C#

Organização do nosso código
- No .NET temos os namespaces, que têm a mesma função e que estruturam todas as bibliotecas do framework.

Padrão de Camadas
- A arquitetura de camadas que tem por objetivo uma criação mais modular do software. Dessa forma cada camada assume uma responsabilidade e elas se comunicam para sua aplicação funcionar.
    - <a href="https://cursos.alura.com.br/extra/alura-mais/design-de-codigo-vs-arquitetura-de-software-c640">Design de código vs Arquitetura de software</a>
    - <a href="https://cursos.alura.com.br/extra/alura-mais/domain-driven-design-ddd-o-que-e--c283">Domain-Driven Design (DDD) - O que é?</a>

Usando o this 
- Com o this eu consigo diferenciar o que é um objeto da classe e o que é parametro

Polimofismo
- A definição de polimorfismo é que um mesmo comportamento pode acontecer de várias formas, dependendo da lista de parâmetros que ele recebe.

Sobrecarga de métodos
- Mesmo nome e argumentos diferentes 

Utilizando a herança temos dois tipos básicos de classes:

- Classe base: contém as características que servirão de base para uma outra classe, em algumas literaturas também são chamadas de superclasses.
- Classe derivada: herda as características e comportamentos da classe base. Esse tipo de classe também é conhecida como subclasse.
- <a href="https://cursos.alura.com.br/course/introducao-a-uml">Curso UML introdução: modelagem de soluções</a>


Herança 
- Na orientação a objetos, a herança é um mecanismo que possibilita que classes compartilhem definições de atributos (propriedades), comportamentos (métodos) e outros membros entre elas

Classe base
- contém as características que servirão de base para uma outra classe, em algumas literaturas também são chamadas de superclasses

Classe derivada 
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
O que aprendemos? 

- Na orientação a objetos, a herança é um mecanismo que nos permite reaproveitar código.
- Podemos redefinir um comportamento escrito em uma classe base em uma classe derivada. Assim, ele passará a funcionar de forma específica em uma classe derivada.
- Acessamos definições presentes na classe base usando o operador base.

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

Deixar atributo como obrigatório atráves do método construtor

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