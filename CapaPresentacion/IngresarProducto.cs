using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class IngresarProducto : Form
    {
        CE ce = new CE();
        CN cn = new CN();
        public IngresarProducto()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            
            ce.Codigo = int.Parse(txtCodigo.Text);
            ce.Descripcion = txtDescripcion.Text;
            ce.Valor = int.Parse(txtValor.Text);
            ce.Cantidad = int.Parse(txtCantidad.Text);
            MessageBox.Show("Se ha ingresado el producto.");
            cn.CrearProducto(ce);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtValor.Text = string.Empty;
            txtCantidad.Text = string.Empty;

        }
    }
}
