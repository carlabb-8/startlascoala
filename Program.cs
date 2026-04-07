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

// Redirecționăm cererile HTTP către HTTPS doar în mediul local de development
// Pe Railway și alte platforme cloud, HTTPS este gestionat de proxy-ul lor extern
if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

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

// Citim portul din variabila de mediu PORT (folosit de Railway și alte platforme cloud)
// Dacă variabila PORT nu există, folosim portul implicit 5000 pe local
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";

// Pornim serverul web și ascultăm pe portul specificat de platforma de hosting
app.Run($"http://0.0.0.0:{port}");
