using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStore.Infrastructure;
using SportsStore.Models;

namespace SportsStore.Pages;

public class CartModel(IStoreRepository repo, Cart cartService) : PageModel
{
    private readonly IStoreRepository repository = repo;

    public Cart Cart { get; set; } = cartService;
    public string ReturnUrl { get; set; } = "/";

    // This is the GET
    public void OnGet(string returnUrl)
    {
        ReturnUrl = returnUrl ?? "/";
        //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart(); 
    }

    // This is the POST
    public IActionResult OnPost(long productId, string returnUrl)
    {
        Product? product = repository.Products.FirstOrDefault(p => p.ProductID == productId);

        if (product != null)
        {
            Cart.AddItem(product, 1);
        }

        return RedirectToPage(new { returnUrl });
    }

    public IActionResult OnPostRemove(long productId, string returnUrl)
    {
        Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.ProductID == productId).Product);
        return RedirectToPage(new { returnUrl });
    }
}
