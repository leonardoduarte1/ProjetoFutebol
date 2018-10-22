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
                consulta += " id, data, idLocalPartida, ";
                consulta += " idTimeA, idTimeB, idTimeVencedor, ";
                consulta += " placarTimeA, placarTimeB ";
                consulta += " from partidas ";

                consulta += consultaWhere != "" ? " where " + consultaWhere : "";

                var busca = db.Query<Partida>(consulta);

                return busca.ToList(); 
            }

        }
    }
}
