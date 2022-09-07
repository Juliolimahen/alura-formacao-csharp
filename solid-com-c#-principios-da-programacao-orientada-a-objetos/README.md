SOLID com C#: princípios da programação orientada a objetos

## Referências utilizadas (em inglês)

## Dívida Técnica
Nessa <a href="https://en.wikipedia.org/wiki/Technical_debt">página da Wikipedia</a> você vai encontrar mais informações sobre esse termo, suas principais causas e consequências.

<a href="https://www.youtube.com/watch?v=pqeJFYwnkjE">Nesse vídeo</a> você ouve o próprio Ward Cunningham falando sobre como criou a metáfora da dívida técnica.

## Code Smells
Vários autores escreveram sobre os famosos fedores de código. Martin Fowler explica a idéia <a herf="https://www.martinfowler.com/bliki/CodeSmell.html">nesse artigo.</a>

Mesmo código repetido sendo um dos principais sinais de problemas em seu projeto, alguns autores criaram catálogos para ajudar os iniciantes e interessados a melhor identificar esses cheiros:

- https://refactoring.guru/refactoring/smells
- https://blog.codinghorror.com/code-smells/
- https://blog.jetbrains.com/dotnet/2018/06/18/sharpen-sense-code-smell/

## Manifesto Ágil
A iniciativa Ágil surgiu dentro do contexto de projetos de software. Seus valores e princípios foram materializados em um documento chamado <a>Manifesto Ágil.</a>

Vários autores citados nesse curso (inclusive o autor dos princípios S.O.L.I.D.) são signatários do manifesto. Suas idéias e experiências estão refletidas nos princípios e padrões que discutiremos a partir da próxima aula.

## DRY - Dont Repeat Yourself
- Métodos devem ter uma única responsabilidade
- Classes também devem ter uma única responsabilidade
 - Responsabilidade de método é diferente de resposabilidade de classes 
- Classes são coesas qunado elas possuem somente uma razão para existir

## Single Source of Truth

- Buscar informação em um unico lugar 
- única fonte de informação 

## SINGLE RESPONSIBILITY PRINCIPLE

## SRP 

- principio da responsabilidade única 

Robert C. Martin 


## Agentes de mudança

Robert Martin, em seu <a href="https://blog.cleancoder.com/uncle-bob/2014/05/08/SingleReponsibilityPrinciple.html">artigo sobre o SRP</a> (em inglês), escreveu (tradução e destaques meus):


Esse princípio é sobre pessoas.

Ao escrever um módulo de software você precisa garantir que quando as mudanças forem solicitadas, elas só originem de uma pessoa ou grupo de pessoas representando uma função de negócio específica.

Baseado nesse texto (e na aula!) faça o exercício abaixo.

Apesar de não haver repetição o código da classe a seguir tem baixa coesão. Escolha as alternativas que relacionam agentes que podem originar solicitações de mudança no código dessa classe.

`````cs

public abstract class Empregado
{
  public decimal Salario { get; set; }
  public abstract void GravarNoBD();
  public TimeSpan HorasTrabalhadasNoMes { get; set; }
}
`````

- Área responsável pela decisão sobre a remuneração dos funcionários. Sempre que houver um pedido de alteração no cálculo salarial do empregado a propriedade Salario pode precisar ser revista.

- Área responsável por decisões sobre o banco de dados utilizado pelo sistema. O método Gravar() responde à mudanças solicitadas pelo setor de tecnologia.

- Área responsável pela emissão da folha salarial. Suponha que houve um pedido para que a folha salarial seja emitida quinzenalmente. O que fazer com a propriedade HorasTrabalhadasNoMes? Certamente ela precisará ser revista.


## Agentes de mudança em controladores

A classe a seguir representa um controlador MVC numa típica aplicação AspNet Core. Esse controlador atende 3 rotas, uma para listar os empregados e outras duas para realizar a inclusão de um novo funcionário.

````cs
public class EmpregadosController: Controller
{

  public IActionResult Index()
  {
    return View();
  }

  [HttpGet]
  public IActionResult Novo()
  {
    return View();
  }

  [HttpPost]
  public IActionResult Novo(Empregado model)
  {
    if (ModelState.IsValid)
    {
      var ctx = new AppDbContext();
      ctx.Empregados.Add(model);
      ctx.SaveChanges();
      return RedirectToAction("Index");
    }
    return View(model);
  }
}

````

Baseado no que aprendemos podemos concluir que a classe possui duas responsabilidades e portanto baixa coesão. Quais seriam os dois agentes de mudança que causariam impacto nesse controlador?

- responsável pela definição das rotas que a aplicação atende
- responsável pela estratégia de persistência da aplicação

Se quem definiu as rotas Empregados\Index e Empregados\Novo decidir mudar então esse controlador será afetado.
Além disso causará impacto no trecho do EF Core a pessoa que resolver mudar a maneira que um empregado é incluído no banco



# Referências utilizadas (em inglês)

## Princípio DRY
Dont Repeat Yourself foi cunhado por Andrew Hunt e Dave Thomas e escrito em seu livro Pragmatic Programmer. Aqui está seu enunciado (tradução minha):

