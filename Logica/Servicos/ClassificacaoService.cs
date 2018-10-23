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
    public class ClassificacaoService
    {
        private ClassificacaoDAO dao = new ClassificacaoDAO();

        
        public IList<Classificacao> Listar()
        {
            return dao.Listar();
        }

    }
}
