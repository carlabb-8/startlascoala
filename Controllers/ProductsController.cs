using Microsoft.AspNetCore.Mvc;
using MagazinOnline.Models;

namespace MagazinOnline.Controllers;

public class ProductsController : Controller
{
    public IActionResult Books()
    {
        var books = new List<Product>
        {
            new Product { Id = 101, Name = "Manual Matematica Clasa 5", Price = 29.99m, Category = "Carti", SubCategory = "Clasa 5-12", ImageUrl = "/images/manual1.png", Description = "Manual matematica clasa 5" },
            new Product { Id = 102, Name = "Manual Romana Clasa 5", Price = 27.50m, Category = "Carti", SubCategory = "Clasa 5-12", ImageUrl = "/images/manual2.jpg", Description = "Manual romana clasa 5" },
            new Product { Id = 103, Name = "Manual Geografie Clasa 5", Price = 26.00m, Category = "Carti", SubCategory = "Clasa 5-12", ImageUrl = "/images/manual3.jpg", Description = "Manual geografie clasa 5" },
            new Product { Id = 104, Name = "Manual Matematica Clasa 9", Price = 32.99m, Category = "Carti", SubCategory = "Clasa 5-12", ImageUrl = "/images/manual4.jpg", Description = "Manual matematica clasa 9" },
            new Product { Id = 105, Name = "Manual Fizica Clasa 9", Price = 31.00m, Category = "Carti", SubCategory = "Clasa 5-12", ImageUrl = "/images/manual5.jpg", Description = "Manual fizica clasa 9" },
            new Product { Id = 106, Name = "Manual Chimie Clasa 9", Price = 30.50m, Category = "Carti", SubCategory = "Clasa 5-12", ImageUrl = "/images/manual6.jpg", Description = "Manual chimie clasa 9" },
            new Product { Id = 107, Name = "Manual Romana Clasa 12", Price = 34.99m, Category = "Carti", SubCategory = "Clasa 5-12", ImageUrl = "/images/manual7.jpg", Description = "Manual romana clasa 12" },
            new Product { Id = 108, Name = "Manual Informatica Clasa 12", Price = 36.00m, Category = "Carti", SubCategory = "Clasa 5-12", ImageUrl = "/images/manual8.jpg", Description = "Manual informatica clasa 12" },
            new Product { Id = 109, Name = "Culegere Mate Exercitii Suplimentare", Price = 22.00m, Category = "Carti", SubCategory = "Materii", ImageUrl = "/images/culegere1.jpg", Description = "Exercitii suplimentare de matematica" },
            new Product { Id = 110, Name = "Gramatica Limbii Romane", Price = 19.99m, Category = "Carti", SubCategory = "Materii", ImageUrl = "/images/gramatica.jpg", Description = "Gramatica completa a limbii romane" },
            new Product { Id = 111, Name = "Atlas Geografic Scolar", Price = 45.00m, Category = "Carti", SubCategory = "Materii", ImageUrl = "/images/atlas.jpg", Description = "Atlas geografic pentru scoala" },
            new Product { Id = 112, Name = "Culegere BAC Matematica M1", Price = 39.99m, Category = "Carti", SubCategory = "BAC", ImageUrl = "/images/culegere2.jpg", Description = "Teste BAC matematica M1" },
            new Product { Id = 113, Name = "Culegere BAC Romana", Price = 37.50m, Category = "Carti", SubCategory = "BAC", ImageUrl = "/images/bac1.jpg", Description = "Teste BAC limba romana" },
            new Product { Id = 114, Name = "Culegere BAC Biologie", Price = 35.99m, Category = "Carti", SubCategory = "BAC", ImageUrl = "/images/bac2.jpg", Description = "Teste BAC biologie" },
            new Product { Id = 115, Name = "Culegere EN Matematica Clasa 8", Price = 33.00m, Category = "Carti", SubCategory = "Evaluare Nationala", ImageUrl = "/images/en1.jpg", Description = "Simulari evaluare nationala matematica" },
            new Product { Id = 116, Name = "Culegere EN Romana Clasa 8", Price = 31.00m, Category = "Carti", SubCategory = "Evaluare Nationala", ImageUrl = "/images/en2.jpg", Description = "Simulari evaluare nationala romana" },
            new Product { Id = 117, Name = "Culegere EN Clasa 4", Price = 28.00m, Category = "Carti", SubCategory = "Evaluare Nationala", ImageUrl = "/images/en3.jpg", Description = "Teste evaluare nationala clasa 4" }
        };

        return View(books);
    }

