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
    public class CidadeDAO
    {
        private string dbConnect = ConfigurationManager.ConnectionStrings["conexaoBanco"].ToString();
            
        public CidadeDAO() { }

        public string IdEstado { get; set; }

        public IList<Cidade> Listar()
        {
            using (var db = new MySqlConnection(dbConnect))
            {
                var consultaWhere = "";
                var consulta = "SELECT ";
                consulta += " id, nome1, idestado ";
                consulta += " from cidades ";


                if (!String.IsNullOrEmpty(this.IdEstado))
                {
                    consultaWhere += consultaWhere != "" ? " and " : "";
                    consultaWhere += " idestado = " + this.IdEstado; // Ativo nas escolas
                }

                consulta += consultaWhere != "" ? " where " + consultaWhere : "";

                var busca = db.Query<Cidade>(consulta);



                return busca.ToList(); 
            }

        }
    }
}
