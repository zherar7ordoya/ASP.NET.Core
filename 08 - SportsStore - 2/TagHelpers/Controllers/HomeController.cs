using Microsoft.AspNetCore.Mvc;


namespace ContactManager.Controllers;


public class HomeController : Controller
{

    public IActionResult Index()
    {
        // La idea es que, cuando se cargue la página de inicio, se redirija
        // automáticamente a la lista de contactos.
        return RedirectToAction("Index", "Contact");
    }
}
