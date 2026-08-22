using Microsoft.EntityFrameworkCore;

public class InventarioDbContext : DbContext
{
    public DbSet<Producto> Productos { get; set; }

    public InventarioDbContext(DbContextOptions<InventarioDbContext> options)
        : base(options)
    {
    }
}
