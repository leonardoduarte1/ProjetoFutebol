using Dapper;
using Dominio;
using Infraestrutura.Banco.Views;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Banco
{
    public class EstatisticasDAO
    {
        public string dbConnect = ConfigurationManager.ConnectionStrings["conexaoBanco"].ToString();
            
        public EstatisticasDAO() { }

        //public string IdEstado { get; set; }

        public EstatisticasView GolsContraAFavor(string idTime)
        {
            using (var db = new MySqlConnection(dbConnect))
            {
                var consultaWhere = "";
                var consulta = "SELECT ";
                
                consulta += "   (SELECT ";
                consulta += "       case ";
                consulta += "           when idTimeA = p.id then SUM(placarTimeA) ";
                consulta += "           else SUM(placarTimeB) ";
                consulta += "       end ";
                consulta += "   FROM ";
                consulta += "       partidas ";
                consulta += "   WHERE ";
                consulta += " idTimeA = p.id OR idTimeB = p.id) total1, ";
                consulta += "   (SELECT ";
                consulta += "       case ";
                consulta += "           when idTimeA = p.id then SUM(placarTimeB) ";
                consulta += "           else SUM(placarTimeA) ";
                consulta += "       end ";
                consulta += "   FROM ";
                consulta += "       partidas ";
                consulta += "   WHERE ";
                consulta += "       idTimeA = p.id OR idTimeB = p.id) total2 ";
                consulta += "   FROM ";
                consulta += "       times p ";
                consulta += "   where id = " + idTime;

                consulta += consultaWhere != "" ? " where " + consultaWhere : "";

                var busca = db.Query<EstatisticasView>(consulta);

                return busca.FirstOrDefault(); 
            }

        }

        public EstatisticasView Partidas(string idTime)
        {
            using (var db = new MySqlConnection(dbConnect))
            {
                var consultaWhere = "";
                var consulta = "SELECT ";
                consulta += "   (SELECT ";
                consulta += "       count(id) ";
                consulta += "   FROM ";
                consulta += "       partidas ";
                consulta += "   WHERE ";
                consulta += "       (idTimeA = p.id OR idTimeB = p.id) ";
                consulta += "       and idTimeVencedor = p.id ) total1, ";
                consulta += "   (SELECT ";
                consulta += "      count(id)";
                consulta += "   FROM ";
                consulta += "       partidas ";
                consulta += "   WHERE ";
                consulta += "       (idTimeA = p.id OR idTimeB = p.id) ";
                consulta += "       and idTimeVencedor <> p.id ) total2 ";
                consulta += "   FROM ";
                consulta += "       times p ";
                consulta += "   where id = " + idTime;

                consulta += consultaWhere != "" ? " where " + consultaWhere : "";

                var busca = db.Query<EstatisticasView>(consulta);

                return busca.FirstOrDefault();
            }
        }
    }
}
