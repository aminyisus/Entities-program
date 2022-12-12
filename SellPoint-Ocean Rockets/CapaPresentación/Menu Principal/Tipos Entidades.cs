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

namespace Proyecto_FinalP2.Menu_Principal
{
    public partial class Tipos_Entidades : Form
    {
        N_TiposEntidades ntent=new N_TiposEntidades();
        private int xClick;
        private int yClick;

        private int id=0;
        public Tipos_Entidades()
        {
            InitializeComponent();

            CargarDatos();
            CargarComboBoxes();
        }

        private void CargarDatos(){
            grvTiposEntidades.DataSource=ntent.Listar();
        }

        private void CargarComboBoxes(){
            cmbGrEnt.Items.Clear();

            string[] grEnt=ntent.CargarGrEntidad();

            for (int i = 0; i < grEnt.Length; i++)
            {
                cmbGrEnt.Items.Add(grEnt[i]);
                cmbGrEnt.SelectedIndex = 0;
            }
        }

        private void panelPrincipal_MouseMove(object sender, MouseEventArgs e)
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

        private void Minimizar_MouseHover(object sender, EventArgs e)
        {
            Color color = Color.FromArgb(60, Color.White);
            Minimizar.BackColor = color;
        }

        private void Minimizar_MouseLeave(object sender, EventArgs e)
        {
            Minimizar.BackColor = Color.Transparent;
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string desc = txtDesc.Text;
            int grEnt = Convert.ToInt32(cmbGrEnt.Text);
            string comment = txtComment.Text;
            string status = cmbStatus.Text;
            bool noElim = chkNoElim.Checked;

            if (desc==""){
                MessageBox.Show("Todos los campos terminados en asterisco (*) son requeridos\ndebe rellenar al menos los siguientes campos:" +
                    "\nDescripcion","Debe rellenar todos los campos requeridos");
            }else{
                int result=ntent.Insert(desc, grEnt, comment, status, noElim);

                switch (result)
                {
                    case 1:
                        LimpiarCampos();
                        CargarDatos();
                        CargarComboBoxes();
                        MessageBox.Show("Datos agregados con exito en la base de datos",
                    "Operacion exitosa");
                        break;

                    case 3:
                        MessageBox.Show("Se ha detectado un error referente a la conexion con SQL:\n" + ntent.msg,
                    "Error de SQL");
                        break;

                    case 4:
                        MessageBox.Show("Se ha detectado un error inesperado:\n" + ntent.msg,
                    "Error");
                        break;
                }
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            string desc = txtDesc.Text;
            int grEnt = Convert.ToInt32(cmbGrEnt.Text);
            string comment = txtComment.Text;
            string status = cmbStatus.Text;
            bool noElim = chkNoElim.Checked;

            if(desc==""){
                MessageBox.Show("Todos los campos terminados en asterisco (*) son requeridos\ndebe rellenar al menos los siguientes campos:" +
                    "\nDescripcion","Debe rellenar todos los campos requeridos");
            }else{
                int result =ntent.Update(id, desc, grEnt, comment, status, noElim);

                switch (result)
                {
                    case 1:
                        LimpiarCampos();
                        CargarDatos();
                        CargarComboBoxes();
                        MessageBox.Show("Datos actualizados con exito en la base de datos",
                    "Operacion exitosa");
                        break;

                    case 3:
                        MessageBox.Show("Se ha detectado un error referente a la conexion con SQL:\n" + ntent.msg,
                    "Error de SQL");
                        break;

                    case 4:
                        MessageBox.Show("Se ha detectado un error inesperado:\n" + ntent.msg,
                    "Error");
                        break;
                }
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            int result=ntent.Delete(id);
            switch (result)
            {
                case 1:
                    LimpiarCampos();
                    CargarDatos();
                    CargarComboBoxes();
                    MessageBox.Show("Datos eliminados con exito en la base de datos",
                "Operacion exitosa");
                    break;

                case 3:
                    MessageBox.Show("Se ha detectado un error referente a la conexion con SQL:\n" + ntent.msg,
                "Error de SQL");
                    break;

                case 4:
                    MessageBox.Show("Se ha detectado un error inesperado:\n" + ntent.msg,
                "Error");
                    break;
            }
        }

        private void LimpiarCampos()
        {
            txtID.Text = "0";
            txtComment.Text = "";
            txtDesc.Text = "";
            cmbGrEnt.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            chkNoElim.Checked = false;

            btnadd.Enabled = true;
            btndelete.Enabled = false;
            btnupdate.Enabled = false;
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string param = txtSearch.Text;

            if (param == "")
            {
                grvTiposEntidades.DataSource = ntent.Listar();
            }
            else
            {
                grvTiposEntidades.DataSource = ntent.Buscar(param);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnrefrescar_Click(object sender, EventArgs e)
        {
            grvTiposEntidades.DataSource = ntent.Listar();
        }

        private void grvTiposEntidades_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(grvTiposEntidades.CurrentRow.Cells[0].Value.ToString());
            txtID.Text = grvTiposEntidades.CurrentRow.Cells[0].Value.ToString();
            txtDesc.Text = grvTiposEntidades.CurrentRow.Cells[1].Value.ToString();
            cmbGrEnt.Text = grvTiposEntidades.CurrentRow.Cells[2].Value.ToString();
            txtComment.Text = grvTiposEntidades.CurrentRow.Cells[3].Value.ToString();
            cmbStatus.Text = grvTiposEntidades.CurrentRow.Cells[4].Value.ToString();
            chkNoElim.Checked = Convert.ToBoolean(grvTiposEntidades.CurrentRow.Cells[5].Value.ToString());

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
