
using Microsoft.EntityFrameworkCore;
using Sistema_Inventario_CSharp.Domain;

namespace Sistema_Inventario_CSharp.Infrastructure;

public class InventarioDbContext : DbContext
{
    public DbSet<Producto> Productos { get; set; }

    public InventarioDbContext(DbContextOptions<InventarioDbContext> options)
        : base(options)
    {
    }
}