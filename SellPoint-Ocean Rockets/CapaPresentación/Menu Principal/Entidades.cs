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
    public partial class Entidades : Form
    {
        N_Entidades nent = new N_Entidades();

        private int xClick;
        private int yClick;
        private int id=0;
        public Entidades()
        {
            InitializeComponent();

            CargarDatos();
            CargarComboBoxes();
        }

        private void CargarDatos(){
            grvEntidades.DataSource=nent.Listar();
        }

        private void CargarComboBoxes(){
            cmbIdTpEnt.Items.Clear();
            cmbIdGrEnt.Items.Clear();

            string[] tpEnt=nent.CargarTpEntidad();
            string[] grEnt=nent.CargarGrEntidad();

            for (int i = 0; i < tpEnt.Length; i++)
            {
                cmbIdTpEnt.Items.Add(tpEnt[i]);
                cmbIdTpEnt.SelectedIndex = 0;
            }

            for (int i = 0; i < grEnt.Length; i++)
            {
                cmbIdGrEnt.Items.Add(grEnt[i]);
                cmbIdGrEnt.SelectedIndex = 0;
            }
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string desc = txtDesc.Text;
            string dir = txtDir.Text;
            string local = txtLocal.Text;
            string tpEnttxt = cmbTpEnt.Text;
            string tpDoc = cmbTpDoc.Text;
            string numeroDoc = numDoc.Text;
            string tel = txtTel.Text;
            string urlWeb = txtWeb.Text;
            string urlFB = txtFB.Text;
            string urlIG = txtIG.Text;
            string urlTW = txtTW.Text;
            string urlTK = txtTK.Text;
            int grEnt = Convert.ToInt32(cmbIdGrEnt.Text);
            int tpEnt = Convert.ToInt32(cmbIdTpEnt.Text);
            int limCred = (int)numCred.Value;
            string usu = txtUser.Text;
            string pass = txtPass.Text;
            string rol = cmbRol.Text;
            string comment = txtComment.Text;
            string status = boxStatus.Text;
            bool noElim = NoEliminable.Checked;

            if (desc == "" || dir == "" || local == "" || numeroDoc == ""
                || tel == "" || usu == "" || pass == "")
            {
                MessageBox.Show("Todos los campos terminados en asterisco (*) son requeridos\ndebe rellenar al menos los siguientes campos:" +
                    "\nDescripcion\nDireccion\nLocalidad\nNumero de Documento\nTelefonos\nUsuario\nContraseña",
                    "Debe rellenar todos los campos requeridos");
            }
            else
            {
                int result=nent.Insert(desc, dir, local, tpEnttxt, tpDoc, numeroDoc, tel, urlWeb, urlFB, urlIG, urlTW,
                urlTK, grEnt, tpEnt, limCred, usu, pass, rol, comment, status, noElim);

                switch (result)
                {
                    case 1:
                        LimpiarCampos();
                        CargarDatos();
                        CargarComboBoxes();
                        MessageBox.Show("Datos insertados con exito en la base de datos",
                    "Operacion exitosa");
                        break;

                    case 2:
                        MessageBox.Show("El limite de credito no puede ser menor a cero,\ncualquier monto registrado debe ser mayor a cero",
                    "Valor no soportado");
                        break;

                    case 3:
                        MessageBox.Show("Se ha detectado un error referente a la conexion con SQL:\n" +nent.msg,
                    "Error de SQL");
                        break;

                    case 4:
                        MessageBox.Show("Se ha detectado un error inesperado:\n" + nent.msg,
                    "Error");
                        break;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string param = txtBuscar.Text;

            if (param == "")
            {
                grvEntidades.DataSource = nent.Listar();
            }
            else
            {
                grvEntidades.DataSource = nent.Buscar(param);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string desc = txtDesc.Text;
            string dir = txtDir.Text;
            string local = txtLocal.Text;
            string tpEnttxt = cmbTpEnt.Text;
            string tpDoc = cmbTpDoc.Text;
            string numeroDoc = numDoc.Text;
            string tel = txtTel.Text;
            string urlWeb = txtWeb.Text;
            string urlFB = txtFB.Text;
            string urlIG = txtIG.Text;
            string urlTW = txtTW.Text;
            string urlTK = txtTK.Text;
            int grEnt = Convert.ToInt32(cmbIdGrEnt.Text);
            int tpEnt = Convert.ToInt32(cmbIdTpEnt.Text);
            int limCred = Convert.ToInt32(numCred.Value);
            string usu = txtUser.Text;
            string pass = txtPass.Text;
            string rol = cmbRol.Text;
            string comment = txtComment.Text;
            string status = boxStatus.Text;
            bool noElim = NoEliminable.Checked;

            if (desc == "" || dir == "" || local == "" || numeroDoc == ""
                || tel == "" || usu == "" || pass == "")
            {
                MessageBox.Show("Todos los campos terminados en asterisco (*) son requeridos\ndebe rellenar al menos los siguientes campos:" +
                    "\nDescripcion\nDireccion\nLocalidad\nNumero de Documento\nTelefonos\nUsuario\nContraseña",
                    "Debe rellenar todos los campos requeridos");
            }
            else
            {
                int intNoElim = noElim ? 1 : 0;
                int result = nent.Update(id, desc, dir, local, tpEnttxt, tpDoc, numeroDoc, tel, urlWeb, urlFB, urlIG, urlTW,
                urlTK, grEnt, tpEnt, limCred, usu, pass, rol, comment, status, intNoElim);

                switch (result)
                {
                    case 1:
                        LimpiarCampos();
                        CargarDatos();
                        CargarComboBoxes();
                        MessageBox.Show("Datos actualizados con exito en la base de datos",
                    "Operacion exitosa");
                        break;

                    case 2:
                        MessageBox.Show("El limite de credito no puede ser menor a cero,\ncualquier monto registrado debe ser mayor a cero",
                    "Valor no soportado");
                        break;

                    case 3:
                        MessageBox.Show("Se ha detectado un error referente a la conexion con SQL:\n" + nent.msg,
                    "Error de SQL");
                        break;

                    case 4:
                        MessageBox.Show("Se ha detectado un error inesperado:\n" + nent.msg,
                    "Error");
                        break;
                }
            }

            //MessageBox.Show(limCred.ToString());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int result=nent.Delete(id);
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
                    MessageBox.Show("Se ha detectado un error referente a la conexion con SQL:\n" + nent.msg,
                "Error de SQL");
                    break;

                case 4:
                    MessageBox.Show("Se ha detectado un error inesperado:\n" + nent.msg,
                "Error");
                    break;
            }
        }

        private void grvEntidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void grvEntidades_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grvEntidades.CurrentRow.Index != grvEntidades.Rows.Count - 1)
            {
                switch (grvEntidades.CurrentRow.Cells[5].Value.ToString())
                {
                    case "RNC":
                        numDoc.Mask = "999-99999-9";
                        break;

                    case "Cédula":
                        numDoc.Mask = "999-9999999-9";
                        break;

                    case "Pasaporte":
                        numDoc.Mask = "999999999";
                        break;
                }

                id = Convert.ToInt32(grvEntidades.CurrentRow.Cells[0].Value.ToString());
                txtID.Text = grvEntidades.CurrentRow.Cells[0].Value.ToString();
                txtDesc.Text = grvEntidades.CurrentRow.Cells[1].Value.ToString();
                txtDir.Text = grvEntidades.CurrentRow.Cells[2].Value.ToString();
                txtLocal.Text = grvEntidades.CurrentRow.Cells[3].Value.ToString();
                cmbTpEnt.Text = grvEntidades.CurrentRow.Cells[4].Value.ToString();
                cmbTpDoc.Text = grvEntidades.CurrentRow.Cells[5].Value.ToString();
                numDoc.Text = grvEntidades.CurrentRow.Cells[6].Value.ToString();
                txtTel.Text = grvEntidades.CurrentRow.Cells[7].Value.ToString();
                txtWeb.Text = grvEntidades.CurrentRow.Cells[8].Value.ToString();
                txtFB.Text = grvEntidades.CurrentRow.Cells[9].Value.ToString();
                txtIG.Text = grvEntidades.CurrentRow.Cells[10].Value.ToString();
                txtTW.Text = grvEntidades.CurrentRow.Cells[11].Value.ToString();
                txtTK.Text = grvEntidades.CurrentRow.Cells[12].Value.ToString();
                cmbIdGrEnt.Text = grvEntidades.CurrentRow.Cells[13].Value.ToString();
                cmbIdTpEnt.Text = grvEntidades.CurrentRow.Cells[14].Value.ToString();
                numCred.Value = Convert.ToDecimal(grvEntidades.CurrentRow.Cells[15].Value.ToString());
                txtUser.Text = grvEntidades.CurrentRow.Cells[16].Value.ToString();
                txtPass.Text = grvEntidades.CurrentRow.Cells[17].Value.ToString();
                cmbRol.Text = grvEntidades.CurrentRow.Cells[18].Value.ToString();
                txtComment.Text = grvEntidades.CurrentRow.Cells[19].Value.ToString();
                boxStatus.Text = grvEntidades.CurrentRow.Cells[20].Value.ToString();
                NoEliminable.Checked = Convert.ToBoolean(grvEntidades.CurrentRow.Cells[21].Value.ToString());

                btnAgregar.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void LimpiarCampos()
        {
            txtID.Text = "0";
            txtDesc.Text = "";
            txtDir.Text = "";
            txtLocal.Text = "";
            cmbTpEnt.SelectedIndex = 0;
            cmbTpDoc.SelectedIndex = 0;
            numDoc.Text = "";
            txtTel.Text = "";
            txtWeb.Text = "Url Pagina Web";
            txtFB.Text = "Url Facebook";
            txtIG.Text = "Url Instagram";
            txtTW.Text = "Url Twitter";
            txtTK.Text = "Url TikTok";
            cmbIdGrEnt.SelectedIndex = 0;
            cmbIdTpEnt.SelectedIndex = 0;
            numCred.Value = 0;
            txtUser.Text = "";
            txtPass.Text = "";
            cmbRol.SelectedIndex = 0;
            txtComment.Text = "";
            boxStatus.SelectedIndex = 0;
            NoEliminable.Checked = false;

            btnAgregar.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void txtWeb_Enter(object sender, EventArgs e)
        {
            txtWeb.Text = txtWeb.Text == "Url Pagina Web" ? "" : txtWeb.Text;
        }

        private void txtWeb_Leave(object sender, EventArgs e)
        {
            txtWeb.Text = txtWeb.Text == "" ? "Url Pagina Web" : txtWeb.Text;
        }


        private void txtFB_Enter(object sender, EventArgs e)
        {
            txtFB.Text = txtFB.Text == "Url Facebook" ? "" : txtFB.Text;
        }

        private void txtFB_Leave(object sender, EventArgs e)
        {
            txtFB.Text = txtFB.Text == "" ? "Url Facebook" : txtFB.Text;
        }


        private void txtIG_Enter(object sender, EventArgs e)
        {
            txtIG.Text = txtIG.Text == "Url Instagram" ? "" : txtIG.Text;
        }

        private void txtIG_Leave(object sender, EventArgs e)
        {
            txtIG.Text = txtIG.Text == "" ? "Url Instagram" : txtIG.Text;
        }


        private void txtTW_Enter(object sender, EventArgs e)
        {
            txtTW.Text = txtTW.Text == "Url Twitter" ? "" : txtTW.Text;
        }

        private void txtTW_Leave(object sender, EventArgs e)
        {
            txtTW.Text = txtTW.Text == "" ? "Url Twitter" : txtTW.Text;
        }


        private void txtTK_Enter(object sender, EventArgs e)
        {
            txtTK.Text = txtTK.Text == "Url TikTok" ? "" : txtTK.Text;
        }

        private void txtTK_Leave(object sender, EventArgs e)
        {
            txtTK.Text = txtTK.Text == "" ? "Url TikTok" : txtTK.Text;
        }

        private void cmbTpDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTpDoc.SelectedIndex)
            {
                case 0:
                    numDoc.Mask = "999-99999-9";
                    break;

                case 1:
                    numDoc.Mask = "999-9999999-9";
                    break;

                case 2:
                    numDoc.Mask = "999999999";
                    break;
            }
        }

        private void numDoc_Enter(object sender, EventArgs e)
        {
            switch (cmbTpDoc.SelectedIndex)
            {
                case 0:
                    numDoc.Mask = "999-99999-9";
                    break;

                case 1:
                    numDoc.Mask = "999-9999999-9";
                    break;

                case 2:
                    numDoc.Mask = "999999999";
                    break;
            }
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            this.BringToFront();
        }
    }
}
