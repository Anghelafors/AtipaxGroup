namespace ProjectAtipax.Models
{
    public class Destino
    { /*
       idDestino char(5) primary key not null,
pais nvarchar(40) not null,
ciudad nvarchar(40) not null,
idHotel char(5) not null,*/
        public String idDestino { get; set; }
        public String pais { get; set; }
        public String ciudad { get; set; }
        public String idHotel { get; set; }

        public Destino()
        {
            idDestino = "";
            pais = "";
            ciudad = "";
            idHotel = "";
        }
    }
}
