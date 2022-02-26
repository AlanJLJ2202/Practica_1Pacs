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
    public partial class frmMarcas : Form
    {

        private MarcaBLL marcaBLL = MarcaBLL.Instance();


        public frmMarcas()
        {
            InitializeComponent();
        }

        private void frmMarcas_Load(object sender, EventArgs e)
        {
            dgvMarcas.DataSource = marcaBLL.GetAll();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            new frmNMarca { Text = "Nueva Marca" }.ShowDialog();
            dgvMarcas.DataSource = marcaBLL.GetAll();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idMarca = (int)(dgvMarcas.CurrentRow.Cells[0].Value);
            frmNMarca nMarca = new frmNMarca(idMarca);
            nMarca.ShowDialog();

            dgvMarcas.DataSource = marcaBLL.GetAll();
        }
    }
}
