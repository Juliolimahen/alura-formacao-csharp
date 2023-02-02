ASP.NET Core parte 1: um e-Commerce com MVC e EF Core 2

## PARA SABER MAIS...


### .NET Core ou .NET Framework? E agora?


© 2018 Microsoft
Alura 2023


Ao criar um projeto ASP.NET Core, você pode escolher entre dois tipos de compilação: .NET Framework e .NET Core. Embora grande parte do código possa ser o mesmo em ambos os projetos, você precisa saber que existem vantagens e limitações em ambas as opções de compilação. Portanto, é bom conhecer essas diferenças antes de criar seu projeto, caso contrário isso poderá ter um impacto negativo mais tarde em seu projeto.

Crie aplicações ASP.NET Core para .NET Core nas seguintes situações:

- Você quer estender sua aplicação .NET Framework com uma nova área desenvolvida com ASP.NET Core +.NET Core.
- Você precisa desenvolver sua aplicação web em Windows, Linux ou MacOS.
- Você precisa executar sua aplicação web em Windows, Linux ou MacOS.
- Você precisa de microsserviços.
- Você precisa rodar sua aplicação web em contêineres Docker.
- Você precisa de aplicações web escaláveis e de grande performance.
- Você precisa de componentes .NET com versões "lado-a-lado".


Crie aplicações ASP.NET Core para .NET Framework nas seguintes situações:


- Você já utiliza o .NET Framework na aplicação atual.
- Você utiliza componentes .NET de terceiros.
- Você utiliza pacotes .NET Framework do NuGet que ainda não têm versão .NET Core disponível.
- Você utiliza tecnologias .NET que ainda não existem para o .NET Core.


### Contêineres: .NET Core ou .NET Framework? 


Nos últimos anos houve um grande crescimento na demanda por contêineres no mundo da computação.

Um contêiner é um ambiente virtual isolado onde rodam aplicações. Do ponto de vista dessas aplicações, o contêiner onde elas estão hospedadas funciona como um computador real, com todos os seus recursos. Isso é possível por causa da técnica de virtualização, que faz com que o kernel do sistema operacional permita a existência de várias instâncias isoladas, que são os contêineres.

Enquanto uma aplicação rodando num sistema operacional em uma hospedagem tradicional tem acesso a todos os recursos do servidor (tais como CPU, redes, sistema de arquivos, etc.), uma aplicação implantada em um contêiner está restrita a acessar e utilizar somente os recursos do servidor que estão configurados para esse contêiner.

Isso torna a implantação de aplicações web em contêineres muito estáveis, e a sua configuração bem definida evita imprevistos que são comuns quando aplicações rodam em ambientes com diferentes configurações de sistema operacional, permissões, rede, etc.

É possível utilizar aplicações web com .NET Framework em contêineres Windows. Porém, o .NET Core é bem mais indicado para esse tipo de implantação, por ser modular, ter uma imagem bem menor do que a do .NET Framework. Além disso, diferente do .NET Framework, uma aplicação web com .NET Core pode rodar tanto em contêineres Windows como Linux.


### Microsserviços: .NET Core ou .NET Framework?


Microsserviço é uma técnica de desenvolvimento de software onde a arquitetura da aplicação é formada por um conjunto de serviços independentes e desacoplados.

Uma aplicação composta assim por serviços menores, mais leves e independentes, acaba se tornando mais modular, mais fácil de desenvolver e de testar e de implantar. Várias equipe de desenvolvimento podem trabalhar em paralelo e de forma independente em cada um dos microsserviços, eliminando gargalos na entrega contínua e no desenvolvimento.

Projetos ASP.NET Core para .NET Core são ideais para arquitetura de microsserviços.


### Multiplataforma: .NET Core ou .NET Framework?


Multiplataforma: .NET Core ou .NET Framework?
Felizmente, desenvolvedores de aplicações ASP.NET Core com .NET Core não estão limitados a computadores Windows.

O .NET Core dá suporte ao desenvolvimento em múltiplos sistemas operacionais: Windows, Linux e macOS.

