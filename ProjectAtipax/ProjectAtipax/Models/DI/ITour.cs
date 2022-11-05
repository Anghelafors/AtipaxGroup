namespace ProjectAtipax.Models.DI
{
    public interface ITour
    {
        IEnumerable<Tour> listado();
        Tour buscar(string codigo);
        string agregar(Tour t);
    }
}
