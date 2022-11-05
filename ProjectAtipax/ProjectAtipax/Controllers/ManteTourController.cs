using Microsoft.AspNetCore.Mvc;
using ProjectAtipax.DAO;
using ProjectAtipax.Models;
using ProjectAtipax.Models.DI;

namespace ProjectAtipax.Controllers
{
    public class ManteTourController : Controller
    {
        ITour _tour;
        public ManteTourController()
        {
            _tour = new tourDAO();
        }
        public IActionResult Create()
        {
            //enviar lista de tours
            ViewBag.tours = _tour.listado();
            return View(new Tour());
        }

        [HttpPost]
        public IActionResult Create(Tour to)
        {
            
            ViewBag.mensaje = _tour.agregar(to);
            ViewBag.tours = _tour.listado();
            return View(to);
        }
    }
}
