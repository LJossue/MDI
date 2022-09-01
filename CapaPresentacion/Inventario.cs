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

namespace CapaPresentacion
{
    public partial class Inventario : Form
    {
        string CadenaConexion = "server=localhost;User=root;Password=admin;Port=3306;database=naturvida;";
        CN cn = new CN();   
        public Inventario()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnminus_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            gridDatos.DataSource = cn.ObtenerDatosPro().Tables["tbl"];
        }

        private void buttonConsulta_Click(object sender, EventArgs e)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "select * from productos where proDescripción LIKE ('" + txtconsulta.Text + "%')";
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
