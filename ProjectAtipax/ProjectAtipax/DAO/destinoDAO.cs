using Microsoft.Data.SqlClient;
using ProjectAtipax.Models;
using ProjectAtipax.Models.DI;

namespace ProjectAtipax.DAO
{
    public class destinoDAO : IDestino
    {
        public string agregar(Destino d)
        {
            string mensaje = "";
            conexionDAO cn = new conexionDAO();
            using (cn.getcn)
            {
                cn.getcn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(
                    "exec usp_agregar_destino @idDes,@pais,@ciu,@idHo,@idCate,@pre,@uni", cn.getcn);
                    cmd.Parameters.AddWithValue("@idDes", d.idDestino);
                    cmd.Parameters.AddWithValue("@pais", d.pais);
                    cmd.Parameters.AddWithValue("@ciu", d.ciudad);
                    cmd.Parameters.AddWithValue("@idHo", d.idHotel);
                    cmd.Parameters.AddWithValue("@idCate", d.IdCategoria);
                    cmd.Parameters.AddWithValue("@pre", d.precio);
                    cmd.Parameters.AddWithValue("@uni", d.UnidadesEnExistencia);


                    cmd.ExecuteNonQuery();
                    mensaje = "Se ha registrado correctamente";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.getcn.Close(); }
            }
            return mensaje;
        }

        public Destino buscar(int id)
        {
            /*if (string.IsNullOrEmpty(codigo))
                return null;
            else*/
            return listado().Where(c => c.idDestino == id).FirstOrDefault();
        }

        public IEnumerable<Destino> listado()
        {
            List<Destino> temporal = new List<Destino>();
            conexionDAO cn = new conexionDAO();
            using (cn.getcn)
            {
                cn.getcn.Open();
                SqlCommand cmd = new SqlCommand("usp_destino_list", cn.getcn);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Destino()
                    {
                        idDestino = dr.GetInt32(0),
                        pais = dr.GetString(1),
                        ciudad = dr.GetString(2),
                        idHotel = dr.GetInt32(3)


                    });
                }
            }
            return temporal;

        }
        public string actualizar(Destino d)
        {
            string mensaje = "";
            conexionDAO cn = new conexionDAO();
            using (cn.getcn)
            {
                cn.getcn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(
                    "exec usp_actualizar_destino @idDes,@pais,@ciu,@idHo,@idCate,@pre,@uni", cn.getcn);
                    cmd.Parameters.AddWithValue("@idDes", d.idDestino);
                    cmd.Parameters.AddWithValue("@pais", d.pais);
                    cmd.Parameters.AddWithValue("@ciu", d.ciudad);
                    cmd.Parameters.AddWithValue("@idHo", d.idHotel);
                    cmd.Parameters.AddWithValue("@idCate", d.IdCategoria);
                    cmd.Parameters.AddWithValue("@pre", d.precio);
                    cmd.Parameters.AddWithValue("@uni", d.UnidadesEnExistencia);


                    cmd.ExecuteNonQuery();
                    mensaje = "Se ha actualizado correctamente";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.getcn.Close(); }
            }
            return mensaje;
        }

        public string eliminar(object obj)
        {
            throw new NotImplementedException();
        }
    }


}
