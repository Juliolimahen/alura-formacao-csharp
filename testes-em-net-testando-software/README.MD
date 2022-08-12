# Testes em .NET: testando software

## Criando um projeto com testes

Criar projeto de teste

- FrameWork Xnunit

- Solução -> novo projeto -> projeto de teste Xnunit


Exemplo de teste da classe veiculo 
````cs

    public class VeiculoTestes
    {
        [Fact]
        public void TestarVeiculoAcelerar()
        {
            var veiculo = new Veiculo();
            veiculo.Acelerar(10);
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFrear()
        {
            var veiculo = new Veiculo();
            veiculo.Frear(10);
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }
    }
````

### Métodos
````cs
Assert.Equal(arg1, arg2);
````
    - Verifica igualdade, resultado do teste tem que ser ao argumento passado

- É uma boa pratica que se adote uma padronização para a criação dos testes 

Padrão AAA

- Arrange 

Utilizado na preparação do ambiente, senário (Estânciar o que for necessário ), objetos, variaveis 

- Act 

É o método que necessáriamente que eu quero testar 

- Assert 

Validação dos resultados obtidos com os esperados

Exemplo
````cs
[Fact]
        public void TestarVeiculoAcelerar()
        {
            //Arrange
            var veiculo = new Veiculo();
            
            //Act
            veiculo.Acelerar(10);

            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }
````

### Exercício

No desenvolvimento de códigos de testes, sobretudo na programação orientada a objetos, testam-se unidades de códigos. Uma forma de escrever a codificação de um teste é a adoção de um passo a passo, composto por três etapas: Arrange, Act e Assert.

Escolha a alternativa correta sobre o padrão AAA.

- A escrita de um código de teste seguindo o padrão AAA, possibilita ver com clareza o que está sendo testado e validar o resultado esperado com o valor obtido. A adoção do padrão AAA define três passos bem claros para a escrita e manutenção futura do teste.

## Para saber mais: Criando um projeto de Testes pelo CLI

No desenvolvimento de uma aplicação com objetivo de desenvolver testes com base em algum framework, uma boa prática a ser adotada é a criação de um projeto dentro da solução com os nossos códigos de testes. Para a criação deste projeto usando o Visual Studio Community, temos a opção de uma interface gráfica no estilo Wizard.

<a></a>

Podemos também usar a linha de comando para a adição deste projeto de teste à nossa solução. Navegue no terminal até a pasta do projeto e usando a CLI (command line interface), digite o seguinte comando: ````dotnet new xunit -o ProjetoTeste.Tests.```` Como resultado teremos:

````bash
PM> dotnet new xunit -o Alura.Estacionamento.Tests
Preparando...
O modelo "xUnit Test Project" foi criado com êxito.

Processando ações pós-criação...
Executando 'dotnet restore' em Alura.Estacionamento.Tests\Alura.Estacionamento.Tests.csproj...
  Determinando os projetos a serem restaurados...
….Alura.Estacionamento\Alura.Estacionamento.Tests\Alura.Estacionamento.Tests.csproj restaurado (em 728 ms).
A restauração foi bem-sucedida.
````

Em seguida, será necessário adicionar o projeto com o comando: ````dotnet sln add ./ProjetoTeste.Tests/ProjetoTeste.Tests.csproj````

A saída será:

````bash
PM> dotnet sln add ./Alura.Estacionamento.Tests/Alura.Estacionamento.Tests.csproj
O projeto 'Alura.Estacionamento.Tests\Alura.Estacionamento.Tests.csproj' foi adicionado … solução.
````

E para que o projeto Reconheça o código que será alvo do teste, vamos adicionar uma referência com o comando: 
````dotnet add ./ProjetoTeste.Tests/ProjetoTeste.Tests.csproj reference````  
````./ProjetoAlvoTeste/ProjetoAlvoTeste.csproj.````

Quando executarmos o comando, teremos uma saída como em:

````bash
PM> dotnet sln add ./Alura.Estacionamento.Tests/Alura.Estacionamento.Tests.csproj
O projeto 'Alura.Estacionamento.Tests\Alura.Estacionamento.Tests.csproj' foi adicionado … solução.
PM> dotnet add ./Alura.Estacionamento.Tests/Alura.Estacionamento.Tests.csproj reference ./Alura.Estacionamento/Alura.Estacionamento.csproj 
A referência '..\Alura.Estacionamento\Alura.Estacionamento.csproj' foi adicionada ao projeto.
````
Saber utilizar a linha de comando é muito importante para a pessoa que desenvolve, por isso pratique também a criação de soluções e configurações de projetos usando a CLI.

## Faça como eu fiz: Teste unitários

Nesta aula começamos a aprender um pouco sobre testes unitários e boas práticas na organização do nosso código de teste, o que facilitará inclusive futuras manutenções.

Começamos gerando nosso projeto de testes com xUnit e criamos nossa classe de testes com alguns métodos. Agora é com você: crie um método de teste para a classe VeiculoTeste para validar tipo do objeto veiculo. Considere a propriedade TipoVeiculo com a seguinte codificação:

````cs
 public TipoVeiculo Tipo {
            get { return _tipo; } 
            set {
                if (value == null)
                {
                    _tipo = TipoVeiculo.Automovel; 
                }
                else { _tipo = value; }
            }
        }
````

No caso do teste da propriedade TipoVeiculo , de acordo com o código precisamos criar um método de testes no xUnit e usar [Fact] como atributo. Na escrita do método será necessário nos atentarmos aos passos do padrão AAA (Arrange,Act e Assert).

````cs
[Fact]
        public void TestaTipoVeiculo()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act            
            //Assert
            Assert.Equal(TipoVeiculo.Automovel,veiculo.Tipo);
        }
