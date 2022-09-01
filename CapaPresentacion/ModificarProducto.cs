using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using MySql.Data.MySqlClient;

namespace CapaPresentacion
{
    public partial class ModificarProducto : Form
    {
        string CadenaConexion = "server=localhost;User=root;Password=admin;Port=3306;database=naturvida;";
        CE ce = new CE();
        CN cn = new CN();
        public ModificarProducto()
        {
            InitializeComponent();

                
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            ce.Codigo = int.Parse(txtCodigo.Text);
            ce.Descripcion = txtDescripcion.Text;
            ce.Valor = int.Parse(txtValor.Text);
            ce.Cantidad = int.Parse(txtCantidad.Text);
            cn.EditarPro(ce);
            CargarDatos();
            

        }

        private void ModificarProducto_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txtCodigo.Text = gridDatos.CurrentRow.Cells["proCodigo"].Value.ToString();
            txtDescripcion.Text = gridDatos.CurrentRow.Cells["proDescripción"].Value.ToString();
            txtValor.Text = gridDatos.CurrentRow.Cells["proValor"].Value.ToString();
            txtCantidad.Text = gridDatos.CurrentRow.Cells["proCantidad"].Value.ToString();
        }

        private void CargarDatos()
        {
            gridDatos.DataSource = cn.ObtenerDatosPro().Tables["tbl"];
        }
    }
}
