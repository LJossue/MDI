﻿using System;
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
    public partial class EliminarProducto : Form
    {
        CN cn = new CN();
        CE ce = new CE();
        public EliminarProducto()
        {
            InitializeComponent();
        }

        private void gridDatos_DoubleClick(object sender, EventArgs e)
        {
            txtCodigo.Text = gridDatos.CurrentRow.Cells["proCodigo"].Value.ToString();
            txtNombre.Text = gridDatos.CurrentRow.Cells["proDescripción"].Value.ToString();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            ce.Codigo = int.Parse(txtCodigo.Text);
            cn.EliminarPro(ce);
            CargarDatos();
        }
        private void CargarDatos()
        {
            gridDatos.DataSource = cn.ObtenerDatosPro().Tables["tbl"];
        }

        private void EliminarProducto_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
