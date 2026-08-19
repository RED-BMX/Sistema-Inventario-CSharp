public interface IPersistencia
{
    void GuardarProductos(IEnumerable<Producto> productos);

    IEnumerable<Producto> CargarProductos();
}