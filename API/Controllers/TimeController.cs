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
    public class TimeController : ApiController
    {
        private TimeService _svTime;

        public TimeController(
            TimeService _svTime
            )
        {
            this._svTime = _svTime;
        }
        // GET: api/Time
        public IList<Time> Get()
        {
            return this._svTime.Listar();
        }

        // GET: api/Time/5
        public Time Get(string id)
        {
            return this._svTime.BuscarPeloId(id);
        }

        public Time Get(string email, string senha)
        {
            return this._svTime.BuscarPeloEmailESenha(email, senha);
        }

        // POST: api/Time
        public bool Post(Time time)
        {
            return _svTime.Inserir(time);
        }

        // PUT: api/Time/5
        public void Put(int id, [FromBody]Time value)
        {
        }

        // DELETE: api/Time/5
        public void Delete(int id)
        {
            this._svTime.Remover(id);
        }
    }
}
