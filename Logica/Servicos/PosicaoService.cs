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
    public class PosicaoService
    {
        private PosicaoDAO dao = new PosicaoDAO();

        
        public IList<Posicao> Listar()
        {
            return dao.Listar();
        }

    }
}
