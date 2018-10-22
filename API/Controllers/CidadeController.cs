using Dominio;
using Logica.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class CidadeController : ApiController
    {

        // GET: api/Default
        private CidadeService _servico;

        public CidadeController(CidadeService servico)
        {
            this._servico = servico;
        }

        public IList<Cidade> Get()
        {

            return _servico.Listar();
        }

       

        // POST: api/Default
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}
