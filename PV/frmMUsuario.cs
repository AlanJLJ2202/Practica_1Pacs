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
    public partial class frmMUsuario : Form
    {
        UsuarioBLL usuarioBLL = UsuarioBLL.Instance();


        public frmMUsuario()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Clean()
        {
            txtPassword.Text = "";
            txtNombre.Text = "";
            txtID.Text = "";
            txtID.Focus();
        }


        private void frmMUsuario_Load(object sender, EventArgs e)
        {
           
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (usuarioBLL.Update(new BOL.Usuario()
            {
                idUsuario = int.Parse(txtID.Text),
                nombre = txtNombre.Text,
                password = txtPassword.Text

            }))
            {
                MessageBox.Show("Usuario actualizada", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clean();
            }
            else
                MessageBox.Show("Usuario no actualizada", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clean();
        }
    }
    }

