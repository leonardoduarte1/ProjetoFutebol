using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Banco
{
    public class TimeDAO
    {
        public string dbConnect = ConfigurationManager.ConnectionStrings["conexaoBanco"].ToString();
            
        public TimeDAO() { }

        public void Listar()
        {
            var db = new MySqlConnection(dbConnect);
        /*using (var db = new OleDbConnection(dbConnect))
        {
            var consultaWhere = "";
            var consulta = "SELECT ";
            consulta += " teste ";
               
            consulta += " from teste ";


            /* -----------------------------------------------------------------------------------------------------		
                * Filtra pelas regionais vinculadas com as escolas qiue o professor leciona.
                *-------------------------------------------------------------------------------------------------------	
            */

            /*
                if (!String.IsNullOrEmpty(this.Cpf))
                {
                    consultaWhere += consultaWhere != "" ? " and " : "";
                    consultaWhere += " cpf_cnpj = '" + this.Cpf + "' "; // Ativo nas escolas
                }




                consulta += consultaWhere != "" ? " where " + consultaWhere : "";

                var busca = db.Query<T>(consulta);



                return busca.OrderByDescending(p => p.DataVencimento); 
                }

                 */


        }

        
    }
}
