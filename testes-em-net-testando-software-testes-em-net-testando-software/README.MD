# Testes em .NET: testando software Testes em .NET: testando software

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

### O que aprendemos?

- Podemos usar o Visual Studio Community para configurar um projeto de teste;
- Podemos utilizar a CLI, a linha de comando, para criar e configurar nossa solução e projeto de teste;
- Testes de unidade são testes que tem por objetivo testar as menores unidades de um código, as classes;
- Usamos o padrão de escrita AAA (Arrange, Act, Assert) para permitir que a escrita do código de teste siga uma sequência lógica, que será útil para o entendimento e futuras manutenções;
- Escrevemos códigos de testes com xUnit porque este é um dos mais utilizados frameworks de testes em .NET do mercado.