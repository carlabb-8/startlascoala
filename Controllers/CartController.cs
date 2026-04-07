// CartController.cs — gestionează cererile pentru paginile Coș de Cumpărături și Finalizare Comandă
// Datele coșului sunt stocate în browser prin JavaScript/localStorage
// Acest controller returnează doar paginile View — nu stochez datele coșului pe server

// Importăm MVC framework pentru a putea folosi Controller și IActionResult
using Microsoft.AspNetCore.Mvc;

// Grupăm acest controller sub namespace-ul MagazinOnline.Controllers
namespace MagazinOnline.Controllers;

// CartController moștenește din Controller pentru a avea acces la View() și alte metode helper
public class CartController : Controller
{
    // Index() răspunde la cererile către "/Cart" sau "/Cart/Index"
    // Această pagină afișează produsele din coș (datele vin din localStorage din browser)
    public IActionResult Index()
    {
        // Returnez view-ul Coș (produsele sunt gestionate în JavaScript, nu aici)
        return View();
    }

    // Checkout() răspunde la cererile către "/Cart/Checkout"
    // Această pagină afișează formularul de comandă pentru a introduce datele de livrare
    public IActionResult Checkout()
    {
        // Returnez view-ul Checkout cu formularul de comandă
        return View();
    }
}
