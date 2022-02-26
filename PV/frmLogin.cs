using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PV
{
    public partial class frmLogin : Form
    {

        private UsuarioBLL usuarioBLL = UsuarioBLL.Instance();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }


        private void Clean()
        {
            txtUsuario.Text = "";
            txtPassword.Text = "";
            txtUsuario.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (usuarioBLL.Login(new BOL.Usuario()
            {
                nombre = txtUsuario.Text,
                password = txtPassword.Text
            }))
            {
                MessageBox.Show("Usuario valido", "Bienvenido",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmMain abrir = new frmMain();
                abrir.Show();
            }
            else
            {
                MessageBox.Show("Usuario Invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
