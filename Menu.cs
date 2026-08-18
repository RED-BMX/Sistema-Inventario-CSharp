public class Menu
{
    private Inventario inventario;

    public Menu(Inventario inventario)
    {
        this.inventario = inventario;
    }

    public void MostrarMenu()
    {
        Console.WriteLine("===== SISTEMA DE INVENTARIO =====");
        Console.WriteLine("1. Agregar producto");
        Console.WriteLine("2. Eliminar producto");
        Console.WriteLine("3. Buscar producto");
        Console.WriteLine("4. Mostrar productos");
        Console.WriteLine("5. Aumentar stock");
        Console.WriteLine("6. Reducir stock");
        Console.WriteLine("0. Salir");
        Console.Write("Seleccione una opción: ");
    }

    public void Ejecutar()
    {
        int opcion = -1;
    
        while (opcion != 0)
        {
            MostrarMenu();
    
            string? entrada = Console.ReadLine();
    
            if (int.TryParse(entrada, out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        AgregarProducto();
                        break;

                    case 2:
                        EliminarProducto();
                        break;

                    case 3:
                        BuscarProducto();
                        break;
            
                    case 0:
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    
                    case 4:
                        MostrarProductos();
                        break;

                    case 5:
                        AumentarStock();
                        break;

                    case 6:
                        ReducirStock();
                        break;
            
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opción no válida.");
                opcion = -1;
            }
    
            Console.WriteLine();
        }
    }

    private void AgregarProducto()
    {
        if (!IntentarLeerId(out int id))
        {
            return;
        }
    
        Console.Write("Ingrese el nombre: ");
        string? nombre = Console.ReadLine();
    
        if (string.IsNullOrWhiteSpace(nombre))
        {
            Console.WriteLine("El nombre no puede estar vacío.");
            return;
        }
    
        Console.Write("Ingrese el precio: ");
        string? entradaPrecio = Console.ReadLine();
    
        if (!decimal.TryParse(entradaPrecio, out decimal precio))
        {
            Console.WriteLine("El precio debe ser un número.");
            return;
        }
    
        if (precio < 0)
        {
            Console.WriteLine("El precio no puede ser negativo.");
            return;
        }
    
        Console.Write("Ingrese el stock: ");
        string? entradaStock = Console.ReadLine();
    
        if (!int.TryParse(entradaStock, out int stock))
        {
            Console.WriteLine("El stock debe ser un número.");
            return;
        }
    
        if (stock < 0)
        {
            Console.WriteLine("El stock no puede ser negativo.");
            return;
        }
    
       Producto producto = new Producto(id, nombre, precio, stock);
    
        bool agregado = inventario.AgregarProducto(producto);
    
        if (agregado)
        {
            Console.WriteLine("Producto agregado correctamente.");
        }
        else
        {
            Console.WriteLine("Ya existe un producto con ese ID.");
        }
    }

    private void EliminarProducto()
    {
        if (!IntentarLeerId(out int id))
        {
            return;
        }
    
        bool eliminado = inventario.EliminarProducto(id);
    
        if (eliminado)
        {
            Console.WriteLine("Producto eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    private void BuscarProducto()
    {
        if (!IntentarLeerId(out int id))
        {
            return;
        }
    
        Producto? producto = inventario.BuscarProducto(id);
    
        if (producto != null)
        {
            Console.WriteLine($"ID: {producto.Id}");
            Console.WriteLine($"Nombre: {producto.Nombre}");
            Console.WriteLine($"Precio: {producto.Precio:C}");
            Console.WriteLine($"Stock: {producto.Stock}");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    private void AumentarStock()
    {
        if (!IntentarLeerId(out int id))
        {
            return;
        }
    
        if (!IntentarLeerCantidad("Ingrese la cantidad a aumentar: ", out int cantidad))
        {
            return;
        }
    
        bool aumentado = inventario.AumentarStock(id, cantidad);
    
        if (aumentado)
        {
            Console.WriteLine("Stock actualizado correctamente.");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

   private void ReducirStock()
   {
       if (!IntentarLeerId(out int id))
       {
           return;
       }
   
       if (!IntentarLeerCantidad("Ingrese la cantidad a reducir: ", out int cantidad))
       {
           return;
       }
   
       bool reducido = inventario.ReducirStock(id, cantidad);
   
       if (reducido)
       {
           Console.WriteLine("Stock actualizado correctamente.");
       }
       else
       {
           Console.WriteLine("No se pudo reducir el stock.");
       }
   }

   private bool IntentarLeerId(out int id)
   {
       Console.Write("Ingrese el ID: ");
       string? entradaId = Console.ReadLine();
   
       if (!int.TryParse(entradaId, out id))
       {
           Console.WriteLine("El ID debe ser un número.");
           return false;
       }
   
       if (id <= 0)
       {
           Console.WriteLine("El ID debe ser mayor que cero.");
           return false;
       }
   
       return true;
   }

   private bool IntentarLeerCantidad(string mensaje, out int cantidad)
   {
       Console.Write(mensaje);
       string? entradaCantidad = Console.ReadLine();
   
       if (!int.TryParse(entradaCantidad, out cantidad))
       {
           Console.WriteLine("La cantidad debe ser un número.");
           return false;
       }
   
       if (cantidad <= 0)
       {
           Console.WriteLine("La cantidad debe ser mayor que cero.");
           return false;
       }
   
       return true;
   }

   private void MostrarProductos()
   {
       IEnumerable<Producto> productos = inventario.ObtenerProductos();
   
       bool hayProductos = false;
   
       foreach (Producto producto in productos)
       {
           hayProductos = true;
   
           Console.WriteLine(
               $"ID: {producto.Id} | " +
               $"Nombre: {producto.Nombre} | " +
               $"Precio: {producto.Precio:C} | " +
               $"Stock: {producto.Stock}");
       }
   
       if (!hayProductos)
       {
           Console.WriteLine("No hay productos registrados.");
       }
   }
}
