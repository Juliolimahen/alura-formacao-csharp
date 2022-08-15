# Testes em .NET: testes de interface usando Selenium

## Teste de interface/and to and

## Selenium IDE

No projeto do Selenium, o Selenium IDE se apresenta como alternativa para a criação de script para automação de tarefas repetitivas para interfaces web.

Em relação às vantagens e características desta ferramenta, escolha as alternativas corretas com relação ao teste de interface.

- O Script gerado pode ser convertido em código de linguagem de programação, gerando códigos que podem ser utilizados para entender a sintaxe e como funciona a biblioteca do Selenium WebDriver.  O código gerado pode auxiliar no estudo da biblioteca Selenium WebDriver.

- O Selenium IDE permite que salvemos o script gerado para um código Java, C# ou Python, que pode ser reaproveitado para escrita de um teste automatizado. A ferramenta consegue converter o script da macro gravada para um código em linguagem de programação.


## Para saber mais: O que é HTML e tags?

O HTML existe desde os primórdios da web e é a maneira padronizada de estruturarmos uma página Web. O HTML ou HyperText Markup Language, é uma linguagem de marcação que nos permite construir uma página Web, que poderá ser renderizada em um navegador de sua escolha e assim compor um website ou sistema web.

Até o momento da publicação deste curso, o HTML encontra-se na versão 5 e é mantida pelo W3C (World Wide Web Consortium) - um consórcio internacional que tem por objetivo definir os padrões da internet.

A estrutura básica de um documento HTML é apresentada abaixo:
````html
<!DOCTYPE html>
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Título da página</title>
</head>
<body>
    <!-- Corpo da página -->
</body>
</html>
````
Todo documento HTML é composto por uma série de tags, que representam elementos, e possuem um nome, identificação e são escritas entre os sinais de < e >. Conforme apresentado na codificação acima, temos algumas tags:

````<html></html>````: define o documento como página html;
````<head></head>````: define o cabeçalho da página, e onde geralmente definimos metadados úteis para pesquisa de buscadores;
````<title></title>````: define o título que irá aparecer na página html;
````<body></body>````: é onde definimos o corpo da página, nela inserimos outros elementos do html como links( ````<a>````), botões( ````<button>````), imagens (````<img>````), campos de texto (````<input>````), formulários (````<form>````) entre outros.

Ao trabalhar com tags do html podemos configurá-las, o que confere a formatação uma flexibilidade muito maior por permitir que uma determinada tag assuma um comportamento ou aparência específica, por exemplo:

````html 
<img src="imagens/alura/logo.jpg" alt="Imagem de uma logo Alura" width="300" height="150">
````

Na codificação acima, temos a tag img configurada para apresentar uma imagem presente em “imagens/alura/logo.jpg”. Caso a imagem não seja encontrada, será mostrado o texto alternativo “Imagem de uma logo Alura” e deverá ser apresentada nas dimensões de largura 300 e altura 150. O Src é um atributo específico da imagem, contudo existem alguns atributos globais que podem ser inseridos em qualquer tag html como o Id (identificador), Name (nome) ou Class (configuração css) e são bem úteis para que possamos identificar e configurar um determinado elemento (tag) no html. Veja um exemplo:

````html
<input type="submit" value="Logar" id="btn-logar" class="btn btn-primary btn-lg" />
````

Para se aprofundar ainda mais sobre HTML e suas tags:
<a href="https://www.alura.com.br/artigos/o-que-e-html-suas-tags-parte-1-estrutura-basica"> O que é o HTML e suas tags? Parte 1: estrutura básica.</a>

## Para saber mais: O que é Selenium WebDriver?

A solução do Selenium congrega um conjunto de ferramentas OpenSource usado para testar aplicações web de forma automatizada, permitindo testarmos funcionalidades da aplicação e a compatibilidade com algumas plataformas de browser diferentes e inclusive dá suporte para algumas linguagens de programação como o C#, Java, Python e Ruby.

Dentro do ecossistema do Selenium temos a biblioteca WebDriver, que faz uso do driver do próprio navegador para criar as automações da interface web, ou seja, ela consegue manipular o navegador de forma nativa, como se fosse o usuário executando alguma operação. De acordo com a documentação oficial da biblioteca o Selenium WebDriver:

- Recomendada pela própria W3C.
- Foi projetada como uma interface de programação simples e concisa.
- É uma API compacta e orientada a objetos.
- Permite a manipulação eficaz do navegador web.

Para se aprofundar mais sobre a biblioteca Selenium WebDriver, consulte a documentação:
<a href="https://www.selenium.dev/pt-br/documentation/webdriver/"> Documentação Selenium WebDriver</a>

## Selenium WebDriver

