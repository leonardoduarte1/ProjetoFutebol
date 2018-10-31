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
    public class BairroDAO
    {
        private string dbConnect = ConfigurationManager.ConnectionStrings["conexaoBanco"].ToString();
            
        public BairroDAO() { }

        public string IdEstado { get; set; }
        public string IdCidade { get; set; }

        public IList<Bairro> Listar()
        {
            using (var db = new MySqlConnection(dbConnect))
            {
                var consultaWhere = "";
                var consulta = "SELECT ";
                consulta += " id, nome, idestado, idestado ";
                consulta += " from bairros ";


                if (!String.IsNullOrEmpty(this.IdEstado))
                {
                    consultaWhere += consultaWhere != "" ? " and " : "";
                    consultaWhere += " idestado = " + this.IdEstado; // Ativo nas escolas
                }

                if (!String.IsNullOrEmpty(this.IdCidade))
                {
                    consultaWhere += consultaWhere != "" ? " and " : "";
                    consultaWhere += " idcidade = " + this.IdCidade; // Ativo nas escolas
                }

                consulta += consultaWhere != "" ? " where " + consultaWhere : "";

                var busca = db.Query<Bairro>(consulta);



                return busca.ToList(); 
            }

        }
    }
}
