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
    public class BairroService
    {
        private BairroDAO dao = new BairroDAO();

        public string IdCidade { get; set; }

        public IList<Bairro> Listar()
        {
            dao.IdCidade = this.IdCidade;
            return dao.Listar();
        }

    }
}
