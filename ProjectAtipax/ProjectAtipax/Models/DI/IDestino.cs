namespace ProjectAtipax.Models.DI
{
    public interface IDestino
    {
        IEnumerable<Destino> listado();
        Destino buscar(int codigo);
        string agregar(Destino d);
        string actualizar(Destino d);
    }
}
