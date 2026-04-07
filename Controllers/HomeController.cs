// HomeController.cs — gestionează cererile pentru paginile principale ale site-ului
// Acest controller răspunde pentru pagina principală și pagina "Despre Noi"

// Importăm uneltele MVC de care avem nevoie (Controller, IActionResult, etc.)
using Microsoft.AspNetCore.Mvc;

// Importăm modelele personalizate pentru a putea folosi clasa Product
using MagazinOnline.Models;

// Declarăm namespace-ul care grupează toți controllerii împreună
namespace MagazinOnline.Controllers;

// HomeController moștenește din Controller — ne oferă acces la View(), Json(), etc.
public class HomeController : Controller
{
    // Index() răspunde la cererile către URL-ul rădăcină "/" sau "/Home/Index"
    // IActionResult este tipul returnat — poate fi un View, o redirijare sau alt răspuns
    public IActionResult Index()
    {
        // Creăm o listă de produse populare pentru a fi afișate pe pagina principală
        // Acestea sunt produse ukrample prezentate ca articole "recomandate"
        var popularProducts = new List<Product>
        {
            // Fiecare 'new Product { ... }' creează un obiect produs cu proprietățile completate
            new Product { Id = 1, Name = "Manual Matematica Clasa 9", Price = 32.99m, Category = "Carti", SubCategory = "Clasa 9", ImageUrl = "/images/manual4.jpg", Description = "Manual complet de matematica pentru clasa a 9-a" },

            new Product { Id = 2, Name = "Caiet A4 100 file", Price = 8.50m, Category = "Rechizite", SubCategory = "Varsta 6-10", ImageUrl = "/images/caiet_a4_dictando.png", Description = "Caiet cu linii pentru scoala" },

            new Product { Id = 3, Name = "Manual Romana Clasa 12", Price = 34.99m, Category = "Carti", SubCategory = "Clasa 12", ImageUrl = "/images/manual7.jpg", Description = "Manual de limba romana pentru clasa a 12-a" },

            new Product { Id = 4, Name = "Set Creioane Colorate 24 buc", Price = 15.00m, Category = "Rechizite", SubCategory = "Varsta 6-10", ImageUrl = "/images/crayons.png", Description = "Set de creioane colorate pentru copii" },

            new Product { Id = 5, Name = "Culegere BAC Matematica M1", Price = 39.99m, Category = "Carti", SubCategory = "BAC", ImageUrl = "/images/culegere2.jpg", Description = "Culegere cu teste pentru examenul de bacalaureat" },

            new Product { Id = 6, Name = "Ghiozdan Ergonomic Gimnaziu", Price = 125.00m, Category = "Rechizite", SubCategory = "Varsta 10-14", ImageUrl = "/images/ghiozdan2.jpg", Description = "Ghiozdan ergonomic cu multiple compartimente" }
        };

        // Transmitem lista de produse populare către view-ul Index
        // View-ul va parcurge această listă și va afișa fiecare produs ca un card
        return View(popularProducts);
    }

    // About() răspunde la cererile către "/Home/About"
    // Returnează view-ul paginii Despre Noi — nu are nevoie de date, conținut static
    public IActionResult About()
    {
        // Returnez view-ul About.cshtml fără niciun model de date
        return View();
    }

    // Error() răspunde când ceva merge prost pe server
    // [ResponseCache] spune browser-ului să NU pună în cache această pagină
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        // Returnez view-ul de eroare — într-o aplicație reală ai transmite detaliile erorii
        return View();
    }
}
