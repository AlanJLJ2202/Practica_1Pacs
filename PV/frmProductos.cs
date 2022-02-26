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

    public partial class frmProductos : Form
    {

        private ProductoBLL productoBLL = ProductoBLL.Instance();
        public frmProductos()
        {
            InitializeComponent();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            dgvProductos.DataSource = productoBLL.GetAll();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            new frmNProducto { Text = "Nuevo producto" }.ShowDialog();
            dgvProductos.DataSource = productoBLL.GetAll();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idProducto = (int)(dgvProductos.CurrentRow.Cells[0].Value);
            frmNProducto nProducto = new frmNProducto(idProducto);
            nProducto.ShowDialog();

            dgvProductos.DataSource = productoBLL.GetAll();
        }
    }
}
