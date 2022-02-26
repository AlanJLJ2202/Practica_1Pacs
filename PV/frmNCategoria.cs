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
    public partial class frmNCategoria : Form
    {

        private CategoriaBLL categoriaBLL = CategoriaBLL.Instance();
        Categoria categoria = new Categoria();
        private int idCategoria = 0;
        public frmNCategoria()
        {
            InitializeComponent();
        }


        public frmNCategoria(int idCategoria)
        {
               
            InitializeComponent();
            this.idCategoria = idCategoria;
            categoria.idCategoria = idCategoria;
            
            txtDescripcion.Text = categoriaBLL.GetByID(categoria).descripcion.ToString();
        }


        private void frmNCategoria_Load(object sender, EventArgs e)
        {
            
        }

        private void Clean()
        {
            txtDescripcion.Text = "";
            txtDescripcion.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idCategoria > 0)
            {
                if (categoriaBLL.Update(new BOL.Categoria()
                {
                    idCategoria = idCategoria,
                    descripcion = txtDescripcion.Text

                }))
                {
                    MessageBox.Show("Categoria actualizada", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clean();
                }
                else
                    MessageBox.Show("Categoria no actualizada", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clean();
            }
            else
            {
                if (categoriaBLL.Add(new BOL.Categoria()
                {
                    descripcion = txtDescripcion.Text
                }))
                {
                    MessageBox.Show("Categoria Ingresada Correctamente", Application.ProductName,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clean();

                }
            }

            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
