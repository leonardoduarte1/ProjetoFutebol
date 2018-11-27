using Dominio;
using Logica.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PartidaController : ApiController
    {
        private PartidaService _svPartida;

        public PartidaController(
            PartidaService _svPartida
            )
        {
            this._svPartida = _svPartida;
        }
        // GET: api/Partida/Listar
        [HttpGet Route("api/Partida/Listar")]
        public IList<Partida> Listar()
        {
            return this._svPartida.Listar();
        }

        [HttpGet Route("api/Partida/PreencherSumula/{idTime}")]
        public Partida PreencherSumula(string idTime)
        {
            return this._svPartida.PreencherSumula(idTime);
        }

        [HttpGet Route("api/Partida/Convites/{idTime}")]
        public IList<Partida> Convites(string idTime)
        {
            return this._svPartida.Convites(idTime);
        }

        [HttpGet Route("api/Partida/AlterarSituacao")]
        public bool AlterarSituacao(string idPartida, string idSituacao)
        {
            return this._svPartida.AlterarSituacao(idPartida, idSituacao);
        }


        // POST: api/Time
        public bool Post(Partida partida)
        {
            return _svPartida.Inserir(partida);
        }

        [HttpPut Route("api/Partida/Encerrar/{id}")]
        public bool Encerrar(string id, [FromBody]Partida partida)
        {
            return _svPartida.Encerrar(id, partida);
        }

        // DELETE: api/Time/5
        public void Delete(int id)
        {
            this._svPartida.Remover(id);
        }
    }
}
