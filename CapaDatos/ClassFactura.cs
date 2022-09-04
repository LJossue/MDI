using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using CapaEntidad;
using System.Data;

namespace CapaDatos
{
    public class ClassFactura
    {
        string CadenaConexion = "server=localhost;User=root;Password=admin;Port=3306;database=naturvida;";
        //Factura
        public int Numero { get; set; }
        public string Fecha { get; set; }
        public int Cliente { get; set; }
        public int ValorTotal { get; set; }
        public int Vendedor { get; set; }
        public int UltimaFacturaa { get; set; }
        public ClassFactura(string fecha, int cliente, int valorTotal, int vendedor)
        {

            Fecha = fecha;
            Cliente = cliente;
            ValorTotal = valorTotal;
            Vendedor = vendedor;
        }
        public void registrar()
        {
            int UltimaFactura = 0;

            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "INSERT INTO `facturas` (`facFecha`, `facCliente`, `facValorTotal`, `facVendedor`) VALUES ('" + Fecha + "', '" + Cliente + "', '" + ValorTotal + "', '" + Vendedor + "');";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();

            mySqlConnection.Close();



        }
    }
}
