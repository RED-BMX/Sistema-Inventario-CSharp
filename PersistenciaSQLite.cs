using Microsoft.EntityFrameworkCore;

public class PersistenciaSQLite : IPersistencia
{
    private readonly DbContextOptions<InventarioDbContext> opciones;

    public PersistenciaSQLite(string rutaBaseDatos = "inventario.db")
    {
        var opcionesBuilder = new DbContextOptionsBuilder<InventarioDbContext>();

        opcionesBuilder.UseSqlite($"Data Source={rutaBaseDatos}");

        opciones = opcionesBuilder.Options;

        using var contexto = new InventarioDbContext(opciones);

        contexto.Database.EnsureCreated();
    }

    public void GuardarProductos(IEnumerable<Producto> productos)
    {
        using var contexto = new InventarioDbContext(opciones);

        contexto.Productos.RemoveRange(contexto.Productos);
        contexto.Productos.AddRange(productos);

        contexto.SaveChanges();
    }

    public IEnumerable<Producto> CargarProductos()
    {
        using var contexto = new InventarioDbContext(opciones);

        return contexto.Productos.ToList();
    }
}