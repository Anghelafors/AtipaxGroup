using Microsoft.AspNetCore.Mvc;
using ProjectAtipax.DAO;
using ProjectAtipax.Models;
using ProjectAtipax.Models.DI;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace ProjectAtipax.Controllers
{
    public class ManteHotelController : Controller
    {
        IHotel _hotel;
        ITour _tour;
        public ManteHotelController()
        {
            
            _hotel = new hotelDAO();
            _tour = new tourDAO();
        }
        public IActionResult Create()
        {
            //enviar lista de tours
            ViewBag.tourLis = new SelectList(_tour.listado(), "idTour", "descripcion");
            ViewBag.hotels = _hotel.listado();
            return View(new Hotel());
            
        }

       [HttpPost]
        public IActionResult Create(Hotel ho)
        {

            ViewBag.mensaje = _hotel.agregar(ho);
            ViewBag.tourLis = new SelectList(_tour.listado(), "idTour", "descripcion", ho.idTour);
            ViewBag.hotels = _hotel.listado();
            return View(ho);
        }
    }
}
