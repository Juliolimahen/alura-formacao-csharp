using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoWindowsFormsBiblioteca.Databases
{

    /// <summary>
    /// Classe responsável por se relacionar com o banco 
    /// </summary>
    public class FicharioDb
    {
        /// <summary>
        /// Propriedades 
        /// </summary>
        public string mensagem;
        public bool status;
        public string tabela;
        public LocalDbClass db;

        /// <summary>
        /// Método(construtor) responsável por Instanciar LocalDb, Definir status e Atribuir tabela 
        /// </summary>
        /// <param name="Tabela"></param>
        public FicharioDb(string Tabela)
        {
            status = true;
            try
            {
                db = new LocalDbClass();
                tabela = Tabela;
                mensagem = "Conexão bem sucedida!";
            }
            catch (Exception e)
            {
                status = false;
                mensagem = "Conexão com a tabela com erro: " + e.Message;
            }
        }

        /// <summary>
        /// Classe resposável por inserir dados no banco 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="jsonUnit"></param>
        public void Incluir(string Id, string jsonUnit)
        {
            try
            {
                var SQL = "INSERT INTO " + tabela + "(Id, JSON) VALUES ('" + Id + "', '" + jsonUnit + "')";
                db.SqlCommand(SQL);
                status = true;
                mensagem = "Inclusão efetuada com sucesso. Identificador: " + Id;
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com o Fichario com erro: " + ex.Message;
            }
        }

        /// <summary>
        /// Classe responsável por realizar a busca e retorna uma tabela em memória 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string Buscar(string Id)
        {
            status = true;
            try
            {
                var SQL = "SELECT ID, JSON FROM " + tabela + " WHERE ID = '" + Id + "'";
                var dt = db.SQLQuery(SQL);
                if (dt.Rows.Count > 0)
                {
                    string conteudo = dt.Rows[0]["JSON"].ToString();
                    status = true;
                    mensagem = "Inclusão efetuada com sucesso. Identificador: " + Id;
                    return conteudo;
                }
                else
                {
                    status = false;
                    mensagem = "Identificador não existe: " + Id;
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar o conteúdo do identificador: " + ex.Message;
            }
            return "";
        }

        /// <summary>
        /// Classe responsável por realizar a busca(todos) e retorna uma tabela em memória 
        /// </summary>
        /// <returns></returns>
        public List<string> BuscarTodos()
        {
            status = true;
            List<string> List = new List<string>();
            try
            {
                var SQL = "SELECT ID, JSON FROM " + tabela;
                var dt = db.SQLQuery(SQL);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        string conteudo = dt.Rows[i]["JSON"].ToString();
                        List.Add(conteudo);
                    }
                }

                return List;
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar o conteúdo do identificador: " + ex.Message;
            }
            return List;
        }

        /// <summary>
        /// Método para apagar cliente
        /// </summary>
        /// <param name="Id"></param>
        public void Apagar(string Id)
        {
            status = true;
            try
            {
                var SQL = "SELECT ID, JSON FROM " + tabela + " WHERE ID = '" + Id + "'";
                var dt = db.SQLQuery(SQL);
                if (dt.Rows.Count > 0)
                {
                    SQL = "DELETE FROM " + tabela + " WHERE ID = '" + Id + "'";
                    db.SqlCommand(SQL);
                    string conteudo = dt.Rows[0]["JSON"].ToString();
                    status = true;
                    mensagem = "Exclusão efetuada com sucesso. Identificador: " + Id;
                }
                else
                {
                    status = false;
                    mensagem = "Identificador não existe: " + Id;
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar o conteúdo do identificador: " + ex.Message;
            }
        }
        public void Alterar(string Id, string jsonUnit)
        {
            status = true;
            try
            {
                var SQL = "SELECT ID, JSON FROM " + tabela + " WHERE ID = '" + Id + "'";
                var dt = db.SQLQuery(SQL);
                if (dt.Rows.Count > 0)
                {
                    SQL = "UPDATE " + tabela + " SET JSON = '" + jsonUnit + "WHERE ID = " + Id + "'";
                    db.SqlCommand(SQL);
                    status = true;
                    mensagem = "Alteração efetuada com sucesso. Identificador: " + Id;
                }
                else
                {
                    status = false;
                    mensagem = "Identificador não existe: " + Id;
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com o Fichario com erro: " + ex.Message;
            }

        }
    }
}
