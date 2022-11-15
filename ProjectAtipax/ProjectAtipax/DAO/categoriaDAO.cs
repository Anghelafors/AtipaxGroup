using Microsoft.Data.SqlClient;
using ProjectAtipax.Models;
using ProjectAtipax.Models.DI;

namespace ProjectAtipax.DAO
{
    public class categoriaDAO : ICategoria
    {
        public string actualizar(Categoria c)
        {
            string mensaje = "";
            conexionDAO cn = new conexionDAO();
            using (cn.getcn)
            {
                cn.getcn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(
                    "exec usp_actualizar_categoria @idCa,@nom", cn.getcn);
                    cmd.Parameters.AddWithValue("@idTo", c.IdCategoria);
                    cmd.Parameters.AddWithValue("@nom", c.NombreCategoria);
                    cmd.ExecuteNonQuery();
                    mensaje = "Se ha actualizado correctamente";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.getcn.Close(); }
            }
            return mensaje;
        }

        public string agregar(Categoria c)
        {
            string mensaje = "";
            conexionDAO cn = new conexionDAO();
            using (cn.getcn)
            {
                cn.getcn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(
                    "exec usp_agregar_categoria @idCa,@nom", cn.getcn);
                    cmd.Parameters.AddWithValue("@idTo", c.IdCategoria);
                    cmd.Parameters.AddWithValue("@nom", c.NombreCategoria);
                    cmd.ExecuteNonQuery();
                    mensaje = "Se ha registrado correctamente";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.getcn.Close(); }
            }
            return mensaje;
        }

        public Categoria buscar(int id)
        {
            return listado().Where(c => c.IdCategoria == id).FirstOrDefault();
        }

        public string eliminar(object obj)
        {
            string mensaje = "";
            conexionDAO cn = new conexionDAO();
            using (cn.getcn)
            {

                cn.getcn.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("exec usp_eliminar_categoria @idCa", cn.getcn);

                    cmd.Parameters.AddWithValue("@idCa", obj);
                    cmd.ExecuteNonQuery();

                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.getcn.Close(); }
            }
            return mensaje;
        }

        public IEnumerable<Categoria> listado()
        {
            List<Categoria> temporal = new List<Categoria>();
            conexionDAO cn = new conexionDAO();
            using (cn.getcn)
            {
                cn.getcn.Open();
                SqlCommand cmd = new SqlCommand("usp_categorias_list", cn.getcn);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Categoria()
                    {
                        IdCategoria = dr.GetInt32(0),
                        NombreCategoria = dr.GetString(1)
                    });
                }
            }
            return temporal;

        }
    }
}
