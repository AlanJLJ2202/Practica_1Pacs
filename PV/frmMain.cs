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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }


        private void pPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmMarcas frm = new frmMarcas();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmUsuarios frm = new frmUsuarios();
            frm.Show();

        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            frmCategorias frm = new frmCategorias();
            frm.Show();
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            frmProductos frm = new frmProductos();
            frm.Show();

        }
    }
}
