# Testes em .NET: integrando a aplicação com um banco de dados

## Para saber mais: O que é DDD?

Quando estamos estudando e mergulhando um pouco mais fundo no desenvolvimento de sistemas, nos deparamos com vários conceitos, frameworks, práticas, padrões e assim por diante.

Neste universo de desenvolvimento de software temos algumas formas de estruturar nossos projetos e dentro do contexto de boas práticas há o DDD. Mas do que ele se trata?

DDD ou Domain-Driven Design é um termo difundido por Eric Evans em seu livro “Domain-Driven Design: Atacando as complexidades no coração do software”.

Com base em sua experiência em anos de desenvolvimento orientado a objetos, o engenheiro de software criou uma abordagem para a criação de aplicações com o principal objetivo de entender seu domínio, ou seja, as regras para o negócio.
Essa maneira de pensar em um software agrega um conjunto de técnicas e métodos que nos ajuda a desenvolver uma aplicação de maneira ágil, com boas práticas, mas sem perder o foco no negócio.

Apesar de não ser uma arquitetura e sim um paradigma, o DDD pode ser usado para construir seus sistemas independentemente da linguagem. Apresentamos a adoção de uma arquitetura com base nele na imagem abaixo:

- Apresentção 
- Serviços 
- Aplicação
- Domínio
- Infraestrutura

No projeto sob teste, utilizamos uma arquitetura que se baseia nesta proposta e adicionamos uma camada para os testes da solução.

0-Domínio
1-Aplicação
2-Infraestrutura
3-Apresentção 
4-Testes 


## Testes de Integração

No desenvolvimento e manutenção de sistemas, os testes devem ser pensados desde o início, com o objetivo de garantir o mínimo de qualidade para o produto de software que será entregue. Neste contexto temos os testes de unidade, integração e sistemas.

Escolha a alternativa correta com relação ao teste de integração.

- No teste de integração o foco é testar a interação e comunicação entre módulos de uma aplicação, ou do software com algum tipo de serviço externo. O teste de integração é o momento da integração dos módulos de um sistema ou algum serviço.

## Inversão de dependência 

- Dependa de abstrações e não de implementações
- Módulos de alto nível não devem depender de módulos de baixo nível. Ambos devem depender de abstrações
- Abstrações não devem depender de detalhes. Detalhes devem depender de abstrações

- <strong> Programe para uma interface/classe abstrata e não para uma classe concreta.</strong>


A aplicação do princípio de inversão de dependência permite que a classe A chame métodos em uma abstração implementada por B, possibilitando que A chame B em tempo de execução, mas que B dependa de uma interface controlada por A em tempo de compilação (invertendo assim a dependência em tempo de compilação).

Em tempo de execução, o fluxo de execução do programa permanece inalterado, mas a introdução de interfaces significa que diferentes implementações dessas interfaces podem ser facilmente conectadas.


Como podemos obter a inversão da dependência ?

Uma das formas de obter a inversão da dependência e usar o padrão de projeto da injeção da dependência.

Assim, injetamos a dependência para obter a inversão da dependência.

Como exemplo temos o framework ASP .NET Core que injeta objetos de classes de dependência por meio de construtor ou método usando o contêiner IoC interno.

Assim, na ASP .NET Core , basta criar e registrar o seu serviço usando abstrações onde geralmente criamos uma interface e uma classe concreta que implementa esta interface.

Como exemplo temos a interface ILog e a classe ConsoleLogger que a implementa:
````cs
public interface ILog
{
    void info(string texto);
}

class ConsoleLogger : ILog
{
    public void info(string texto)
    {
        Console.WriteLine(texto);
    }
}
````

A seguir a ASP.NET Core permite registrar nossos serviços de aplicativo no contêiner IoC, no método ConfigureServices da classe Startup.

Este método inclui um parâmetro do tipo IServiceCollection que é usado para registrar serviços de aplicativos.

Vamos registrar acima do ILog com o container IoC no método ConfigureServices(), como mostrado abaixo.

````cs
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton(ILog,ConsoleLogger));        
    }
    // código...
}
````

Acima vemos o método AddSingleton da instância IServiceCollection sendo usado para registrar um serviço  em um contêiner de IoC.

