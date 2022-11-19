using System.ComponentModel.DataAnnotations;

namespace ProjectAtipax.Models
{
    public class Cliente
    {
        [Display(Name = "Nombre"), Required] public string nombre { get; set; }
        [Display(Name = "Apellido Paterno"), Required] public string apePaterno { get; set; }
        [Display(Name = "Apellido Materno"), Required] public string apeMaterno { get; set; }
        [Display(Name = "DNI"), Required] public string dni { get; set; }
        [Display(Name = "Celular"), Required] public int telefono { get; set; }
        [Display(Name = "Correo"), Required] public string email { get; set; }        
      
    }
}
