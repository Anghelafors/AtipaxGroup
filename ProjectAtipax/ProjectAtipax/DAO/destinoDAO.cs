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
                    "exec usp_agregar_destino @idDes,@pais,@ciu,@idHo", cn.getcn);
                    cmd.Parameters.AddWithValue("@idDes", d.idDestino);
                    cmd.Parameters.AddWithValue("@pais", d.pais);
                    cmd.Parameters.AddWithValue("@ciu", d.ciudad);
                    cmd.Parameters.AddWithValue("@idHo", d.idHotel);
                    

                    cmd.ExecuteNonQuery();
                    mensaje = "Se ha registrado correctamente";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.getcn.Close(); }
            }
            return mensaje;
        }

        public Destino buscar(string codigo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Destino> listado()
        {
            List<Destino> temporal = new List<Destino>();
            conexionDAO cn = new conexionDAO();
            using (cn.getcn)
            {
                cn.getcn.Open();
                SqlCommand cmd = new SqlCommand("usp_destino_listar", cn.getcn);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Destino()
                    {
                        idDestino = dr.GetString(0),
                        pais = dr.GetString(1),
                        ciudad = dr.GetString(2),
                        idHotel = dr.GetString(3)


                    });
                }
            }
            return temporal;

        }
    }
}
