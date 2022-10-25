namespace ProjectAtipax.Models
{
    public class Usuario
    {
        /*idUsu int primary key  identity(1,1) not null,
usuario nvarchar(13) not null,
pass nvarchar(15) not null*/
        public int idUsu { get; set; }
        public String usuario { get; set; }
        public String pass { get; set; }
        public Usuario()
        {
            usuario= "";
            pass = "";
        }

    }
}
