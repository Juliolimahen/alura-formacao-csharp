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