Todo pedaço de conhecimento em um sistema deve possuir uma representação única, inequívoca e confiável.

Repare que não está escrito código e sim CONHECIMENTO! Maiores detalhes nesse <a href="https://wiki.c2.com/?DontRepeatYourself">wiki.

## SRP
Aqui está o <a href="https://blog.cleancoder.com/uncle-bob/2014/05/08/SingleReponsibilityPrinciple.html">artigo</a> que enuncia e descreve a história por trás do Princípio da Responsabilidade Única de Robert Martin, tio Bob para os íntimos.


## Dependências de EmpregadoManager

Analise os relacionamentos da classe EmpregadoManager declarada abaixo e marque apenas as alternativas que representam suas dependências.

````cs
public class EmpregadoManager
{
  EmpregadoDao _dao;

  public bool Save(IEnumerable<Empregado> colection)
  {
    // código omitido
  }

  public int TotalDeHorasTrabalhadas(Empregado obj, TimeSpan periodo)
  {
    // código omitido
  }
}
````

## Dependências de EmpregadoManager

Analise os relacionamentos da classe EmpregadoManager declarada abaixo e marque apenas as alternativas que representam suas dependências.

````cs
public class EmpregadoManager
{
  EmpregadoDao _dao;

  public bool Save(IEnumerable<Empregado> colection)
  {
    // código omitido
  }

  public int TotalDeHorasTrabalhadas(Empregado obj, TimeSpan periodo)
  {
    // código omitido
  }
}
````

- Empregado. Temos duas referências: uma no parâmetro genérico do método Save() e outra no primeiro parâmetro do método TotalDeHorasTrabalhadas()

- int. O método TotalDeHorasTrabalhadas() retorna um valor inteiro.

- EmpregadoDao

- bool. O método Save() retorna um valor booleano.

- IEnumerable. O método Save() recebe como entrada um enumerável de empregados.

- TimeSpan. Esse é o segundo parâmetro do método que calcula as horas trabalhadas do empregado.

## EmpregadoManager II

Agora que já listou as dependências da classe EmpregadoManager no exercício anterior marque apenas as alternativas que representam dependências com classes instáveis.

Só como referência repetimos (olha aí eu furando o DRY!) a declaração da classe abaixo.

````cs
public class EmpregadoManager
{
  EmpregadoDao _dao;

  public bool Save(IEnumerable<Empregado> colection)
  {
    // código omitido
  }

  public int TotalDeHorasTrabalhadas(Empregado obj, TimeSpan periodo)
  {
    // código omitido
  }
}
````

- Empregado. Apesar de ser um conceito importante no domínio da aplicação e por isso estar mais consolidada, esse tipo pode sofrer muitas alterações durante a evolução do projeto.

- EmpregadoDao. Essa classe é a mais instável de todas as que estão listadas aqui. Sabe porquê? Spoiller: veja o próximo vídeo.

## Acoplamentos

Acoplamento diz respeito à dependência entre dois tipos. Num sistema orientado a objetos os acoplamentos são inevitáveis. O que devemos fazer é cuidar de sua qualidade. Acoplamentos bons são aqueles para tipos estáveis (que não vão mudar ou tem alta probabilidade de não mudar). Candidatos a tipos estáveis são aqueles que fazem parte da plataforma .NET e de APIs muito usadas. Acoplamentos ruins são aqueles para tipos instáveis. Exemplos dessa categoria são os tipos criados especificamente para nossa aplicação e principalmente implementações para mecanismos específicos (no nosso exemplo o LeilaoDaoComEfCore).

## O que aprendemos?

- Nosso projeto de software pode estagnar e até morrer caso não nos preocupemos com a qualidade de seu código
- Código de má qualidade possui alta dívida técnica que com o tempo se torna mais custosa de quitar
- Identificamos problemas em nosso projeto através dos code smells
- Um dos principais code smells é o código repetido
- Para quitar a dívida técnica usaremos a experiência de outros desenvolvedores através de princípios e padrões
- Alguns princípios foram agrupados na sigla S.O.L.I.D.

- código repetido é uma forma específica de conhecimento repetido (DRY)
- repetição de código é ruim porque impacta nos custos de manutenção e aumenta sua dívida técnica
- repetição de código pode indicar que métodos e classes possuem muitas responsabilidades
- métodos e classes devem ter 1 única responsabilidade! Só assim serão coesos
- a responsabilidade de um método é executar uma única função
- a responsabilidade de uma classe é responder a mudanças originadas por uma única pessoa, função ou área de negócio (agente de mudança)
- essas idéias foram sintetizadas no Princípio da Responsabilidade Única (SRP) cunhado por Robert Martin



Perguntas:

Por que evitar código duplicado?
-
O que devo fazer quando encontro código repetido em meu projeto?
- 
Qual a diferença entre responsabilidade de método e responsabilidade de classes?
- 
Qual o propósito do padrão DAO?
- 
Qual o princípio S.O.L.I.D. relacionado à coesão? 
- 