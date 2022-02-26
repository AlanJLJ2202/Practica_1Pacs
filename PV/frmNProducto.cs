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
    public partial class frmNProducto : Form
    {

        private CategoriaBLL categoriaBLL = CategoriaBLL.Instance();
        private MarcaBLL marcaBLL = MarcaBLL.Instance();
        private ProductoBLL productoBLL = ProductoBLL.Instance();
        Producto producto = new Producto();
        public int idProducto = 0;
        public int idCat = 0;
        public int idMarca = 0;

        public frmNProducto()
        {
            InitializeComponent();
        }

        public frmNProducto(int idProducto)
        {

            InitializeComponent();
            this.idProducto = idProducto;
            producto.idProducto = idProducto;

            txtDescripcion.Text = productoBLL.GetByID(producto).descripcion.ToString();
            txtPrecio.Text = productoBLL.GetByID(producto).precioUnitario.ToString();
            txtStock.Text = productoBLL.GetByID(producto).stock.ToString();
            txtCodigo.Text = productoBLL.GetByID(producto).codigo.ToString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmNProducto_Load(object sender, EventArgs e)
        {
            Categorias categorias = categoriaBLL.GetAll();
            foreach(Categoria categoria in categorias)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            Clean();
            //MessageBox.Show("¿Estas seguro que quieres cerrar?", Application.ProductName,
            //            MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            
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

            if (idProducto > 0)
            {
                if (productoBLL.Update(new BOL.Producto()
                {
                    idProducto = idProducto,
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
            else
            {
                if (productoBLL.Add(new BOL.Producto()
                {
                    descripcion = txtDescripcion.Text,
                    idCategoria = idCat,
                    precioUnitario = decimal.Parse(txtPrecio.Text),
                    stock = int.Parse(txtStock.Text),
                    codigo = txtCodigo.Text,
                    idMarca = idMarca

                }))
                {
                    MessageBox.Show("Producto Ingresado Correctamente", Application.ProductName,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clean();

                }
            }


            

            }


           
         }
}
