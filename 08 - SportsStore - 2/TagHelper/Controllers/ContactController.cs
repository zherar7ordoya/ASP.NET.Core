using System.Text.Json;

using ContactManager.Models;

using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Controllers;

public class ContactController : Controller
{
    public IActionResult Index()
    {
        string pathData = "Data/collection.json";
        using var jsonFile = System.IO.File.OpenRead(pathData);

        var contacts = JsonSerializer.Deserialize<List<Contact>>(jsonFile);

        if (contacts == null)
        {
            return NotFound();
        }

        return View(contacts);
    }

    public IActionResult Detail(Guid? id)
    {
        string pathData = "Data/collection.json";
        using var jsonFile = System.IO.File.OpenRead(pathData);

        var contacts = JsonSerializer.Deserialize<List<Contact>>(jsonFile);

        if (id == null || contacts == null)
        {
            return NotFound();
        }

        var contact = contacts.FirstOrDefault(x => x.Id == id);

        if (contact == null)
        {
            return NotFound();
        }
        return View(contact);
    }

    //..........................................................................
}