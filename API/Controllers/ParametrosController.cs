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
    public class ParametrosController : ApiController
    {

        // GET: api/Default
        private CidadeService _svCidade;
        private EstadoService _svEstado;

        public ParametrosController(
            CidadeService _svCidade,
            EstadoService _svEstado

            )
        {
            this._svCidade = _svCidade;
            this._svEstado = _svEstado;
        }

        // GET api/parametros/cidades
        [HttpGet Route("api/parametros/cidades")]
        public IList<Cidade> GetCidades()
        {

            return _svCidade.Listar();
        }

        // GET api/parametros/estados
        [HttpGet Route("api/parametros/estados")]
        public IList<Estado> GetEstados()
        {

            return _svEstado.Listar();
        }

        
    }
}
