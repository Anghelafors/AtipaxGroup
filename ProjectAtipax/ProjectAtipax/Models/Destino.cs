namespace ProjectAtipax.Models
{
    public class Destino
    { /*
       idDestino char(5) primary key not null,
pais nvarchar(40) not null,
ciudad nvarchar(40) not null,
idHotel char(5) not null,*/
        public int idDestino { get; set; }
        public String pais { get; set; }
        public String ciudad { get; set; }
        public string categoria { get; set; }
        public decimal precio { get; set; }
        public int idHotel { get; set; }

        public Destino()
        {
            
            pais = "";
            ciudad = "";
           
        }
    }
}
