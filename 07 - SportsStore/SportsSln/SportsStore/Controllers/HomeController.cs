using Microsoft.AspNetCore.Mvc;

using SportsStore.Models;

namespace SportsStore.Controllers;

public class HomeController(IStoreRepository repo) : Controller
{
    private readonly IStoreRepository repository = repo;

    public IActionResult Index() => View(repository.Products);
}
