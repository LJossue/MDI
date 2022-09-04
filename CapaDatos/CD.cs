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

        public DataSet ListarProductos()
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

        public DataSet ListarClientes()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "select * from `clientes` limit 1000";
            MySqlDataAdapter Adaptador;
            DataSet dataSet = new DataSet();

            Adaptador = new MySqlDataAdapter(Query, mySqlConnection);
            Adaptador.Fill(dataSet, "tbl");
            return dataSet;

        }

        public void EditarProductos(CE ce)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "UPDATE `productos` SET `proDescripción`= '"+ ce.Descripcion +"', `proValor`= '"+ ce.Valor +"', `proCantidad`= '"+ ce.Cantidad + "' WHERE `proCodigo` = " + ce.Codigo +";";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Producto Actualizado.");

        }
        public void EditarClientes(CE ce)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "UPDATE `clientes` SET `cliNombre`= '" + ce.Nombre + "', `cliTelefono`= '" + ce.Telefono + "', `cliDirección`= '" + ce.Direccion + "', `cliCorreo`= '"+ ce.Correo +"' WHERE `cliDocumento` = " + ce.Documento + ";";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Cliente Actualizado.");

        }

        public void EliminarProductos(CE ce)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "Delete from `productos` where `proCodigo` ="+ ce.Codigo + ";";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Producto Eliminado.");

        }
        public void EliminarClientes(CE ce)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "Delete from `clientes` where `cliDocumento` =" + ce.Documento + ";";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Cliente Eliminado.");

        }

        public DataTable ListarFacClientes(CE ce)
        {
            var tabla = new DataTable();
            try
            {
                using (var adaptador = new MySqlDataAdapter("select cliDocumento, cliNombre from clientes", CadenaConexion))
                {
                    adaptador.SelectCommand.CommandType = CommandType.Text;
                    adaptador.Fill(tabla);
                }

            }
            catch (MySqlException e)
            {

                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            return tabla;
        }
        public DataTable ListarFacProductos(CE ce)
        {
            var tabla = new DataTable();
            try
            {
                using (var adaptador = new MySqlDataAdapter("select proCodigo, proDescripción from productos", CadenaConexion))
                {
                    adaptador.SelectCommand.CommandType = CommandType.Text;
                    adaptador.Fill(tabla);
                }

            }
            catch (MySqlException e)
            {

                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            return tabla;
        }
        public DataTable ListarFacVendedores(CE ce)
        {
            var tabla = new DataTable();
            try
            {
                using (var adaptador = new MySqlDataAdapter("select venId, venUsuario from vendedores", CadenaConexion))
                {
                    adaptador.SelectCommand.CommandType = CommandType.Text;
                    adaptador.Fill(tabla);
                }

            }
            catch (MySqlException e)
            {

                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            return tabla;
        }
        public int ConsultarPrecio(int Codigo)
        {
            int Precio = 0;
            DataTable tabla = new DataTable();
            try
            {
                using (var adaptador = new MySqlDataAdapter("select proValor from productos where proCodigo=" + Codigo, CadenaConexion))
                {
                    adaptador.SelectCommand.CommandType = CommandType.Text;
                    adaptador.Fill(tabla);
                    Precio = Convert.ToInt16(tabla.Rows[0][0]);
                }

            }
            catch (MySqlException e)
            {

                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            return Precio;
        }

    }
}
