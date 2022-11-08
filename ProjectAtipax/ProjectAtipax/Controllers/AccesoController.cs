using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ProjectAtipax.Models;
using System.Data;
using System.Net;
using ProjectAtipax.DAO;

namespace ProjectAtipax.Controllers
{
    public class AccesoController : Controller
    {
        /*  accesoDAO acce = new accesoDAO();
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
          public async Task<IActionResult> Logueo(Usuario reg)
          {




              string mensaje = "";
              using (SqlConnection cn = new SqlConnection(_iconfig["ConnectionStrings:cadena"]))

              {
                  cn.Open();
                  try
                  {
                      var valiUsu = acce.validacion(reg.usuario, reg.pass);
                      if (valiUsu != null)
                      {
                          var claims = new List<Claim>{
                       new Claim("usuario", reg.usuario)

                      };

                          foreach (string rol in reg.roles)
                          {
                              claims.Add(new Claim(ClaimTypes.Role, rol));
                          }

                          var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                          await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));


                          return RedirectToAction("Inicio", "Viajes");
                      }


                  }

                  catch (SqlException)
                  {
                      mensaje = "Usuario incorrecto";
                  }

                  finally
                  {
                      cn.Close();
                  }



                  ViewBag.mensaje = mensaje;
                  return View();

              }




          }

          public async Task<IActionResult> Salir()
          {
              await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

              return RedirectToAction("Logueo", "Acceso");
          }*/

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

                catch (SqlException)
                {
                    mensaje = "Usuario incorrecto";
                }

                finally
                {
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
