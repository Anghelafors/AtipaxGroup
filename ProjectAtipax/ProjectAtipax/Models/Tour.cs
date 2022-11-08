using System.ComponentModel.DataAnnotations;

namespace ProjectAtipax.Models
{
    public class Tour
    {
        /*idTour char (5) primary key not null,
precio decimal (7,2) not null,
descripcion nvarchar(100) not null

        examples display : 
          [Display(Name = "Usuario"),Required]public string login { get; set; }

    [Display(Name ="Password"),Required,StringLength(10)]public string clave { get; set; }
        */
        public int idTour { get; set; }
        public Decimal precio { get; set; }
        public String descripcion { get; set; }

        public Tour()
        {
           
            descripcion = "";
        }
    }
}
