namespace ProjectAtipax.Models.DI
{
    public interface IDestino
    {
        IEnumerable<Destino> listado();
        Destino buscar(string codigo);
        string agregar(Destino d);
    }
}
