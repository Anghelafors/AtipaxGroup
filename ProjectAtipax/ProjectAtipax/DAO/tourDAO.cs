﻿using Microsoft.Data.SqlClient;
using System.Data;
using ProjectAtipax.Models.DI;
using ProjectAtipax.Models;

namespace ProjectAtipax.DAO
{
    public class tourDAO : ITour
    {

        public string agregar(Tour t)
        {
            string mensaje = "";
            conexionDAO cn = new conexionDAO();
            using (cn.getcn)
            {
                cn.getcn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(
                    "exec usp_agregar_tour @idTo,@pre,@des", cn.getcn);
                    cmd.Parameters.AddWithValue("@idTo", t.idTour);
                    cmd.Parameters.AddWithValue("@pre", t.precio);
                    cmd.Parameters.AddWithValue("@des", t.descripcion);

                    cmd.ExecuteNonQuery();
                    mensaje = "Se ha registrado correctamente";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.getcn.Close(); }
            }
            return mensaje;

        }

        public Tour buscar(int id)
        {

            /*if (id == null)
            {

                return null;
            }
            else
            {*/
            return listado().Where(c => c.idTour == id).FirstOrDefault();

        }

        public IEnumerable<Tour> listado()
        {
            List<Tour> temporal = new List<Tour>();
            conexionDAO cn = new conexionDAO();
            using (cn.getcn)
            {
                cn.getcn.Open();
                SqlCommand cmd = new SqlCommand("usp_tour_listar", cn.getcn);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Tour()
                    {
                        idTour = dr.GetInt32(0),
                        precio = dr.GetDecimal(1),
                        descripcion = dr.GetString(2)
                    });
                }
            }
            return temporal;

        }
        public string actualizar(Tour t)
        {
            string mensajeEditar = "";
            conexionDAO cn = new conexionDAO();
            using (cn.getcn)
            {
                cn.getcn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(
                    "exec usp_actualizar_tour @idTo,@pre,@des", cn.getcn);
                    cmd.Parameters.AddWithValue("@idTo", t.idTour);
                    cmd.Parameters.AddWithValue("@pre", t.precio);
                    cmd.Parameters.AddWithValue("@des", t.descripcion);
                    cmd.ExecuteNonQuery();
                    mensajeEditar = "Se ha actualizado correctamente";
                }
                catch (SqlException ex) { mensajeEditar = ex.Message; }
                finally { cn.getcn.Close(); }
            }
            return mensajeEditar;
        }

        public string eliminar(Object obj)
        {

            string mensajeEliminar = "";
            conexionDAO cn = new conexionDAO();
            using (cn.getcn)
            {

                cn.getcn.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("exec usp_eliminar_tour @idTo", cn.getcn);

                    cmd.Parameters.AddWithValue("@idTo", obj);
                    cmd.ExecuteNonQuery();
                    mensajeEliminar = "El Tour se ha eliminado";

                }
                catch (SqlException ex) { mensajeEliminar = ex.Message; }
                finally { cn.getcn.Close(); }
            }
            return mensajeEliminar;
        }
    }

}
