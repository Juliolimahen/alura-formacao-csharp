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

Fonte: <a>https://www.alura.com.br/curso-online-bootstrap-criacao-single-page-responsiva</a>


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