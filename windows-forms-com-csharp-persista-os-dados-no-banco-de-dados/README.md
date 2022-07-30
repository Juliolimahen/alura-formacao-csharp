# CursoWindowsForms



## Chegou a hora de você pôr em prática o que foi visto na aula. Para isso, execute os passos listados abaixo.

1) Abra instalador o Visual Studio Installer, que está na sua máquina.

2) Se, por acaso, o seu instalador apresentar um botão para fazer a atualização do Visual Studio 2019, faça-a. Você somente pode acrescentar novas funcionalidades com esse procedimento.

3) No Visual Studio Community 2019, clique em Modificar, para acrescentar novos componentes.

4) Vá na aba Componentes individuais.

5) Procure por Nuvem, banco de dados e servidor.

6) Marque a opção SQL Server Express 2016 LocalDB.

7) Clique em Modificar, para a instalação ser inicializada. Você deve ter o Visual Studio fechado.

8) Aguarde alguns instantes até ela ser finalizada. Depois feche o Visual Studio Installer.

9) Abra o Visual Studio e verifique se está tudo funcionando corretamente.

10) Abra o projeto no Visual Studio.

11) No projeto CursoWindowsFormsBiblioteca, dentro da pasta Database, adicione um novo item.

12) Em Itens do Visual C# --> Dados, selecione Banco de Dados baseado em Serviço.

13) O nome do banco será Fichario.mdf.

14) Se você verificar uma mensagem dizendo que não há pacotes para suporte do SQL Server, clique em OK. Depois clique em Instalar.

15) Ao finalizar, volte ao Visual Studio. Talvez você tenha perdido o banco criado. Caso isso tenha acontecido, crie a base novamente.

16) Veja, no canto esquerdo do Visual Studio, uma pasta vertical chamada Gerenciador de Servidores. Clique nela e expanda a pasta Conexões de Dados. Você verá o banco de dados criado.

17) Expanda o Fichario.mdf, clique com o botão direito do mouse sobre a pasta Tabelas e selecione Adicionar Nova Tabela.

18) Na área T-SQL, mude o nome da tabela para Cliente

19) Na área acima, no grid, crie a tabela, digitando

Name	Data Type	Allow Nulls
Id	nvarchar(50)	Não
JSON	nvarchar(MAX)	Sim
20) Clique no botão Update


21) Pronto, você terá a tabela criada.

22) No menu superior do Visual Studio, clique em Exibir --> Outras Janelas --> Fontes de Dados. Assim, a aba de fonte de dados será disponibilizada.

23) Clique em Adicionar Nova Fonte de Dados.

24) Escolha Banco de Dados e clique em Avançar.

25) Selecione Conjunto de Dados e clique em Avançar.

26) Selecione a conexão Fichario.mdf e clique em Avançar.

27) Mantenha o nome padrão da conexão e clique em Avançar.

28) Será apresentado a estrutura do banco de dados. Selecione a tabela criada (Cliente) e depois clique em Concluir.

## Encapsular banco de dados 

<a href="connectionstringd.com"> Site para consulta das strings de conexão </a>

Estrutura básica para trabalhar com banco de dados  

- Conexão (Atráves de um String de conexão)
- Abrir a conexão  
- Executar um comando no banco de dados (Pode retornar valores ou mensagem)
- Capturar valores ou mensagens
- Fechar a conexão 

