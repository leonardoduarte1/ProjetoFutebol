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

        // GET: api/Time/5
       /* public Partida Get(string id)
        {
            return this._svPartida.BuscarPeloId(id);
        } */

        
        // POST: api/Time
        public bool Post(Partida partida)
        {
            return _svPartida.Inserir(partida);
        }

        // PUT: api/Time/5
        public void Put(int id, [FromBody]Partida value)
        {
        }

        // DELETE: api/Time/5
        public void Delete(int id)
        {
            this._svPartida.Remover(id);
        }
    }
}
