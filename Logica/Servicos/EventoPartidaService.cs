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
    public class EventoPartidaService
    {
        private EventoPartidaDAO dao = new EventoPartidaDAO();

        
        public IList<EventoPartida> Listar()
        {
            return dao.Listar();
        }

    }
}
