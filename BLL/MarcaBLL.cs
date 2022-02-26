using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MarcaBLL
    {
        private static volatile MarcaBLL instance = null;
        private static readonly object padlock = new object();
        private MarcaDAL marcaDAL = MarcaDAL.Instance();

        public static MarcaBLL Instance()
        {
            if (instance == null)
                lock (padlock)
                    if (instance == null)
                        instance = new MarcaBLL();
            return instance;
        }

        public bool Add(Marca marca)
        {
            if (marcaDAL.Add(marca) > 0)
                return true;
            else
                return false;
        }

        public bool Delete(Marca marca)
        {
            if (marcaDAL.Delete(marca) > 0)
                return true;
            else
                return false;
        }

        public Marcas GetAll()
        {
            return marcaDAL.GetAll();
        }

        public Marca GetByID(Marca marca)
        {
            return marcaDAL.GetByID(marca);
        }

        public bool Update(Marca marca)
        {
            if (marcaDAL.Update(marca) > 0)
                return true;
            else
                return false;
        }


        public Marca GetByDescripcion(Marca marca)
        {
            return marcaDAL.GetByDescripcion(marca);
        }


    }
}
