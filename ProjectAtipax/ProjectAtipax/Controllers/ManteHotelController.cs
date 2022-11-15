using Microsoft.AspNetCore.Mvc;
using ProjectAtipax.DAO;
using ProjectAtipax.Models;
using ProjectAtipax.Models.DI;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace ProjectAtipax.Controllers
{
    [Authorize]
    public class ManteHotelController : Controller
    {
        IHotel _hotel;
        ITour _tour;
        public ManteHotelController()
        {

            _hotel = new hotelDAO();
            _tour = new tourDAO();
        }
        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            //enviar lista de tours
            ViewBag.tourLis = new SelectList(_tour.listado(), "idTour", "descripcion");
            ViewBag.hotels = _hotel.listado();
            return View(new Hotel());

        }

        [HttpPost]
        public IActionResult Create(Hotel h)
        {

            ViewBag.mensaje = _hotel.agregar(h);
            ViewBag.tourLis = new SelectList(_tour.listado(), "idTour", "descripcion", h.idTour);
            ViewBag.hotels = _hotel.listado();
            return View(h);
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult Edit(int id)
        {
            Hotel h = _hotel.buscar(id);

            //  if (t == null) return RedirectToAction("Index");
            ViewBag.tourLis = new SelectList(_tour.listado(), "idTour", "descripcion", h.idTour);


            return View(h);
        }
        [HttpPost]
        public IActionResult Edit(Hotel h)
        {

            ViewBag.mensaje = _hotel.actualizar(h);
            ViewBag.tourLis = new SelectList(_tour.listado(), "idTour", "descripcion", h.idTour);
            return View(h);
        }
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(int id)
        {
            _hotel.eliminar(id);


            return RedirectToAction("Create", "ManteHotel");

        }
    }



}
