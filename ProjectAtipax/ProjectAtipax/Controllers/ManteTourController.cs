using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectAtipax.DAO;
using ProjectAtipax.Models;
using ProjectAtipax.Models.DI;
using System.Data;

namespace ProjectAtipax.Controllers
{
    [Authorize]
    public class ManteTourController : Controller
    {
        ITour _tour;
        public ManteTourController()
        {
            _tour = new tourDAO();
        }
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
        public IActionResult Edit(int id)
        {
            Tour t = _tour.buscar(id);

            //  if (t == null) return RedirectToAction("Index");


            return View(t);
        }
        [HttpPost]
        public IActionResult Edit(Tour t)
        {

            ViewBag.mensajeEditar = _tour.actualizar(t);
            return View(t);
        }
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(int id)
        {
            ViewBag.mensajeEliminar = _tour.eliminar(id);


            return RedirectToAction("Create", "ManteTour");

        }


    }

}
