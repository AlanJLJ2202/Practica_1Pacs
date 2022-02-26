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
    public partial class frmNMarca : Form
    {
        private MarcaBLL marcaBLL = MarcaBLL.Instance();
        Marca marca = new Marca();
        private int idMarca = 0;

        public frmNMarca()
        {
            InitializeComponent();
        }

        public frmNMarca(int idMarca)
        {
            InitializeComponent();
            this.idMarca = idMarca;
            marca.idMarca = idMarca;

            txtDescripcion.Text = marcaBLL.GetByID(marca).descripcion.ToString();
        }

        private void Clean()
        {
            txtDescripcion.Text = "";
            txtDescripcion.Focus();
        }

        private void frmNMarca_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (idMarca > 0)
            {
                if (marcaBLL.Update(new BOL.Marca()
                {
                    idMarca = idMarca,
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
            else
            {
                if (marcaBLL.Add(new BOL.Marca()
                {
                    descripcion = txtDescripcion.Text
                }))
                {
                    MessageBox.Show("Marca Ingresada Correctamente", Application.ProductName,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clean();
                }
            }


           
        }
    }
}
