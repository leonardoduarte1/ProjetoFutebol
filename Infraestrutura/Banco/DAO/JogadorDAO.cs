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

        public string IdTime { get; set; }

        public JogadorDAO() { }

        //public string IdEstado { get; set; }

        public IList<Jogador> Listar()
        {
            using (var db = new MySqlConnection(dbConnect))
            {
                db.Open();

                var consultaWhere = "";
                var consulta = @"SELECT ";
                consulta += " j.id, j.nome, j.email, ";
                consulta += " j.telefone, j.idPosicao, ";
                consulta += " j.idTime, Posicao.sigla, Posicao.nome ";
                consulta += " from jogadores j ";
                consulta += " inner join posicoes Posicao ";
                consulta += " on j.idPosicao = Posicao.Id ";

                if (!String.IsNullOrEmpty(this.IdTime))
                {
                    consultaWhere += consultaWhere != "" ? " and " : "";
                    consultaWhere += " idTime = " + this.IdTime; // Ativo nas escolas
                }

                consulta += consultaWhere != "" ? " where " + consultaWhere : "";

                var busca = db.Query<Jogador, Posicao, Jogador>(consulta, 
                    (jogador, posicao) => 
                    {
                        jogador.Posicao = posicao;
                        return jogador;
                    },
                    splitOn: "idPosicao");

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
