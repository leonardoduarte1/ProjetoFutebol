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
    public class TipoEventoDAO
    {
        public string dbConnect = ConfigurationManager.ConnectionStrings["conexaoBanco"].ToString();
            
        public TipoEventoDAO() { }

        //public string IdEstado { get; set; }

        public IList<TipoEvento> Listar()
        {
            using (var db = new MySqlConnection(dbConnect))
            {
                var consultaWhere = "";
                var consulta = "SELECT ";
                consulta += " id, descricao ";
                consulta += " from tipo_evento ";

                consulta += consultaWhere != "" ? " where " + consultaWhere : "";

                var busca = db.Query<TipoEvento>(consulta);

                return busca.ToList(); 
            }

        }
    }
}
