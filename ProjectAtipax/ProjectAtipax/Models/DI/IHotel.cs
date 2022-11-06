namespace ProjectAtipax.Models.DI
{
    public interface IHotel
    {
        IEnumerable<Hotel> listado();
        Hotel buscar(string codigo);
        string agregar(Hotel h);
        string actualizar(Hotel h);
    }
}
