﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class LocalPartida
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Imagem { get; set; }
        public int IdCidade { get; set; }
        public int IdEstado { get; set; }

    }
}
