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
            
        public TimeDAO() { }

        //public string IdEstado { get; set; }

        public IList<Time> Listar()
        {
            using (var db = new MySqlConnection(dbConnect))
            {
                var consultaWhere = "";
                var consulta = "SELECT ";
                consulta += " id, nome, proprietario, ";
                consulta += " email, telefone, idCidade, ";
                consulta += " idEstado, emblema, senha ";
                consulta += " from times ";

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
                consulta += " times ";
                consulta += " values (@Nome, @Proprietario, @Email, @Telefone, @IdBairro, ";
                consulta += " @IdCidade, @IdEstado, @Emblema, @Senha) ";

                var linhasAfetadas = db.Execute(consulta, time);

                return linhasAfetadas > 0;
            }
        }
    }
}
