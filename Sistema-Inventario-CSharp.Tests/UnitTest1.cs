
using System.Collections.Generic;
using System.Linq;
using Sistema_Inventario_CSharp;
using Sistema_Inventario_CSharp.Tests;

public class InventarioTests
{
    [Fact]
    public void AgregarProducto_AgregaProductoCorrectamente()
    {
        // Arrange
        var persistencia = new FakePersistencia();
        var inventario = new Inventario(persistencia);
        
        var producto = new Producto(1, "Producto Prueba", 10.99m, 5);

        // Act
        bool resultado = inventario.AgregarProducto(producto);
        
        // Assert
        Assert.True(resultado);
        Assert.Single(inventario.ObtenerProductos());
    }

    [Fact]
    public void AgregarProducto_EvitaIDsRepetidos()
    {
        // Arrange
        var persistencia = new FakePersistencia();
        var inventario = new Inventario(persistencia);
        
        var producto1 = new Producto(1, "Producto Prueba", 10.99m, 5);
        inventario.AgregarProducto(producto1);

        var producto2 = new Producto(1, "Otro Producto", 5.99m, 3);

        // Act
        bool resultado = inventario.AgregarProducto(producto2);

        // Assert
        Assert.False(resultado);
        Assert.Single(inventario.ObtenerProductos());
    }

    [Fact]
    public void BuscarProducto_BuscaProductoExistente()
    {
        // Arrange
        var persistencia = new FakePersistencia();
        var inventario = new Inventario(persistencia);

        var producto1 = new Producto(1, "Producto Prueba", 10.99m, 5);
        inventario.AgregarProducto(producto1);

        // Act
        var resultado = inventario.BuscarProducto(1);

        // Assert
        Assert.NotNull(resultado);
        Assert.Equal(1, resultado.Id);
    }

    [Fact]
    public void BuscarProducto_BuscaProductoNoExistente()
    {
        // Arrange
        var persistencia = new FakePersistencia();
        var inventario = new Inventario(persistencia);

        // Act
        var producto = inventario.BuscarProducto(1);

        // Assert
        Assert.Null(producto);
    }

    [Fact]
    public void EliminarProducto_EliminaCorrectamenteUnProductoExistente()
    {
        // Arrange
        var persistencia = new FakePersistencia();
        var inventario = new Inventario(persistencia);

        var producto1 = new Producto(1, "Producto Prueba", 10.99m, 5);
        inventario.AgregarProducto(producto1);

        // Act
        bool resultado = inventario.EliminarProducto(1);

        // Assert
        Assert.True(resultado);
        Assert.Empty(inventario.ObtenerProductos());
    }

    [Fact]
    public void EliminarProducto_DevuelveFalseSiElProductoNoExiste()
    {
        // Arrange
        var persistencia = new FakePersistencia();
        var inventario = new Inventario(persistencia);

        // Act
        bool resultado = inventario.EliminarProducto(1);

        // Assert
        Assert.False(resultado);
        Assert.Empty(inventario.ObtenerProductos());
    }

    [Fact]
    public void AumentarStock_AumentaCorrectamenteElStock()
    {
        // Arrange
        var persistencia = new FakePersistencia();
        var inventario = new Inventario(persistencia);

        var producto1 = new Producto(1, "Producto Prueba", 10.99m, 5);
        inventario.AgregarProducto(producto1);

        // Act
        bool resultado = inventario.AumentarStock(1, 3);

        // Assert
        Assert.True(resultado);
        var productoAumentado = inventario.BuscarProducto(1);
        Assert.NotNull(productoAumentado);
        Assert.Equal(8, productoAumentado.Stock);
    }

    [Fact]
    public void AumentarStock_DevuelveFalseConCantidadNegativa()
    {
        // Arrange
        var persistencia = new FakePersistencia();
        var inventario = new Inventario(persistencia);

        var producto1 = new Producto(1, "Producto Prueba", 10.99m, 5);
        inventario.AgregarProducto(producto1);

        // Act
        bool resultado = inventario.AumentarStock(1, -3);

        // Assert
        Assert.False(resultado);
        var productoAumentado = inventario.BuscarProducto(1);
        Assert.NotNull(productoAumentado);
        Assert.Equal(5, productoAumentado.Stock);
    }

    [Fact]
    public void ReducirStock_ReduceCorrectamenteElStock()
    {
        // Arrange
        var persistencia = new FakePersistencia();
        var inventario = new Inventario(persistencia);

        var producto1 = new Producto(1, "Producto Prueba", 10.99m, 5);
        inventario.AgregarProducto(producto1);

        // Act
        bool resultado = inventario.ReducirStock(1, 2);

        // Assert
        Assert.True(resultado);
        var productoReducido = inventario.BuscarProducto(1);
        Assert.NotNull(productoReducido);
        Assert.Equal(3, productoReducido.Stock);
    }

    [Fact]
    public void ReducirStock_DevuelveFalseConCantidadNegativa()
    {
        // Arrange
        var persistencia = new FakePersistencia();
        var inventario = new Inventario(persistencia);

        var producto1 = new Producto(1, "Producto Prueba", 10.99m, 5);
        inventario.AgregarProducto(producto1);

        // Act
        bool resultado = inventario.ReducirStock(1, -2);

        // Assert
        Assert.False(resultado);
        var productoReducido = inventario.BuscarProducto(1);
        Assert.NotNull(productoReducido);
        Assert.Equal(5, productoReducido.Stock);
    }

    [Fact]
    public void ReducirStock_DevuelveFalseConCantidadSuperiorAlStock()
    {
        // Arrange
        var persistencia = new FakePersistencia();
        var inventario = new Inventario(persistencia);

        var producto1 = new Producto(1, "Producto Prueba", 10.99m, 5);
        inventario.AgregarProducto(producto1);

        // Act
        bool resultado = inventario.ReducirStock(1, 6);

        // Assert
        Assert.False(resultado);
        var productoReducido = inventario.BuscarProducto(1);
        Assert.NotNull(productoReducido);
        Assert.Equal(5, productoReducido.Stock);
    }

    [Fact]
    public void ObtenerProductos_DevuelveCorrectamenteTodosLosProductosAgregados()
    {
        // Arrange
        var persistencia = new FakePersistencia();
        var inventario = new Inventario(persistencia);

        var producto1 = new Producto(1, "Producto Prueba", 10.99m, 5);
        var producto2 = new Producto(2, "Otro Producto", 5.99m, 3);
        inventario.AgregarProducto(producto1);
        inventario.AgregarProducto(producto2);

        // Act
        IEnumerable<Producto> productos = inventario.ObtenerProductos();

        // Assert
        Assert.Equal(2, productos.Count());
    }
}