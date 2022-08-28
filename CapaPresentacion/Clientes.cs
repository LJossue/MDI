using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnminus_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private Form activeform = null;
        private void OpenChildForm(Form ChildForm)
        {
            if (activeform != null)

                activeform.Close();
            activeform = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(ChildForm);
            panelChildForm.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();

        }

        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Ingresar_Cliente());
        }

        private void buttonConsultar_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ConsultarCliente());
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ModificarCliente());
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EliminarCliente());
        }
    }
}
