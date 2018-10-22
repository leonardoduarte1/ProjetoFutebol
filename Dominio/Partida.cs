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
        public int IdTimeA { get; set; }
        public int IdTimeB { get; set; }
        public int IdTimeVencedor { get; set; }
        public string PlacarTimeA { get; set; }
        public string PlacarTimeB { get; set; }
    }
}
