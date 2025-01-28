using System.Collections;

namespace LanguageFeatures.Models;

public class ShoppingCart : IProductSelection
{
    public List<Product> products = new();
    public IEnumerable<Product>? Products { get => products; }
    //..........................................................................
    public ShoppingCart(params Product[] prods)
    {
        products.AddRange(prods);
    }
}
