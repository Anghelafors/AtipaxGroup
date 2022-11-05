using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using ProjectAtipax.DAO;
using ProjectAtipax.Models;
using ProjectAtipax.Models.DI;

namespace ProjectAtipax.Controllers
{
    public class ManteDestinoController : Controller
    {
        IHotel _hotel;
        IDestino _destino;
        public ManteDestinoController()
        {

            _hotel = new hotelDAO();
            _destino = new destinoDAO();
        }
        public IActionResult Create()
        {

            //enviar lista de hoteles
            ViewBag.hotelLis = new SelectList(_hotel.listado(), "idHotel", "nomHotel");
            ViewBag.destinos = _destino.listado();
            return View(new Destino());

        }
        [HttpPost]
        public IActionResult Create(Destino des)
        {

            ViewBag.mensaje = _destino.agregar(des);
            ViewBag.hotelLis = new SelectList(_hotel.listado(), "idHotel", "nomHotel", des.idHotel);
            ViewBag.destinos = _destino.listado();
            return View(des);
        }
    }
}
