using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class EliminarCliente : Form
    {
        CN cn = new CN();
        CE ce = new CE();
        public EliminarCliente()
        {
            InitializeComponent();
        }

        private void gridDatos_DoubleClick(object sender, EventArgs e)
        {
            txtDocumento.Text = gridDatos.CurrentRow.Cells["cliDocumento"].Value.ToString();
            txtNombre.Text = gridDatos.CurrentRow.Cells["cliNombre"].Value.ToString();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            ce.Documento = int.Parse(txtDocumento.Text);
            cn.EliminarCli(ce);
            CargarDatos();

        }
        private void CargarDatos()
        {
            gridDatos.DataSource = cn.ObtenerDatosCli().Tables["tbl"];
        }

        private void EliminarCliente_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
