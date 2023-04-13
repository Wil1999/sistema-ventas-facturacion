using SISTEMA_PUNTO_VENTAS.CONTROLADOR;
using SISTEMA_PUNTO_VENTAS.LOGICA;
using SISTEMA_PUNTO_VENTAS.MODELO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISTEMA_PUNTO_VENTAS
{
    public partial class usuarios : Form
    {
        public usuarios()
        {
            InitializeComponent();
            MostrarUsuarios();
        }


        Controlador control = new Controlador();
        public string idUsuarioSelected;
        public string usuarioLogin;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (panelIcono.Visible)
            {
                MessageBox.Show("Seleccione un ícono.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtNombres.Text != "")
                {
                    if (txtUsuario.Text != "")
                    {
                        if (txtPass.Text != "")
                        {
                            if (txtCorreo.Text != "")
                            {
                                EditarUsuario();
                            }
                            else
                            {
                                MessageBox.Show("Ingrese un Correo Electrónico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ingrese una Contraseña correcta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un nombre de Usuario correcto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese sus Apellidos y Nombres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (panelIcono.Visible)
            {
                MessageBox.Show("Seleccione un ícono.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                    if (txtNombres.Text != "")
                    {
                        if (txtUsuario.Text != "")
                        {
                            if (txtPass.Text != "")
                            {
                                if (txtCorreo.Text != "" && control.ValidacionEmail(txtCorreo.Text))
                                {
                                if (cboRol.SelectedItem != null) {
                                    if (lblNumIcono.Text != "") {
                                        GuardarUsuario();
                                    }
                                    else {
                                        MessageBox.Show("Elige un Icono de Perfil.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                else {
                                    MessageBox.Show("Elige un Rol para el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                }
                                else
                                {
                                    MessageBox.Show("Ingrese un Correo Electrónico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtCorreo.Focus();
                                txtCorreo.SelectAll();
                            }
                            }
                            else
                            {
                                MessageBox.Show("Ingrese una Contraseña correcta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtPass.Focus();
                        }
                        }
                        else
                        {
                            MessageBox.Show("Ingrese un nombre de Usuario correcto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtUsuario.Focus();
                    }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese sus Apellidos y Nombres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombres.Focus();
                }
            }
        }

        private void GuardarUsuario() {
            UsuarioM model = new UsuarioM();
            UsuarioL cmd = new UsuarioL();
            model.NombresApellidos = txtNombres.Text;
            model.Login = txtUsuario.Text;
            model.Password = txtPass.Text;
            //
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            picIcono.Image.Save(ms, picIcono.Image.RawFormat);
            model.Icono = ms.GetBuffer();
            model.IconoNombre = lblNumIcono.Text;
            //
            model.Correo = txtCorreo.Text;
            model.Rol = cboRol.Text;
            cmd.guardar_usuarios(model);
            panelContorno.Visible = false;
            panelFormUsuario.Visible = false;
            //
            MostrarUsuarios();
            // 
        }

        private void EditarUsuario()
        {
            UsuarioM model = new UsuarioM();
            UsuarioL cmd = new UsuarioL();

            model.IdUsuario = Convert.ToInt32(idUsuarioSelected);
            model.NombresApellidos = txtNombres.Text;
            model.Login = txtUsuario.Text;
            model.Password = txtPass.Text;
            //
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            picIcono.Image.Save(ms, picIcono.Image.RawFormat);
            model.Icono = ms.GetBuffer();
            model.IconoNombre = lblNumIcono.Text;
            //
            model.Correo = txtCorreo.Text;
            model.Rol = cboRol.Text;
            cmd.editar_usuarios(model);
            panelContorno.Visible = false;
            panelFormUsuario.Visible = false;
            //
            MostrarUsuarios();
            // 
        }
        private void LimpiarFormulario() {
            idUsuarioSelected = "";
            txtNombres.Text = "";
            txtUsuario.Text = "";
            txtPass.Text = "";
            //
            picIcono.BackgroundImage = null;
            //
            lblNumIcono.Text = "";
            txtCorreo.Text = "";
            cboRol.SelectedIndex=-1;
        }

        private void MostrarUsuarios() {
            DataTable dt = new DataTable();
            UsuarioL cmd = new UsuarioL();
            cmd.mostrar_usuarios(ref dt);
            dataListaUsuario.DataSource = dt;
            //
            dataListaUsuario.Columns[1].Visible = false;
            dataListaUsuario.Columns[5].Visible = false;
            dataListaUsuario.Columns[6].Visible = false;
            dataListaUsuario.Columns[7].Visible = false;
            dataListaUsuario.Columns[8].Visible = false;
            dataListaUsuario.Columns[9].Visible = false;
            //
            dataListaUsuario.Columns[2].HeaderText = "Nombres";
            dataListaUsuario.Columns[3].HeaderText = "Usuario";
            dataListaUsuario.Columns[4].HeaderText = "Contraseña";
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            picIcono.Image = pictureBox3.Image;
            lblNumIcono.Text = "1";
            lblIcono.Visible = false;
            panelIcono.Visible = false;
        }

        private void lblIcono_Click(object sender, EventArgs e)
        {
            panelIcono.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            picIcono.Image = pictureBox4.Image;
            lblNumIcono.Text = "2";
            lblIcono.Visible = false;
            panelIcono.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            picIcono.Image = pictureBox5.Image;
            lblNumIcono.Text = "3";
            lblIcono.Visible = false;
            panelIcono.Visible = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            picIcono.Image = pictureBox3.Image;
            lblNumIcono.Text = "4";
            lblIcono.Visible = false;
            panelIcono.Visible = false;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            picIcono.Image = pictureBox3.Image;
            lblNumIcono.Text = "4";
            lblIcono.Visible = false;
            panelIcono.Visible = false;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            picIcono.Image = pictureBox8.Image;
            lblNumIcono.Text = "4";
            lblIcono.Visible = false;
            panelIcono.Visible = false;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            picIcono.Image = pictureBox9.Image;
            lblNumIcono.Text = "5";
            lblIcono.Visible = false;
            panelIcono.Visible = false;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            picIcono.Image = pictureBox3.Image;
            lblNumIcono.Text = "7";
            lblIcono.Visible = false;
            panelIcono.Visible = false;
        }

        private void usuarios_Load(object sender, EventArgs e)
        {
            panelFormUsuario.Visible = false;
            panelContorno.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panelFormUsuario.Visible = true;
            panelContorno.Visible = true;
            panelIcono.Visible = false;
            btnCambios.Visible = false;
            btnGuardar.Visible = true;

            picIcono.Image = null;
            lblIcono.Visible = true;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            panelIcono.Visible = false;
        }

        private void panelIcono_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picIcono_Click(object sender, EventArgs e)
        {
            panelIcono.Visible = true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            if (panelIcono.Visible)
            {
                MessageBox.Show("Seleccione un ícono.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                panelFormUsuario.Visible = false;
                panelContorno.Visible = false;
                LimpiarFormulario();
            }
        }

        private void dataListaUsuario_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            idUsuarioSelected = dataListaUsuario.SelectedCells[1].Value.ToString();
            txtNombres.Text = dataListaUsuario.SelectedCells[2].Value.ToString();
            txtUsuario.Text = dataListaUsuario.SelectedCells[3].Value.ToString();
            txtPass.Text = dataListaUsuario.SelectedCells[4].Value.ToString();
            lblNumIcono.Text = dataListaUsuario.SelectedCells[6].Value.ToString();
            //
            picIcono.BackgroundImage = null;
            lblIcono.Visible = false;
            Byte[] b = (Byte[]) dataListaUsuario.SelectedCells[5].Value;
            MemoryStream ms = new MemoryStream(b);
            picIcono.Image = Image.FromStream(ms);
            if (lblNumIcono.Text.Length > 1)
            {
                picIcono.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else {
                picIcono.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            //
            txtCorreo.Text = dataListaUsuario.SelectedCells[7].Value.ToString();
            cboRol.Text = dataListaUsuario.SelectedCells[8].Value.ToString();

            //
            panelFormUsuario.Visible = true;
            panelContorno.Visible = true;
            panelIcono.Visible = false;
            //
            btnCambios.Visible = true;
            btnGuardar.Visible = false;
        }

        private void dataListaUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dataListaUsuario.Columns["Eliminar"].Index) {
                idUsuarioSelected = dataListaUsuario.SelectedCells[1].Value.ToString();
                usuarioLogin = dataListaUsuario.SelectedCells[3].Value.ToString();
                EliminarUsuarios();
                MostrarUsuarios();
            }
        }

        private void EliminarUsuarios() {
            UsuarioL cmd = new UsuarioL();
            UsuarioM model = new UsuarioM();
            DialogResult respuesta;
            respuesta = MessageBox.Show("¿Realmente desea eliminar este Usuario?","Eliminando",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (respuesta == DialogResult.OK) {
                model.IdUsuario = Convert.ToInt32(idUsuarioSelected);
                model.Login = usuarioLogin;
                cmd.eliminar_usuarios(model);
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            dlgSubirIcono.InitialDirectory = "";
            dlgSubirIcono.Filter = "Imagenes|*.jpg;*.png";
            dlgSubirIcono.FilterIndex = 2;
            dlgSubirIcono.Title = "Subiendo Imagenes";
            if (dlgSubirIcono.ShowDialog() == DialogResult.OK) {
                picIcono.BackgroundImage = null;
                picIcono.Image = new Bitmap(dlgSubirIcono.FileName);
                picIcono.SizeMode = PictureBoxSizeMode.Zoom;
                lblNumIcono.Text = Path.GetDirectoryName(dlgSubirIcono.FileName);
                lblIcono.Visible = false;
                panelIcono.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gracias por preferirnos!! \n QUALITY SYSTEMS \n Innovation for Success","Cerrando Sesión",MessageBoxButtons.OK,MessageBoxIcon.Information);
            System.Windows.Forms.Application.Exit();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarUsuario(txtBuscar.Text);
        }

        private void BuscarUsuario(string letra) {
            DataTable dt = new DataTable();
            UsuarioL cmd = new UsuarioL();
            cmd.buscar_usuarios(ref dt,letra);
            dataListaUsuario.DataSource = dt;
            //
            dataListaUsuario.Columns[1].Visible = false;
            dataListaUsuario.Columns[5].Visible = false;
            dataListaUsuario.Columns[6].Visible = false;
            dataListaUsuario.Columns[7].Visible = false;
            dataListaUsuario.Columns[8].Visible = false;
            dataListaUsuario.Columns[9].Visible = false;
            //
            dataListaUsuario.Columns[2].HeaderText = "Nombres";
            dataListaUsuario.Columns[3].HeaderText = "Usuario";
            dataListaUsuario.Columns[4].HeaderText = "Contraseña";
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            control.SoloNumeros(txtPass, e);
        }
    }
}
