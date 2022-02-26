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
    public partial class frmMMarcas : Form
    {
        MarcaBLL marcaBLL = MarcaBLL.Instance();
        public frmMMarcas()
        {
            InitializeComponent();
        }

        private void Clean()
        {
            txtDescripcion.Text = "";
            txtID.Text = "";
            txtDescripcion.Focus();
        }

        private void frmMMarcas_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (marcaBLL.Update(new BOL.Marca()
            {
                idMarca = int.Parse(txtID.Text),
                descripcion = txtDescripcion.Text

            }))
            {
                MessageBox.Show("Marca actualizada", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clean();
            }
            else
                MessageBox.Show("Marca no actualizada", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clean();
        }
    }
}
