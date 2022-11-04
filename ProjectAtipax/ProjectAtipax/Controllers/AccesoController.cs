using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ProjectAtipax.Models;
using System.Data;

namespace ProjectAtipax.Controllers
{
    public class AccesoController : Controller
    {
        public readonly IConfiguration _iconfig;
        public AccesoController(IConfiguration iconfig)
        {
            _iconfig = iconfig;
        }
        public IActionResult Logueo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Logueo(Usuario reg)
        {
           

         

            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(_iconfig["ConnectionStrings:cadena"]))

            {
                cn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("usp_validar_usuario", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@usu", reg.usuario);
                    cmd.Parameters.AddWithValue("@pass", reg.pass);
                    cmd.ExecuteNonQuery();
                    return RedirectToAction("Inicio", "Viajes");

                }

                catch (SqlException ) 
                { 
                    mensaje = "Usuario incorrecto"; 
                }

                finally {
                    cn.Close(); 
                }

            }

            ViewBag.mensaje = mensaje;

            return View(); 
        }

        public IActionResult Salir()
        {
            return RedirectToAction("Logueo", "Acceso");
        }

       
    }
}
