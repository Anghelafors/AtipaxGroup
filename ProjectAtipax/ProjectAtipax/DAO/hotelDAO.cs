using Microsoft.Data.SqlClient;
using ProjectAtipax.Models;
using ProjectAtipax.Models.DI;

namespace ProjectAtipax.DAO
{
    public class hotelDAO : IHotel
    {
        public string agregar(Hotel h)
        {
            string mensaje = "";
            conexionDAO cn = new conexionDAO();
            using (cn.getcn)
            {
                cn.getcn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(
                    "exec usp_agregar_hotel @idHo,@nom,@cate,@pre,@des,@idTo", cn.getcn);
                    cmd.Parameters.AddWithValue("@idHo",h.idHotel);
                    cmd.Parameters.AddWithValue("@nom", h.nomHotel);
                    cmd.Parameters.AddWithValue("@cate",h.categoria);
                    cmd.Parameters.AddWithValue("@pre", h.precioHotel);
                    cmd.Parameters.AddWithValue("@des",h.descripcion);
                    cmd.Parameters.AddWithValue("@idTo", h.idTour);

                    cmd.ExecuteNonQuery();
                    mensaje = "Se ha registrado correctamente";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.getcn.Close(); }
            }
            return mensaje;
        }

        public Hotel buscar(string codigo)
        {
            if (string.IsNullOrEmpty(codigo))
                return null;
            else
                return listado().Where(c => c.idHotel == codigo).FirstOrDefault();
        }

        public IEnumerable<Hotel> listado()
        {
            List<Hotel> temporal = new List<Hotel>();
            conexionDAO cn = new conexionDAO();
            using (cn.getcn)
            {
                cn.getcn.Open();
                SqlCommand cmd = new SqlCommand("usp_hotel_listar", cn.getcn);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Hotel()
                    {
                        idHotel = dr.GetString(0),
                        nomHotel = dr.GetString(1),
                        categoria = dr.GetString(2),
                        precioHotel = dr.GetDecimal(3),
                        descripcion = dr.GetString(4),
                        idTour= dr.GetString(5)
                        
                    });
                }
            }
            return temporal;

        }
        public string actualizar(Hotel h)
        {
            string mensaje = "";
            conexionDAO cn = new conexionDAO();
            using (cn.getcn)
            {
                cn.getcn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(
                    "exec usp_actualizar_hotel @idHo,@nom,@cate,@pre,@des,@idTo", cn.getcn);
                    cmd.Parameters.AddWithValue("@idHo", h.idHotel);
                    cmd.Parameters.AddWithValue("@nom", h.nomHotel);
                    cmd.Parameters.AddWithValue("@cate", h.categoria);
                    cmd.Parameters.AddWithValue("@pre", h.precioHotel);
                    cmd.Parameters.AddWithValue("@des", h.descripcion);
                    cmd.Parameters.AddWithValue("@idTo", h.idTour);

                    cmd.ExecuteNonQuery();
                    mensaje = "Se ha actualizado correctamente";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.getcn.Close(); }
            }
            return mensaje;
        }
    }
}
