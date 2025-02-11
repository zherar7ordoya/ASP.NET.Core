using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStore.Infrastructure;
using SportsStore.Models;


namespace SportsStore.Pages;


public class CartModel(IStoreRepository repo) : PageModel
{
    private readonly IStoreRepository repository = repo;

    public Cart? Cart { get; set; }
    public string ReturnUrl { get; set; } = "/";

    //..................................
    // This is GET, stupid!
    public void OnGet(string returnUrl)
    {
        ReturnUrl = returnUrl ?? "/";
        Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
    }

    //..................................
    // This is POST, stupid!
    public IActionResult OnPost(long productId, string returnUrl)
    {
        Product? product = repository.Products.FirstOrDefault(p => p.ProductID == productId);

        if (product != null)
        {
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.AddItem(product, 1);
            HttpContext.Session.SetJson("cart", Cart);
        }

        return RedirectToPage(new { returnUrl });
    }
}
