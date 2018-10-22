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
    public class CidadeService
    {
        private CidadeDAO dao = new CidadeDAO();

        
        public IList<Cidade> Listar()
        {
            return dao.Listar();
        }

    }
}
