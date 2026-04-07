// Program.cs — punctul de intrare al aplicației ASP.NET Core
// Acest fișier configurează și pornește serverul web

// Creăm un obiect builder care configurează toate serviciile de care aplicația are nevoie
var builder = WebApplication.CreateBuilder(args);

// Adăugăm serviciile MVC astfel încât aplicația să înțeleagă Controllere și View-uri
// Aceasta activează modelul Model-View-Controller
builder.Services.AddControllersWithViews();

// Construim aplicația folosind toate serviciile configurate mai sus
var app = builder.Build();

// Verificăm dacă aplicația rulează în modul development (pe calculatorul dezvoltatorului)
if (!app.Environment.IsDevelopment())
{
    // Dacă NU suntem în development, afișăm o pagină de eroare prietenoasă în loc de detalii tehnice
    app.UseExceptionHandler("/Home/Error");

    // Activăm HTTP Strict Transport Security (HSTS) pentru securitate mai bună în producție
    app.UseHsts();
}

// Redirecționăm cererile HTTP către HTTPS pentru securitate
app.UseHttpsRedirection();

// Permitem aplicației să servească fișiere statice (CSS, JavaScript, imagini) din wwwroot
app.UseStaticFiles();

// Activăm rutarea pentru ca aplicația să știe cum să mapeze URL-urile la controllerul și acțiunea corectă
app.UseRouting();

// Activăm middleware-ul de autorizare (verifică dacă utilizatorul are permisiunea pentru paginile protejate)
app.UseAuthorization();

// Definim modelul implicit de rutare URL: /NumeController/NumeAcțiune/Id
// Dacă nu se scrie nimic în URL, se deschide controller-ul Home, acțiunea Index
app.MapControllerRoute(
    name: "default",                        // Numele acestei rute (folosit intern)
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Model: controller/acțiune/id-opțional

// Pornim serverul web și începem să ascultăm cererile HTTP incoming
app.Run();
