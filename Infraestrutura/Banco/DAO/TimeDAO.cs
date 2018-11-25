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
    public class TimeDAO
    {
        public string dbConnect = ConfigurationManager.ConnectionStrings["conexaoBanco"].ToString();
        public string inicioConsulta;
        public string idNao;

        public string Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        

        public TimeDAO() { }

        //public string IdEstado { get; set; }

        public IList<Time> Listar()
        {
            using (var db = new MySqlConnection(dbConnect))
            {
                var consultaWhere = "";
                var consulta = "SELECT ";
                consulta += " t.id, t.nome, t.proprietario, ";
                consulta += " t.email, t.telefone, t.emblema, ";
                consulta += " t.dataCriacao, t.idBairro, t.idCidade, t.idEstado, ";
                consulta += " b.id, b.nome, c.id, c.nome, e.id, e.sigla ";
                consulta += " from times t ";
                consulta += " inner join bairros b ";
                consulta += " on t.idBairro = b.Id ";
                consulta += " inner join cidades c ";
                consulta += " on t.idCidade = c.Id ";
                consulta += " inner join estados e ";
                consulta += " on t.idEstado = e.Id ";

                if (!String.IsNullOrEmpty(this.Id))
                {
                    consultaWhere += consultaWhere != "" ? " and " : "";
                    consultaWhere += " t.id = " + this.Id; // Ativo nas escolas
                }

                if (!String.IsNullOrEmpty(this.Email))
                {
                    consultaWhere += consultaWhere != "" ? " and " : "";
                    consultaWhere += " t.Email = '" + this.Email + "' "; // Ativo nas escolas
                }

                if (!String.IsNullOrEmpty(this.Senha))
                {
                    consultaWhere += consultaWhere != "" ? " and " : "";
                    consultaWhere += " t.Senha = '" + this.Senha + "' "; // Ativo nas escolas
                }

                if (!String.IsNullOrEmpty(this.idNao))
                {
                    consultaWhere += consultaWhere != "" ? " and " : "";
                    consultaWhere += " t.id not in (" + this.idNao + ") "; // Ativo nas escolas
                }

                if (!String.IsNullOrEmpty(this.inicioConsulta))
                {
                    consultaWhere += consultaWhere != "" ? " and " : "";
                    consultaWhere += " limit " + this.inicioConsulta + ",10 "; // Ativo nas escolas
                }

                consulta += consultaWhere != "" ? " where " + consultaWhere : "";

                var busca = db.Query<Time, Bairro, Cidade, Estado, Time>(consulta,
                    (time, bairro, cidade, estado) => 
                    {
                        time.Bairro = bairro;
                        time.Cidade = cidade;
                        time.Estado = estado;
                        return time;
                    },
                    splitOn: "id");

                return busca.ToList(); 
            }

        }

        public bool Remover(int id)
        {
            using (var db = new MySqlConnection(dbConnect))
            {
                
                var consulta = "DELETE ";
                consulta += " from times ";
                consulta += " where id = " + id;

                var linhasAfetadas = db.Execute(consulta);

                return linhasAfetadas > 0;
            }
        }

        public bool Atualizar(Time time)
        {
            throw new NotImplementedException();
        }

        public bool Inserir(Time time)
        {
            time.DataCriacao = DateTime.Now;
            using (var db = new MySqlConnection(dbConnect))
            {
                
                var consulta = "INSERT INTO ";
                consulta += " times (nome, proprietario, email, telefone, idBairro, idCidade, idEstado, emblema, senha, dataCriacao) ";
                consulta += " values (@Nome, @Proprietario, @Email, @Telefone, @IdBairro, ";
                consulta += " @IdCidade, @IdEstado, @Emblema, @Senha, @DataCriacao) ";

                var linhasAfetadas = db.Execute(consulta, time);

                return linhasAfetadas > 0;
            }
        }
    }
}
