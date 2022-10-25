namespace ProjectAtipax.Models
{
    public class Cliente
    {
       /* idCliente char (6) primary key not null,
nombre nvarchar(40)not null,
apePaterno nvarchar(20) not null,
apeMaterno nvarchar(20) not null,
dni char (8) not null,
telefono char (9) not null,
correo nvarchar(40) not null */
       public String idCliente { get; set; }
        public String nombre { get; set; }
        public String apePaterno { get; set; }
        public String apeMaterno { get; set; }
        public String dni { get; set; }
        public String telefono { get; set; }
        public String correo { get; set; }
        public Cliente()
        {
            idCliente = "";
            nombre = "";
            apePaterno = "";
            apeMaterno = "";
            dni = "";
            telefono = "";
            correo = "";
        }
    }
}
