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
    public class LocalPartidaService
    {
        private LocalPartidaDAO dao = new LocalPartidaDAO();

        
        public IList<LocalPartida> Listar()
        {
            return dao.Listar();
        }

    }
}
