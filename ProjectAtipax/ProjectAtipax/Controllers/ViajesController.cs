using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectAtipax.Models;
using System.Diagnostics;

namespace ProjectAtipax.Controllers
{
    [Authorize]
    public class ViajesController : Controller
    {
        [Authorize(Roles = "Cliente")]
        public IActionResult Inicio()
        {
            return View();
        }
        [Authorize(Roles = "Cliente")]
        public IActionResult Contactenos()
        {
            return View();
        }
        [Authorize(Roles = "Cliente")]
        public IActionResult EscojeDestino()
        {
            return View();
        }
       /* public IActionResult InicioAdmi()
        {
            return View();
        }*/
       
      
    }
}
