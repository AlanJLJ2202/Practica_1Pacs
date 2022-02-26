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
    public class CategoriaDAL
    {
        private static volatile CategoriaDAL instance = null;
        private static readonly object padlock = new object();
        private DataAccess dataAccess = DataAccess.Instance();

        private CategoriaDAL(){ }

        public static CategoriaDAL Instance()
        {
            if (instance == null)//verificar si hay una instancia creada
                lock (padlock)
                    if (instance == null)
                        instance = new CategoriaDAL();
            return instance;
        }

        public int Add(Categoria categoria)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@descripcion", categoria.descripcion);
                string query = "stp_categorias_add";
                return dataAccess.Execute(query, parameters);
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public int Delete(Categoria categoria)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idCategoria", categoria.idCategoria);
                string query = "stp_categorias_delete";
                return dataAccess.Execute(query, parameters);
            }
            catch(Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public Categorias GetAll()
        {
            try
            {
                string query = "stp_categorias_getall";
                DataTable resultado = dataAccess.Query(query);
                Categorias categorias = new Categorias();
                foreach(DataRow item in resultado.Rows)
                {
                    categorias.Add(new Categoria()
                    {
                        idCategoria = (int)item["idCategoria"],
                        descripcion = (string)item["descripcion"],
                        activo = (bool)item["activo"]
                    });
                }
                return categorias;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public Categoria GetByID(Categoria categoria)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idCategoria", categoria.idCategoria);
                string query = "stp_categorias_getbyid";
                DataTable resultado = dataAccess.Query(query, parameters);

                if(resultado.Rows.Count > 0)
                {
                    categoria = new Categoria()
                    {
                        idCategoria = (int)resultado.Rows[0]["idCategoria"],
                        descripcion = (string)resultado.Rows[0]["descripcion"],
                        activo = (bool)resultado.Rows[0]["activo"]
                    };
                    
                }
                return categoria;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }

        public Categoria GetByDescripcion(Categoria categoria)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@descripcion", categoria.descripcion);
                string query = "stp_categorias_getbydescripcion";
                DataTable resultado = dataAccess.Query(query, parameters);

                if(resultado.Rows.Count > 0)
                {
                    categoria = new Categoria()
                    {
                        idCategoria = (int)resultado.Rows[0]["idCategoria"],
                        descripcion = (string)resultado.Rows[0]["descripcion"],
                        activo = (bool)resultado.Rows[0]["activo"]
                    };
                }
                return categoria;
            }
            
            catch(Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }



        public int Update(Categoria categoria)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@idCategoria", categoria.idCategoria);
                parameters[1] = new SqlParameter("@descripcion", categoria.descripcion);
                string query = "stp_categorias_update";
                return dataAccess.Execute(query, parameters);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error" + ex.Message);
            }
        }

    }
}
