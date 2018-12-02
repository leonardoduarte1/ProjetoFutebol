using Dominio;
using Logica.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
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
        // GET: api/Time/Listar
        [HttpGet Route("api/Time/Listar")]
        public IList<Time> Listar(string idNao = null, string inicioConsulta = null, string nome = null)
        {
            this._svTime.nome = nome;
            this._svTime.idNao = idNao;
            this._svTime.inicioConsulta = inicioConsulta; 
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

        [HttpPost Route("api/Time/Upload")]
        public HttpResponseMessage Upload()
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count < 1)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            foreach (string file in httpRequest.Files)
            {
                var postedFile = httpRequest.Files[file];
                var filePath = HttpContext.Current.Server.MapPath("~/emblemas/" + postedFile.FileName + ".jpg");
                postedFile.SaveAs(filePath);
                // NOTE: To store in memory use postedFile.InputStream
            }

            return Request.CreateResponse(HttpStatusCode.Created);
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
