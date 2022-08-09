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

## Para saber mais: resumo dos estados EntityState
Segue abaixo um resumo dos estados e seu comportamento.

- Added
O objeto é novo, foi adicionado ao contexto, e o método SaveChanges ainda não foi executado. Depois que as mudanças são salvas, o estado do objeto muda para Unchanged. Objetos no estado Added não têm seus valores rastreados em sua instância de EntityEntry.

- Deleted
O objeto foi excluído do contexto. Depois que as mudanças foram salvas, seu estado muda para Detached.

- Detached
O objeto existe, mas não está sendo monitorado. Uma entidade fica nesse estado imediatamente após ter sido criada e antes de ser adicionada ao contexto. Ela também fica nesse estado depois que foi removida do contexto através do método Detach ou se é carregada por um método com opção NoTracking. Não existem instâncias de EntityEntry associadas a objetos com esse estado.

- Modified
Uma das propriedades escalares do objeto foi modificada e o método SaveChanges ainda não foi executado. Quando o monitoramento automático de mudanças está desligado, o estado é alterado para Modified apenas quando o método DetectChanges é chamado. Quando as mudanças são salvas, o estado do objeto muda para Unchanged.

- Unchanged
O objeto não foi modificado desde que foi anexado ao contexto ou desde a última vez que o método SaveChanges foi chamado.

## Como sincronizar o modelo de classes com a estrutura de dados?

### Para saber mais 
A sigla DDL significa Data Definition Language, ela é um subconjunto da linguagem SQL. comandos INSERT, DELETE, UPDATE e SELECT, esses comandos são DML que significa Data Manipulation Language.</strong>

## Migrations
- Parte responsável pela de sincronização
Para usar é necessário instalar o pacote 
````bash 
Install-Package Microsoft.EntityFrameworkCore.Tools -Version
````

## Comandos Migrations

````bash 
Add-Migration
````

````bash
Drop-Database 
````
    - Esse comando é utilizado para dropar o banco de dados apontado pelo contexto

````bash
Remove-Migration
````
    - Esse comando é utilizado para remover a última migração não aplicada no banco de dados apontado pelo contexto

````bash
Scaffold-DbContext
````
    -Esse comando é utilizado para criar uma classe que estende de DbContext, além de classes que representam as tabelas do banco


Para descobrir quais comandos estão disponíveis no recurso de Migrations, use este:
````bash 
Get-Help EntityFramework
````

## passos para sincronizar uma mudança de seu modelo de classes com o banco de dados

Registrar uma versão (migration, nos termos do Entity)

- Esse passo é executado pelo comando Add-Migration.

Efetivamente sincronizar as mudanças no banco apontado pelo contexto da aplicação. Isso é feito pelo comando Update-Database
-  Existe uma alternativa a esse passo, que é gerar o script DDL das migrações e enviar para o responsável por executá-lo no servidor desejado

## Para saber mais: sincronizando o banco com sua própria aplicação

Depois que sua aplicação estiver madura o bastante para ser promovida, surge a questão: como atualizar o banco de dados daquele ambiente específico? Vimos que em organizações com políticas de acesso mais restritas a ambientes críticos, a solução é gerar um arquivo com o script das migrações e entregar esse arquivo à equipe responsável. Essa tarefa é realizada com o comando ````Script-Migration````.

Além disso, também é possível fazer que sua própria aplicação cuide da migração das versões. Ou seja, podemos escrever código em nossa aplicação para que o banco de dados seja sincronizado. Isso é feito através do método de extensão ````Migrate````, que está acessível na propriedade ````Database```` da classe ````DbContext````. Essa propriedade representa a instância do banco de dados apontado pelo contexto Entity específico de sua aplicação (no nosso exemplo, ````LojaContext````), e expõe métodos que permitem gerenciar o banco apontado pelo contexto, como por exemplo sua criação, exclusão e validação de existência.

O método ````Migrate```` só pode ser usado em bancos de dados relacionais e fica disponível no pacote ````Microsoft.EntityFrameworkCore.Relational````.

Assim, para garantir que todas as migrações estarão aplicadas no banco de dados, podemos escrever:

