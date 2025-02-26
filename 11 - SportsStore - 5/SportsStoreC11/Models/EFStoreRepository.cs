﻿namespace SportsStore.Models;

// Se encarga de proporcionar acceso a los datos de Product mediante IQueryable,
// permitiendo filtrado y paginación en la capa de servicio.
public class EFStoreRepository(StoreDbContext ctx) : IStoreRepository
{
    private readonly StoreDbContext context = ctx;
    public IQueryable<Product> Products => context.Products;

    public void CreateProduct(Product p)
    {
        context.Add(p);
        context.SaveChanges();
    }

    public void DeleteProduct(Product p)
    {
        context.Remove(p);
        context.SaveChanges();
    }

    public void SaveProduct(Product p)
    {
        context.SaveChanges();
    }
}
