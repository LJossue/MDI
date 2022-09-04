using System;
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
        public long Telefono { get; set; }
        public string Correo { get; set; }
        public string Consultar2 { get; set; }


        //Producto
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Valor { get; set; }
        public int Cantidad { get; set; }

        public string Consultar1 { get; set; }

        //Vendedor
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
    }

}
