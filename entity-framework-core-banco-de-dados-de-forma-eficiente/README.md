# Entity Framework Core

## Vantagens
- Usar algum ORM em seus projetos costuma ser mais produtiva, pois a biblioteca de ORM já abstrai muito do código de persistência e das tarefas tradicionais de manter um banco de dados
- Uma das principais vantagens do ORM é nos blindar de ter que fazer todo o trabalho sujo que envolve criar uma query SQL na mão
- Quando estamos trabalhando com um ORM ele se encarrega de escrever o SQL para nós e o desenvolvedor só tem que intervir em casos muito específicos

## Instale o EntityFrameworkCore usando o provider SQL Server

Abra o console do gerenciador de pacotes (em Ferramentas\Gerenciador de Pacotes do Nuget\Console do gerenciador de pacotes) para executar o comando abaixo que vai instalar o EF Core como dependência do provider SQL Server
- Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 1.1

## Para saber mais: outros providers de bancos para o Entity

Na documentação da Microsoft para o EF Core, existe uma página dedicada para os providers existentes atualmente. Por exemplo, existem providers para o MySQL, Postgres e DB2. Infelizmente, durante a escrita desse texto, ainda não havia um provider disponível para o famoso banco de dados Oracle.

Um desses providers é o InMemory, que é um provider para acessar um banco de dados que fica na própria memória da aplicação. <a href="https://docs.microsoft.com/en-us/ef/core/testing/">Na página específica deste provider (em inglês)</a>, a Microsoft informa que o seu principal uso é para testes em classes que utilizam o EF Core, conforme indicado no texto abaixo:

- The InMemory provider is useful when you want to test components using something that approximates connecting to the real database, without the overhead of actual database operations.

# Criar classe contexto

