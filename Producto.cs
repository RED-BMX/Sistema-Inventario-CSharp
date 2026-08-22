public class Producto
{
    public int Id { get; private set; }
    public string Nombre { get; private set; }
    public decimal Precio { get; private set; }
    public int Stock { get; private set; }

    private Producto()
    {
        Nombre = string.Empty;
    }

    public Producto(int id, string nombre, decimal precio, int stock)
    {
        if (id <= 0)
        {
            throw new ArgumentException("El ID debe ser mayor que cero.");
        }
        if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacío.");
            }
        
        if (precio < 0)
            {
                throw new ArgumentException("El precio no puede ser negativo.");
            }
        if (stock < 0)
        {
            throw new ArgumentException("El stock no puede ser negativo.");
        }

        Id = id;
        Nombre = nombre;
        Precio = precio;
        Stock = stock;
    }

    public bool AumentarStock(int cantidad)
    {
        if (cantidad <= 0)
        {
            return false;
        }
    
        Stock += cantidad;
        return true;
    }

    public bool ReducirStock(int cantidad)
    {
        if (cantidad <= 0)
        {
            return false;
        }
    
        if (Stock < cantidad)
        {
            return false;
        }
    
        Stock -= cantidad;
        return true;
    }
}
