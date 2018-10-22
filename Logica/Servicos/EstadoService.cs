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
    public class EstadoService
    {
        private EstadoDAO dao = new EstadoDAO();

        
        public IList<Estado> Listar()
        {
            return dao.Listar();
        }

    }
}