- necessário herdar da classe DbContext
    ````cs
       public class LojaContext : DbContext`
    ````

Primeiramente faremos com que a classe permita usar a API do Entity dentro dela. Para que isso aconteça, faremos a classe herdar de DbContext.

````cs 
using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class LojaContext : DbContext
    {

    }
}
````
Informaremos quais classe serão persistidas pelo Entity. Mas como será feito? Faremos isso por meio de uma propriedade que vai representar o conjunto de objetos da classe ````Produto````. A propriedade ficará definida com o tipo ````DbSet<Produto>````, e o nome da propriedade colocaremos o *mesmo nome da tabela do banco de dados.

````cs
using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class LojaContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
    }
}
````

## Para saber mais: Entity suporta transações?

Você deve estar se perguntando se o Entity suporta transações. Por padrão, desde a versão 6, quando o Entity executa o método SaveChanges uma transação é criada para englobar os comandos SQL necessários para salvar as alterações do contexto no banco.

Se você precisar de um maior controle sobre transações em sua aplicação, poderá usar os métodos BeginTransaction e UseTransaction, disponíveis na propriedade Database da classe DbContext.

Para maiores informações sobre o assunto, <a href="https://docs.microsoft.com/pt-br/ef/ef6/saving/transactions?redirectedfrom=MSDN">leia a página (em inglês)</a> no site da Microsoft.

Recentemente saiu também a tradução deste <a href="https://docs.microsoft.com/pt-br/ef/ef6/saving/transactions?redirectedfrom=MSDN"> artigo em português</a>, caso o link não redirecione para o português.

## Para saber mais: permitindo o uso de LojaContext com outros providers

Suponha que sua aplicação deverá suportar o MySQL. Atualmente o código de LojaContext está acoplado diretamente ao SQL Server. Como podemos tornar LojaContext independente do banco de dados empregado na aplicação?

Usando o princípio da Injeção de Dependência! Criaremos um construtor que receberá um objeto do tipo ````DbContextOptions<LojaContext>```` com as opções necessárias para usar o MySQL. Ele chamará o construtor da classe base ````DbContext```` através da palavra reservada ````base````, passando as opções como argumento. Para que o código continue compilando, manteremos o construtor sem argumentos.

Quando tanto o construtor como o método OnConfiguring são usados, o último sobrescreve as opções no contexto. Por isso precisamos colocar uma condição no método OnConfiguring perguntando se as opções já foram configuradas, o que é obtido através da verificação da propriedade booleana IsConfigured.

O código final fica assim:
using Microsoft.EntityFrameworkCore;
````cs
namespace Alura.Loja.Testes.ConsoleApp
{
    public class LojaContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public LojaContext()
        {  }

        public LojaContext(DbContextOptions<LojaContext> options): base(options)
        {  }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LojaDB;Trusted_Connection=true;");
            }
        }
    }
}
````

Para maiores detalhes e outras informações,<a href="https://docs.microsoft.com/en-us/ef/core/dbcontext-configuration/"> leia a página (em inglês)</a> sobre configuração do DbContext no site da Microsoft.

## Para saber mais: outro método de inclusão, AddRange

Repare que é possível incluir mais de um produto antes de enviar as mudanças para o banco de dados.

````cs
Produto p1 = new Produto();
p1.Nome = "Harry Potter e a Ordem da Fênix";
p1.Categoria = "Livros";
p1.Preco = 19.89;

Produto p2 = new Produto();
p2.Nome = "Senhor dos Anéis 1";
p2.Categoria = "Livros";
p2.Preco = 19.89;

Produto p3 = new Produto();
p3.Nome = "O Monge e o Executivo";
p3.Categoria = "Livros";
p3.Preco = 19.89;

contexto.Produtos.Add(p1);
contexto.Produtos.Add(p2);
contexto.Produtos.Add(p3);
contexto.SaveChanges();
````

Melhor ainda, como vimos em um exercício anterior, essas mudanças farão parte da mesma transação. Mesmo assim a classe ````DbSet```` possui outro método para incluir objetos no contexto. É o método ````AddRange````

````cs
contexto.Produtos.AddRange(p1, p2, p3);
contexto.SaveChanges();
````

Qual a diferença entre os métodos ````Add```` e ````AddRange````, além de um aceitar como argumento um objeto e outro uma lista? O segundo pode trazer uma melhora significativa de performance para inclusão de muitos objetos. Voltaremos a esse assunto com mais detalhes no capítulo 3

## Recuperando Dados (select) 
````cs
 private static void RecuperarProdutos()
        {
            using (var context = new LojaContext())
            {
                //Tolista funciona como se fosse o select do ADO.net
                IList<Produto> produtos = context.Produtos.ToList();
                foreach (var item in produtos)
                {
                    Console.WriteLine(item.Nome);
                    Console.ReadKey();
                }
            }
        }
````
## Deletando dados da tabela 

````cs
private static void ExcluirProdutos()
        {
            using (var context = new LojaContext())
            {
                IList<Produto> produtos = context.Produtos.ToList();
                foreach (var item in produtos)
                {
                    context.Produtos.Remove(item);
                }
                context.SaveChanges();
            }
        }
````

## Atualizar dados
````cs
private static void AtualizarProduto()
        {
            GravarUsandoEntity();
            RecuperarProdutos();
            using (var context = new LojaContext())
            {
                //Pegar o primeiro produto
                Produto primeiro = context.Produtos.First();
                primeiro.Nome = "Cassino Royale Editado";
                context.Produtos.Update(primeiro);
                context.SaveChanges();
            }
                RecuperarProdutos();
        }
````
## Gereciamento de objetos persistidos em banco

## Para saber mais: como o ChangeTracker funciona 

Nossas classes não tem nenhuma lógica adicional para facilitar o monitoramento de mudanças em suas propriedades. Isto é, elas não herdam de nenhuma classe com esse propósito, e não possuem nenhuma propriedade que registra se foram modificadas (por exemplo,IsDirty). São classes simples que usam o padrão POCO (Plain Old C# Objects).

Então, como o ChangeTracker sabe que, quando uma propriedade foi alterada, ele deve fazer um ````UPDATE```` no banco?

O Entity guarda um snapshot dos valores dos objetos por padrão. Quando aquele objeto começa a ser monitorado pelo Entity, seja através de métodos que recuperam objetos do banco via ````SELECT```` (por exemplo ````ToList````, ````First````, ````Find````, etc.), seja através do método Entry que cria uma entrada no ChangeTracker para o objeto passado como argumento do método.

E chama o método ````DetectChanges```` ao executar o ````SaveChanges````. O que esse método faz? ````DetectChanges```` verifica diferenças entre os valores atuais das propriedades da entidade e os valores originais guardados no snapshot quando ela foi anexada ao contexto.

É possível desligar o monitoramento automático de mudanças através de uma propriedade booleana no ChangeTracker chamada ````AutoDetectChangesEnabled````. Quando isso é necessário? Quando você tiver uma gravação massiva de objetos através do ````SaveChanges````, a performance pode sofrer impacto considerável, uma vez que o método ````DetectChanges```` será chamado e o ChangeTracker irá percorrer toda a lista de objetos sendo monitorados.

Maiores informações neste artigo <a href="https://blog.oneunicorn.com/2016/11/16/notification-entities-in-ef-core-1-1/">aqui</a> (em inglês).