Quais opções tenho para minha IDE (ambiente de desenvolvimento integrado)?
- Se você usa Linux, pode utilizar o Visual Studio Code
- Se você usa Windows ou macOS, pode utilizar tanto o Visual Studio como o Visual Studio Code
A maioria dos editores de terceiros, como Sublime, Emacs e VI, trabalham com o .NET Core. Esses editores de terceiros podem utilizar o IntelliSense através da instalação da ferramenta OmniSharp.


### Para saber mais - Bootstrap

O Bootstrap se tornou um padrão, reduzindo grande parte do desenvolvimento de interfaces, com layouts simples, rápidos e responsivos.

Neste curso, Yuri Padilha ensina passo-a-passo a criação de uma single-page responsiva, e esse conhecimento você pode aproveitar para criação de suas próprias aplicações web com ASP.NET Core.

Criaremos um site voltado para arquitetura. Usaremos, para tanto, tecnologias como HTML, CSS, Javascript, JQuery e, por fim, o Bootstrap3. O Bootstrap3 é um framework que possui vários códigos já prontos o que acaba aumentando a nossa produtividade. Vamos utilizar bastante a sua documentação para nos auxiliar a fazer o site da forma mais eficiente e eficaz possível. Assim, consultando a documentação não será preciso decorar nada! Usaremos, ainda, as melhores práticas de HTML e CSS.

Bootstrap: criação de uma single-page responsiva
Alura Cursos Online

Autor: Yuri Padilha

 <a href="https://www.alura.com.br/curso-online-bootstrap-criacao-single-page-responsiva"> Fonte </a>


### Classe startup

Método ConfigureServices:

- Serve para adcionar serviços a aplicação

Método Configure:

- Serve para consumir o serviço
- Configuração/definição pipeline 

### Injecção de dependência

Ele fez isso graças a uma técnica chamada injeção de dependência. Ele já possui esta técnica nativamente, e pode ser utilizada para criar instâncias a partir da definição de parâmetros do tipo interface. Ou seja, podemos definir uma interface, dizer que ela gerará uma instância de uma determinada classe, e então injetar, inserindo parâmetros para a criação das novas instâncias. Também podemos utilizar um esquema alternativo de injeção de dependência, utilizando um outro framework, como o ninject.


### Migrate x EnsureCreated

Qual a diferença entre invocar o método contexto.Database.EnsureCreated() e o método contexto.Database.Migrate() para criar um novo banco de dados através do Entity Framework Core?

O método EnsureCreated() cria o banco de dados e seus objetos (tabelas, campos, índices, etc) usando apenas as entidades e mapeamentos da aplicação. Já o método Migrate() realiza exatamente a mesma tarefa, porém usando apenas as migrações da aplicação.

Isso mesmo! Além disso, uma vez que o banco de dados foi gerado através do método EnsureCreated(), a aplicação não pode mais usar migrations. Por isso, a não ser que uma aplicação seja pequena e destinada a testes, é recomendável usar sempre o método Migrate().

## Para Saber Mais


### Como Ler Configurações no Controller?

Você pode ter se deparado com esse problema da vida real, fora do contexto do nosso curso: como ler configurações do ASP.NET Core 2.0 a partir de um controller? Vamos partir do pressuposto de que você tenha uma aplicação de blog com uma estrutura de configuração definida no arquivo appsetings.json.

Vamos começar pelo arquivo appsetings.json. Digamos que sua configuração seja definida pelo arquivo abaixo:

````json

{
    "ConnectionStrings": {
        "Blog": "Server=(localdb)\\mssqllocaldb;Database=MeuBlog;Trusted_Connection=True;"
    },  
    "Security": {
        "Language" : "pt-BR",
        "SuperUser": {
            "Login": "bgiorgione",
            "Email": "bgiorgione@bgiorgione.com.br",
            "ShowEmail": "true"
        },
        "Admin": {
            "Login": "moliveira",
            "Email": "mclricardo@gmail.com.br",
            "ShowEmail": "false"
        }
    }
}

````

