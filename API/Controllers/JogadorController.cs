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
    public class JogadorController : ApiController
    {
        private JogadorService _svJogador;

        public JogadorController(
            JogadorService _svJogador
            )
        {
            this._svJogador = _svJogador;
        }

        // GET: api/Jogador
        public IList<Jogador> Get()
        {
            return this._svJogador.Listar();
        }

        // GET: api/Jogador/5
        public Jogador Get(int id)
        {
            return this._svJogador.BuscarPeloId(id);
        }

        // POST: api/Jogador
        public void Post([FromBody]Jogador jogador)
        {
            this._svJogador.Inserir(jogador);
        }

        // PUT: api/Jogador/5
        public void Put(int id, [FromBody]Jogador value)
        {
        }

        // DELETE: api/Jogador/5
        public void Delete(int id)
        {
            this._svJogador.Remover(id);
        }
    }
}
