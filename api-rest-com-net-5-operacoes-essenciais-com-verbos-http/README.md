# API Rest com .NET 5: operações essenciais com verbos HTTP

Rest é um padrão para APIs

API RESTful
rest ful é quem  implementa o esse padrão 

## API 
- Visa disponibilizar informações para outras aplicações.
- Para consumir seus recursos, é necessário que siga as regras estabilecidas.
- Abstrai detalhes de implementação.
Controla o que pode/deve ser acessado.

Sobre APIs

APIs possuem finalidades específicas e diversas utilizações. Quais das alternativas abaixo mostram essas características?

- Abstraem detalhes de implementação para quem for consumir a API. Os consumidores não precisam saber detalhes de implementação.

- Controlam o que pode/deve ser acessado. Os consumidores não conseguirão acessar caminhos que não estão expostos.



## Notations
````cs
//Define que a classe é um controlador 
[ApiController]
//Define que o nome da rota será o nome do controlador
[Route("[conttroller]")]


````

## O papel do controlador

Dentre as afirmações abaixo, qual delas melhor retrata o papel do controlador dentro do escopo de uma API?

- Controladores servem para lidar com as requisições recebidas e devolver uma resposta. Controladores são a porta de entrada da nossa API.

## Verbos Http

### Post

httpPost
````cs
[HttpPost]
````
- Resposável por criar algum recurso


## Api simples, para aprendizado

Controller

````cs
[ApiController]
[Route("[controller]")]
public class FilmeController:ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();

    [HttpPost]
    //[FromBody], é necessário para informar que o cateúdo vira através corpo da requisição
    public void AdicionarFilme([FromBody] Filme filme){
        filmes.Add(filme);
        return CreateAction(nameof(RecuperarFilmeID) new {Id = filme.Id}, filme);
    }
    
    [HttpGet]
    //IEnumarable, evitar de quebrar aplicação caso o parâmentro não seja mais filme
    public IActionResult RecuperarFilmes(){
        return Ok(filmes);
    } 

    [HttpGet("{id}")]
    public IActionResult RecuperarFilmeID(int id){
        //Sintaxe C#, forma limpa 

        Filme filme = filmes.FirstOrDefault(filme=>filme.Id==id);
        if(filme!=null){
            return Ok(filme);
        }
        return NotFound();
        //Maneira convencional
        /*foreach(Filme filme in filmes ){
            if(filme.Id ==id){
                return filme;
            } 
        }*/
    }
}
````

Model
````cs
public class Filme{
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Duracao { get; set; }
        public string Diretor { get; set; }
        public string Genero { get; set; }
}
````



## Enviando requisições para a API

Quando enviamos requisições para a API a fim de criarmos um novo recurso, é padrão explicitarmos um verbo HTTP para tal ação. Qual?

- POST. Sempre devemos seguir as convenções e boas práticas.


## validações 
````cs
 public class Filme{
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de título é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo de duração é obrigatório")]
        [Range(1, 600, ErrorMessage = "A duração deve ter no mínimo 1 minuto e no máximo 600.")]
        public int Duracao { get; set; }
        [StringLength(100, ErrorMessage = "O nome do diretor não pode exceder 100 caracteres")]
        public string Diretor { get; set; }
        public string Genero { get; set; }
    }
````

Não é recomendável criar valições com if e else no controlador, pois não é retornado uma mensagem no corpo da requisição(resposta) isso dificulta quem for consumir a api a identificar o por que aconteceu esse erro 


## Praticando o uso de annotations

O seguinte código foi escrito:

````cs 
public class Filme
    {
        [Required]
        public string Titulo { get; set; }
        [Required]
        [Range(1, 120)]
        public int Duracao { get; set; }
        [StringLength(30)]
        public string Diretor { get; set; }
        public string Genero { get; set; }
    }
````

Qual das alternativas abaixo apresenta uma entrada válida para as anotações utilizadas acima?
- ````cs
    Titulo = "Alura Filmes - O retorno"
    Duracao = 90
    Diretor = "Luis"
  ````
- Todos os parâmetros respeitam as anotações utilizadas

## Extra

IENumerable
evitar de quebrar aplicação caso o parâmentro não seja mais filme

## HttpGet

retornar algum elemento

## Validando o retorno

Segundo o REST e as boas práticas de criação de uma API, qual dos trechos de código abaixo melhor representa o retorno de um recurso do sistema?
````cs
[HttpGet]
public IEnumerable<Filme> RecuperaFilmes()
{
    //lógica de retorno
}
````

## Extra 
O ideal é padronizar o retorno para que quem consumir consiga entender de forma clara o que está acontecendo 

## Recebendo parâmetros na requisição

Como podemos enviar parâmetros através da requisição utilizando o verbo GET?
- Através da anotação
````cs
[HttpGet("{param}")]
````
- Podemos utilizar a própria anotação para isso.

## Definindo o retorno das rotas


Qual deve ser o retorno?

João enviou uma requisição para a API procurando por um recurso específico, porém, o recurso procurado não foi encontrado. Qual dos códigos abaixo melhor retrata o status de "não encontrado"?

- 404. representa o famoso Not Found.

Seguindo as boas práticas

Quando criamos um recurso novo no sistema através do verbo POST, qual é a convenção do que deve ser retornado caso a requisição tenha sido efetuada com sucesso?

- 201 (Created) e a localização de onde o recurso pode ser acessado no nosso sistema. Além de informarmos que o recurso foi criado, é importante informarmos onde podemos localizá-lo.


## Para saber mais: Instalando pacotes Nuget no Linux

Como dito em vídeo, a proposta desta atividade será ilustrar como instalar pacotes do NUGET utilizando o Linux como ambiente de desenvolvimento.

1- Será necessário acessar o diretório de seu arquivo .csproj através do comando cd. Por exemplo, ````cd```` ````caminho/do/projeto/.````

2- Execute os comandos para instalar os pacotes necessários:

````bash
dotnet add package Microsoft.EntityFrameworkCore --version 5.0.5
````

````bash

dotnet add package Microsoft.EntityFrameworkCore.Tools --version 5.0.5
````

````bash
dotnet add package MySql.Data.EntityFrameworkCore --version 5.0.3
````

Papel do DBContext

Qual das alternativas abaixo melhor representa o papel do DbContext?

- Abstrair a lógica de acesso ao banco de dados. Dessa maneira, nosso esforço de acessar o banco de dados é reduzido.

## A importância das migrations

Quais são as principais vantagens da utilização de migrations neste nosso primeiro cenário de utilização?

- A possibilidade de conferir se o que vamos criar no banco está conforme esperamos.
- Pois ao gerarmos a migration, um código C# é gerado representando as operações que serão executadas no banco.

- Gerar o banco e tabelas de maneira programática.
- Com isso, não precisamos nos preocupar em detalhes de utilização do banco em questão.



## O que aprendemos

- Como enviar requisições para a API.
- Como preparar a API para receber requisições.
- A finalidade do verbo POST.
- Como criar um recurso no sistema.
- Como adicionar validações nos parâmetros enviados.

- As vantagens da utilização de uma API.
- Por quê e quando utilizar/desenvolver uma API.
- Como preparar o ambiente no Windows e Linux.

- Como recuperar informações da API.
- A finalidade do verbo GET.
- Como enviar parâmetros através da URL de requisição.
- Como filtrar recursos para retornar para o usuário.
- Como devemos retornar as informações para o usuário com base no tipo de requisição.
