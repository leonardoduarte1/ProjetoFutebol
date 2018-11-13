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
        private PosicaoService _svPosicoes;
        private LocalPartidaService _svLocalPartida;

        public ParametrosController(
            CidadeService _svCidade,
            EstadoService _svEstado,
            BairroService _svBairro,
            PosicaoService _svPosicoes,
            LocalPartidaService _svLocalPartida
            )
        {
            this._svCidade = _svCidade;
            this._svEstado = _svEstado;
            this._svBairro = _svBairro;
            this._svPosicoes = _svPosicoes;
            this._svLocalPartida = _svLocalPartida;
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

        // GET api/parametros/estados
        [HttpGet Route("api/parametros/posicoes")]
        public IList<Posicao> GetPosicoes()
        {

            return _svPosicoes.Listar();
        }

        [HttpGet Route("api/parametros/localpartida")]
        public IList<LocalPartida> GetLocalPartida()
        {

            return _svLocalPartida.Listar();
        }
    }
}
