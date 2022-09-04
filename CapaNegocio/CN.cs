using System;
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
            return cd.ListarProductos();
        }
        public DataSet ObtenerDatosCli()
        {
            return cd.ListarClientes();
        }
        public void EditarPro(CE ce)
        {
            cd.EditarProductos(ce);
        }
        public void EditarCli(CE ce)
        {
            cd.EditarClientes(ce);
        }
        public void EliminarPro(CE ce)
        {
            cd.EliminarProductos(ce);
        }
        public void EliminarCli(CE ce)
        {
            cd.EliminarClientes(ce);
        }
        public DataTable DatosFacCli(CE ce)
        {
           return cd.ListarFacClientes(ce);
        }
        public DataTable DatosFacPro(CE ce)
        {
            return cd.ListarFacProductos(ce);
        }
        public DataTable DatosFacVen(CE ce)
        {
            return cd.ListarFacVendedores(ce);
        }
        public int ConsultarPrecioPro(int Codigo)
        {
            return cd.ConsultarPrecio(Codigo);
        }
    }
}
