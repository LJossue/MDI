using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CapaNegocio;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class ConsultarCliente : Form
    {
        string CadenaConexion = "server=localhost;User=root;Password=admin;Port=3306;database=naturvida;";
        CN cn = new CN();
        CE ce = new CE();
        public ConsultarCliente()
        {
            InitializeComponent();
        }

        private void ConsultarCliente_Load(object sender, EventArgs e)
        {
            gridDatos.DataSource = cn.ObtenerDatosCli().Tables["tbl"];
        }

        private void buttonConsulta_Click(object sender, EventArgs e)
        {
            ce.Consultar2 = txtconsulta.Text;
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "select * from clientes where cliNombre LIKE ('" + ce.Consultar2 + "%')";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
            mySqlDataAdapter.Fill(dataTable);
            gridDatos.DataSource = dataTable;


            mySqlConnection.Close();
        }
    }
}
