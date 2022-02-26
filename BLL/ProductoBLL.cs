using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductoBLL
    {
        private static volatile ProductoBLL instance = null;
        private static readonly object padlock = new object();
        private ProductoDAL productoDAL = ProductoDAL.Instance();


        public static ProductoBLL Instance()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new ProductoBLL();
            return instance;
        }


        //Sigue metodo para
        //Agregar, Eliminar, Actualizar

        public bool Add(Producto producto)
        {
            if (productoDAL.Add(producto) > 0)
                return true;
            else
                return false;
        }

        public bool Delete(Producto producto)
        {
            if (productoDAL.Delete(producto) > 0)
                return true;
            else
                return false;
        }

        public Productos GetAll()
        {
            return productoDAL.GetAll();
        }

        public Producto GetByID(Producto producto)
        {
            return productoDAL.GetByID(producto);
        }

        public bool Update(Producto producto)
        {
            if (productoDAL.Update(producto) > 0)
                return true;
            else
                return false;
        }



    }
}
