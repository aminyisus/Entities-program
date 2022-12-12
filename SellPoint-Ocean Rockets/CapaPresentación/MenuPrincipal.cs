
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_FinalP2.Menu_Principal;
using Proyecto_FinalP2.Menu_Principal.Sistema;
using CapaPresentación.Menu_Principal.Sistema;
using CapaNegocio;



namespace CapaPresentación
{
    public partial class MenuPrincipal : Form
    {

        private int xClick;
        private int yClick;


        string usuario;
        public MenuPrincipal(string usuario)
        {
            this.usuario = usuario;
            int xer = this.Location.X;
            int yer = this.Location.Y;
            this.Location = new Point(xer,yer);
            InitializeComponent();
        }


        private void MenuPrincipal_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void GrupoEntidades(Object Form)
        {
            if (this.panelPr.Controls.Count > 5)
                this.panelPr.Controls.RemoveAt(0);

            Form Ven = Form as Form;
            
            Ven.TopMost = true;
            Ven.Dock = DockStyle.Fill;
            Ven.MdiParent = this;
            this.panelPr.Controls.Add(Ven);
            this.panelPr.Tag = Ven;
            statusStrip1.Visible = true;
            Ven.Show();
            Ven.BringToFront();
        }
        
       
        

        private void TipoEntidades(Object Form)
        {
            if (this.panelPr.Controls.Count > 5)
                this.panelPr.Controls.RemoveAt(0);

            Form Ven = Form as Form;
            Ven.TopMost = true;
            Ven.Dock = DockStyle.Fill;
            Ven.MdiParent = this;
            this.panelPr.Controls.Add(Ven);
            this.panelPr.Tag = Ven;
            Ven.Show();
            Ven.BringToFront();
        }

        private void Entidades(Object Form)
        {
            if (this.panelPr.Controls.Count > 5)
                this.panelPr.Controls.RemoveAt(0);

            Form Ven = Form as Form;
            Ven.TopLevel = false;
            Ven.Dock = DockStyle.Fill;
            Ven.MdiParent = this;
            this.panelPr.Controls.Add(Ven);
            this.panelPr.Tag = Ven;
            Ven.Show();
            Ven.BringToFront();
        }
        private void AcercaDe(Object Form)
        {
            if (this.panelPr.Controls.Count > 4)
                this.panelPr.Controls.RemoveAt(0);

            Form Ven = Form as Form;
            Ven.TopLevel = false;
            Ven.Dock = DockStyle.Fill;
            Ven.MdiParent = this;
            this.panelPr.Controls.Add(Ven);
            this.panelPr.Tag = Ven;
            Ven.Show();
            Ven.BringToFront();
        }

        private void MenuPrincipal_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void MenuPrincipal_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
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

        public void grupoEntidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrupoEntidades(new GrupoEntidades());
            panelPrincipal.Visible = false;
            panelIzquierdo.Visible = false;

        }

        private void tipoEntidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TipoEntidades(new Tipos_Entidades());
            panelPrincipal.Visible = false;
            panelIzquierdo.Visible = false;

        }

        private void entidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entidades(new Entidades());
            panelPrincipal.Visible = false;
            panelIzquierdo.Visible = false;
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcercaDe(new AcercaDe());
            panelPrincipal.Visible = false;
            panelIzquierdo.Visible = false;

        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Dispose();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MostrarFecha_Tick(object sender, EventArgs e)
        {
            //lblHora.Text = DateTime.Now.ToLongTimeString(); Fecha larga
            //lblHora.Text = DateTime.Now.ToShortTimeString(); Fecha corta
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
            //lblFecha.Text = DateTime.Now.ToLongDateString();
            lblFecha.Text = DateTime.Now.ToString("dd MMMM yyy");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        Login lg = new Login();
        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            Datos.Text = lg.MostrarUsuario(usuario);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