No desenvolvimento de um teste usando como ferramenta o xUnit e a biblioteca Selenium WebDriver, o programador, David, quer escrever seu primeiro teste de interface. Para isso, ele decidiu acessar a página da Alura e identificar um elemento para um código. Veja o código escrito por ele e marque a opção correta.
-   ````cs
    [Fact]
            public void AcessandoPaginaDaAlura()
            {
                //Arrange
                IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(
                    Assembly.GetExecutingAssembly().Location));
                //Act
                driver.Navigate().GoToUrl("https://www.alura.com.br/");
                //Assert
                Assert.Contains("Alura", driver.Title);
            }
    ````

## Capturando um elementos da página

Douglas, um estudante de tecnologia, está iniciando seus estudos da biblioteca Selenium WebDriver e está com dificuldade de identificar maneiras de capturar um determinado elemento de uma página web.

No momento, Douglas busca a maneira correta de capturar um elemento do tipo link de texto em uma página html. Qual alternativa abaixo atende Douglas corretamente?

- Com a utilização da combinação dos métodos driver.FindElement(By.LinkText("Login")).
- Esta é a forma correta de encontrar um elemento do tipo Link de texto em uma página com o WebDriver.

Considere o código abaixo que utiliza o Selenium WebDriver para a escrita de um teste funcional usando a linguagem C#:

````cs
        [Fact]
        public void ExecutaLoginAdicionaUmCliente()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location));

            driver.Navigate().GoToUrl("https://localhost:44309/");            

            var linkLogin = driver.FindElement(By.LinkText("Login"));
            linkLogin.Click();

            var email = driver.FindElement(By.Id("Email"));
             **//código omitido**       
            var senha = driver.FindElement(By.Id("Senha"));
               **//código omitido**       
            var btnLogar = driver.FindElement(By.Id("btn-logar"));
            btnLogar.Click();

            //Clientes
            var clientesLink =  driver.FindElement(By.Id("clientes"));
            clientesLink.Click();

            //Adicionar clientes
            var adicionarCliente = driver.FindElement(By.LinkText("Adicionar Cliente"));
            adicionarCliente.Click();

            var identificador = driver.FindElement(By.Id("Identificador"));
            **//código omitido**      
            var cpf = driver.FindElement(By.Id("CPF"));
             **//código omitido**      
            var nome = driver.FindElement(By.Id("Nome"));
             **//código omitido**       
            var profissao = driver.FindElement(By.Id("Profissao"));
               **//código omitido**      

            //Act
            var btnCriar = driver.FindElement(By.Id("btn-criar"));
            btnCriar.Click();

            var linkHome = driver.FindElement(By.Id("home"));
            linkHome.Click();

            //Assert
            Assert.Contains("Boas-vindas!", driver.PageSource);
        } 
````
Em vários momentos, o código mostrado acima captura o elemento html hora por Id hora por linkText. Qual trecho de código deve ser substituído em “//código omitido” para a manipulação de campos de texto para que assim o teste execute com sucesso e permita o login “maria@email.com”?

- Devemos substituir o comentário “//código omitido” pela invocação do método elemento.SendKeys(“conteúdo”). A opção correta para trabalhar com campos de texto no Selenium WebDriver é a utilização do método ````.SendKeys````.`

## Para saber mais: Códigos de status HTTP

Quando estamos trabalhando com aplicações Web, é importante entender que toda a comunicação gira em torno de uma comunicação HTTP (HyperText Transfer Protocol), sendo o principal protocolo em uso por aplicações de internet que faz uso da arquitetura cliente-servidor. A estrutura de comunicação HTTP é uma sequência simples de requisição e resposta.

Neste diálogo temos aplicações clientes como um navegador, requisitando algum recurso ou informação do servidor web e, em cada solicitação feita, o protocolo responde com um código de status daquela comunicação.

Como há a possibilidade que durante a comunicação haja um grande números de status de respostas, existe uma divisão destes por classes de respostas. Temos a seguir algumas classes e exemplos:

- Status 1XX, são status de informação, por exemplo: 100,101.
- Status 2xx, são respostas às solicitações que obtiveram sucesso como: 200(OK), 201 (criado)
- Status 3xx, informa redirecionamento como 300(Múltipla escolha), 302(encontrado).
- Status 4xx, esses revelam status de erro do cliente onde temos de exemplos o 400(requisição inválida), 401(não autorizado), 404 (recurso não encontrado).

Portanto, toda conexão usando HTTP retornará algum status de sucesso ou falha referente à comunicação estabelecida. A lista de códigos é bem extensa, mas entendê-la e conseguir identificar a que situação se refere é de grande ajuda para o trabalho e desenvolvimento de aplicações web modernas.

