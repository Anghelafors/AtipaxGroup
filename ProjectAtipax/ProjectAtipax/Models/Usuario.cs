using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectAtipax.Models
{
    public class Usuario
    {
       
        public int idUsuario { get; set; }
        [Display(Name ="Usuario") , Required] public String  usuario { get; set; }
        [Display(Name = "Contraseña"), Required, StringLength(15)] public String pass { get; set; }
        public int idRol { get; set; }

        public Usuario()
        {
            usuario = "";
            pass = "";
        }

       

    }
}
