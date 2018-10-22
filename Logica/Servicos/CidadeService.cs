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
    public class CidadeService : IService<Cidade>
    {
        private CidadeDAO dao = new CidadeDAO();

        public void Atualizar(Cidade obj)
        {
            throw new NotImplementedException();
        }

        public Cidade BuscarPeloId(int id)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Cidade obj)
        {
            throw new NotImplementedException();
        }
        
        public IList<Cidade> Listar()
        {
            return dao.Listar();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }

    }
}
