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
    public class JogadorService
    {
        private JogadorDAO dao = new JogadorDAO();

        
        public IList<Jogador> Listar()
        {
            return dao.Listar();
        }

    }
}
