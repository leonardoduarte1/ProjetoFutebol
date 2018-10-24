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
    public class JogadorDAO
    {
        public string dbConnect = ConfigurationManager.ConnectionStrings["conexaoBanco"].ToString();
            
        public JogadorDAO() { }

        //public string IdEstado { get; set; }

        public IList<Jogador> Listar()
        {
            using (var db = new MySqlConnection(dbConnect))
            {
                var consultaWhere = "";
                var consulta = "SELECT ";
                consulta += " id, nome, email, ";
                consulta += " telefone, idPosicao, ";
                consulta += " idTime ";
                consulta += " from jogadores ";

                consulta += consultaWhere != "" ? " where " + consultaWhere : "";

                var busca = db.Query<Jogador>(consulta);

                return busca.ToList(); 
            }

        }

        public bool Inserir(Jogador jogador)
        {
            using (var db = new MySqlConnection(dbConnect))
            {

                var consulta = "INSERT INTO ";
                consulta += " jogadores (nome, email, telefone, idPosicao, idTime) ";
                consulta += " values (@Nome, @Email, @Telefone, @IdPosicao, ";
                consulta += " @IdTime) ";

                var linhasAfetadas = db.Execute(consulta, jogador);

                return linhasAfetadas > 0;
            }
        }

        public bool Remover(int id)
        {
            using (var db = new MySqlConnection(dbConnect))
            {

                var consulta = "DELETE ";
                consulta += " from jogadores ";
                consulta += " where id = " + id;

                var linhasAfetadas = db.Execute(consulta);

                return linhasAfetadas > 0;
            }
        }
    }
}
