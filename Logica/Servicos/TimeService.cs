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
    public class TimeService
    {
        private TimeDAO dao = new TimeDAO();


        public IList<Time> Listar()
        {
            return dao.Listar();
        }

        public bool Inserir(Time time)
        {
            return dao.Inserir(time);
        }

        public bool Atualizar(Time time)
        {
            return dao.Atualizar(time);
        }

        public bool Remover(int id)
        {
            return dao.Remover(id);
        }

        public Time BuscarPeloId(string id)
        {
            dao.Id = id;
            return dao.Listar().FirstOrDefault();
        }

        public Time BuscarPeloEmailESenha(string email, string senha)
        {
            dao.Email = email;
            dao.Senha = senha;
            return dao.Listar().FirstOrDefault();
        }
    }
}
