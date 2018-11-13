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
    public class PartidaDAO
    {
        public string dbConnect = ConfigurationManager.ConnectionStrings["conexaoBanco"].ToString();
            
        public PartidaDAO() { }

        //public string IdEstado { get; set; }

        public IList<Partida> Listar()
        {
            using (var db = new MySqlConnection(dbConnect))
            {
                var consultaWhere = "";
                var consulta = "SELECT ";
                consulta += "     p.id, p.data, p.idLocalPartida, p.idTimeA, p.idTimeB, p.idTimeVencedor, p.idSituacao, ";
                consulta += "     p.placarTimeA, p.placarTimeB, ";
                consulta += "     lp.id, lp.nome, ta.id, ta.nome, ta.emblema, ta.proprietario,  ";
                consulta += "     tb.id, tb.nome, tb.emblema, tb.proprietario, ";
                consulta += "     s.id, s.descricao ";
                consulta += " FROM ";
                consulta += "     partidas p ";
                consulta += "         INNER JOIN ";
                consulta += "     local_partida lp ON p.idLocalPartida = lp.id ";
                consulta += "         INNER JOIN ";
                consulta += "     times ta ON p.idTimeA = ta.id ";
                consulta += "         INNER JOIN ";
                consulta += "     times tb ON p.idTimeB = tb.id ";
                consulta += "          INNER JOIN ";
                consulta += "     situacao_partida s ON p.idSituacao = s.id ";


                consulta += consultaWhere != "" ? " where " + consultaWhere : "";

                var busca = db.Query<Partida, LocalPartida, Time, Time, SituacaoPartida, Partida>(consulta,
                    (partida, localPartida, timeA, timeB, situacaoPartida) =>
                    {
                        partida.LocalPartida = localPartida;
                        partida.TimeA = timeA;
                        partida.TimeB = timeB;
                        partida.SituacaoPartida = situacaoPartida;
                        return partida;
                    },
                    splitOn: "id");

                return busca.ToList(); 
            }

        }

        public bool Inserir(Partida partida)
        {
            using (var db = new MySqlConnection(dbConnect))
            {
                
                var consulta = "INSERT INTO ";
                consulta += " partidas (data, idLocalPartida, idTimeA, idTimeB, placarTimeA, placarTimeB, idSituacao) ";
                consulta += " values (@Data, @IdLocalPartida, @IdTimeA, @IdTimeB, ";
                consulta += " @PlacarTimeA, @PlacarTimeB, @IdSituacao) ";

                var linhasAfetadas = db.Execute(consulta, partida);

                return linhasAfetadas > 0;
            }
        }

        public bool Remover(int id)
        {
            using (var db = new MySqlConnection(dbConnect))
            {

                var consulta = "DELETE ";
                consulta += " from partidas ";
                consulta += " where id = " + id;

                var linhasAfetadas = db.Execute(consulta);

                return linhasAfetadas > 0;
            }
        }
    }
}
