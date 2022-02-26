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
    public partial class frmMProducto : Form
    {

        private CategoriaBLL categoriaBLL = CategoriaBLL.Instance();
        private MarcaBLL marcaBLL = MarcaBLL.Instance();
        private ProductoBLL productoBLL = ProductoBLL.Instance();

        public int idCat = 0;
        public int idMarca = 0;
        public frmMProducto()
        {
            InitializeComponent();
        }

        private void frmMProducto_Load(object sender, EventArgs e)
        {
            Categorias categorias = categoriaBLL.GetAll();
            foreach (Categoria categoria in categorias)
            {
                cbCategorias.Items.Add(categoria.descripcion);
            }
            Marcas marcas = marcaBLL.GetAll();
            foreach (Marca marca in marcas)
            {
                cbMarcas.Items.Add(marca.descripcion);
            }
        }

        private void Clean()
        {
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtCodigo.Text = "";
            txtStock.Text = "";
            txtDescripcion.Focus();
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!cbCategorias.Text.Equals(""))
            {
                idCat = categoriaBLL.GetByDescripcion(new Categoria()
                {
                    descripcion = cbCategorias.Text
                }).idCategoria;

            }


            if (!cbCategorias.Text.Equals(""))
            {
                idMarca = marcaBLL.GetByDescripcion(new Marca()
                {
                    descripcion = cbMarcas.Text
                }).idMarca;


            }

            if (productoBLL.Update(new BOL.Producto()
            {
                idProducto = int.Parse(txtID.Text),
                descripcion = txtDescripcion.Text,
                idCategoria = idCat,
                precioUnitario = decimal.Parse(txtPrecio.Text),
                stock = int.Parse(txtStock.Text),
                codigo = txtCodigo.Text,
                idMarca = idMarca

            }))
            {
                MessageBox.Show("Producto actualizado Correctamente", Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clean();

            }

        }

    }
}

