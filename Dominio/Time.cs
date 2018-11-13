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
        public int IdBairro { get; set; }
        public virtual Bairro Bairro { get; set; }
        public int IdCidade { get; set; }
        public virtual Cidade Cidade { get; set; }
        public int IdEstado { get; set; }
        public virtual Estado Estado { get; set; }
        public string Emblema { get; set; }
        public string Senha { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
