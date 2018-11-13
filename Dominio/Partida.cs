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
        public string DataPartida { get; set; }
        public DateTime Data { get; set; }
        public int IdLocalPartida { get; set; }
        public LocalPartida LocalPartida { get; set; }
        public int IdTimeA { get; set; }
        public Time TimeA { get; set; }
        public int IdTimeB { get; set; }
        public Time TimeB { get; set; }
        public int IdTimeVencedor { get; set; }
        public int IdSituacao { get; set; }
        public SituacaoPartida SituacaoPartida { get; set; }
        public string PlacarTimeA { get; set; }
        public string PlacarTimeB { get; set; }
    }
}
