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
    public class classFacturaDetalle
    {
        string CadenaConexion = "server=localhost;User=root;Password=admin;Port=3306;database=naturvida;";

        public classFacturaDetalle( int producto, int cantidad)
        {

            Producto = producto;
            Cantidad = cantidad;
        }

        public int Producto { get; set; }
        public int Cantidad { get; set; }

        public bool Registrar()
        {
            bool i = false;
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
                mySqlConnection.Open();
                string Query = "INSERT INTO `facturadetalle` ( `facProducto`, `facCantidad`) VALUES ('" + Producto + "', '" + Cantidad + "');";
                MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();
                i = true;
            }
            catch (MySqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return false;
            }
            return i;
        }
        
    }

}
