// Product.cs — definește structura de date (modelul) pentru un produs din magazin
// Acest fișier se află în folderul Models și reprezintă un singur produs

// Declarăm namespace-ul astfel încât celelalte fișiere din proiect să poată găsi această clasă
namespace MagazinOnline.Models;

// Definim clasa Product — un șablon care descrie cum arată un produs
public class Product
{
    // Id este un număr unic care identifică fiecare produs (ex: 1, 2, 3...)
    public int Id { get; set; }

    // Name conține titlul produsului, ex: "Matematică Clasa 9"
    // '= string.Empty' previne avertismentele de null prin setarea valorii implicite la string gol
    public string Name { get; set; } = string.Empty;

    // Price conține prețul produsului, stocat ca decimal pentru precizie
    // ex: 29.99 (decimal este mai bun decât float pentru valori monetare)
    public decimal Price { get; set; }

    // Category descrie tipul produsului, ex: "Cărți" sau "Rechizite"
    public string Category { get; set; } = string.Empty;

    // SubCategory conține o grupare mai specifică, ex: "Clasa 9" sau "Vârsta 6-10"
    public string SubCategory { get; set; } = string.Empty;

    // ImageUrl stochează calea relativă către fișierul imagine al produsului
    // ex: "/images/carte1.png" — începe cu '/' pentru a referi folderul wwwroot
    public string ImageUrl { get; set; } = string.Empty;

    // Description conține un text scurt care explică ce este produsul
    public string Description { get; set; } = string.Empty;
}
