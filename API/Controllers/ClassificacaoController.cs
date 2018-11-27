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
    public class ClassificacaoController : ApiController
    {
        // GET: api/Classificacao
        private ClassificacaoService _svClassificacao;

        public ClassificacaoController(
            ClassificacaoService _svClassificacao
            )
        {
            this._svClassificacao = _svClassificacao;
        }

        // POST: api/Classificacao
        public void Post([FromBody]Classificacao classificacao)
        {
            this._svClassificacao.Inserir(classificacao);
        }

        // PUT: api/Classificacao/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Classificacao/5
        public void Delete(int id)
        {
        }
    }
}
