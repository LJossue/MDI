﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE
    {
        //Cliente
        public int Documento { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }

        //Producto
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Valor { get; set; }
        public int Cantidad { get; set; }
    }
}
