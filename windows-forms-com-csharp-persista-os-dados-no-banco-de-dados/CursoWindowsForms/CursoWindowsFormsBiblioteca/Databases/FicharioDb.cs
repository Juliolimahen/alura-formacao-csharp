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
    }
}