Especificamos ILog como tipo de serviço e ConsoleLogger como sua instância. Isso registrará o serviço ILog como um serviço com tempo de vida Singleton por padrão. Agora, um contêiner de IoC criará um objeto singleton da classe ConsoleLogger e o injetará no construtor de classes, sempre que incluirmos o ILog como construtor ou parâmetro de método em todo o aplicativo.


    creditos: https://macoratti.net/

## Para saber mais: Injeção de dependências

A injeção de dependência é um padrão de projeto, ou seja, um modelo genérico para resolver um problema recorrente em desenvolvimento de software. Injeções nos ajudam a diminuir o acoplamento entre módulos de um sistema. O que isso quer dizer?

Isso significa que podemos reduzir o quão dependente um módulo é do outro com o objetivo de alcançar baixo acoplamento. Assim, conseguimos classes menos dependentes entre si e consequentemente mais flexíveis a ocasionais mudanças em nosso código.

Usando a injeção, trabalhamos com abstrações (classes abstratas e interfaces) e não com implementações concretas (classes). Em outras palavras, injetar uma dependência é passar uma classe para uma outra que irá utilizá-la.

Escrevendo código focado nas interfaces em vez da implementação, conseguimos evitar, por exemplo, uma situação em que alguma alteração no comportamento de uma classe afete todo um módulo de um sistema. Quando dependemos da interface, podemos usar qualquer classe que implemente os comportamentos definidos naquele contrato.

No projeto do “Alura.ByteBank”, estamos usando a injeção de dependência no construtor e, utilizamos a biblioteca ````Microsoft.Extensions.DependencyInjection```` do .NET para injetar as dependências necessárias para uma determinada classe conforme o código abaixo.

````cs
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class AgenciaRepositorioTestes
    {
        private readonly IAgenciaRepositorio _repositorio;

        public AgenciaRepositorioTestes(ITestOutputHelper _saidaConsoleTeste)
        {

            var servico = new ServiceCollection();
            servico.AddTransient<IAgenciaRepositorio, AgenciaRepositorio>();
            var provedor = servico.BuildServiceProvider();
            _repositorio = provedor.GetService<IAgenciaRepositorio>();

        }
           //restante do código omitido... 
    }
}
````


### Injeção de dependência
David, programador .NET, está implementando um sistema acadêmico guiando o desenvolvimento com base em testes. Ele precisa deixar o código apropriado caso precise fazer mudanças, ou seja, com baixo acoplamento. Na escrita de um determinado método de testes, percebeu que um objeto do tipo Academico poderia ser utilizado em mais de um lugar na classe de teste. Como o objeto ainda está em desenvolvimento, comportamentos podem ser modificados.

Selecione quais boas práticas podem ser utilizadas no objeto.

- David pode usar a injeção de dependência no construtor, e usar a biblioteca do .NET que implementam esse padrão a Microsoft.Extensions.DependencyInjection, assim agilizando sua codificação e adotando boas práticas. O .NET possui a biblioteca Microsoft.Extensions.DependencyInjection que permite implementarmos o padrão da injeção de dependência, criando e registrando um container de serviço que irá criar uma instância do objeto que possui os comportamentos que desejamos usar.

- Uma recomendação para David é usar o conceito de injeção de dependência no construtor, pois assim ele passa a depender dos comportamentos definidos em uma interface. Como esse objeto vai ser utilizado em outras partes do código, pode usar o conceito de Setup, criando as dependências em um só lugar. Como vimos nesta aula, a injeção de dependência foca no baixo acoplamento, deixando o código mais flexível a mudanças, por focarmos no comportamento presente em uma interface. Assim qualquer objeto que implementa a interface pode ser utilizado.

## O que aprendemos?

- Configurar nosso ambiente com um banco de dados e a IDE Visual Studio Community 2019 para receber o projeto Alura.ByteBank;
- Executar migrações usando o entity Framework para configurar nosso banco de dados;
- Instalar nosso banco de dados MySQL e uma ferramenta de acesso e gerência, o WorkBench.

- Criar um novo projeto de teste com xUnit;
- Criar nosso primeiro teste de integração para validar uma conexão com o serviço de banco de dados;
- Realizar uma migração que insere algumas informações nas tabelas do banco de dados usando o recurso das migrações com Entity Framework;
- Utilizar o pacote using Microsoft.Extensions.DependencyInjection; do .NET para criar uma injeção de dependência no construtor da classe de testes.


## Testando os selects

