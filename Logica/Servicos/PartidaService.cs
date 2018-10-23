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
    public class PartidaService
    {
        private PartidaDAO dao = new PartidaDAO();

        
        public IList<Partida> Listar()
        {
            return dao.Listar();
        }

    }
}