````

Veja que no código acima, estamos testando somente se a propriedade TipoVeiculo, está setando automaticamente o tipo Automovel, quando criamos um objeto e não informamos o tipo.


## Anotações xnunit

````
[Theory]
````

````cs
 [Theory]
        [InlineData("André Silva", "ASD-1498", "preto", "Gol")]
        [InlineData("José Silva", "ASD-1497", "prata", "Uno")]
        [InlineData("Anderson Silva", "ASD-1499", "braco", "Celta")]
        public void ValidaFaturamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }
````

Cada inline data é reconhecido como um novo teste
- Importante para se criar senarios diferentes para testes, afim de avitar testes com vícios
- Consigo testar, criar testes, com um volume maor de dados 

## Configuração

Definir nome do teste 
````cs
 //Possibilidade de definir um nome pro teste
        [Fact(DisplayName ="Teste n° 1")]
````

Ignorar teste não implementado 

````cs
 [Fact(Skip ="Teste ainda não implementado. Ignorar.")]
        public void ValidaNomeProprietario()
        {

        }
````
Definir agrupamento 
````cs
[Trait("Funcionalidade", "Acelerar")]
        public void TestarVeiculoAcelerar()
        {}

[Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrear()
        {}
````

## Anotações do xUnit

Na escrita de códigos de testes utilizando o framework de testes xUnit, é necessário identificar qual anotação ou conjunto de anotações queremos utilizar, sempre levando em consideração o objetivo do teste.

Sendo assim, marque as opções corretas.
- Um método de teste com [Fact], tem como objetivo testar um “fato” único, e como um dos recursos mais utilizados, consegue atender  todo um projeto de testes. o [Fact] tem como objetivo ser o atributo de um método para testar um fato único

- Outra alternativa de anotação que podemos usar no xUnit é o [Theory] que permite que passemos parâmetros para um método de teste em conjunto com a anotação [InLineData(“Parâmetros”)].

- Na utilização do xUnit deve-se realizar uma análise e identificar se o método de teste será decorado com [Fact] ou Theory porque não é possível usar as duas anotações para um método de testes. Para decorarmos um método de teste devemos analisar e escolher um [Fact] ou Theory de acordo com os objetivos de nossos testes

## Para saber mais: Utilizando ClassData ao InlineData

Quando estamos utilizando uma ````Theory````, temos a flexibilidade de utilizar o InlineData com o objetivo de passar um conjunto considerável de parâmetros para executar no método de testes. Porém, em alguns casos, o conjunto de InlineData pode crescer muito e poluir o código de testes. Ou ainda, temos a necessidade de passar um objeto como parâmetro, mas não temos como gerar uma instância e passar para uma anotação.

Para esses casos, temos como opção a anotação ClassData. Para utilizar este recurso é importante que a classe que terá os objetos passados como parâmetros implemente a interface IEnumerable<object[]> Como exemplo vamos usar a classe Veículo:

````cs
    public class Veiculo:IEnumerable<object[]>
````
e implementamos o método:

````cs
 public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Veiculo
                {
                    Proprietario = "André Silva",
                    Placa = "ASD-9999",
                    Cor="Verde",
                    Modelo="Fusca"
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
````

Com essas refatorações, podemos criar um método de teste que receba um objeto da classe veículo, veja o exemplo abaixo:

````cs
        [Theory]
        [ClassData(typeof(Veiculo))]
        public void TestaVeiculoClass(Veiculo modelo)
        {
            //Arrange
            var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);
            modelo.Acelerar(10);

            //Assert
            Assert.Equal(modelo.VelocidadeAtual, veiculo.VelocidadeAtual);
        }
````

Apesar de parecer um pouco mais complexo, é sempre preferível passar um objeto para um conjunto grande de parâmetros na assinatura de qualquer método.


## TDD - Desenvolvimento guiado por testes

A idéia do tdd é primeiro ser implementado o teste e depois as funcionadades e os ajustes para que os teste sejam aprovados  

3 Princípios básicos TDD

- Implementar um teste que falhe 
- Não escrever mais nada além do necessário para um teste falhar 
- Não escrever nada além do necessário para o teste passar


### Sobre TDD

Conforme aprendemos, o TDD é uma maneira de pensar o desenvolvimento de uma aplicação no qual cada nova funcionalidade criada é testada.Imagine um cenário, onde o processo de desenvolvimento de alguma nova função de um software, deve ser sempre testada antes de entrar em produção, são cenários assim que a adoção de metodologias como o TDD é amplamente empregada.

- O TDD colabora para o desenvolvimento de um código com mais qualidade, já que a pessoa desenvolvedora escreverá funcionalidades testadas. O TDD guia todo o desenvolvimento com base nos testes a serem desenvolvidos antes de qualquer funcionalidade, portanto as funcionalidades escritas já estarão testadas.


Com base nisso, assinale a alternativa correta.

- O TDD colabora para o desenvolvimento de um código com mais qualidade, já que a pessoa desenvolvedora escreverá funcionalidades testadas. O TDD guia todo o desenvolvimento com base nos testes a serem desenvolvidos antes de qualquer funcionalidade, portanto as funcionalidades escritas já estarão testadas.


### Boas Práticas com Testes

É interessante que os nomes dos metodos das classes de testes sejam autodescritivos 

A adoção de boas práticas de desenvolvimento é sempre recomendada, pois ajuda na manutenção de um código mais organizado e na evolução da solução em desenvolvimento. Se tratando de testes, isso não é diferente. Há uma recomendação relacionada ao nome dos testes.

Com base nesta informação, assinale as alternativas corretas.

- Apesar de não existir uma regra de como nomear um método de teste, podemos combinar com a equipe a melhor maneira para isso, levando em conta que o nome seja significativo, que seja possível identificar o que está sendo testado, parâmetros de entrada e o que espera-se da saída da execução do método, para saber se ele executa adequadamente. Quanto mais informações extrairmos na leitura do nome de um método de teste, mais fácil se tornará a manutenção do código e a produtividade ao trabalhar com ele.

- Como uma boa prática, é recomendado que ao se nomear um teste seja possível saber com clareza qual o comportamento esperado para determinado cenário. O nome do teste deve ser objetivo e determinar o que está em teste e o resultado esperado.

## Extra - Boa prática

Definir a instância como propriedade e inicializala no contrutor da classe, para evitar ficar instanciando a mesma clsse em todos os métodos

Conceito de Setup 

````cs
private Veiculo veiculo;

        public VeiculoTestes()
        {
            veiculo = new Veiculo();
        }`
````


## Testtando exceções 

````cs 
 public void TestarNomePropriedadeVeiculoComMenosDeTresCaracteres()
        {
            //Arrange
            string nomeProprietario = "Ab";

            //Assert
            Assert.Throws<System.FormatException>(
            //Act
            () => new Veiculo(nomeProprietario));
        }
````

Usar Assert.Throws

## Testando exceções

Imagine que um aplicativo precisa realizar o download de um arquivo de determinado diretório. Quem desenvolve precisa validar se o diretório existe, se ele ainda tem permissão de acesso, dentre outras verificações. Não conferir nada disso pode gerar algum comportamento inesperado durante a utilização do software, mas a maioria das linguagens de programação já trazem recursos que nos ajudam nestas validações: as exceções. No desenvolvimento baseado em testes é altamente recomendável que as exceções geradas pela aplicação também sejam testadas.

Sendo assim, assinale a alternativa correta sobre testes de exceções.

- No xUnit podemos testar exceções usando o método ````Assert.Throws<Exception>````, no qual passamos como parâmetro a função que deve gerar a exceção. No xUnit, para testar exceções usamos o ````Assert.Throws<Exception>````.

## Teste de regrassão
Ao implementar uma novo funcionalidade em uma das classes com testes implicará na falha dos outros teste e será necessário adequalos 
.....

## Testando métodos privados 

Verificar se esse método é ultilizado em um método público, que por consequência o privado será testado tbm 

## Faça como eu fiz: Testando métodos privados

No desenvolvimento da nossa solução para gerenciar um estacionamento criamos métodos novos nas classes de modelo, que surgiram da necessidade de implementar novos requisitos de acordo com a demanda do dono do produto. Durante este processo, é natural haver alguns métodos de classe com visibilidade privada.

Mas então surge a dúvida: como podemos testar esses métodos se eles não são visíveis no projeto de testes?

Vamos olhar o método GerarTicket da classe Patio. Ele foi definido como um método privado, ou seja, é usado internamente na classe.

````cs
       private string GerarTicket(Veiculo veiculo){
            string identificador = new Guid().ToString().Substring(0, 5);
            veiculo.IdTicket = identificador;
            string ticket = "### Ticket Estacionameno Alura ###" +
                           $">>> Identificador: {identificador}" +
                           $">>> Data/Hora de Entrada: {DateTime.Now}" +
                           $">>> Placa Veículo: {veiculo.Placa}";
            return ticket;
        }
````

Podemos ficar tentados a mudar a visibilidade dele para poder testá-lo, porém, isso não é recomendado, já que iria contra conceitos como encapsulamento e visibilidade.

Ao analisar o cenário, identificamos que o método RegistrarEntradaVeiculo, que está sendo testado indiretamente, faz uso do GerarTicket.

````cs
       public void RegistrarEntradaVeiculo(Veiculo veiculo)
        {
            veiculo.HoraEntrada = DateTime.Now;
            veiculo.Ticket = this.GerarTicket(veiculo);
            this.Veiculos.Add(veiculo);            
        }
````

Note que o RegistrarEntradaVeiculo é um método público, enxergado pelo projeto de teste. Portanto, a maneira de testar um método privado será utilizá-lo em algum método público.


## O que testar?

É importante, antes de escrevermos uma classe de teste ou um método de teste, analisarmos a real necessidade daquele teste. Ele vai agregar valor para mim, para o meu trabalho? Ou vou perder tempo desenvolvendo um código de teste, que vai agregar muito pouco ou nenhum valor para o que eu estou fazendo? São questionamentos importantes a serem feitos durante o desenvolvimento dos códigos do nosso teste.

Testar uma aplicação é importante para podermos confiar que o que desenvolvemos irá funcionar adequadamente e atendendo aos requisitos definidos pelo usuário. No entanto, quando guiamos o desenvolvimento de nossas soluções com base nos testes, nos deparamos com algumas questões de grande relevância.

Sobre as questões que lidamos ao realizar testes, marque as alternativas corretas.

- O importante é priorizar os requisitos de alto valor para o usuário e garantir que eles estejam devidamente testados. Testar tudo que é possível em um software é tentador, mas o importante e guiar o desenvolvimento e os testes para funcionalidades de maior valor para nosso cliente.
- Durante a criação dos testes, é importante analisar quais funcionalidades precisam realmente ser testadas para não desperdiçar esforço e tempo. Nem sempre precisaremos testar todas as funcionalidades desenvolvidas em uma aplicação.

## O que aprendemos?

- Podemos usar o Visual Studio Community para configurar um projeto de teste;
- Podemos utilizar a CLI, a linha de comando, para criar e configurar nossa solução e projeto de teste;
- Testes de unidade são testes que tem por objetivo testar as menores unidades de um código, as classes;
- Usamos o padrão de escrita AAA (Arrange, Act, Assert) para permitir que a escrita do código de teste siga uma sequência lógica, que será útil para o entendimento e futuras manutenções;
- Escrevemos códigos de testes com xUnit porque este é um dos mais utilizados frameworks de testes em .NET do mercado.

- Usamos a anotação ````[Fact]```` para testar “fatos” únicos, ou seja, um único método, e quando não temos a necessidade de parâmetros;
- Existe vantagem da utilização da anotação ````[Theory]````, passar um conjunto grande de valores para um método de teste que serão entendidos como uma novo teste;
- Podemos gerenciar os testes em desenvolvimento através da janela do gerenciador de testes.

- O conceito do TDD e como aplicá-lo, guiando o desenvolvimento da nossa solução de estacionamento com base no teste;
- De acordo com o desenvolvimento orientado por testes, primeiro escrevemos o teste e depois a implementação da funcionalidade;
- A prática do TDD pode ajudar no aprimoramento dos comportamentos de uma classe.

- Boas práticas na nomeação de métodos de testes podem facilitar o entendimento do que estamos testando;
- Para seguir as boas práticas de nomenclatura, podemos precisar refatorar os nomes de nossos métodos de testes;
- Os conceitos de Setup e Cleanup na escrita de métodos de testes permitem otimizar a escrita de nossos códigos, reaproveitando-os;
- Usamos o ITestOutputHelper para escrever no console do gerenciador de testes.

- Criamos um método de teste para testar exceções mapeadas no desenvolvimento da aplicação;
- Conseguimos passar um método a ser testado para o Assert.Throws, que é o método do xUnit para testarmos as exceções;
- Nos testes de regressão adicionamos novas funcionalidades à aplicação “quebrando” testes que já funcionavam;
- Para a evolução da aplicação não regredir,conforme implementamos novas funções, precisamos sempre fazer testes.

- Podemos testar um método privado por meio da chamada de um método público que o utiliza. Assim não contrariamos os conceitos de encapsulamento e visibilidade;
- Devemos analisar a necessidade da criação de códigos de testes para cada funcionalidade, assim não fazemos testes desnecessários, apenas os fundamentais.