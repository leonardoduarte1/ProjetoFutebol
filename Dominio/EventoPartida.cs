using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class EventoPartida
    {
        public int Id { get; set; }
        public int IdTipoEvento { get; set; }
        public int IdJogador { get; set; }
        public int IdPartida { get; set; }
    }
}
