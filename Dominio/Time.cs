using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Time
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Proprietario { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Bairro { get; set; }
        public int IdCidade { get; set; }
        public int IdEstado { get; set; }
        public string Emblema { get; set; }
        public string Senha { get; set; }
    }
}
