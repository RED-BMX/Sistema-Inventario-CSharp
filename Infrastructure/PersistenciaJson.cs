using System.Text.Json;
using Sistema_Inventario_CSharp.Application;
using Sistema_Inventario_CSharp.Domain;

namespace Sistema_Inventario_CSharp.Infrastructure;

public class PersistenciaJson : IPersistencia
{
    private readonly string rutaArchivo = "productos.json";

    public void GuardarProductos(IEnumerable<Producto> productos)
    {
        try
        {
            string json = JsonSerializer.Serialize(
                productos,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(rutaArchivo, json);
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error al guardar los productos: {ex.Message}");
        }
    }

    public IEnumerable<Producto> CargarProductos()
    {
        if (!File.Exists(rutaArchivo))
        {
            return new List<Producto>();
        }

        try
        {
            string json = File.ReadAllText(rutaArchivo);

            return JsonSerializer.Deserialize<List<Producto>>(json)
                   ?? new List<Producto>();
        }
        catch (JsonException)
        {
            Console.WriteLine("Error: el archivo de productos contiene JSON inválido.");
            return new List<Producto>();
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error al leer los productos: {ex.Message}");
            return new List<Producto>();
        }
    }
}