Todos os método de que precisamos precisam vir da classe Configuration, que é uma implementação da interface IConfiguration.

O primeiro passo seria configurar o mecanismo de injeção de dependência do ASP.NET Core para obter o objeto de configuração. Mas felizmente esse objeto já vem automaticamente registrado internamente no contêiner de injeção de dependência do ASP.NET Core, portanto você não precisa adicionar o código services.AddSingleton<IConfiguration>(Configuration); na sua classe Startup.

Agora, como vimos no curso, basta adicionar um parâmetro IConfiguration no construtor do controller para começarmos a obter as configurações:

````cs

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Blog.Controllers
{
    public class BlogController : Controller
    {
        private IConfiguration _configuration;

        public BlogController(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        public IActionResult Usuarios()
        {
            // Configuração usando a string de chave
            ViewData["SecurityLanguage"] = _configuration["Security:Language"];

            // Configuração usando método GetSection

            ViewData["SecuritySuperUserLogin"] = 
            _configuration.GetSection("Security").GetSection("SuperUser").GetSection("Login");

            // Configuração usando GetSection e string de chave ao mesmo tempo
            ViewData["SecuritySuperUserEmail"] = 
                _configuration.GetSection("Security")["SuperUser:Email"];

            // Configuração usando GetSection e string de chave ao mesmo tempo
            ViewData["SecuritySuperUserShowEmail"] = 
                _configuration.GetSection("Security")["SuperUser:ShowEmail"];

            return View();
        }
    }
}

````

No exemplo acima, populamos o ViewData com as configuração. Mas você pode utilizar as configurações como quiser, claro.

Agora basta exibir os dados na view Usuarios:

````html

<p>
    SecurityLanguage <strong>@ViewData["SecurityLanguage"]</strong><br />
    SecuritySuperUserLogin <strong>@ViewData["SecuritySuperUserLogin"]</strong><br />
    SecuritySuperUserEmail <strong>@ViewData["SecuritySuperUserEmail"]</strong>
    SecuritySuperUserShowEmail <strong>@ViewData["SecuritySuperUserShowEmail"]</strong>
</p>

````

## Para saber mais

### Diferenças entre o Entity Framework 6 e o Entity Framework Core


Neste curso utilizamos Entity Framework Core 2.0 como ORM (Framework de Mapeamento Objeto-Relacional). Talvez você esteja se perguntando: "Quais as diferenças entre o Entity Framework Core e o Entity Framework 6 que eu costumava usar em projetos anteriores?"

Primeiro caso: Para aplicações EF6 existentes
O Entity Framework Core é considerado um avanço em relação ao Entity Framework 6, porém nem todas as funcionalidades do EF6 foram implementadas no EF Core. As próximas versões do EF Core irão tratar de eliminar essas limitações.

É preciso um bom motivo para migrar um projeto EF 6 para EF Core, caso contrário você pode estar arriscando seu projeto.

Veja no final da página as tabelas comparativas entre as duas versões do Entity Framework para decidir qual a melhor opção.

Segundo caso: Para novas aplicações
Se você precisar criar novas aplicações, é recomendával utilizar o EF Core, desde que seu aplicativo não necessite de recursos do Entity Framework 6 que ainda não foram implementados no EF Core.

O EF 6 depende do Windows. Isso significa que você não poderá criar novas aplicações com EF 6 para o .NET Core. Somente o Entity Framework Core pode rodar sobre o .NET Core.

Você ainda pode utilizar o Entity Framework 6 em novos projetos, porém é importante saber se ele é aceitável para sua aplicação. Você pode visualizar as diferenças entre EF 6 e EF Core nas tabelas abaixo, que podem lhe ajudar a decidir qual das duas opções é mais adequada ao seu projeto.



### Vamos dar uma olhada no código do PedidoController:

````cs
 public class PedidoController : Controller
    {
        private readonly IProdutoRepository produtoRepository;

        public PedidoController(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }
    }
````


Note que esse construtor está exigindo um parâmetro: public PedidoController(IProdutoRepository produtoRepository). Esse parâmetro é uma dependência, isto é, sem ele o controller não vai funcionar, pois precisamos do repositório de produtos para podermos consultar os produtos do e-commerce.

Mas como esse parâmetro é injetado? Note que, em nenhum momento, nós instanciamos um controller diretamente, como por exemplo PedidoController meuController = new PedidoController(), certo? Quando chamamos uma url para acessar action através do navegador, o controller é instanciado pelo próprio ASP.NET Core, por baixo dos panos. O que fazemos na injeção de dependência é informar o ASP.NET Core sobre tudo o que a instância do controller precisa para ser criada. 

E então o que o ASP.NET Core faz automatimente, sem a gente ver?

- Ele cria uma instância de IProdutoRepository (através da classe ProdutoRepository)
- Ele cria uma instância de PedidoController, passando a instância de IProdutoRepository criada no passo 1.

Ou seja, esse parâmetro é injetado automaticamente sempre que o ASP.NET Core cria uma nova instância do PedidoController.

Qual seria a alternativa a isso?

Sem injeção de dependência, teríamos que criar as instâncias manualmente, usando o operador new. Teríamos que informar a classe concreta, em tempo de desenvolvimento, o tempo todo. Com injeção de dependência, podemos simplesmente definir parâmetros nos construtores, que são interfaces e não classes concretas. Por que isso é importante? Porque quando programamos com interfaces fazemos com que as classes não precisem conhecer as classes concretas que vão ser criadas, apenas as interfaces. Isso é bom porque diminui o acoplamento e a dependência entre classes.

Um exemplo de injeção de dependência: Imagine que você tenha uma aplicação que gera logs sobre a atividade do usuário no seu site. Você então utiliza injeção de dependência, fazendo seu programa chamar métodos da interface IUserLog. Inicialmente, você define que os logs vão ser gravados em arquivo texto, através de uma classe FileLog (que implementa IUserLog). Mas depois de um tempo, você decide gravar os logs em banco de dados, usando uma outra classe chamada SQLServerLog (que também implementa IUserLog).

Como você faria essa mudança? Com injeção de dependência, você pode simplesmente mudar uma única linha de configuração, indicando que IUserLog deve ser instanciada como SQLServerLog, e não mais como FileLog. Agora, sem injeção de dependência você teria que substituir todas as chamadas da classe FileLog para SQLServerLog.


### Você está desenvolvendo uma aplicação da área de Recursos Humanos usando ASP.NET Core 2.0 MVC, e acaba de criar uma nova classe chamada Calendario. Essa classe possui métodos que serão úteis para obter dados para várias páginas. Os métodos são:

````cs 
public int GetDiasCorridos(DateTime dataInicial, DateTime dataFinal){}
public int GetDiasUteis(DateTime dataInicial, DateTime dataFinal){}
public DateTime GetProximasFerias(int funcionarioId){}
````

Você deseja que uma instância da classe Calendario esteja disponível para uso em todos os pontos da sua aplicação, e deseja que o código não referencie a classe diretamente, mas sim através da sua interface ICalendario. Quais os passos necessários para realizar essa tarefa?


- Criando um parâmetro ICalendario no construtor de cada classe que utilizará a instância da classe Calendario:
````cs
public class MinhaClasse()
{
    public MinhaClasse(ICalendario calendario)
    {
    }
}

````

O parâmetro ICalendario será passado pelo container de injeção de dependência do ASP.NET Core 2.0 como uma instância da classe Calendario.


- Usando os métodos da instância do campo calendario nos métodos da classe MinhaClasse:

````cs
public void AlgumMetodo(int funcionarioId, DateTime dataInicial, DateTime dataFinal)
{
    DateTime inicioProximasFerias = calendario.GetProximasFerias(funcionarioId)
    int diasCorridos = calendario.GetDiasCorridos(dataInicial, dataFinal)
    int diasUteis = calendario.GetDiasUteis(dataInicial, dataFinal)
}
````

O campo ICalendario calendario armazena uma referência para o objeto que foi injetado na classe MinhaClasse, portanto os seus métodos já estão disponíveis para uso dentro dos métodos da classe.


- Atribuindo o valor do parâmetro ICalendario a um campo privado da classe MinhaClasse:

````cs
public class MinhaClasse()
{
    private readonly ICalendario calendario;

    public MinhaClasse(ICalendario calendario)
    {
        this.calendario = calendario;
    }
}

````

O campo ICalendario calendario armazenará uma referência para o objeto que foi injetado na classe MinhaClasse;


- Registrando a interface e a classe no container de injeção de dependência, no método Startup.ConfigureServices:

````cs
services.AddTransient<ICalendario, Calendario>();
````

Usamos services.AddTransient para registrar a interface juntamente com a classe concreta. Dessa forma, o container de injeção de dependência do ASP.NET Core 2.0 saberá criar a instância da classe apropriada a partir da interface.


### Por que parâmetro como interface e não como classe concreta?

Quando definimos que os parâmetros de métodos e construtores de uma determinada classe são classes concretas, corremos o risco de "engessar" as relações entre as classes.

É uma boa prática programar para interfaces, pois isso diminui o acoplamento entre as classes, isto é, diminui a dependência entre elas. Por exemplo, imagine esta classe:

````cs 
public class Automovel()
{
    public Automovel(MotorAGasolina motor)
    {
    ...
    }
}`
````

O que acontece quando você precisa trocar MotorAGasolina por uma outra classe, chamada MotorAAlcool, que implementa os mesmos métodos e interfaces? Nesse caso, você precisa mudar a classe Automovel:

````cs
public class Automovel()
{
    public Automovel(MotorAAlcool motor)
    {
    ...
    }
}
````

Mas isso não é bom, pois você está modificando uma classe que funciona perfeitamente, apenas para trocar o tipo de um parâmetro!

Isso representa uma violação de um princípio conhecido como "open-closed principle", isto é, aberto para extensibilidade, fechado para modificação. De acordo com esse princípio, você deveria projetar sua classe para que as mudanças, como alterações nos tipos de parâmeros, não necessitem de alterações na classe Automovel.

Mas quando você estabelece que a interface utilizada é de uma determinada interface, você já definiu um contrato entre a classe Automovel e o tipo de classe que ela recebe como parâmetro do construtor:

````cs
public class Automovel()
{
    public Automovel(IMotor motor)
    {
    }
}
````

A partir daí, não importa qual é exatamente a classe recebida como parâmetro do construtor de Automovel, desde que ela implemente a interface IMotor.


### Numa view Razor, qual a diferença entre @model (com inicial em minúscula) e @Model (com inicial em maiúscula)?

As duas formas tem uma utilização bem específica:


- 1) Para declarar com qual qual modelo a página Razor irá trabalhar, utilizamos a diretiva @model (inicial em minúscula):

````cshtml 
@model Cadastro
````

Nesse caso, Cadastro é a classe que serve de modelo para a view.

- 2) Para acessar as propriedades do modelo, precisamos utilizar o objeto Model (inicial em maiúscula):

````cshtml 
<input type="text" class="form-control" id="nomeCliente" placeholder="Nome do Cliente"
       asp-for="@Model.Nome">
````

Mas por que nesse caso também foi usado o símbolo de arroba (@) ? Porque ele sempre demarca o início de código C# dentro do HTML numa view Razor.

Note que nem sempre o objeto Model é precedido pelo arroba (@): Ele só é necessário quando você está inserindo o Model diretament num código HTML. Se você utilizar o Model dentro de um bloco C#, não se usa o arroba (@):

````cshtml 
<div class="carousel-inner" role="listbox">
    @{
        const int TAMANHO_PAGINA = 4;
        int paginas = (int)Math.Ceiling((double)Model.Count() / TAMANHO_PAGINA);
    }
````

## Renderizando a view com o modelo

### Como uma view obtém os dados do modelo para exibir na interface do usuário?

- Uma view automaticamente recebe o modelo a partir de uma action do controller. Em seguida, esse modelo é usado pelo mecanismo de renderização Razor para montar a interface.

- O controller serve para coordenar as requisições da rota da aplicação, obter os dados do modelo e passá-los para a view renderizá-los.


### Para saber mais - Code First, Database First ou Model First?

Quando trabalhamos com frameworks de "Mapeamento Objeto-Relacional", como Entity Framework, temos 3 alternativas: Code First, Database First ou Model First. Como escolher a melhor? Neste post, Gabriel Ferreira desmistifica e discute cada um deles, para você não ter dúvidas quando iniciar seu próximo projeto com Entity Framework Core.

### Qual técnica utilizar com o Entity Framework: Code First, Database First ou Model First?

Gabriel Ferreira

<a href="http://gabsferreira.com/qual-tecnica-utilizar-com-o-entity-framework-code-first-database-first-ou-model-first/"> Fonte</a>


### Âncora HTML x AnchorTagHelper


Como o ASP.NET Core consegue diferenciar uma Âncora HTML de um AnchorTagHelper, se ambos têm o formato 
````html
<a ...></a>?
````

- Uma AnchorTagHelper sempre tem pelo menos um atributo asp-...

- Os atributos asp-... fazer o ASP.NET Core tratar a âncora como AnchorTagHelper, que será executada no servidor e em seguida irá gerar o código HTML final.


## Modificando a rota default

Você está desenvolvendo uma aplicação web para consultório de odontologia.

Você precisa criar uma visualização do histórico de visitas de um paciente.

Você então cria um controller chamado PacienteController, onde o método com assinatura IActionResult Historico(int pacienteId) funciona como Action para a view Historico.cshtml.

Você quer que a view de histórico de visitas do cliente seja acessada através de uma url específica, como no exemplo abaixo:

````cshtml

[endereço do website]://paciente/historico/123
````

````cshtml
    name: "default", template: "{controller=Paciente}/{action=NovaVisita}/{pacienteId?}");
````

- Assim a view default se torna NovaVisita, do controller PacienteController, e a action receberá corretamente o parâmetro pacienteId.

## Para quê sessão?

Por qual motivo você usaria a sessão (Session) numa aplicação ASP.NET Core MVC? Escolha a melhor resposta.

- Para a aplicação não perder uma informação importante do usuário enquanto o usuário navega pelas páginas da aplicação

- O estado de sessão é um recurso do ASP.NET Core que você pode usar para salvar e armazenar dados de usuário enquanto o usuário navega seu aplicativo Web. Composto por um dicionário ou tabela de hash no servidor, o estado de sessão persiste dados entre solicitações de um navegador. É feito um back up dos dados da sessão em um cache.


## Para saber mais - Entity Framework Core

O Entity Framework Core é tão importante que a Alura Cursos Online criou um curso só para ele! Acompanhe com Daniel Portugal este novo curso para você ter mais poder sobre o banco de dados a partir da sua aplicação .NET.


## Entity Framework Core: Banco de dados de forma eficiente

Alura Cursos Online

Daniel Portugal

<a href="https://www.alura.com.br/curso-online-entity-framework-core">Fonte</a>


## Obtendo produtos do banco de dados

Como você implementaria o método GetProdutos() para obter todos os produtos da entidade Produto do banco de dados?


````cs
public List<Produto> GetProdutos()
{
    return contexto.Set<Produto>().ToList();
} 
````

````cs 
contexto.Set<Produto>()
```` 
representa no contexto do Entity Framework Core a coleção de produtos do banco de dados, portanto, quando obtemos seu valor, estamos na verdade consultando todos os produtos do banco de dados.

## Gravando id do pedido na sessão

Você está desenvolvendo uma aplicação de comércio eletrônico, utilizando ASP.NET Core 2.0 e Entity Framework Core.

Num certo momento, você implementa o método GetPedido(), que obtém o Pedido atual do usuário ou cria um novo se ele não existir:

````cs
001    public Pedido GetPedido()
002    {
003        var pedidoId = GetPedidoId();
004        var pedido = dbSet
005            .Include(p => p.Itens)
006                .ThenInclude(i => i.Produto)
007            .Where(p => p.Id == pedidoId)
008            .SingleOrDefault();
009    
010        if (pedido == null)
011        {
012            pedido = new Pedido();
013            dbSet.Add(pedido);
014            contexto.SaveChanges();
015        }
016    
017        return pedido;
018    }
````

Porém, você se esqueceu de fazer a chamada ao método SetPedidoId(int pedidoId), que grava o Id do pedido na sessão do ASP.NET Core para que ele seja preservado durante a navegação do usuário.

Em que lugar do código você implementaria a chamada ao método SetPedidoId?

- Entre as linhas 14 e 15

### Consultando entidades associadas

Você está desenvolvendo uma aplicação web para consultório de odontologia. Sua aplicação usa ASP.NET Core e Entity Framework Core para mapear as entidades do modelo (escrito em C#), para o banco de dados relacional Sql Server.

As entidades do banco de dados são:

Paciente: O cliente que se submete ao procedimento
Procedimento: O trabalho realizado (limpeza, extração, implante, etc.)
Dentista: O(a) profissional de odontologia
Suas entidades em C# possuem os seguintes relacionamentos:

Cada Paciente se submete a 0 ou mais procedimentos
Cada Procedimento é realizado em 1 e somente 1 Paciente
Cada Procedimento é realizado por 1 e somente 1 Dentista
Cada Dentista realiza 0 ou mais procedimentos
Para uma das consultas ao banco de dados, realizadas usando Entity Framework Core, você implementa o seguinte código para obter os dados do paciente e também os dentistas que o atenderam:

````cs
    var paciente = contexto.Set<Paciente>()
        .Where(pac => pac.Id == pacienteId)
        .SingleOrDefault();
````

Porém, ao obter o resultado da consulta, você percebe que o paciente contém todos os dados do paciente, porém não a consulta não trouxe nenhum Procedimento e, por causa disso, também nenhum Dentista.

````cs
    var paciente = contexto.Set<Paciente>()
        .Include(pac => pac.Procedimento)
            .ThenInclude(proc => proc.Dentista)
        .Where(pac => pac.Id == pacienteId)
        .SingleOrDefault();
````

- Você pode usar o método Include para especificar dados relacionados a serem incluídos nos resultados da consulta. Além disso, você pode fazer uma busca detalhada por meio de relações para incluir vários níveis de dados relacionados usando o método ThenInclude.

ASP.NET Core parte 2: um e-Commerce com MVC e EF Core 2

## Obtendo elementos na hierarquia do HTML

Você está desenvolvendo uma aplicação de comércio eletrônico, usando a biblioteca JavaScript JQuery.

A página de carrinho da aplicação possui um trecho contendo informações importantes sobre os itens do pedido, e você precisa obter informações nos elementos desse documento HTML.

Quais métodos jQuery você usaria para obter os elementos acima e abaixo de um determinado elemento, respectivamente? Escolha a melhor alternativa.

- parents e find

- O método parents obtém os "ancestrais" (elementos acima da hierarquia) do elemento. O método find vai obter os elementos abaixo da hiearquia.


## Defina o Binding dos Campos do Formulário

Você está desenvolvendo uma aplicação MVC com ASP.NET Core.

Uma das views possui um formulário de cadastro de dados de cliente, e seu modelo é definido como o tipo Cadastro:

````cshtml
@model Cadastro
````

Essa classe possui Cadastro possui propriedades como Nome, Email e Telefone.

Para o campo Nome, você cria um ````<label>```` e um ````<input>````, conforme segue:

````cshtml 
<label class="control-label" for="nomeCliente">Nome do Cliente</label>
<input type="text" class="form-control" id="nomeCliente" placeholder="Nome do Cliente">
````

Porém, você precisa fazer um binding dessa campo com o modelo da view.

Qual atributo você adiciona à tag <input> para fazer o binding com a propriedade Cadastro.Nome e transformá-la em uma TagHelper?

````cshtml 
asp-for="@Model.Nome"
````

Isso mesmo! O atributo asp-for transforma a tag ````<input>```` em uma TagHelper e também faz o binding do elemento com a propriedade Nome do Model.


## Valide o Campo do Formulário

Você está montando um cadastro de clientes em uma aplicação MVC usando ASP.NET Core.

Na view contendo o cadastro, você cria o label e também o input para o campo Nome:

````cshtml
<label class="control-label" for="nomeCliente">Nome do Cliente</label>
<input type="text" class="form-control" id="nomeCliente" placeholder="Nome do Cliente"
       asp-for="@Model.Nome">
````

- ````cshtml
  <span asp-validation-for="@Model.Nome" class="text-danger"></span>
  ````

Isso mesmo! O atributo asp-validation-for transforma o elemento numa ValidationMessageTagHelper e ainda injeta no HTML os atributos necessários para a validação do campo pelo plugin jquery-validation que é instalado na criação do projeto MVC Web App do ASP.NET Core.

## Retornando uma View Diferente

Você precisa fazer uma action de uma aplicação MVC com ASP.NET Core para receber uma requisição partindo de um formulário de cadastro de cliente.

Caso os dados do modelo sejam válidos, a action deve gravar os dados em banco de dados. Caso contrário, uma view diferente a requisição deve ser retornada a partir da action.

Qual alternativa contém o código necessário para realizar essa tarefa? Escolha a melhor resposta.


````cs
[HttpPost]
public IActionResult Resumo(Cadastro cadastro)
{
    if (ModelState.IsValid)
    {
        var model = pedidoRepository.UpdateCadastro(cadastro);
        return View(model);
    }
    return RedirectToAction("Cadastro");
}
````

- Caso o modelo seja válido, os dados serão gravados. Caso contrário, a chamada é redirecionada para a action "Cadastro".


## Proteja a Action do Controller

Você está desenvolvendo uma aplicação de comércio eletrônico (MVC Web App) com ASP.NET Core.

Em determinado momento, você necessita proteger uma action do controller contra ataques CSRF (Cross-site Request Forgery, ou Falsificação de solicitação entre sites).

Qual estratégia você tomaria para proteger a action abaixo? Escolha a melhor alternativa.


````cs
public IActionResult Resumo(Cadastro cadastro)
{
    if (ModelState.IsValid)
    {
        return View(pedidoRepository.UpdateCadastro(cadastro));
    }
    return RedirectToAction("Cadastro");
}
````

- Um atributo de token anti-falsificação

- O ValidateAntiForgeryToken especifica que a class ou método onde este atributo é aplicado faz uma validação do token anti-falsificação. Se esse token não estiver disponível, ou se o token for inválido, a validação irá falhar e o método da action não será executado.

## Forneça um Token Anti-Falsificação para a Página

Você precisa fazer uma requisição AJAX no JavaScript para um método no servidor que exige um token anti-falsificação.

Porém, a view de onde o JavaScript é executado não contém o token anti-falsificação.

Que estratégia você escolheria para fornecer um token anti-falsificação à página.

- Adicionar uma tag ````<form>```` na view da página.

- A tag ````<form>```` cria um FormTagHelper, que automaticamente fornece à página um token anti-falsificação na forma de um campo ````<input>```` oculto (hidden).


### Passe o Token Anti-Falsificação na Chamada Ajax

Você precisa enviar um token anti-falsificação através de uma requsição AJAX no código JavaScript. Observe o trecho de código abaixo, e escolha a modificação mais adequada para realizar essa tarefa.

````js

var data = {
    Id: 123,
    Quantidade: 7
};

$.ajax({
    url: '/pedido/updatequantidade',
    type: 'POST',
    contentType: 'application/json',
    data: JSON.stringify(data)
})
````

````js
let token = $('[name=__RequestVerificationToken]').val();
let headers = {};
headers['RequestVerificationToken'] = token;

$.ajax({
    url: '/pedido/updatequantidade',
    type: 'POST',
    contentType: 'application/json',
    data: JSON.stringify(data),
    headers: headers
})
````

- O token deve ser fornecido como um valor do cabeçalho (headers).