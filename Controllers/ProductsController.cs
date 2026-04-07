// ProductsController.cs — gestionează cererile pentru paginile de produse (Cărți și Rechizite)
// Acest controller construiește listele de produse și le trimite către view-uri

// Importăm MVC framework pentru a putea folosi Controller, IActionResult, etc.
using Microsoft.AspNetCore.Mvc;

// Importăm modelul Product pentru a crea liste de produse
using MagazinOnline.Models;

// Grupăm acest controller sub namespace-ul MagazinOnline.Controllers
namespace MagazinOnline.Controllers;

// ProductsController moștenește din Controller pentru a avea acces la metodele MVC
public class ProductsController : Controller
{
    // Books() răspunde la cererile către "/Products/Books"
    // Pregătește lista de cărți școlare și o trimite view-ului Books
    public IActionResult Books()
    {
        // Creăm o listă completă de cărți vândute în magazin
        // Fiecare carte are Id, Nume, Preț, Categorie, Subcategorie și URL imagine
        var books = new List<Product>
        {
            // --- Clasa 5 ---
            // Cărți pentru elevii din clasa a 5-a
            new Product { Id = 101, Name = "Manual Matematica Clasa 5", Price = 29.99m, Category = "Carti", SubCategory = "Clasa 5-12", ImageUrl = "/images/book_math.png", Description = "Manual matematica clasa 5" },
            new Product { Id = 102, Name = "Manual Romana Clasa 5", Price = 27.50m, Category = "Carti", SubCategory = "Clasa 5-12", ImageUrl = "/images/book_ro.png", Description = "Manual romana clasa 5" },
            new Product { Id = 103, Name = "Manual Geografie Clasa 5", Price = 26.00m, Category = "Carti", SubCategory = "Clasa 5-12", ImageUrl = "/images/book_geo.png", Description = "Manual geografie clasa 5" },

            // --- Clasa 9 ---
            // Cărți pentru elevii din clasa a 9-a
            new Product { Id = 104, Name = "Manual Matematica Clasa 9", Price = 32.99m, Category = "Carti", SubCategory = "Clasa 5-12", ImageUrl = "/images/book_math.png", Description = "Manual matematica clasa 9" },
            new Product { Id = 105, Name = "Manual Fizica Clasa 9", Price = 31.00m, Category = "Carti", SubCategory = "Clasa 5-12", ImageUrl = "/images/book_phys.png", Description = "Manual fizica clasa 9" },
            new Product { Id = 106, Name = "Manual Chimie Clasa 9", Price = 30.50m, Category = "Carti", SubCategory = "Clasa 5-12", ImageUrl = "/images/book_chem.png", Description = "Manual chimie clasa 9" },

            // --- Clasa 12 ---
            // Cărți pentru elevii din clasa a 12-a
            new Product { Id = 107, Name = "Manual Romana Clasa 12", Price = 34.99m, Category = "Carti", SubCategory = "Clasa 5-12", ImageUrl = "/images/book_ro.png", Description = "Manual romana clasa 12" },
            new Product { Id = 108, Name = "Manual Informatica Clasa 12", Price = 36.00m, Category = "Carti", SubCategory = "Clasa 5-12", ImageUrl = "/images/book_info.png", Description = "Manual informatica clasa 12" },

            // --- Materii (Discipline) ---
            // Cărți pe discipline specifice (nu legate de o anumită clasă)
            new Product { Id = 109, Name = "Culegere Mate Exercitii Suplimentare", Price = 22.00m, Category = "Carti", SubCategory = "Materii", ImageUrl = "/images/book_math.png", Description = "Exercitii suplimentare de matematica" },
            new Product { Id = 110, Name = "Gramatica Limbii Romane", Price = 19.99m, Category = "Carti", SubCategory = "Materii", ImageUrl = "/images/book_ro.png", Description = "Gramatica completa a limbii romane" },
            new Product { Id = 111, Name = "Atlas Geografic Scolar", Price = 45.00m, Category = "Carti", SubCategory = "Materii", ImageUrl = "/images/book_geo.png", Description = "Atlas geografic pentru scoala" },

            // --- BAC ---
            // Cărți de pregătire pentru examenul de bacalaureat
            new Product { Id = 112, Name = "Culegere BAC Matematica M1", Price = 39.99m, Category = "Carti", SubCategory = "BAC", ImageUrl = "/images/book_bac.png", Description = "Teste BAC matematica M1" },
            new Product { Id = 113, Name = "Culegere BAC Romana", Price = 37.50m, Category = "Carti", SubCategory = "BAC", ImageUrl = "/images/book_bac.png", Description = "Teste BAC limba romana" },
            new Product { Id = 114, Name = "Culegere BAC Biologie", Price = 35.99m, Category = "Carti", SubCategory = "BAC", ImageUrl = "/images/book_bac.png", Description = "Teste BAC biologie" },

            // --- Evaluare Națională ---
            // Cărți de pregătire pentru Evaluarea Națională (sfârșitul clasei a 8-a)
            new Product { Id = 115, Name = "Culegere EN Matematica Clasa 8", Price = 33.00m, Category = "Carti", SubCategory = "Evaluare Nationala", ImageUrl = "/images/book_eval.png", Description = "Simulari evaluare nationala matematica" },
            new Product { Id = 116, Name = "Culegere EN Romana Clasa 8", Price = 31.00m, Category = "Carti", SubCategory = "Evaluare Nationala", ImageUrl = "/images/book_eval.png", Description = "Simulari evaluare nationala romana" },
            new Product { Id = 117, Name = "Culegere EN Clasa 4", Price = 28.00m, Category = "Carti", SubCategory = "Evaluare Nationala", ImageUrl = "/images/book_eval.png", Description = "Teste evaluare nationala clasa 4" }
        };

        // Trimitem lista de cărți către view-ul Books.cshtml pentru a afișa produsele
        return View(books);
    }

