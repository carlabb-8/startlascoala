using Microsoft.AspNetCore.Mvc;
using MagazinOnline.Models;

namespace MagazinOnline.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var popularProducts = new List<Product>
        {
            new Product { Id = 1, Name = "Manual Matematica Clasa 9", Price = 32.99m, Category = "Carti", SubCategory = "Clasa 9", ImageUrl = "/images/manual4.jpg", Description = "Manual complet de matematica pentru clasa a 9-a" },
            new Product { Id = 2, Name = "Caiet A4 100 file", Price = 8.50m, Category = "Rechizite", SubCategory = "Varsta 6-10", ImageUrl = "/images/caiet_a4_dictando.png", Description = "Caiet cu linii pentru scoala" },
            new Product { Id = 3, Name = "Manual Romana Clasa 12", Price = 34.99m, Category = "Carti", SubCategory = "Clasa 12", ImageUrl = "/images/manual7.jpg", Description = "Manual de limba romana pentru clasa a 12-a" },
            new Product { Id = 4, Name = "Set Creioane Colorate 24 buc", Price = 15.00m, Category = "Rechizite", SubCategory = "Varsta 6-10", ImageUrl = "/images/crayons.png", Description = "Set de creioane colorate pentru copii" },
            new Product { Id = 5, Name = "Culegere BAC Matematica M1", Price = 39.99m, Category = "Carti", SubCategory = "BAC", ImageUrl = "/images/culegere2.jpg", Description = "Culegere cu teste pentru examenul de bacalaureat" },
            new Product { Id = 6, Name = "Ghiozdan Ergonomic Gimnaziu", Price = 125.00m, Category = "Rechizite", SubCategory = "Varsta 10-14", ImageUrl = "/images/ghiozdan2.jpg", Description = "Ghiozdan ergonomic cu multiple compartimente" }
        };

        return View(popularProducts);
    }

    public IActionResult About()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View();
    }
}
