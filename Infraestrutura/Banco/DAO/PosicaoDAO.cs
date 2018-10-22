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
    public class PosicaoDAO
    {
        public string dbConnect = ConfigurationManager.ConnectionStrings["conexaoBanco"].ToString();
            
        public PosicaoDAO() { }

        //public string IdEstado { get; set; }

        public IList<Posicao> Listar()
        {
            using (var db = new MySqlConnection(dbConnect))
            {
                var consultaWhere = "";
                var consulta = "SELECT ";
                consulta += " id, nome, sigla ";
                consulta += " from posicoes ";

                consulta += consultaWhere != "" ? " where " + consultaWhere : "";

                var busca = db.Query<Posicao>(consulta);

                return busca.ToList(); 
            }

        }
    }
}