````cs
using(var contexto = new LojaContext())
{
  contexto.Database.Migrate();
}`
````
Você precisa garantir que esse código seja executado antes de qualquer acesso aos objetos gerenciados pelo contexto. Isso vai depender do tipo de aplicação que será implementada.

## Relacionamento um para muitos

No Entity Framework, para representarmos que uma compra tem um produto, colocamos uma propriedade do tipo Produto na classe Compra, chamada por exemplo de Produto. Além disso, como no modelo relacional não podemos guardar um objeto (Produto), precisamos guardar uma referência para a sua chave primária, chamada de chave estrangeira.

Se tivermos a seguinte classe Compra no código:

````cs
internal class Compra
{
   public int Id { get; set; }
   public int Quantidade { get; internal set; }
   public Produto Produto { get; internal set; }
   public double Preco { get; internal set; }
}
````

Qual deve ser o nome da chave estrangeira desse relacionamento, e em qual classe essa propriedade deve ser colocada?

- ProdutoID na classe Compra.

Por convenção, o nome da propriedade que representará o relacionamento será o nome da classe seguido da palavra ID. Então para representar a classe Produto dentro da classe Compra, criamos a propriedade ProdutoID na classe Compra, do tipo int, pois não pode ser nulo.


## Inserindo objetos relacionados

````cs
class Program
{
    static void Main(string[] args)
    {
        //compra de 6 pães franceses
        var paoFrances = new Produto();
        paoFrances.Nome = "Pão Francês";
        paoFrances.PrecoUnitario = 0.40;
        paoFrances.Unidade = "Unidade";
        paoFrances.Categoria = "Padaria";

        var compra = new Compra();
        compra.Quantidade = 6;
        compra.Produto = paoFrances;
        compra.Preco = paoFrances.PrecoUnitario * compra.Quantidade;

        using(var contexto = new LojaContext())
        {
            var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            loggerFactory.AddProvider(SqlLoggerProvider.Create());

            contexto.Compras.Add(compra);
            
            //monitoramento change tracker
            //ExibeEntries(contexto.ChangeTracker.Entries());

            contexto.SaveChanges();
        }
    }
}
````
Quando adicionarmos o compra no Change Tracker, o Entity perceberá que existe uma referência ao produto paoFrances e também o incluirá para ser supervisionado.

Executaremos a aplicação, como resultado veremos que temos duas entidades, um do tipo Compra e outro do tipo Produto. As duas entidades estão com o estado Added, por isso o Entity irá gerar o comando SQL INSERT para cada um deles. O contexto foi esperto o suficiente para adicionar a referência do produto contida na compra.

## Relacionamento muitos para muitos e a classe de join

É necessário criar uma classe para fazer essa relação(versão do entity core não permite)

````cs
    public class PromocaoProduto
    {
        public PromocaoProduto() { }

        public int ProdutoId { get; set; }
        public int PromacaoId { get; set; }
        public Produto Produto { get; set; }
        public Promocao promacao { get; set; }
    }
````
E criar uma chave composta sobescrevendo o Método OnModelCreate na classe de contexto

````cs
//composição de chaves primarias 
            modelBuilder.Entity<PromocaoProduto>().HasKey(p => new { p.PromacaoId, p.ProdutoId });
            base.OnModelCreating(modelBuilder);
````
### Exercício 

No sistema bancário que Manoel está produzindo, chegou a hora de relacionar contas a clientes. O requisito que Manoel precisa atender é: uma conta pode estar associada a vários clientes, e um cliente pode ter várias contas.

Suponha que as classes Conta e Cliente estejam especificadas desta maneira:

````cs
namespace Alura.Banco.Modelo
{
    public class Conta
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public double Saldo { get; set; }
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
    }
}
````

Para que o Entity consiga mapear o cenário Contas x Clientes (descrito no primeiro parágrafo) no banco de dados, selecione as alternativas que descrevem as mudanças que você vai precisar fazer em seu modelo.

- Incluir uma propriedade Clientes do tipo ````IList<ContaCliente>```` na classe Conta.
- Incluir uma propriedade Contas do tipo ````IList<ContaCliente>```` na classe Cliente.
- Criar uma classe ContaCliente para representar a tabela de join entre conta e cliente.

O código da solução deve ficar parecido com:

````cs
namespace Alura.Banco.Modelo
{
    public class Conta
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public double Saldo { get; set; }
        public IList<ContaCliente> Clientes { get; set; }
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public IList<ContaCliente> Contas { get; set; }
    }

    public class ContaCliente
    {
        public int IdConta { get; set; }
        public int IdCliente { get; set; }
        public Conta Conta { get; set; }
        public Cliente Cliente { get; set; }
    }
}
````
### Exercício

Onde foram parar os registros da tabela de join?


Você viu no vídeo que quando excluímos uma promoção, os registros relacionados à tabela de join também são excluídos.

Isso aconteceu porque...

- A tabela de join foi criada com uma chave estrangeira para a tabela de promoção, e nessa chave foi definido o trigger OnDeleteCascade. Quando a promoção foi excluída, os registros relacionados foram excluídos em cascata.

## Shadow Properties

Para maiores informações sobre o assunto, visite a página da <a href="https://docs.microsoft.com/pt-br/ef/core/modeling/shadow-properties">documentação na Microsoft (em inglês)</a>.

### Exercício 

Cidades do Rio de Janeiro

````cs
namespace Alura.Banco.Modelo
{
    public class Cidade
    {
        public int Id { get; set; }
        public string Nome  { get; set; }
        public int Populacao  { get; set; }
        public string Estado { get; set; }
    }
}
````

Considere também que o contexto BancoContext está gerenciando a persistência de objetos do tipo Cidade:

````cs
namespace Alura.Banco.Entity
{
    public class BancoContext : DbContext
    {
        public DbSet<Cidade> Cidades { get; set; }

        //...outras propriedades aqui...
    }
}
````

Selecione a alternativa que faz o seguinte SQL:

````sql
SELECT * From Cidades WHERE Estado = 'RJ' AND Populacao > 50000
````

- ````cs
    var cidades = contexto.Cidades
    .Where(c => c.Estado == "RJ" && c.Populacao > 50000)
    .ToList();
    ````


## Como realizar joins entre entidades relacionadas 

### Exercício

O cliente possui que contas?

Selecione a opção que irá recuperar o primeiro cliente do banco de dados, juntamente com suas contas bancárias. Lembre-se que Manoel criou um relacionamento muitos para muitos entre Cliente e Conta.

Abaixo o modelo que representa a relação entre essas classes.

````cs 

namespace Alura.Banco.Modelo
{
    public class Conta
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public double Saldo { get; set; }
        public IList<ContaCliente> Clientes { get; set; }
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public IList<ContaCliente> Contas { get; set; }
    }

    public class ContaCliente
    {
        public int IdConta { get; set; }
        public int IdCliente { get; set; }
        public Conta Conta { get; set; }
        public Cliente Cliente { get; set; }
    }
}`
````