- <a href="https://developer.mozilla.org/pt-BR/docs/Web/HTTP/Status">Códigos de status de respostas HTTP.</a>

## CssSelector  

Douglas, estagiário, está desenvolvendo um teste de interface usando C# e Selenium para uma aplicação cliente do escritório de desenvolvimento em que trabalha. A aplicação é um e-commerce de uma floricultura. Douglas precisa testar o formulário de contato, contudo após a análise do HTML do formulário, ele notou que os elementos não possuem ID ou Name, o que dificulta a identificação do elemento para o código C#. Das opções disponíveis para identificação de um elemento HTML usando o Selenium WebDriver, marque a opção que melhor atende nosso amigo Douglas:

Assinale a alternativa correta.

- Uma opção que pode atender Douglas é realizar uma busca pelo elemento Css usando o código como em driver.FindElement(By.CssSelector(" css do elemento")).

- Usando o WebDriver, temos à disposição o By.CssSelector, muito útil quando não conseguimos usar as opções por Id ou Name.

## Para saber mais: O que é Css?

O CSS ou simplesmente Cascading Style Sheets é uma linguagem de estilização usada para definir a apresentação de páginas HTML. No CSS vamos definir cores, tamanhos, posicionamento, entre outros. O Css é um padrão internacional também mantido pelo W3C.

O CSS é executado no lado cliente (client-side), ou seja, a interpretação do documento é feita pelo browser do usuário, não sendo necessário nenhum tipo de servidor web para visualização.

alt text: A imagem mostra arquivos com extensão .html e .css para estilização de um site.

O objetivo do Css é informar ao navegador como ele apresentará o HTML da página. A sua sintaxe básica é:

alt text: A imagem mostra a sintaxe básica de um css. seletor abre chaves propriedade dois pontos valor ponto e vírgula e fecha chaves.

No Css, o seletor "seleciona" o elemento HTML usando o atributo Class=“...” ou ID=“...”, mas também podemos identificar o nome da tag como ````<H1>````, ````<Title>````ou ````<p>````. A propriedade é o elemento que vamos estilizar, já o valor é o que atribuímos à propriedade. Como podemos ver no exemplo da imagem abaixo:

````css
h1{
    font-family: 'Franklin Gothic';
    font-size: 30px;
    color: aqua;
}
````

Para a estilização de uma página usando o css, podemos aplicar inline, interno e arquivo externo.

No css inline, aplicamos o estilo diretamente ao elemento HTML, como no exemplo abaixo estamos estilizando a tag h1:

````html
<!DOCTYPE html>
<head>
    <meta charset="UTF-8">
    <title>O que é Css?</title>
</head>
<body>
    <!-- css inline -->
    <h1 style="font-size: 30px;color: blue; margin: 0;">Mas o que é Css?</h1>
</body>
</html>
````

Na estilização usando o css interno, definimos uma tag style no head do documento html, como no exemplo abaixo:

````html
<!DOCTYPE html>
<head>
    <style>
        /* Css interno */
        h1{
            font-size: 30px;
            color: blue;
            margin: 0;
        }
    </style>
    <meta charset="UTF-8">
    <title>O que é Css?</title>
</head>
<body>
    <h1>Mas o que é Css?</h1>
</body>
</html>
````
Na utilização de um arquivo externo, podemos centralizar a manutenção do css de uma aplicação em um só local, o que facilita bastante. Observe o exemplo abaixo:

````css
h1{
    font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
    font-size: 30px;
    color: aqua;
}
````

````html

<!DOCTYPE html>
<head>
     <meta charset="UTF-8">
     <link rel="stylesheet" href="/css/estilo.css">
    <title>O que é Css?</title>
</head>
<body>
    <h1>Mas o que é Css?</h1>
</body>
</html>
````

Para maior aprofundamento do tema Css, acesse os links abaixo:
<a href="https://www.alura.com.br/artigos/html-css-e-js-definicoes">HTML, CSS e Javascript, quais as diferenças?</a>
<a heref="https://www.alura.com.br/artigos/o-que-e-reset-css">Reset CSS: O que é, Exemplos, Como Criar e Utilizar</a>


## Page Objects

Criar classe responsável por encapsular os elementos da interface

Abstrair ao maximo o código, para que seja possível fazer alteração em partes especificas alterando o menos codigo possível  

Manter o codigo mais fácil 


### Usando Page Objects

Nosso amigo, Douglas, agora dev júnior, ficou responsável por escrever os testes de interface usando Selenium WebDriver e c# para uma aplicação Web voltada para o ramo da saúde. Douglas já escreveu testes para validação de login, formulário de cadastro de prontuários e do gerenciador de relatórios em um total de 40 testes.

