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
        public string idEstado;
        private CidadeDAO dao = new CidadeDAO();

        
        public IList<Cidade> Listar()
        {
            dao.IdEstado = this.idEstado;
            return dao.Listar();
        }

    }
}