````cs 
/// <summary>
    /// Classe responsável pela conexão com o banco 
    /// </summary>
    public class LocalDbClass
    {
        /// <summary>
        /// Variável para string de conexão
        /// </summary>
        public string strConn;
        public SqlConnection connDb;

        /// <summary>
        /// Criando conexão, pelo construtor
        /// </summary>
        public LocalDbClass()
        {
            try
            {
                strConn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\ws-projetos\alura-formacao-csharp\windows-forms-com-csharp-persista-os-dados-no-banco-de-dados\CursoWindowsForms\CursoWindowsFormsBiblioteca\Databases\Fichario.mdf;Integrated Security=True";//definir string
                connDb = new SqlConnection(strConn);//Criar conexão
                connDb.Open();//Abrir conexão
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Método para retornar uma consulta, dados, e  tranformar em uma tabela em memória 
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public DataTable SQLQuery(string SQL)
        {
            DataTable dt = new DataTable();

            try
            {
                var myCommad = new SqlCommand(SQL, connDb);//passar a string sql e a conexão 
                myCommad.CommandTimeout = 0;//Define o tempo em que esperar pela resposta
                var myReader = myCommad.ExecuteReader();//Envia um pacote 
                dt.Load(myReader);//Transformar em tabela em memória 
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return dt;
        }

        /// <summary>
        /// Método para executar apenas um comando. por exemplo: 
        /// UPDATE, DELETE ou INSERT
        /// Um comando que não retorna dados, logo usamos o SQLCommand.
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string SqlCommand(string SQL)
        {
            try
            {
                var myCommad = new SqlCommand(SQL, connDb);//passar a string sql e a conexão 
                myCommad.CommandTimeout = 0;//Define o tempo em que esperar pela resposta
                var myReader = myCommad.ExecuteReader();//Envia um pacote 
                return "";
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Método para fechar a conexão 
        /// </summary>
        public void Close()
        {
            connDb.Close();
        }
    }
````

Podemos resumir os passos em: Conectamos através da string de conexão, depois abrimos a conexão, executamos um comando, seja para retornar um dado, seja para modificar os dados do banco, capturamos o retorno, fazemos alguma coisa com ele e finalmente fechamos a conexão.

## DataTable

É uma tabela em memória 
- Instanciação 
 - ````cs 
    DataTable dt = new DataTable();
    ````

Retornando uma consulta para uma tabela em memória 
````cs
public DataTable SQLQuery(string SQL)
        {
            DataTable dt = new DataTable();

            try
            {
                var myCommad = new SqlCommand(SQL, connDb);//passar a string sql e a conexão 
                myCommad.CommandTimeout = 0;//Define o tempo em que esperar pela resposta
                var myReader = myCommad.ExecuteReader();//Envia um pacote 
                dt.Load(myReader);//Transformar em tabela em memória 
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return dt;
        }
````

Executando apenas um comando sem retorno(Ou retornado uma mensagem de sucesso)
````cs
public string SqlCommand(string SQL)
        {
            try
            {
                var myCommad = new SqlCommand(SQL, connDb);//passar a string sql e a conexão 
                myCommad.CommandTimeout = 0;//Define o tempo em que esperar pela resposta
                var myReader = myCommad.ExecuteReader();//Envia um pacote 
                return "";
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
````
## Linguagem SQL - STRUCTURE QUERY LANGUAGE

Vantagens 
- Apredizado 
- Portabilidade
- Longevidade
- Comunicação 
- Liberdade de Escolha

Desvantagens
- Falta de criatividade 
- Falta de estruturação

Comandos
- DDL - DATA DEFINITION LANGUAGE
- DML - DATA MANIPULATION LANGUAGE
- DCL - DATA CONTROL LANGUAGE

### INSERT 

ex.

````sql
INSERT INTO TABELA (CODIGO, NOME, CPF, IDADE) VALUES ('ZZZZZ','MARIA','333333333333',40)
````

### Para saber mais: SQL Injection

O objetivo deste curso foi de mostrar como podemos fazer a interação do código C# com banco de dados.

Em uma parte das aulas usamos a técnica de concatenar as variáveis com os comandos SQL como mostrado abaixo:

````cs
string SQL;
    SQL = @"INSERT INTO TB_Cliente
            (Id
            ,Nome
            ,NomePai
            ,NomeMae
            ,NaoTemPai
            ,Cpf
            ,Genero
            ,Cep
            ,Logradouro
            ,Complemento
            ,Bairro
            ,Cidade
            ,Estado
            ,Telefone
            ,Profissao
            ,RendaFamiliar) 
            VALUES ";
    SQL += "('" + this.Id + "'";
    SQL += ",'" + this.Nome + "'";
    SQL += ",'" + this.NomePai + "'";
    SQL += ",'" + this.NomeMae + "'";
    SQL += "," + Convert.ToString(this.NaoTemPai) + ",";
    SQL += "'" + this.Cpf + "'";
    SQL += "," + Convert.ToString(this.Genero) + ",";
    SQL += "'" + this.Cep + "'";
    SQL += ",'" + this.Logradouro + "'";
    SQL += ",'" + this.Complemento + "'";
    SQL += " ,'" + this.Bairro + "'";
    SQL += ",'" + this.Cidade + "'";
    SQL += ",'" + this.Estado + "'";
    SQL += ",'" + this.Telefone + "'";
    SQL += ",'" + this.Profissao + "'";
    SQL += "," + Convert.ToString(this.RendaFamiliar) + ");"; 
````

A técnica de concatenar as variáveis sobre o código pode acarretar no que chamamos de SQL Injection.

SQL Injection é uma técnica de ataque baseada na manipulação do código SQL, que é a linguagem utilizada para troca de informações entre aplicativos e bancos de dados relacionais. Como a maioria dos fabricantes de software utiliza o padrão SQL-92 ANSI na escrita do código SQL, os problemas e as falhas de segurança aqui apresentadas se aplicam a todo ambiente que faz uso desse padrão para troca de informações.

Por isso, caso você use a concatenação de varáveis com comandos, deve tomar muito cuidado em:
- Não usar esta técnica caos a consulta envolva segurança do sistema;
- Mesmo que não envolva segurança seja mais criterioso em criticar a variável utilizada.

Os códigos apresentados neste curso foram apenas acadêmicos. Não há motivo para se preocupar em SQL Injection porque, por exemplo, nem Login implementamos.

Mas, irei mostrar a seguir, alguns exemplos em que a técnica de concatenar variáveis com comandos SQL possam trazer problemas.

Por exemplo: Vamos supor que você tenha feito uma tela de Login. O conteúdo do Login foi salvo em duas variáveis: username e password.

No seu código você escreve a seguinte consulta para validar o usuário e senha:



Os códigos apresentados neste curso foram apenas acadêmicos. Não há motivo para se preocupar em SQL Injection porque, por exemplo, nem Login implementamos.

Mas, irei mostrar a seguir, alguns exemplos em que a técnica de concatenar variáveis com comandos SQL possam trazer problemas.

Por exemplo: Vamos supor que você tenha feito uma tela de Login. O conteúdo do Login foi salvo em duas variáveis: username e password.

No seu código você escreve a seguinte consulta para validar o usuário e senha:

````cs 
var sql = "select Count(*) from users where username = '" + username +
"' and password = '" + password + "'";
````

var sql = "select Count(*) from users where username = '" + username +
"' and password = '" + password + "'";COPIAR CÓDIGO
Se o valor de Count(*) for maior que 1 significa que o Login será aceito.

Vamos supor que você é um hacker e queira burlar a segurança do sistema. Você então entra com os seguintes valores, sabendo de antemão que o usuário admin é um Login válido mas que você não sabe a senha dele:

Username: admin' --

Password: xxxxx

Quando seu programa for concatenar as variáveis aos comandos SQL teremos:

var sql = "select Count(*) from users where username = 'admin' -- and password = 'xxxxx'";COPIAR CÓDIGO
Note que, ao executar o comando acima, o que vier após o -- será um comentário. Logo, o que o SQL fará é o comando:

var sql = "select Count(*) from users where username = 'admin'COPIAR CÓDIGO
Esta consulta retornará um valor já que o usuário Admin existe. O resultado será um valore de Count maior que 0 e, isso, significará validação na entrada do sistema.

Isso é um SQL Injection.

Veja outro exemplo. Vamos supor que a sua String de Conexão do banco você use um usuário administrador do banco de dados. Você esqueceu de criar um usuário com privilégios limitados.

Aqui, no nosso curso, se você se recorda, usamos o usuário root para fazer a conexão. E este usuário é um administrador.

Logo o seu Hacker faz o seguinte. Digita os seguintes dados:

Username: ' having 1=1 --

Password: xxxxx

O comando ficará assim:
````cs
var sql = "select Count(*) from users where username = ' having 1=1
````
Este comando acarretará, dependendo do banco de dados, na seguinte mensagem:
````sql
Column 'usuarios.codigo' is invalid in the select list because it is not contained in an aggregate function and there is no GROUP BY clause
````

Neste caso o Hacker sabe o nome da tabela de usuários na base de dados. Logo ele pode fazer o seguinte:

Username: admin' ;drop table usuarios --

Password: xxxxx

Será executado o comando:
````cs
var sql = "select Count(*) from users where username = 'admin'; drop table usuarios";
````
Pronto. Sua tabela de usuários será destruída e seu sistema ficará fora do ar já que ninguém mais vai validar o Login e Password.

Apresentamos o problema. Agora como resolvemos isso?

Algumas dicas:

- Estabeleça uma política de segurança rígida e criteriosa limitando o acesso dos seus usuários de conexão de banco a apenas algumas ações. Usar o usuário administrador do banco no String de Conexão só funciona quando você está estudando e fazendo exemplos para aprendizado em sua máquina;

- Faça validação da entrada de dados dos seus usuários e não permita a entrada de caracteres como ponto e vírgula (;), dois traços (--) e aspas simples ('). Claro que estes caracteres vão depender que banco de dados você está usando. E impeça caracteres que permitam modificar os comandos SQL do seu código.

No caso da aspas simples (') substitua por aspas duplas (").

````cs
public void ExpurgaApostrofe(object texto)
{
    ExpurgaApostrofe = replace(texto, "'", "''");
}
````
E no caso dos caracteres e aspas maliciosas substitua por vazio.

````cs
public void LimpaLixo(object input)
{
    var lixo;
    var textoOK;
    lixo = array("select", "drop", ";", "--", "insert", "delete", "xp_");
    textoOK = input;
    for (var i = 0; i <= uBound(lixo); i++)
        textoOK = replace(textoOK, lixo(i), "");
    LimpaLixo = textoOK;
}
````
E rejeite os caracteres maliciosos:

````cs
public void ValidaDados(object input)
{
    lixo = array("select", "insert", "update", "delete", "drop", "--", "'");
    ValidaDados = true;
    for (var i = lBound(lixo); i <= ubound(llixo); i++)
    {
        if ((instr(1, input, lixo(i), vbtextcompare) != 0))
        {
            ValidaDados = false;
        }
    }
}
````
- Limite o tamanho dos usuários e senhas. E, se possível, implemente regras de senhas (Numero mínimo e máximo de caracteres, obrigatoriedade de letras minúsculas e maiúsculas, etc.);

- Implemente um Log de auditoria na sua aplicação. A cada linha de comando digitada escreva em um arquivo onde o acesso somente seja permitido no servidor para você detectar possíveis tentativas de ataques;

- Implementa, pelo menos nos processos que envolvam seguranças, Stored Procedures para validar, por exemplo, usuários, ou para atualizar algum critério de segurança no sistema;

- Somente execute a concatenação do usuário no comando SQL, como abaixo:

````cs
var sql = "select Count(*) from users where username = '" + username +
"' and password = '" + password + "'";
````
Somente depois de validar o conteúdo da variável username e password nos critérios de validação e limpeza.


## O que aprendemos

- A recuperar o projeto
- O processo de armazenamento do fichário, usando o disco rígido
- Um pouco sobre SQL e banco de dados

- A instalar e configurar uma tabela de dados em um banco local
- Como criar uma classe de atualização da base de dados]

- Como criar uma classe de atualização da base de dados
- O que é uma string de conexão
- Como obtemos a string de conexão de uma base, através da fonte de dados
- A implementar o método para executar uma consulta no banco de dados
- A implementar o método para executar um comando no banco de dados

- Como implementar a classe FicharioDB
- Um pouco da história do SQL
- Alguns comandos de SQL a serem usados na nossa aplicação
- Como implementar o construtor da classe FicharioDB
- Como criar o método de inclusão de um registro na base de dados

- Como complementar a classe FicharioDB
- A implementar o método de alteração
- Como implementar o método de exclusão
- Como implementar o método de busca de um item e de busca de todos os itens