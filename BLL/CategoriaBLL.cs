using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoriaBLL
    {
        private static volatile CategoriaBLL instance = null;
        private static readonly object padlock = new object();
        private CategoriaDAL categoriaDAL = CategoriaDAL.Instance();


        public static CategoriaBLL Instance()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new CategoriaBLL();
            return instance;
        }


        //Sigue metodo para
        //Agregar, Eliminar, Actualizar

        public bool Add(Categoria categoria)
        {
            if (categoriaDAL.Add(categoria) > 0)
                return true;
            else
                return false;
        }

        public bool Delete(Categoria categoria)
        {
            if (categoriaDAL.Delete(categoria) > 0)
                return true;
            else
                return false;
        }

        public Categorias GetAll()
        {
            return categoriaDAL.GetAll();
        }

        public Categoria GetByID(Categoria categoria)
        {
            return categoriaDAL.GetByID(categoria);
        }

        public Categoria GetByDescripcion(Categoria categoria)
        {
            return categoriaDAL.GetByDescripcion(categoria);
        }

        public bool Update(Categoria categoria)
        {
            if (categoriaDAL.Update(categoria) > 0)
                return true;
            else
                return false;
        }

    }
}
