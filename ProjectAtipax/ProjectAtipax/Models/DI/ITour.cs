namespace ProjectAtipax.Models.DI
{
    public interface ITour
    {
        IEnumerable<Tour> listado();
        Tour buscar(int codigo);
        string agregar(Tour t);

        string actualizar(Tour t);
    }
}
