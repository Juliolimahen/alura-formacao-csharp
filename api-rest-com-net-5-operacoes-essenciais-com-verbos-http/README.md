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

- As vantagens da utilização de uma API.
- Por quê e quando utilizar/desenvolver uma API.
- Como preparar o ambiente no Windows e Linux.

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
        Console.WriteLime(filme.Titulo);
    }
    
    [HttpGet]
    //IEnumarable, evitar de quebrar aplicação caso o parâmentro não seja mais filme
    public IEnumarable<Filme> RecuperarFilmes(){
        return filmes;
    } 

    [HttpGet("{id}")]
    public Filme RecuperarFilmeID(int id){
        //Sintaxe C#, forma limpa 
        return filmes.FirstOrDefault(filme=>filme.Id==id);
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

- Como enviar requisições para a API.
- Como preparar a API para receber requisições.
- A finalidade do verbo POST.
- Como criar um recurso no sistema.
- Como adicionar validações nos parâmetros enviados.