using Dominio;
using Infraestrutura.Banco;
using Logica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Servicos
{
    public class EstatisticaService
    {
        private EstatisticasDAO dao = new EstatisticasDAO();

        
        public string Gols(string idTime)
        {
            var retorno = dao.GolsContraAFavor(idTime);
            return retorno.Total1 + "," + retorno.Total2;
        }

        public string Partidas(string idTime)
        {
            var retorno = dao.Partidas(idTime);
            return retorno.Total1 + "," + retorno.Total2;
        }

    }
}
