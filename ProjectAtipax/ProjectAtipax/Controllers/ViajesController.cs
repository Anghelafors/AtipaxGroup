using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectAtipax.Models;

namespace ProjectAtipax.Controllers
{
   // [Authorize]
    public class ViajesController : Controller
    {
       // [Authorize(Roles = "Cliente")]
        public IActionResult Inicio()
        {
            return View();
        }
       // [Authorize(Roles = "Cliente")]
        public IActionResult Contactenos()
        {
            return View();
        }
        //[Authorize(Roles = "Cliente")]
        public IActionResult EscojeDestino()
        {
            return View();
        }
       
       // [Authorize(Roles = "Administrador")]
        public IActionResult Tour()
        {
            return Content("<h1>PAGINA TOUR PRUEBA</h1>" , "text/html");
        }
       // [Authorize(Roles = "Administrador")]
        public IActionResult Hotel()
        {
            return Content("<h1>PAGINA HOTEL PRUEBA</h1>", "text/html");
        }
        //[Authorize(Roles = "Administrador")]
        public IActionResult Destino()
        {
            return Content("<h1>PAGINA DESTINO PRUEBA</h1>", "text/html");
        }
    }
}
