using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Session;
using Microsoft.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

using ProjectAtipax.Models;

namespace ProjectAtipax.Controllers
{
    public class AtipaxController : Controller
    {
        public readonly IConfiguration _iconfig;
        public AtipaxController(IConfiguration iconfig)
        {
            _iconfig = iconfig;
        }

        IEnumerable<Destino> catalogo()
        {
            List<Destino> temporal = new List<Destino>();
            using (SqlConnection cn = new SqlConnection(_iconfig["ConnectionStrings:cadena"]))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(
                "Select iddestino,pais,ciudad,nombrecategoria,precio " +
                "from tb_destino d join tb_categorias c on d.idcategoria=c.idcategoria", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Destino()
                    {
                        idDestino = dr.GetInt32(0),
                        pais = dr.GetString(1),
                        ciudad = dr.GetString(2),
                        categoria = dr.GetString(3),
                        precio = dr.GetDecimal(4)                     
                    });
                }
                cn.Close();
            }
            return temporal;
        }

        public IActionResult Portal()
        {
            return View(catalogo());
        }

        public IActionResult Seleccionar(int id = 0)
        {
            //buscar el producto por id
            Destino reg = catalogo().FirstOrDefault(p => p.idDestino == id);
            return View(reg);
        }
        [HttpPost]
        public IActionResult Seleccionar(int codigo, int cantidad)
        {
            //recibir los datos para agregar al Session
            return View();

        }
    }
}
