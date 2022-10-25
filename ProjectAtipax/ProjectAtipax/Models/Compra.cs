namespace ProjectAtipax.Models
{
    public class Compra
    {
        /*idCompra char(6) primary key not null,
cantidadPerson int not null,
total decimal(10,2) not null,
fechaInicio date not null,
fechaFin date not null,
idHotel char(5) not null,
idTour char(5) not null,
idDestino char(5) not null,
idCliente char(6) not null,*/
        public  String idCompra {get; set;}
        public int cantidadPerson { get; set; }
        public Decimal total { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public String idHotel { get; set; }
        public String idTour { get; set; }
        public String idDestino { get; set; }
        public String idCliente { get; set; }
        public Compra()
        {
            idCompra = "";
            idTour = "";
            idHotel = "";
          
            idDestino = "";
            idCliente = "";
        }
    }
}