No intuito de utilizar boas práticas, ele está refatorando seus testes para aplicar Page Objects. Qual benefício Douglas pode obter na adoção deste padrão?

Assinale a alternativa correta:

- Douglas terá a separação do código do Selenium Webdriver do código de teste, logo, alterações de algum elemento de interface terão impacto reduzido nos testes já escritos e manutenções futuras serão mais facilitadas por serem realizadas em um único local, nas Page Objects criadas. Usar Page Objects permitirá que tenhamos um único arquivo que conhece e representa os elementos HTML da página, facilitando manutenções futuras. Além disso, a responsabilidade de conhecer o HTML da página fica encapsulado em uma classe.

## Para saber mais: Padrões de projeto

Na aula é mencionado o termo “padrões de projeto” quando falamos de Page Objects, mas o que é um padrão de projeto? Um padrão de projeto ou Design Patterns são soluções e estratégias de implementação que podemos aplicar no desenvolvimento de um software com objetivo de propor uma solução para um problema já conhecido e vivenciado por desenvolvedores mais experientes a fim de ajudar quem está iniciando.

Os Design Patterns são um catálogo de padrões, que teve inspiração na engenharia tradicional e foi proposto pelo desenvolvedor Christopher Alexander no fim da década de 1970. Para Alexander: “Um padrão descreve um problema recorrente em determinado contexto, e deve descrever uma solução para esse problema, de modo que essa solução possa ser utilizada sistematicamente em distintas situações”.

Baseando-se nos trabalhos de Alexander, em 1995, Eric Gamma, Richard Helm, Ralph Johnson e John Vlissides, que ficaram conhecidos como a “Gangue dos 4”, publicaram o livro “Design Patterns: Elements of Reusable Object-Oriented Software” que compila 23 padrões frutos da experiência dos autores - livro este que inclusive é referência na comunidade de tecnologia.

Com o passar do tempo, essa ideia de padrões de projeto foi amplamente difundida pela comunidade de tecnologia que catalogou e desenvolveu outros padrões como os Page Objects, por exemplo. Vale ressaltar que os padrões de projeto são soluções que podem ser aplicadas em diversas linguagens como Java, Python, Lua, Objective C, PHP, entre outras.

Para se aprofundar ainda mais neste tema, fica a recomendação abaixo:

- <a href="https://www.alura.com.br/artigos/design-patterns-introducao-padroes-projeto">Design patterns: Breve introdução aos padrões de projeto</a>
- <a href="https://www.alura.com.br/podcast/hipsterstech-design-patterns-hipsters-206-a345">Design Patterns - Hipsters#206</a>
- <a href="https://www.alura.com.br/curso-online-design-patterns-dotnet">Curso Design Patterns C# I: Boas práticas de programação</a>

## Boas práticas

## O que Aprendemos?

- Conhecemos o projeto que iremos trabalhar neste curso o Alura.ByteBank.WebApp;
- Aprendemos a configurar o projeto, seu banco de dados e a rodar a aplicação para o projeto de testes;
- Conhecemos um pouco sobre o projeto Selenium IDE e como ele pode ser útil para gravarmos ações de utilizações de um sistema Web;
- Aprendemos como gerar um script usando a ferramenta Selenium IDE e exportar o código gerado que poderá ser reaproveitado na escrita de futuros métodos de testes de interface.

- Criar um projeto do xUnit e configurar a biblioteca do Selenium WebDriver para criar um teste automatizado da interface da aplicação;
- Criar nosso primeiro teste usando o Selenium WebDriver;
- Recuperar um código gerado pelo Selenium IDE como um teste na nossa suite de testes.

- Identificar um elemento específico no html usando a biblioteca do Selenium WebDriver;
- Capturar o elemento html para um código C# para a escrita do código de testes;
- Manipular campos de texto dentro de uma aplicação usando Selenium WebDriver para testar a interação de um formulário;
- Validar urls restritas de uma aplicação com foco em validar questões como segurança da aplicação.

- Outras formas de capturar os elementos de uma página HTML para não ficarmos restritos ao Id ou Name;
- Criar uma lista de elementos que estão na página usando a biblioteca do Selenium WebDriver, o que pode deixar nosso código mais dinâmico;
- Escrever no console do gerenciador de testes usando recursos do próprio xUnit.

- O que são Page Objects e como esse padrão pode ser útil para manutenção do código de testes;
- Usar Page Objects para separar o código do Selenium WebDriver do código de teste, deixando mais limpo e orientado à objetos;
- Criar uma estratégia de código que permita a gerência do navegador, possibilitando a otimização deste recurso;
- Podemos adotar boas práticas que nos ajudem a otimizar o código de teste e aplicar padrão recomendado pelo próprio Selenium.