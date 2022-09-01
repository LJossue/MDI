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

namespace CapaPresentacion
{
    public partial class ModificarCliente : Form
    {
        CE ce = new CE();
        CN cn = new CN();
        public ModificarCliente()
        {
            InitializeComponent();
        }

        private void CargarDatos()
        {
            gridDatos.DataSource = cn.ObtenerDatosCli().Tables["tbl"];
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            ce.Documento = int.Parse(txtDocumento.Text);
            ce.Nombre = txtNombre.Text;
            ce.Telefono = long.Parse(txtTelefono.Text);
            ce.Direccion = txtDireccion.Text;
            ce.Correo = txtCorreo.Text;
            cn.EditarCli(ce);
            CargarDatos();
        }

        private void ModificarCliente_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void gridDatos_DoubleClick(object sender, EventArgs e)
        {
            txtDocumento.Text = gridDatos.CurrentRow.Cells["cliDocumento"].Value.ToString();
            txtNombre.Text = gridDatos.CurrentRow.Cells["cliNombre"].Value.ToString();
            txtTelefono.Text = gridDatos.CurrentRow.Cells["cliTelefono"].Value.ToString();
            txtDireccion.Text = gridDatos.CurrentRow.Cells["cliDirección"].Value.ToString();
            txtCorreo.Text = gridDatos.CurrentRow.Cells["cliCorreo"].Value.ToString();
        }
    }
}
