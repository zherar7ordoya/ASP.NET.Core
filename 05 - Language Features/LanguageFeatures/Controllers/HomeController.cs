namespace LanguageFeatures.Controllers;

public class HomeController : Controller
{
    public ViewResult Index()
    {
        return View(Product.GetProducts().Where(p => p != null).Select(p => p?.Name));
    }
}
