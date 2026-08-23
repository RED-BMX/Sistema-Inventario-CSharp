using Sistema_Inventario_CSharp.Application;
using Sistema_Inventario_CSharp.Domain;

using System.Collections.Generic;
using System.Linq;
using Sistema_Inventario_CSharp;

namespace Sistema_Inventario_CSharp.Tests;

public class FakePersistencia : IPersistencia
{
    private List<Producto> productos = new();

    public void GuardarProductos(IEnumerable<Producto> productos)
    {
        this.productos = productos.ToList();
    }

    public IEnumerable<Producto> CargarProductos()
    {
        return productos.AsReadOnly();
    }
}
