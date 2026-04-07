// CartItem.cs — definește structura de date pentru un articol din coșul de cumpărături
// Când utilizatorul adaugă un produs în coș, se creează un CartItem pentru a-l urmări

// Declarăm namespace-ul astfel încât celelalte fișiere din proiect să poată referenția această clasă
namespace MagazinOnline.Models;

// Definim clasa CartItem — reprezintă un produs adăugat în coșul de cumpărături
public class CartItem
{
    // Name stochează numele produsului introdus de utilizator sau din lista de produse
    // ex: "Limba Română Clasa 8"
    public string Name { get; set; } = string.Empty;

    // Price stochează prețul acestui articol
    // Folosim decimal pentru calcule precise cu bani
    public decimal Price { get; set; }

    // Quantity urmărește câte bucăți din acest articol a adăugat utilizatorul
    // Pornește de la 1 implicit când este adăugat prima dată
    public int Quantity { get; set; } = 1;

    // Total este o proprietate calculată — calculează automat Preț × Cantitate
    // Blocul 'get' rulează de fiecare dată când cineva citește valoarea Total
    public decimal Total => Price * Quantity;
    // => este o prescurtare care returnează un rezultat calculat fără metodă separată
}
