﻿using Dapper;
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
    public class SituacaoPartidaDAO
    {
        public string dbConnect = ConfigurationManager.ConnectionStrings["conexaoBanco"].ToString();
            
        public SituacaoPartidaDAO() { }

        //public string IdEstado { get; set; }
        public IList<SituacaoPartida> Listar()
        {
            using (var db = new MySqlConnection(dbConnect))
            {
                var consultaWhere = "";
                var consulta = "SELECT ";
                consulta += " id, descricao ";
                consulta += " from situacao_partida ";

                consulta += consultaWhere != "" ? " where " + consultaWhere : "";

                var busca = db.Query<SituacaoPartida>(consulta);

                return busca.ToList();
            }

        }

    }
}
