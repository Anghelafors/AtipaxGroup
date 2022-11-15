using System.ComponentModel.DataAnnotations;

namespace ProjectAtipax.Models
{
    public class Hotel
    {
        /*idHotel char(5) primary key not null,
nomHotel nvarchar(20) not null,
categoria nvarchar(15) not null,
precioHotel decimal(6,2) not null,
descripcion nvarchar(50) not null,
idTour char(5) not null,*/

        [Display(Name = "Código Hotel"), Required] public int idHotel { get; set; }
        [Display(Name = "Nombre del Hotel"), Required] public String nomHotel { get; set; }
        [Display(Name = "Categoría"), Required] public String categoria { get; set; }
        [Display(Name = "Precio"), Required] public Decimal precioHotel { get; set; }
        [Display(Name = "Descripción"), Required] public String descripcion { get; set; }
        [Display(Name = "Código Tour"), Required] public int idTour { get; set; }

        public Hotel()
        {

            nomHotel = "";
            categoria = "";
            descripcion = "";

        }
    }
}