    public IActionResult Supplies()
    {
        var supplies = new List<Product>
        {
            new Product { Id = 201, Name = "Caiet A4 100 file dictando", Price = 8.50m, Category = "Rechizite", SubCategory = "Varsta 6-10", ImageUrl = "/images/caiet_a4_dictando.png", Description = "Caiet liniat pentru clasa 1-4" },
            new Product { Id = 202, Name = "Set Creioane Colorate 24 buc", Price = 15.00m, Category = "Rechizite", SubCategory = "Varsta 6-10", ImageUrl = "/images/crayons.png", Description = "Creioane colorate pentru copii mici" },
            new Product { Id = 203, Name = "Plastelina Set 12 culori", Price = 12.00m, Category = "Rechizite", SubCategory = "Varsta 6-10", ImageUrl = "/images/clay.png", Description = "Plastelina colorata sigura pentru copii" },
            new Product { Id = 204, Name = "Ghiozdan Primar Colorat", Price = 89.00m, Category = "Rechizite", SubCategory = "Varsta 6-10", ImageUrl = "/images/ghiozdan_primar.png", Description = "Ghiozdan usor pentru clasele 1-4" },
            new Product { Id = 205, Name = "Penar cu accesorii incluse", Price = 35.00m, Category = "Rechizite", SubCategory = "Varsta 6-10", ImageUrl = "/images/penar_accesorii.jpg", Description = "Penar complet cu stilou, creioane si guma" },
            new Product { Id = 206, Name = "Caiet A5 cu spirala 80 file", Price = 9.99m, Category = "Rechizite", SubCategory = "Varsta 10-14", ImageUrl = "/images/caiet_a5_spirala.jpg", Description = "Caiet cu spirala pentru gimnaziu" },
            new Product { Id = 207, Name = "Stilou Parker Jotter", Price = 55.00m, Category = "Rechizite", SubCategory = "Varsta 10-14", ImageUrl = "/images/stilou_parker.jpg", Description = "Stilou elegant pentru elevi" },
            new Product { Id = 208, Name = "Set Markere 20 culori", Price = 22.50m, Category = "Rechizite", SubCategory = "Varsta 10-14", ImageUrl = "/images/markere_20_culori.jpg", Description = "Markere colorate pentru proiecte scolare" },
            new Product { Id = 209, Name = "Ghiozdan Ergonomic Gimnaziu", Price = 125.00m, Category = "Rechizite", SubCategory = "Varsta 10-14", ImageUrl = "/images/ghiozdan2.jpg", Description = "Ghiozdan cu bretele ergonomice" },
            new Product { Id = 210, Name = "Calculator Stiintific Casio", Price = 79.99m, Category = "Rechizite", SubCategory = "Varsta 10-14", ImageUrl = "/images/calculator_casio.jpg", Description = "Calculator stiintific pentru gimnaziu si liceu" },
            new Product { Id = 211, Name = "Agenda Scolara A5", Price = 18.00m, Category = "Rechizite", SubCategory = "Varsta 14+", ImageUrl = "/images/agenda_scolara.jpg", Description = "Agenda organizator pentru liceu" },
            new Product { Id = 212, Name = "Set Pixuri Pilot G2 6 buc", Price = 28.00m, Category = "Rechizite", SubCategory = "Varsta 14+", ImageUrl = "/images/pixuri.jpg", Description = "Pixuri cu gel pentru scriere fluida" },
            new Product { Id = 213, Name = "Dosar Prezentare A4 50 file", Price = 14.50m, Category = "Rechizite", SubCategory = "Varsta 14+", ImageUrl = "/images/dosar_prezentare.jpg", Description = "Dosar pentru proiecte si referate" },
            new Product { Id = 214, Name = "Calculator Grafic Texas TI-84", Price = 249.00m, Category = "Rechizite", SubCategory = "Varsta 14+", ImageUrl = "/images/texas.jpg", Description = "Calculator grafic pentru matematica avansata" }
        };

        return View(supplies);
    }
}
