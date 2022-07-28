using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CursoWindowsFormsBiblioteca.Databases
{
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
}
