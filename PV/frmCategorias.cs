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
    public partial class frmCategorias : Form
    {

        private CategoriaBLL categoriaBLL = CategoriaBLL.Instance();

        public frmCategorias()
        {
            InitializeComponent();
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {

            dgvCategorias.DataSource = categoriaBLL.GetAll();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            new frmNCategoria { Text = "Nueva categoria" }.ShowDialog();
            dgvCategorias.DataSource = categoriaBLL.GetAll();

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            int idCategoria = (int)(dgvCategorias.CurrentRow.Cells[0].Value);
            frmNCategoria nCategoria = new frmNCategoria(idCategoria);
            nCategoria.ShowDialog();
            
            dgvCategorias.DataSource = categoriaBLL.GetAll();

        }
    }
}
