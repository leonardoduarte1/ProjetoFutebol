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
    public class EstatisticasController : ApiController
    {
        private EstatisticaService _svEstatisticas;

        public EstatisticasController(
            EstatisticaService _svEstatisticas
            )
        {
            this._svEstatisticas = _svEstatisticas;
        }
        // GET: api/Notificacao
        [HttpGet Route("api/estatisticas/gols/{idTime}")]
        public string Gols(string idTime)
        {
            return this._svEstatisticas.Gols(idTime);
        }

        // GET: api/Notificacao
        [HttpGet Route("api/estatisticas/partidas/{idTime}")]
        public string Partidas(string idTime)
        {
            return this._svEstatisticas.Partidas(idTime);
        }
        
    }
}
