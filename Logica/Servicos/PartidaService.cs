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
    public class PartidaService
    {
        private PartidaDAO dao = new PartidaDAO();

        
        public IList<Partida> Listar()
        {
            return dao.Listar();
        }

        public IList<Partida> Historico(string idTime)
        {
            dao.IdTime = idTime;
            dao.SelecaoEspecifica.Add("historico");
            return dao.Listar();
        }

        public IList<Partida> Ultimas()
        {
            dao.SelecaoEspecifica.Add("ultimas");
            return dao.Listar();
        }
        

        public Partida PreencherSumula(string idTime)
        {
            dao.SelecaoEspecifica.Add("verificaSePossuiJogo");
            dao.IdTime = idTime;
            return dao.Listar().FirstOrDefault();
        }

        public bool PossuiSumula(string idTime)
        {
            dao.IdTime = idTime;
            return dao.PossuiSumula();
        }

        public bool PossuiJogoPendente(string idTime)
        {
            dao.IdTime = idTime;
            return dao.PossuiJogoPendente();
        }

        public bool AlterarSituacao(string id, string situacao)
        {
            return dao.AlterarSituacao(id, situacao);
        }

        public IList<Partida> Convites(string idTime)
        {
            dao.SelecaoEspecifica.Add("retornaPartidasPendentes");
            dao.IdTime = idTime;
            return dao.Listar();
        }

        public bool Remover(int id)
        {
            return dao.Remover(id);
        }

        public bool Inserir(Partida partida)
        {
            partida.Data = DateTime.Parse(partida.DataPartida);

            return dao.Inserir(partida);
        }

        public bool Encerrar(string id, Partida partida)
        {
            return dao.Encerrar(id, partida.PlacarTimeA, partida.PlacarTimeB, partida.IdTimeVencedor);
        }
    }
}
