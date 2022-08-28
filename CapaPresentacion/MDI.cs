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
    public partial class MDI : Form
    {
        private Productos productos;
        private Clientes clientes;
        private Facturar facturar;
        private Inventario inventario;
        public MDI()
        {
            InitializeComponent();
        }

        int m, mx, my;

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }

        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void TitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                productos = new Productos();
                productos.MdiParent = this;
               
                
                
                productos.Show();

           
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clientes = new Clientes();
            clientes.MdiParent = this;


            
            clientes.Show();

        }

        private void facturarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            facturar = new Facturar();
            facturar.MdiParent = this;



            facturar.Show();
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inventario = new Inventario();
            inventario.MdiParent = this;



            inventario.Show();
        }

        private void btnminus_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
