public class Inventario
{
    private readonly List<Producto> productos = new();

    public bool AgregarProducto(Producto producto)
    {
        if (productos.Any(p => p.Id == producto.Id))
        {
            return false;
        }
    
        productos.Add(producto);
        return true;
    }

    public bool EliminarProducto(int id)
    {
        Producto? producto = productos.FirstOrDefault(producto => producto.Id == id);
    
        if (producto == null)
        {
            return false;
        }
    
        productos.Remove(producto);
        return true;
    }
    
    public Producto? BuscarProducto(int id)
    {
        return productos.FirstOrDefault(producto => producto.Id == id);
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
   
       producto.AumentarStock(cantidad);
           return true;
   }

    public bool ReducirStock(int id, int cantidad)
    {
        Producto? producto = BuscarProducto(id);
    
        if (producto == null)
        {
            return false;
        }
    
        
            return producto.ReducirStock(cantidad);
    }

    
}