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
    public class SituacaoPartidaService
    {
        private SituacaoPartidaDAO dao = new SituacaoPartidaDAO();

        
        public IList<SituacaoPartida> Listar()
        {
            return dao.Listar();
        }

    }
}
