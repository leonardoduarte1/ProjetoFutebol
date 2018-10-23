﻿using Dominio;
using Infraestrutura.Banco;
using Logica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Servicos
{
    public class TipoEventoService
    {
        private TipoEventoDAO dao = new TipoEventoDAO();

        
        public IList<TipoEvento> Listar()
        {
            return dao.Listar();
        }

    }
}
