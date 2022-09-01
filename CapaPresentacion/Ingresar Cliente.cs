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
    public partial class Ingresar_Cliente : Form
    {
        public Ingresar_Cliente()
        {
            InitializeComponent();
        }

        private void buttonIngresar_Click(object sender, EventArgs e)
        {
           
            CE ce = new CE();
            CN cn = new CN();
            ce.Documento = int.Parse(txtDocumento.Text);
            ce.Nombre = txtNombre.Text;
            ce.Direccion = txtDireccion.Text;
            ce.Telefono = long.Parse(txtTelefono.Text);
            ce.Correo = txtCorreo.Text;
            MessageBox.Show("Se ha ingresado el cliente.");
            cn.CrearCliente(ce);

        }
        

            private void Limpiar_Click(object sender, EventArgs e)
        {
            txtCorreo.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtDocumento.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtTelefono.Text = string.Empty;
        }
    }
}
