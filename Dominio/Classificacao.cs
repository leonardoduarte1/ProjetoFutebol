using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Classificacao
    {
        public int Id { get; set; }
        public string Pontualidade { get; set; }
        public string FairPlay { get; set; }
        public string NivelTecnico { get; set; }
        public int IdTime { get; set; }
    }
}
