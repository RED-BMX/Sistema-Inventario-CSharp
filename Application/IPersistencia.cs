using Sistema_Inventario_CSharp.Domain;
namespace Sistema_Inventario_CSharp.Application;

public interface IPersistencia
{
    void GuardarProductos(IEnumerable<Producto> productos);

    IEnumerable<Producto> CargarProductos();
}