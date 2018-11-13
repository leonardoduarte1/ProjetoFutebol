using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Jogador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int IdPosicao { get; set; }
        public virtual Posicao Posicao { get; set; }
        public int IdTime { get; set; }

    }
}
