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
    public class ParametrosController : ApiController
    {

        // GET: api/Default
        private BairroService _svBairro;
        private CidadeService _svCidade;
        private EstadoService _svEstado;

        public ParametrosController(
            CidadeService _svCidade,
            EstadoService _svEstado,
            BairroService _svBairro

            )
        {
            this._svCidade = _svCidade;
            this._svEstado = _svEstado;
            this._svBairro = _svBairro;
        }

        // GET api/parametros/cidades
        [HttpGet Route("api/parametros/bairros/{idCidade}")]
        public IList<Bairro> GetBairros(string idCidade = null)
        {
            _svBairro.IdCidade = idCidade;
            return _svBairro.Listar();
        }

        // GET api/parametros/cidades
        [HttpGet Route("api/parametros/cidades/{idEstado}")]
        public IList<Cidade> GetCidades(string idEstado = null)
        {
            _svCidade.idEstado = idEstado;
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
