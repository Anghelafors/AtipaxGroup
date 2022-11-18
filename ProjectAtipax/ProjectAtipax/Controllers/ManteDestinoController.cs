using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using ProjectAtipax.DAO;
using ProjectAtipax.Models;
using ProjectAtipax.Models.DI;
using System.Data;

namespace ProjectAtipax.Controllers
{
    [Authorize]
    public class ManteDestinoController : Controller
    {
        IHotel _hotel;
        IDestino _destino;
        ICategoria _categoria;
        public ManteDestinoController()
        {

            _hotel = new hotelDAO();
            _destino = new destinoDAO();
            _categoria = new categoriaDAO();
        }
        //  [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {

            //enviar lista de hoteles
            ViewBag.categoriaLis = new SelectList(_categoria.listado(), "IdCategoria", "NombreCategoria");
            ViewBag.hotelLis = new SelectList(_hotel.listado(), "idHotel", "nomHotel");
            ViewBag.destinos = _destino.listado();
            return View(new Destino());

        }
        [HttpPost]
        public IActionResult Create(Destino d)
        {

            ViewBag.mensaje = _destino.agregar(d);
            ViewBag.categoriaLis = new SelectList(_categoria.listado(), "IdCategoria", "NombreCategoria", d.IdCategoria);

            ViewBag.hotelLis = new SelectList(_hotel.listado(), "idHotel", "nomHotel", d.idHotel);
            ViewBag.destinos = _destino.listado();
            return View(d);
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult Edit(int id)
        {
            Destino d = _destino.buscar(id);

            //  if (t == null) return RedirectToAction("Index");
            ViewBag.categoriaLis = new SelectList(_categoria.listado(), "IdCategoria", "NombreCategoria", d.IdCategoria);

            ViewBag.hotelLis = new SelectList(_hotel.listado(), "idHotel", "nomHotel", d.idHotel);


            return View(d);
        }
        [HttpPost]
        public IActionResult Edit(Destino d)
        {

            ViewBag.mensaje = _destino.actualizar(d);
            ViewBag.categoriaLis = new SelectList(_categoria.listado(), "IdCategoria", "NombreCategoria", d.IdCategoria);
            ViewBag.hotelLis = new SelectList(_hotel.listado(), "idHotel", "nomHotel", d.idHotel);
            return View(d);
        }
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(int id)
        {
            _destino.eliminar(id);


            return RedirectToAction("Create", "ManteDestino");

        }
    }


}
