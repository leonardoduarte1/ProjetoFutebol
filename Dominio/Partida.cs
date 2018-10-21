using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Partida
    {
        public int Id { get; set; }
        public DateTime data { get; set; }
        public int IdEstadio { get; set; }
        public int IdTime1 { get; set; }
        public int IdTime2 { get; set; }
        public string Vencedor { get; set; }
        public string Placar { get; set; }
    }
}
