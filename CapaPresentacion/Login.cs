using System.Runtime.InteropServices;
namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        int m, mx, my;

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminus_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;

        }

       

        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
          if(m==1)
            {
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void TitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MDI mdi = new MDI();
            mdi.Show();

        }

        //private bool ValidarCampos()
        //{
        //    bool validar = true;
        //    if (textemail.Text == "")
        //    {
        //        validar = false;
        //        errorProvider1.SetError(textemail, "Digite su correo electronico");
        //    }
        //    if (textpassword.Text == "")
        //    {
        //        validar = false;
        //        errorProvider1.SetError(textpassword, "Digite su contraseña");
        //    }
        //    return validar;
        //}

    }
}