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
    public class NotificacaoController : ApiController
    {
        private PartidaService _svPartida;

        public NotificacaoController(
            PartidaService _svPartida
            )
        {
            this._svPartida = _svPartida;
        }
        // GET: api/Notificacao
        [HttpGet Route("api/notificacao/sumula/{idTime}")]
        public bool Sumula(string idTime)
        {
            return this._svPartida.PossuiSumula(idTime);
        }

        // GET: api/Notificacao
        [HttpGet Route("api/notificacao/pendente/{idTime}")]
        public bool Pendente(string idTime)
        {
            return this._svPartida.PossuiJogoPendente(idTime);
        }

        // GET: api/Notificacao/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Notificacao
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Notificacao/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Notificacao/5
        public void Delete(int id)
        {
        }
    }
}
