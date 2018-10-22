using Dapper;
using Dominio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Banco
{
    public class LocalPartidaDAO
    {
        public string dbConnect = ConfigurationManager.ConnectionStrings["conexaoBanco"].ToString();
            
        public LocalPartidaDAO() { }

        //public string IdEstado { get; set; }

        public IList<LocalPartida> Listar()
        {
            using (var db = new MySqlConnection(dbConnect))
            {
                var consultaWhere = "";
                var consulta = "SELECT ";
                consulta += " id, nome, telefone, ";
                consulta += " idCidade, idEstado ";
                consulta += " from local_partida ";

                consulta += consultaWhere != "" ? " where " + consultaWhere : "";

                var busca = db.Query<LocalPartida>(consulta);

                return busca.ToList(); 
            }

        }
    }
}
