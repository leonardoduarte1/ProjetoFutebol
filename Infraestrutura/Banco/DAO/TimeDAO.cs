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
                consulta += " id, nome, proprietario, ";
                consulta += " email, telefone, idBairro, idCidade, ";
                consulta += " idEstado, emblema, senha ";
                consulta += " from times ";

                if (!String.IsNullOrEmpty(this.Id))
                {
                    consultaWhere += consultaWhere != "" ? " and " : "";
                    consultaWhere += " id = " + this.Id; // Ativo nas escolas
                }

                if (!String.IsNullOrEmpty(this.Email))
                {
                    consultaWhere += consultaWhere != "" ? " and " : "";
                    consultaWhere += " Email = '" + this.Email + "' "; // Ativo nas escolas
                }

                if (!String.IsNullOrEmpty(this.Senha))
                {
                    consultaWhere += consultaWhere != "" ? " and " : "";
                    consultaWhere += " Senha = '" + this.Senha + "' "; // Ativo nas escolas
                }

                consulta += consultaWhere != "" ? " where " + consultaWhere : "";

                var busca = db.Query<Time>(consulta);

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
            using (var db = new MySqlConnection(dbConnect))
            {
                
                var consulta = "INSERT INTO ";
                consulta += " times (nome, proprietario, email, telefone, idBairro, idCidade, idEstado, Emblema, Senha) ";
                consulta += " values (@Nome, @Proprietario, @Email, @Telefone, @IdBairro, ";
                consulta += " @IdCidade, @IdEstado, @Emblema, @Senha) ";

                var linhasAfetadas = db.Execute(consulta, time);

                return linhasAfetadas > 0;
            }
        }
    }
}
