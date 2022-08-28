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
    public class CD
    {
        
        string CadenaConexion = "server=localhost;User=root;Password=admin;Port=3306;database=naturvida;";
        
            
        

        public void CrearCli(CE ce)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "INSERT INTO `clientes` (`CliDocumento`, `CliNombre`, `CliDirección`, `CliTelefono`, `CliCorreo`) VALUES ('" + ce.Documento + "', '"+ ce.Nombre +"', '"+ ce.Direccion +"', '"+ ce.Telefono +"', '"+ ce.Correo +"');";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
        public void CrearPro(CE ce)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "INSERT INTO `productos` (`proCodigo`, `proDescripción`, `proValor`, `proCantidad`) VALUES ('" + ce.Codigo + "', '" + ce.Descripcion + "', '" + ce.Valor + "', '" + ce.Cantidad + "');";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }

        public DataSet Listar()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "select * from `productos` limit 1000";
            MySqlDataAdapter Adaptador;
            DataSet dataSet = new DataSet();

            Adaptador = new MySqlDataAdapter(Query, mySqlConnection);
            Adaptador.Fill(dataSet, "tbl");
            return dataSet;

        }
    }
}
