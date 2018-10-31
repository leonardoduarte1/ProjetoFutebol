using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Bairro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdCidade { get; set; }
        public int IdEstado { get; set; }
    }
}
