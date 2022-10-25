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

        public String idHotel { get; set; }
        public String nomHotel { get; set; }
        public String categoria { get; set; }
        public Decimal precioHotel { get; set; }
        public String descripcion { get; set; }
        public String idTour { get; set; }

        public Hotel()
        {
            idHotel = "";
            nomHotel = "";
            categoria = "";
            descripcion = "";
            idTour = "";
        }
    }
}
