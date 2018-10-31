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

        public string IdTime { get; set; }

        public IList<Jogador> Listar()
        {
            dao.IdTime = this.IdTime;
            return dao.Listar();
        }

        public Jogador BuscarPeloId(int id)
        {
            return dao.Listar().FirstOrDefault();
        }

        public bool Remover(int id)
        {
            return dao.Remover(id);
        }

        public bool Inserir(Jogador jogador)
        {
            return dao.Inserir(jogador);
        }
    }
}
