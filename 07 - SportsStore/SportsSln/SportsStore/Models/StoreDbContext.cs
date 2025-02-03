using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models;

// Define la interacción con la base de datos y mapea la tabla Products.
public class StoreDbContext(DbContextOptions<StoreDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
}