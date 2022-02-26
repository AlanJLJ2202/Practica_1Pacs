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
    public partial class frmMCategoria : Form
    {
        CategoriaBLL categoriaBLL = CategoriaBLL.Instance();

        public frmMCategoria()
        {
            InitializeComponent();
        }

        private void frmMCategoria_Load(object sender, EventArgs e)
        {

        }

        private void Clean()
        {
            txtDescripcion.Text = "";
            txtID.Text = "";
            txtDescripcion.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (categoriaBLL.Update(new BOL.Categoria()
            {
                idCategoria = int.Parse(txtID.Text),
                descripcion = txtDescripcion.Text

            }))
            {
                MessageBox.Show("Categoria actualizada", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clean();
            }
            else
                MessageBox.Show("categoria no actualizada", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clean();
        }
    }
}