- ````cs 
    var cliente = contexto.Clientes
  .Include(c => c.Contas)
  .ThenInclude(cc => cc.Conta)
  .FirstOrDefault();
  ````

### Para saber mais: sobrecarga de Include

O método Include possui uma segunda sobrecarga, que permite informarmos como argumento de entrada uma string com o nome da propriedade de navegação a ser incluída no join. A vantagem dessa abordagem é que não precisamos usar outros métodos ThenInclude para continuar a navegação em outras entidades. Por exemplo, para o exemplo Cliente x Conta, poderíamos fazer:

````cs
var lista = contexto.Clientes.Include("Contas.Conta");
````

A desvantagem é que se o nome da propriedade mudar, teremos que lembrar todos os lugares onde fizemos isso, porque não teremos ajuda do compilador.

### Exercício 

LEFT JOIN?

No vídeo anterior, você viu que o SELECT gerado pelo Entity para recuperar o endereço de entrega foi parecido com o SQL abaixo:

````sql
SELECT TOP 1 c.*, e.*
FROM Clientes c LEFT JOIN Enderecos e ON e.ClienteId = c.Id
````

Porque o Entity optou por gerar um join com a cláusula LEFT JOIN, ao invés de INNER JOIN?

- Porque Endereco não é obrigatório, e o uso da cláusula ````INNER JOIN```` faria com que clientes sem endereços fossem rejeitados pelo ```` SELECT````.

## Visão geral 

Finalizamos o curso de Entity Framework Core! Faremos um resumo sobre o que aprendemos durante o curso.

Vimos que para trabalhar com o modelo de negócios e persisti-lo no banco de dados era algo extremamente trabalhoso. O programador era responsável por gerenciar e manter o código que se comunicava com o banco. Qualquer mudança na lógica de negócio, gerava uma série de impactos nas classes de acesso aos dados.

Em seguida, Começamos o uso do Entity após a instalação dos pacotes, passando a substituir todo o trabalho, permitindo forcarmos na lógica de negócio. Aprendemos como o Entity gerencia os comandos SQL, trabalhando com a DML (INSERT, SELECT, UPDATE e DELETE) para manipular os dados.

manipulação de dados
<a></a>

Para gerenciar quais objetos e quais comandos SQL precisavam ser emitidos para o banco de dados, o Entity usava um recurso chamado Change Tracker, onde era armazenado os estados de cada objeto.

change tracker

<a></a>

Enquanto a aplicação evoluía, era necessário sincronizá-la com o banco de dados, onde Entity também nos auxilia com a DDL (CREATE, DROP, ALTER, RENAME). Utilizamos o conceito de migrações (Migrations), onde as alterações no negócio são aplicadas ao banco. As migrações eram feitas por meio de classes, que tinha os métodos Up() para subir e Down() para descer de versão.

Instalamos no NuGet, um pacote para utilizarmos diversos comandos que trabalham com as migrações.

Add-Migration
Remove-Migration
Update-Database
Todas as alterações no banco de dados eram armazenadas na tabela __EFMigrationHistory. A tabela indicava quais migrações tinham sido aplicadas no banco de dados.

Após entender como o Entity funciona, aprendemos como ele trabalha e gerencia os relacionamentos entre classe. Os relacionamentos eram um para um, um para muitos e muitos para muitos. Porém o Entity Core não gerencia sozinho as tabelas JOIN, por isso contornamos criando uma classe específica.
<a></a>
tabela de relacionamentos

Para recuperarmos dados relacionados, usamos métodos específicos:

Include()
ThenInclude()
Load()
