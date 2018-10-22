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
    public class EstadoDAO
    {
        private string dbConnect = ConfigurationManager.ConnectionStrings["conexaoBanco"].ToString();
            
        public EstadoDAO() { }

        //public string IdEstado { get; set; }

        public IList<Estado> Listar()
        {
            using (var db = new MySqlConnection(dbConnect))
            {
                var consultaWhere = "";
                var consulta = "SELECT ";
                consulta += " id, nome, sigla ";
                consulta += " from estados ";

                consulta += consultaWhere != "" ? " where " + consultaWhere : "";

                var busca = db.Query<Estado>(consulta);

                return busca.ToList(); 
            }

        }
    }
}
