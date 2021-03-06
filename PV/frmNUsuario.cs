using BLL;
using BOL;
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
    public partial class frmNUsuario : Form
    {

        private UsuarioBLL usuarioBLL = UsuarioBLL.Instance();
        Usuario usuario = new Usuario();
        public int idUsuario = 0;
        public frmNUsuario()
        {
            InitializeComponent();
        }

        public frmNUsuario(int idUsuario)
        {
            
            InitializeComponent();
            this.idUsuario = idUsuario;
            usuario.idUsuario = idUsuario;

            txtNombre.Text = usuarioBLL.GetByID(usuario).nombre.ToString();
            txtPassword.Text = usuarioBLL.GetByID(usuario).password.ToString();

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void Clean()
        {
            txtNombre.Text = "";
            txtPassword.Text = "";
            txtNombre.Focus();
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (idUsuario > 0)
            {
                if (usuarioBLL.Update(new BOL.Usuario()
                {
                    idUsuario = idUsuario,
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
            else
            {
                if (usuarioBLL.Add(new BOL.Usuario()
                {
                    nombre = txtNombre.Text,
                    password = txtPassword.Text
                }))
                {
                    MessageBox.Show("Usuario agregado Correctamente", Application.ProductName,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clean();
                }
            }



            
        }

        private void frmNUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
