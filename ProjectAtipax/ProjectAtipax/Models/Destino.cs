using System.ComponentModel.DataAnnotations;

namespace ProjectAtipax.Models
{
    public class Destino
    { /*
       idDestino char(5) primary key not null,
pais nvarchar(40) not null,
ciudad nvarchar(40) not null,
idHotel char(5) not null,*/
        [Display(Name = "Código Destino"), Required] public int idDestino { get; set; }
        [Display(Name = "País"), Required] public String pais { get; set; }
        [Display(Name = "Ciudad"), Required] public String ciudad { get; set; }
      
        [Display(Name = "Código Categoria"), Required] public int IdCategoria { get; set; }
        [Display(Name = "Código Hotel"), Required] public int idHotel { get; set; }
        [Display(Name = "Precio"), Required] public decimal precio { get; set; }
        [Display(Name = "Precio"), Required] public int UnidadesEnExistencia { get; set; }

        
        public Destino()
        {

            pais = "";
            ciudad = "";

        }
    }
}