    // Supplies() răspunde la cererile către "/Products/Supplies"
    // Pregătește lista de rechizite școlare și o trimite view-ului Supplies
    public IActionResult Supplies()
    {
        // Creăm o listă de rechizite organizate pe grupe de vârstă
        var supplies = new List<Product>
        {
            // --- Varsta 6-10 (Vârsta 6-10) ---
            // Produse potrivite pentru copii mici din școala primară
            new Product { Id = 201, Name = "Caiet A4 100 file dictando", Price = 8.50m, Category = "Rechizite", SubCategory = "Varsta 6-10", ImageUrl = "/images/caiet_a4_dictando.png", Description = "Caiet liniat pentru clasa 1-4" },
            new Product { Id = 202, Name = "Set Creioane Colorate 24 buc", Price = 15.00m, Category = "Rechizite", SubCategory = "Varsta 6-10", ImageUrl = "/images/crayons.png", Description = "Creioane colorate pentru copii mici" },
            new Product { Id = 203, Name = "Plastelina Set 12 culori", Price = 12.00m, Category = "Rechizite", SubCategory = "Varsta 6-10", ImageUrl = "/images/clay.png", Description = "Plastelina colorata sigura pentru copii" },
            new Product { Id = 204, Name = "Ghiozdan Primar Colorat", Price = 89.00m, Category = "Rechizite", SubCategory = "Varsta 6-10", ImageUrl = "/images/ghiozdan_primar.png", Description = "Ghiozdan usor pentru clasele 1-4" },
            new Product { Id = 205, Name = "Penar cu accesorii incluse", Price = 35.00m, Category = "Rechizite", SubCategory = "Varsta 6-10", ImageUrl = "/images/penar_accesorii.jpg", Description = "Penar complet cu stilou, creioane si guma" },

            // --- Varsta 10-14 (Vârsta 10-14) ---
            // Produse pentru elevii din gimnaziu
            new Product { Id = 206, Name = "Caiet A5 cu spirala 80 file", Price = 9.99m, Category = "Rechizite", SubCategory = "Varsta 10-14", ImageUrl = "/images/caiet_a5_spirala.jpg", Description = "Caiet cu spirala pentru gimnaziu" },
            new Product { Id = 207, Name = "Stilou Parker Jotter", Price = 55.00m, Category = "Rechizite", SubCategory = "Varsta 10-14", ImageUrl = "/images/stilou_parker.jpg", Description = "Stilou elegant pentru elevi" },
            new Product { Id = 208, Name = "Set Markere 20 culori", Price = 22.50m, Category = "Rechizite", SubCategory = "Varsta 10-14", ImageUrl = "/images/markere_20_culori.jpg", Description = "Markere colorate pentru proiecte scolare" },
            new Product { Id = 209, Name = "Ghiozdan Ergonomic Gimnaziu", Price = 125.00m, Category = "Rechizite", SubCategory = "Varsta 10-14", ImageUrl = "/images/ghiozdan_gimnaziu.png", Description = "Ghiozdan cu bretele ergonomice" },
            new Product { Id = 210, Name = "Calculator Stiintific Casio", Price = 79.99m, Category = "Rechizite", SubCategory = "Varsta 10-14", ImageUrl = "/images/calculator_casio.jpg", Description = "Calculator stiintific pentru gimnaziu si liceu" },

            // --- Varsta 14+ (Age 14+) ---
            // Products for high school students
            new Product { Id = 211, Name = "Agenda Scolara A5", Price = 18.00m, Category = "Rechizite", SubCategory = "Varsta 14+", ImageUrl = "/images/agenda_scolara.jpg", Description = "Agenda organizator pentru liceu" },
            new Product { Id = 212, Name = "Set Pixuri Pilot G2 6 buc", Price = 28.00m, Category = "Rechizite", SubCategory = "Varsta 14+", ImageUrl = "/images/pen.png", Description = "Pixuri cu gel pentru scriere fluida" },
            new Product { Id = 213, Name = "Dosar Prezentare A4 50 file", Price = 14.50m, Category = "Rechizite", SubCategory = "Varsta 14+", ImageUrl = "/images/folder.png", Description = "Dosar pentru proiecte si referate" },
            new Product { Id = 214, Name = "Calculator Grafic Texas TI-84", Price = 249.00m, Category = "Rechizite", SubCategory = "Varsta 14+", ImageUrl = "/images/calculator.png", Description = "Calculator grafic pentru matematica avansata" }
        };

        // Send the supplies list to the Supplies.cshtml view
        return View(supplies);
    }
}
