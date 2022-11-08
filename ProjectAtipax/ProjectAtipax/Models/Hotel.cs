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

        public int idHotel { get; set; }
        public String nomHotel { get; set; }
        public String categoria { get; set; }
        public Decimal precioHotel { get; set; }
        public String descripcion { get; set; }
        public int idTour { get; set; }

        public Hotel()
        {
           
            nomHotel = "";
            categoria = "";
            descripcion = "";
           
        }
    }
}
