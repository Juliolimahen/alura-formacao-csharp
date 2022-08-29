## .Net e MongoDB parte 1: integre aplicações .NET 

## Por que usar mongoDb (NoSql)

Em que ocasiões o MongoDB é mais vantajoso em relação aos bancos de dados relacionais? 

- Quanto temos uma modelagem dinâmica que irá exigir uma mudança na estrutura do banco de dados. O MongoDB permite que possamos modificar a estrutura do dado sem que haja necessidade de reestruturar o banco, pois ele não se organiza em tabelas com campos previamente estruturados. Ele armazena em coleções onde, em cada linha da coleção, temos um texto no formato JSON, que informa a estrutura e conteúdo. Isso permite que na linha seguinte o dado possa ter outra estrutura.

## Desvantagem da utilização do MongoDB

Em que ocasiões o MongoDB não é mais vantajoso em relação aos bancos de dados relacionais?

- Quando temos que ter integridade referencial entre as entidades do banco de dados. Não há como, pelo menos até o momento da criação deste curso, criar integridade referencial no MongoDB. Isso não tem sentido em bancos de dados orientados a documentos, mas, em contrapartida, se você deseja manter a integridade, ela tem que ser garantida pela aplicação que está acessando o banco MongoDB.

## Qual banco de dados utilizar?

Se você fosse construir um tipo de rede social que banco de dados seria mais vantajoso?

- Banco de dados NoSQL. A vantagem do uso do banco de dados NoSQL é sua flexibilização quanto a estrutura dos dados. Como um sistema que gerencia uma rede social é extremamente dinâmico, ter um banco de dados NoSQL ajuda na sua manutenção.

## Referências para uso das conexões do .NET com o MongoDB

Quais as referências que devem estar presentes para usarmos todas as conexões do .NET com o MongoDB?

- MongoDB.Bson, MongoDB.Drive e MongoDB.Drive.Core . Se não usarmos referência estas três, veremos que alguns procedimentos e funções obterão erro de compilação na execução do programa. Quando adicionamos o MongoDB.Driver através do Nuget, são essas as referências que são adicionadas no projeto.

## Programações síncrona e assíncrona

Qual das afirmações abaixo é verdadeira?

- Programação assíncrona efetua somente os processos em paralelo. A própria palavra assíncrona significa independente, com isso, um processo é executado sem tomar conhecimento do outro que o chamou.

## Execução de processos da biblioteca MongoDB.Drive

Qual das afirmações abaixo é verdadeira?

- A biblioteca MongoDB.Drive pode executar processos síncronos e assíncronos. Se observar o código do seu programa em .NET, veja que diversas funções e procedimentos possuem a versão síncrona ou assíncrona. A versão assíncrona sempre terá, no final da declaração do nome da função ou procedimento, o sufixo ````async````.


## Comando para inclusão de um objeto JSON

Qual é o comando correto para incluir o seguinte objeto JSON, usando a biblioteca do MongoDB para .NET?

````json
{
    "Cidade" : "Rio de Janeiro"
} 
````

- ````cs
    var doc = new BsonDocument
    {
        { "Cidade", "Rio de Janeiro" }
    };
    ````

- Para representar um documento, um objeto JSON, instanciamos um BsonDocument, reproduzindo dentro do parâmetro o objeto no formato JSON, separando a chave e o valor por vírgula

## Qual o tipo de variável?

Qual o tipo de variável deve ser usado quando incluímos um array dentro de um JSON construído pela biblioteca do MongoDB .NET?

- O tipo BsonArray é o que deve ser usado para representar um array dentro de um objeto JSON.

## String de conexão

Como é a string de conexão para acesso ao MongoDB (string mais simples, para acesso a um único servidor)?

````cs 
"mongodb://localhost:27017"
````

A string de conexão possui o prefixo mongodb, e no nosso caso, é seguida do host (localhost) mais a porta (27017).

## Tipos de variáveis para trabalhar com o MongoDB

Temos três tipos de variáveis, uma para ser usada para acesso ao servidor MongoDB, uma para acesso a uma base de dados do MongoDB e outra para acesso a uma coleção do MongoDB. Esses tipos de variáveis, respectivamente, são representados por:

IMongoClient é o tipo de variável usado para acesso ao servidor MongoDB, IMongoDatabase é o tipo de variável usado para acesso a uma base de dados do MongoDB e IMongoCollection é o tipo de variável usado para acesso a uma coleção do MongoDB.

## O que aprendemos?

- Vantagens e desvantagens do MongoDB
- Quando utilizar o MongoDB
- Como instalar e configurar o MongoDB
- Como se conectar ao MongoDB
- Como instalar o driver de conexão do MongoDB no Visual Studio