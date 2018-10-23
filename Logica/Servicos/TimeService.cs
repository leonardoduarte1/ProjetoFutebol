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
    public class TimeService
    {
        private TimeDAO dao = new TimeDAO();

        
        public IList<Time> Listar()
        {
            return dao.Listar();
        }

    }
}