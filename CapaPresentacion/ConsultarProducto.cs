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
using CapaNegocio;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class ConsultarProducto : Form
    {
        CN cn = new CN();   
        public ConsultarProducto()
        {
            InitializeComponent();
        }

        private void ConsultarProducto_Load(object sender, EventArgs e)
        {
            gridDatos.DataSource = cn.ObtenerDatosPro().Tables["tbl"];
            comboBox.DataSource = cn.ObtenerDatosPro().Tables["tbl"];
        }
    }
}
