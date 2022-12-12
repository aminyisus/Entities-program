using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentación.Menu_Principal.Sistema
{
    public partial class GrupoEntidades : Form
    {
        N_GruposEntidades ngent=new N_GruposEntidades();
        private int xClick;
        private int yClick;

        private int id = 0;

        public GrupoEntidades()
        {
            InitializeComponent();

            CargarDatos();
        }

        private void CargarDatos()
        {
            grvGruposEntidades.DataSource = ngent.Listar();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
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

        private void Cerrar_MouseHover(object sender, EventArgs e)
        {
            Cerrar.BackColor = Color.Red;
        }

        private void Cerrar_MouseLeave(object sender, EventArgs e)
        {
            Cerrar.BackColor = Color.Transparent;
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Minimizar_MouseHover(object sender, EventArgs e)
        {
            Color color = Color.FromArgb(60, Color.White);
            Minimizar.BackColor = color;
        }

        private void Minimizar_MouseLeave(object sender, EventArgs e)
        {
            Minimizar.BackColor = Color.Transparent;
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            string desc = txtDesc.Text;
            string comment = txtComment.Text;
            string status = cmbStatus.Text;
            bool noElim = chkNoElim.Checked;

            if (desc == "")
            {
                MessageBox.Show("Todos los campos terminados en asterisco (*) son requeridos\ndebe rellenar al menos los siguientes campos:" +
                    "\nDescripcion", "Debe rellenar todos los campos requeridos");
            }
            else
            {
                int result=ngent.Update(id, desc, comment, status, noElim);

                switch (result)
                {
                    case 1:
                        LimpiarCampos();
                        CargarDatos();
                        MessageBox.Show("Datos actualizados con exito en la base de datos",
                    "Operacion exitosa");
                        break;

                    case 3:
                        MessageBox.Show("Se ha detectado un error referente a la conexion con SQL:\n" + ngent.msg,
                    "Error de SQL");
                        break;

                    case 4:
                        MessageBox.Show("Se ha detectado un error inesperado:\n" + ngent.msg,
                    "Error");
                        break;
                }
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string param = txtSearch.Text;

            if (param == "")
            {
                MessageBox.Show("Por favor digite el id");
                grvGruposEntidades.DataSource = ngent.Listar();
            }
            else
            {
                grvGruposEntidades.DataSource = ngent.Buscar(param);

            }
            
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            string desc = txtDesc.Text;
            string comment = txtComment.Text;
            string status = cmbStatus.Text;
            bool noElim = chkNoElim.Checked;

            if (desc == "")
            {
                MessageBox.Show("Todos los campos terminados en asterisco (*) son requeridos\ndebe rellenar al menos los siguientes campos:" +
                    "\nDescripcion", "Debe rellenar todos los campos requeridos");
            }
            else
            {
                int result=ngent.Insert(desc, comment, status, noElim);

                switch (result)
                {
                    case 1:
                        LimpiarCampos();
                        CargarDatos();
                        MessageBox.Show("Datos insertados con exito en la base de datos",
                    "Operacion exitosa");
                        break;

                    case 3:
                        MessageBox.Show("Se ha detectado un error referente a la conexion con SQL:\n" + ngent.msg,
                    "Error de SQL");
                        break;

                    case 4:
                        MessageBox.Show("Se ha detectado un error inesperado:\n" + ngent.msg,
                    "Error");
                        break;
                }
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            int result = ngent.Delete(id);

            switch (result)
            {
                case 1:
                    LimpiarCampos();
                    CargarDatos();
                    MessageBox.Show("Datos eliminados con exito en la base de datos",
                "Operacion exitosa");
                    break;

                case 3:
                    MessageBox.Show("Se ha detectado un error referente a la conexion con SQL:\n" + ngent.msg,
                "Error de SQL");
                    break;

                case 4:
                    MessageBox.Show("Se ha detectado un error inesperado:\n" + ngent.msg,
                "Error");
                    break;
            }
        }

        private void LimpiarCampos()
        {
            txtID.Text = "0";
            txtComment.Text = "";
            txtDesc.Text = "";
            cmbStatus.SelectedIndex = 0;
            chkNoElim.Checked = false;

            btnadd.Enabled = true;
            btndelete.Enabled = false;
            btnupdate.Enabled = false;
        }

        private void grvGruposEntidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnrefrescar_Click(object sender, EventArgs e)
        {
            grvGruposEntidades.DataSource = ngent.Listar();
        }

        private void grvGruposEntidades_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(grvGruposEntidades.CurrentRow.Cells[0].Value.ToString());
            txtID.Text = grvGruposEntidades.CurrentRow.Cells[0].Value.ToString();
            txtDesc.Text = grvGruposEntidades.CurrentRow.Cells[1].Value.ToString();
            txtComment.Text = grvGruposEntidades.CurrentRow.Cells[2].Value.ToString();
            cmbStatus.Text = grvGruposEntidades.CurrentRow.Cells[3].Value.ToString();
            chkNoElim.Checked = Convert.ToBoolean(grvGruposEntidades.CurrentRow.Cells[4].Value.ToString());

            btnadd.Enabled = false;
            btnupdate.Enabled = true;
            btndelete.Enabled = true;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            this.BringToFront();
        }
    }
}
