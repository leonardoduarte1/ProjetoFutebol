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
    public class ClassificacaoDAO
    {
        public string dbConnect = ConfigurationManager.ConnectionStrings["conexaoBanco"].ToString();
            
        public ClassificacaoDAO() { }

        //public string IdEstado { get; set; }


        public IList<Classificacao> Listar()
        {
            using (var db = new MySqlConnection(dbConnect))
            {
                var consultaWhere = "";
                var consulta = "SELECT ";
                consulta += " id, pontualidade, fairplay, niveltecnico, idTime ";
                consulta += " from classificacao ";

                consulta += consultaWhere != "" ? " where " + consultaWhere : "";

                var busca = db.Query<Classificacao>(consulta);

                return busca.ToList();
            }

        }

        public bool Inserir(Classificacao classificacao)
        {
            using (var db = new MySqlConnection(dbConnect))
            {

                var consulta = "INSERT INTO ";
                consulta += " classificacao (pontualidade, fairplay, niveltecnico, idtime) ";
                consulta += " values (@Pontualidade, @FairPlay, @NivelTecnico, @IdTime) ";

                var linhasAfetadas = db.Execute(consulta, classificacao);

                return linhasAfetadas > 0;
            }
        }
    }
}
