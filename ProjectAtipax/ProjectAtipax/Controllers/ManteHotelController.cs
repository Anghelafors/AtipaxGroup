﻿using Microsoft.AspNetCore.Mvc;
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
      
        public ManteHotelController()
        {

            _hotel = new hotelDAO();
        }
        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            //enviar lista de tours
            ViewBag.hotels = _hotel.listado();
            return View(new Hotel());

        }

        [HttpPost]
        public IActionResult Create(Hotel h)
        {

            ViewBag.mensaje = _hotel.agregar(h);
            ViewBag.hotels = _hotel.listado();
            return View(h);
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult Edit(int id)
        {
            Hotel h = _hotel.buscar(id);

            //  if (t == null) return RedirectToAction("Index");


            return View(h);
        }
        [HttpPost]
        public IActionResult Edit(Hotel h)
        {

            ViewBag.mensajeEditar = _hotel.actualizar(h);
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
