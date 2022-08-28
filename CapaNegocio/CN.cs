﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN
    {
        
        CD cd = new CD();
        
        public void CrearCliente(CE ce)
        {
            cd.CrearCli(ce);
        }
        public void CrearProducto(CE ce)
        {
            cd.CrearPro(ce);
        }
        public DataSet ObtenerDatosPro()
        {
            return cd.Listar();
        }
    }
}
