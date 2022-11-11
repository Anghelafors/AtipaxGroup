namespace ProjectAtipax.Models
{
    public class Compra
    {
        public int codigo { get; set; }
        public string pais { get; set; }
        public string ciudad { get; set; }
        public string categoria { get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }
        public decimal monto { get { return precio * cantidad; } }
        /*
        public  int idCompra {get; set;}
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
        }*/
    }
}
