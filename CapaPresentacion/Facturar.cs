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
using CapaDatos;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Facturar : Form
    {
        string CadenaConexion = "server=localhost;User=root;Password=admin;Port=3306;database=naturvida;";
        CD cd = new CD();
        CN cn = new CN();
        CE ce = new CE();
        public Facturar()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnminus_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void añadir()
        {
            
        }

        private void Facturar_Load(object sender, EventArgs e)
        {
            txtCantidad.Text = "1";
            comboVendedor.DataSource = cn.DatosFacVen(ce);
            comboVendedor.DisplayMember = "venUsuario";
            comboVendedor.ValueMember = "venId";

            comboCliente.DataSource = cn.DatosFacCli(ce); //obtiene datos del cliente
            comboCliente.DisplayMember = "cliNombre"; //solo muestra el nombre
            comboCliente.ValueMember = "cliDocumento"; //pero su valor el el id

            comboProducto.DataSource = cn.DatosFacPro(ce);
            comboProducto.DisplayMember = "proDescripción";
            comboProducto.ValueMember = "proCodigo";
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            int Codigo = Convert.ToInt16(comboProducto.SelectedValue.ToString());
            String Producto = comboProducto.Text;
            String Cantidad = txtCantidad.Text;
            int Valor = cd.ConsultarPrecio(Codigo);
            gridFact.Rows.Add(Codigo, Producto, Cantidad, Valor);
            int NumeroFilas = gridFact.Rows.Count;
            int ValorTotal = 0;
            if(NumeroFilas > 1)
            {
                for (int i = 0; i < (NumeroFilas-1); i++)
                {
                    int Can = Convert.ToInt16(gridFact.Rows[i].Cells[2].Value.ToString());
                    int Val = Convert.ToInt16(gridFact.Rows[i].Cells[3].Value.ToString());
                    ValorTotal += Can * Val;
                }
                txtTotal.Text = ValorTotal.ToString();
            }
            else
            {
                txtTotal.Text = Valor.ToString();
            }
        }

        private void buttonTerminar_Click(object sender, EventArgs e)
        {
            int NumeroFilas = gridFact.Rows.Count;
            DateTime date = dateTimePicker1.Value;
            string dte = date.ToString("yyyy/MM/dd");
            int Cliente = Convert.ToInt32(comboCliente.SelectedValue.ToString());
            int Vendedor = Convert.ToInt16(comboVendedor.SelectedValue.ToString());
            int ValorTotal = Convert.ToInt16(txtTotal.Text.ToString());
            var RegistrarFactura = new CapaDatos.ClassFactura(dte, Cliente, ValorTotal, Vendedor);
            RegistrarFactura.registrar();
            for (int i =0; i < (NumeroFilas-1); i++)
            {
                int Producto = Convert.ToInt16(gridFact.Rows[i].Cells[0].Value.ToString());
                int Cantidad = Convert.ToInt16(gridFact.Rows[i].Cells[2].Value.ToString());
                var AgregarProducto = new CapaDatos.classFacturaDetalle(Producto, Cantidad);
                //AgregarProducto.Registrar();
            }
            System.Windows.Forms.MessageBox.Show("Se creo la factura con exito.");
        }
    }
}
