
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class ProductoDAL
    {

        private static volatile ProductoDAL instance = null;
        private static readonly object padlock = new object();
        private DataAccess dataAccess = DataAccess.Instance();

        private ProductoDAL() { }

        public static ProductoDAL Instance()
        {
            if (instance == null)//verificar si hay una instancia creada
                lock (padlock)
                    if (instance == null)
                        instance = new ProductoDAL();
            return instance;
        }

        public int Add(Producto producto)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[6];
                parameters[0] = new SqlParameter("@descripcion", producto.descripcion);
                parameters[1] = new SqlParameter("@idCategoria", producto.idCategoria);
                parameters[2] = new SqlParameter("@precioUnitario", producto.precioUnitario);
                parameters[3] = new SqlParameter("@stock", producto.stock);
                parameters[4] = new SqlParameter("@codigo", producto.codigo);
                parameters[5] = new SqlParameter("@idMarca", producto.idMarca);
                
                string query = "stp_productos_add";
                return dataAccess.Execute(query, parameters);
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public int Delete(Producto producto)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idProducto", producto.idProducto);
                string query = "stp_productos_delete";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public Productos GetAll()
        {
            try
            {
                string query = "stp_productos_getall";
                DataTable resultado = dataAccess.Query(query);
                Productos productos = new Productos();
                foreach (DataRow item in resultado.Rows)
                {
                    productos.Add(new Producto()
                    {
                        idProducto = (int)item["idProducto"],
                        descripcion = (string)item["descripcion"],
                        idCategoria = (int)item["idCategoria"],
                        precioUnitario = (decimal)item["precioUnitario"],
                        stock = (int)item["stock"],
                        codigo = (string)item["codigo"],
                        idMarca = (int)item["idMarca"],
                        activo = (bool)item["activo"]
                    });
                }
                return productos;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }


        public Producto GetByID(Producto producto)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idProducto", producto.idProducto);
                string query = "stp_productos_getbyid";
                DataTable resultado = dataAccess.Query(query, parameters);

                if (resultado.Rows.Count > 0)
                {
                    producto = new Producto()
                    {
                        idProducto = (int)resultado.Rows[0]["idProducto"],
                        descripcion = (string)resultado.Rows[0]["descripcion"],
                        idCategoria = (int)resultado.Rows[0]["idCategoria"],
                        precioUnitario = (decimal)resultado.Rows[0]["precioUnitario"],
                        stock = (int)resultado.Rows[0]["stock"],
                        codigo = (string)resultado.Rows[0]["codigo"],
                        idMarca = (int)resultado.Rows[0]["idMarca"],
                        activo = (bool)resultado.Rows[0]["activo"]
                    };

                }
                return producto;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }


        public int Update(Producto producto)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[7];
                parameters[0] = new SqlParameter("@idProducto", producto.idProducto);
                parameters[1] = new SqlParameter("@descripcion", producto.descripcion);
                parameters[2] = new SqlParameter("@idCategoria", producto.idCategoria);
                parameters[3] = new SqlParameter("@precioUnitario", producto.precioUnitario);
                parameters[4] = new SqlParameter("@stock", producto.stock);
                parameters[5] = new SqlParameter("@idMarca", producto.idMarca);
                parameters[6] = new SqlParameter("@codigo", producto.codigo);
                string query = "stp_productos_update";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }



    }
}
