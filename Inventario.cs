public class Inventario
{
    private readonly List<Producto> productos = new();
    private readonly IPersistencia persistencia;

    public Inventario(IPersistencia persistencia)
    {
        this.persistencia = persistencia;

        CargarProductos();
    }

    private void CargarProductos()
    {
        IEnumerable<Producto> productosGuardados = persistencia.CargarProductos();

        productos.AddRange(productosGuardados);
    }

    private void GuardarCambios()
    {
        persistencia.GuardarProductos(productos);
    }

    public bool AgregarProducto(Producto producto)
    {
        if (productos.Any(p => p.Id == producto.Id))
        {
            return false;
        }

        productos.Add(producto);
        GuardarCambios();

        return true;
    }

    public bool EliminarProducto(int id)
    {
        Producto? producto = productos.FirstOrDefault(p => p.Id == id);

        if (producto == null)
        {
            return false;
        }

        productos.Remove(producto);
        GuardarCambios();

        return true;
    }

    public Producto? BuscarProducto(int id)
    {
        return productos.FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Producto> ObtenerProductos()
    {
        return productos.AsReadOnly();
    }

    public bool AumentarStock(int id, int cantidad)
    {
        Producto? producto = BuscarProducto(id);

        if (producto == null)
        {
            return false;
        }

        bool aumentado = producto.AumentarStock(cantidad);

        if (!aumentado)
        {
            return false;
        }

        GuardarCambios();

        return true;
    }

    public bool ReducirStock(int id, int cantidad)
    {
        Producto? producto = BuscarProducto(id);

        if (producto == null)
        {
            return false;
        }

        bool reducido = producto.ReducirStock(cantidad);

        if (!reducido)
        {
            return false;
        }

        GuardarCambios();

        return true;
    }
}