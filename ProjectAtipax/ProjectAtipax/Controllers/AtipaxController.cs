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

            if (HttpContext.Session.GetString("canasta") == null)
            {
                HttpContext.Session.SetString("canasta", JsonConvert.SerializeObject(new List<Compra>()));
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
            //buscar el producto por su codigo
            Destino reg = catalogo().FirstOrDefault(p => p.idDestino == codigo);

            //definir una Compra y almacenar los datos 
            Compra it = new Compra()
            {
                codigo = codigo,
                pais = reg.pais,
                ciudad = reg.ciudad,
                categoria = reg.categoria,
                precio = reg.precio,
                cantidad = cantidad
            };

            //deserializar el Session canasta para almacenar it
            List<Compra> temporal = JsonConvert.DeserializeObject<List<Compra>>(
                          HttpContext.Session.GetString("canasta"));
            //agregar
            temporal.Add(it);

            //serializar
            HttpContext.Session.SetString("canasta", JsonConvert.SerializeObject(temporal));
            ViewBag.mensaje = $"Se ha registrado el destino{reg.pais}";
            return View(reg);
        }

        public ActionResult Resumen()
        {
            //enviar a la vista la lista deserializada del Session Canasta
            List<Compra> temporal = JsonConvert.DeserializeObject<List<Compra>>(
                         HttpContext.Session.GetString("canasta"));
            return View(temporal);
        }

        public IActionResult Delete(int id)
        {
            //deserializar
            List<Compra> temporal = JsonConvert.DeserializeObject<List<Compra>>(
                         HttpContext.Session.GetString("canasta"));

            temporal.Remove(temporal.FirstOrDefault(p => p.codigo == id));

            HttpContext.Session.SetString("canasta", JsonConvert.SerializeObject(temporal));

            return RedirectToAction("Resumen");
        }

        public IActionResult Comprar()
        {
            //enviamos a vista un nuevo Cliente para el pedido
            return View(new Cliente());
        }

        [HttpPost]
        public IActionResult Comprar(Cliente reg)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(_iconfig["ConnectionStrings:cadena"]))
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction(IsolationLevel.Serializable);
                try
                {
                    //ejecutar el proceso donde agrega_pedido
                    SqlCommand cmd = new SqlCommand("usp_agrega_pedido", cn, tr);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idpedido", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@dni", reg.dni);
                    cmd.Parameters.AddWithValue("@nombre", reg.nombre);
                    cmd.Parameters.AddWithValue("@email", reg.email);
                    cmd.ExecuteNonQuery();
                    int idpedido = (int)cmd.Parameters["@idpedido"].Value; //recupero el valor @idpedido

                    List<Compra> temporal = JsonConvert.DeserializeObject<List<Compra>>(
                            HttpContext.Session.GetString("canasta"));

                    foreach (Compra item in temporal)
                    {
                        cmd = new SqlCommand("exec usp_agrega_detalle @idpedido,@idDestino,@cantidad,@precio", cn, tr);
                        cmd.Parameters.AddWithValue("@idpedido", idpedido);
                        cmd.Parameters.AddWithValue("@idDestino", item.codigo);
                        cmd.Parameters.AddWithValue("@cantidad", item.cantidad);
                        cmd.Parameters.AddWithValue("@precio", item.precio);
                        cmd.ExecuteNonQuery();
                    }

                    foreach (Compra item in temporal)
                    {
                        cmd = new SqlCommand("exec usp_actualiza_stock @idDestino,@cant", cn, tr);
                        cmd.Parameters.AddWithValue("@idDestino", item.codigo);
                        cmd.Parameters.AddWithValue("@cant", item.cantidad);
                        cmd.ExecuteNonQuery();
                    }

                    tr.Commit(); //si todo esta OK
                    mensaje = $"Se ha registrado el pedido {idpedido}";
                }
                catch (SqlException ex)
                {
                    mensaje = ex.Message;
                    tr.Rollback(); //deshacer el proceso
                }
                finally { cn.Close(); }
            }

            ViewBag.mensaje = mensaje;
            return View(reg);
        }
    }
}
