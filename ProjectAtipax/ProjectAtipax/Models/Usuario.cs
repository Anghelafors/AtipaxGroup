using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectAtipax.Models
{
    public class Usuario
    {

        //  public int idUsuario { get; set; }
        public string nombre { get; set; }
        //[Display(Name ="Usuario") , Required] public String  usuario { get; set; }
        public string usuario { get; set; }
        //   [Display(Name = "Contraseña"), Required, StringLength(15)]
        public string pass { get; set; }
        public string[] Roles { get; set; }

      



    }
}
