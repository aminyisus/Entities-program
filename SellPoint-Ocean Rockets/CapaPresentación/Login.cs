using Proyecto_FinalP2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;


namespace CapaPresentación
{
    
    public partial class Login : Form
    {
        private int xClick;
        private int yClick;

        public static string usuario = string.Empty;


        public Login()
        {

            InitializeComponent();
 
        }

/*
        public void StartForm()
        {
            Application.Run(new SplashScreen());
        }
*/
        private void MainScreen_Load(object sender, EventArgs e)
        {

        }

        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text == "Usuario:")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.LightGray;                                              
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "Usuario:";
                txtuser.ForeColor = Color.DimGray;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "Contraseña:")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "Contraseña:";
                txtpass.ForeColor = Color.DimGray;
                txtpass.UseSystemPasswordChar = false;
            }
        }

       
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        
        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void btnCerrar_MouseHover(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.Red;
        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.Transparent;
        }

        private void btnMinimizar_MouseHover(object sender, EventArgs e)
        {
            Color color = Color.FromArgb(60, Color.White);
            btnMinimizar.BackColor = color;
        }

        private void btnMinimizar_MouseLeave(object sender, EventArgs e)
        {
            btnMinimizar.BackColor = Color.Transparent;
        }

        public string MostrarUsuario(string user)
        {
            N_Login objecto = new N_Login();
            DataTable tb = objecto.MostrarUsuario(user);

            string UserNameEntidad = tb.Rows[0][0].ToString();
            string Direccion = tb.Rows[0][1].ToString();
            string Localidad = tb.Rows[0][2].ToString();
            string Telefonos = tb.Rows[0][3].ToString();
            string RolUserEntidad = tb.Rows[0][4].ToString();


            string fecha = DateTime.Now.ToString("HH:mm:ss");

            string datos  = " Usuario: " + UserNameEntidad
                 + " | Hora actual: " + fecha + " | Dirección: " + Direccion
                 + " | Localidad: " + Localidad
                 + " | Teléfono: " + Telefonos
                 + " | RolUserEntidad: " + RolUserEntidad;
            return datos;
        }

        public string Datos(string datos)
        {
            return datos;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            usuario = txtuser.Text;
            string pass = txtpass.Text;

            N_Login login = new N_Login();
            MenuPrincipal main = new MenuPrincipal(usuario);
            int acc = login.Login(usuario, pass);


            if (acc == 1)
            {
                main.Show();
                this.Hide();
                MostrarUsuario(usuario);
                

            }
            else if (acc == 0)
            {
                Error.Visible = true;
                Error.Text = "        Usuario y/ o contraseña incorrectos"; 
            }
            else
            {
                MessageBox.Show(login.msg, "Error");

            }
        }

       
        private void btnLogin_KeyDown(object sender, KeyEventArgs e)
        {

        }

        

      

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtpass.Text == "hola")
                {
                    MessageBox.Show("Correcto!");
                }
                if (txtuser.Text == "hola")
                {
                    MessageBox.Show("Correcto!");
                }
            }
        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
