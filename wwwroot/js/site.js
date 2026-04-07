// site.js — fișierul JavaScript principal pentru întregul site Start la Şcoală
// Acest fișier gestionează: logica coșului de cumpărături, căutare, meniu mobil, notificări toast

// ============================================================
// 1. GESTIONAREA DATELOR COȘULUI
// Coșul este stocat în localStorage ca un array JSON de obiecte CartItem
// Fiecare articol: { name: "...", price: 12.99, quantity: 1 }
// ============================================================

// getCart() — citește și returnează array-ul coșului din localStorage
// Returnează un array gol [] dacă coșul nu a fost creat încă
function getCart() {
    // Citește elementul 'cart' din localStorage-ul browser-ului (stocat ca string JSON)
    const cartData = localStorage.getItem('cart');
    // localStorage.getItem() returnează null dacă cheia nu există

    // Dacă cartData există, îl parsăm din string JSON → Array; altfel returnăm []
    return cartData ? JSON.parse(cartData) : [];
    // JSON.parse() convertește un string JSON '[{"name":"Carte"}]' îtr-un array real JS
}

// saveCart(cart) — salvează un array coș în localStorage ca string JSON
// cart: array-ul de obiecte articole din coș care trebuie salvat
function saveCart(cart) {
    // Convertește array-ul coșului în string JSON și îl salvează în localStorage
    localStorage.setItem('cart', JSON.stringify(cart));
    // JSON.stringify() convertește un array/obiect îtr-un string ex: '[{"name":"Carte"}]'
    // localStorage.setItem() salvează o pereche cheie/valoare care persistă după reîncărcarea paginii
}

// addToCart(name, price) — adaugă un produs în coș sau îi crește cantitatea
// name: numele produsului (string)
// price: prețul produsului (număr, ex: 29.99)
function addToCart(name, price) {
    // Încărcăm coșul curent din localStorage
    const cart = getCart();
    // cart este acum un array de obiecte { name, price, quantity }

    // Verificăm dacă produsul este deja în coș
    const existingItem = cart.find(item => item.name === name);
    // .find() returnează primul articol unde item.name corespunde numelui produsului nostru
    // Returnează undefined dacă nu găsește nicio potrivire

    if (existingItem) {
        // Produsul este deja în coș — creștem cantitatea cu 1
        existingItem.quantity += 1;
        // += 1 incrementează cantitatea (ex: 1 → 2 → 3)
    } else {
        // Produs nou — îl adăugăm ca articol proaspăt cu cantitatea 1
        cart.push({ name: name, price: price, quantity: 1 });
        // .push() adaugă un obiect nou la SFÂRŞITUL array-ului
    }

    // Salvăm coșul actualizat în localStorage
    saveCart(cart);

    // Actualizăm numărul din badge-ul coșului din navbar
    updateCartCount();

    // Afisăm o notificare toast popup pentru a confirma adăugarea articolului
    showToast(name + ' a fost adaugat in cos!');
    // 'name' + ' a fost adaugat in cos!' creează mesajul ex: "Carte a fost adaugat in cos!"
}

// removeFromCart(name) — elimină complet un produs din coș
// name: numele produsului de eliminat
function removeFromCart(name) {
    // Încărcăm coșul
    const cart = getCart();

    // Creăm un nou array cu toate articolele EXCEPTÂND cel cu acest nume
    const updatedCart = cart.filter(item => item.name !== name);
    // .filter() păstrează doar articolele unde condiția este adevărată (numele nu se potrivește)

    // Salvăm coșul filtrat
    saveCart(updatedCart);

    // Re-randăm UI-ul coșului pentru a reflecta eliminarea
    showCart();

    // Actualizăm numărul din badge
    updateCartCount();
}

// updateQuantity(name, delta) — crește sau scade cantitatea unui articol
// name: numele produsului
// delta: +1 pentru creștere, -1 pentru scădere
function updateQuantity(name, delta) {
    // Încărcăm coșul
    const cart = getCart();

    // Găsim articolul în coș
    const item = cart.find(i => i.name === name);

    if (item) {
        // Articol găsit — ajustăm cantitatea cu delta (+1 sau -1)
        item.quantity += delta;
        // Adăugăm sau scădem 1 din cantitatea curentă

        if (item.quantity <= 0) {
            // Dacă cantitatea a scăzut la 0 sau mai jos, eliminăm complet articolul
            removeFromCart(name);
            // removeFromCart gestionează salvarea și re-randarea
            return; // Oprim aici — removeFromCart deja salvează și re-randează
        }
    }

    // Salvăm coșul actualizat (ajuns aici doar dacă cantitatea este ≥ 1)
    saveCart(cart);

    // Re-randăm afisajul coșului
    showCart();

    // Actualizăm badge-ul
    updateCartCount();
}

// clearCart() — elimină TOATE articolele din coș
function clearCart() {
    // Cerem utilizatorului să confirme înainte de a șterge totul
    if (!confirm('Esti sigur ca vrei sa stergi tot cosul?')) {
        // confirm() afișează un dialog OK/Anulare al browser-ului
        // Dacă utilizatorul apasă Anulare (returnează false), ! îl face true → oprim funcția
        return;
    }

    // Ștergem coșul din localStorage
    localStorage.removeItem('cart');
    // removeItem() șterge complet cheia 'cart' din localStorage

    // Re-randăm coșul pentru a arăta starea goală
    showCart();

    // Resetăm badge-ul la 0
    updateCartCount();
}

// updateCartCount() — actualizează numărul din badge-ul coșului din navbar
// Citește numărul total de articole din localStorage și actualizează elementul badge
function updateCartCount() {
    // Încărcăm coșul
    const cart = getCart();

    // Calculăm numărul total de articole (suma tuturor cantităților)
    const totalCount = cart.reduce((sum, item) => sum + item.quantity, 0);
    // .reduce() parcurge array-ul, acumulând un total curent
    // Pentru fiecare articol, adaugăm item.quantity la suma curentă
    // 0 este valoarea inițială a sumei

    // Găsim elementul badge al coșului din HTML-ul navbar-ului
    const badge = document.getElementById('cartCount');
    // getElementById() găsește elementul cu id="cartCount"

    if (badge) {
        // Actualizăm doar dacă elementul badge există pe această pagină
        badge.textContent = totalCount;
        // textContent setează textul vizibil din interiorul elementului badge
    }
}

// ============================================================
// 2. AFIŞAREA PAGINII COŞ
// showCart() randează UI-ul complet al coșului pe pagina Cart/Index
// ============================================================

// showCart() — randează coșul de cumpărături pe pagina coșului
// Citește datele din localStorage și construiește HTML-ul dinamic
function showCart() {
    // Obținem elementele pe care le vom arăta sau ascunde în funcție de starea coșului
    const emptyCart = document.getElementById('emptyCart');
    const cartLayout = document.getElementById('cartLayout');   // Grid-ul cu două coloane
    const cartItemsList = document.getElementById('cartItemsList');
    const cartSummary = document.getElementById('cartSummary');
    const cartItemsContent = document.getElementById('cartItemsContent');

    // Dacă aceste elemente nu există (NU suntem pe pagina coșului), oprim
    if (!emptyCart) return;
    // Returnarea timpurie previne erorile pe paginile care nu au HTML-ul coșului

    // Încărcăm array-ul coșului din localStorage
    const cart = getCart();

    if (cart.length === 0) {
        // Coșul este gol — arătăm mesajul centrat și ascundem întregul grid
        emptyCart.style.display = 'block';       // Arătăm div-ul de stare goală
        if (cartLayout) cartLayout.style.display = 'none'; // Ascundem grid-ul cu două coloane
        return; // Nu mai avem ce randat
    }

    // Coșul are articole — ascundem starea goală și arătăm grid-ul cu articole + rezumat
    emptyCart.style.display = 'none';           // Ascundem mesajul coș gol
    if (cartLayout) cartLayout.style.display = 'grid'; // Arătăm grid-ul cu două coloane
    cartItemsList.style.display = 'block';      // Arătăm div-ul cu articolele coșului
    cartSummary.style.display = 'block';        // Arătăm panoul de rezumat

    // Construim string-ul HTML pentru toate rândurile articolelor din coș
    let html = '';
    // Începe cu string gol — vom adăuga HTML pentru fiecare articol

    let subtotal = 0;
    // Total curent preț — adăugăm totalul fiecărui articol pe măsură ce parcurgem

    let totalItems = 0;
    // Număr curent articole — folosit în rezumat

    cart.forEach(item => {
        // Parcurgem fiecare articol din array-ul coșului
        const itemTotal = item.price * item.quantity;
        // Calculăm totalul acestui articol: preț × cantitate

        subtotal += itemTotal;
        // Adăugăm totalul acestui articol la subtotalul curent

        totalItems += item.quantity;
        // Adăugăm cantitatea acestui articol la numărul curent de articole

        // Pregătim sigur numele articolului pentru atributul onclick (apostrofele ar strica JS)
        const safeName = item.name.replace(/'/g, "\\'");
        // String.replace() cu regex /'/g înlocuiește TOATE apostrofele cu \'
        // Fără asta, un nume ca "O'Brien Carte" ar strica string-ul onclick

        // Creăm HTML-ul pentru un rând de articol din coș
        html += `
            <div class="cart-item-row">
                <!-- Fiecare rând din coș conține: detalii, controale cantitate, total, buton eliminare -->

                <div class="cart-item-details">
                    <!-- Numele și prețul unitar al produsului -->
                    <div class="cart-item-name">${item.name}</div>
                    <!-- Afisăm numele produsului -->
                    <div class="cart-item-price">${item.price.toFixed(2)} Lei / buc</div>
                    <!-- Afisăm prețul unitar formatat cu 2 zecimale + "Lei / buc" -->
                </div>

                <div class="cart-item-qty">
                    <!-- Ajustare cantitate: buton minus, număr, buton plus -->
                    <button class="qty-btn" onclick="updateQuantity('${safeName}', -1)">−</button>
                    <!-- Butonul minus scade cantitatea cu 1 -->
                    <span class="qty-number">${item.quantity}</span>
                    <!-- Cantitatea curentă afișată între butoane -->
                    <button class="qty-btn" onclick="updateQuantity('${safeName}', +1)">+</button>
                    <!-- Butonul plus crește cantitatea cu 1 -->
                </div>

                <div class="cart-item-total">
                    <!-- Prețul total pentru acest articol (preț × cantitate) -->
                    ${itemTotal.toFixed(2)} Lei
                    <!-- toFixed(2) formatează la 2 zecimale -->
                </div>

                <button class="cart-item-remove" onclick="removeFromCart('${safeName}')" title="Sterge produsul">
                    <!-- Butonul de eliminare — apelează removeFromCart cu numele produsului -->
                    <!-- title= afișează un tooltip la hover -->
                    <i class="fas fa-trash"></i>
                    <!-- Iconță cu coș de gunoi din Font Awesome -->
                </button>

            </div>
        `;
        // Template literals cu backtick permit string-uri pe mai multe linii cu expresii ${}
    });

    // Insertăm toate rândurile de articole în div-ul cu conținutul coșului
    cartItemsContent.innerHTML = html;
    // innerHTML setează conținutul HTML al elementului

    // Actualizăm valorile din panoul de rezumat
    document.getElementById('summaryCount').textContent = totalItems + (totalItems === 1 ? ' produs' : ' produse');
    // Afișăm "1 produs" sau "2 produse" — singular/plural corect în română

    document.getElementById('summarySubtotal').textContent = subtotal.toFixed(2) + ' Lei';
    // Afisăm subtotalul formatat cu 2 zecimale

    document.getElementById('summaryTotal').textContent = subtotal.toFixed(2) + ' Lei';
    // Totalul este același cu subtotalul (transportul este gratuit)
}

// ============================================================
// 3. FUNCȚIONALITATEA DE CĂUTARE
// searchProducts() filtrează cardurile de produse după textul căutării
// ============================================================

// searchProducts() — filtrează cardurile de produse vizibile după nume
// Apelată prin onkeyup pe input-ul de căutare din navbar
function searchProducts() {
    // Obt̆inem textul scris în câmpul de căutare
    const searchInput = document.getElementById('searchInput');
    // getElementById() găsește elementul input de căutare

    if (!searchInput) return;
    // Dacă input-ul de căutare nu există pe această pagină, oprim

    // Convertește textul căutării la litere mici pentru comparare insensibilă la majuscule
    const query = searchInput.value.toLowerCase().trim();
    // .toLowerCase() face ca "Carte" și "carte" să se potrivească
    // .trim() elimină spațiile de la început și sfârșit

    // Obt̆inem toate cardurile de produse de pe pagina curentă
    const cards = document.querySelectorAll('.product-card');
    // querySelectorAll returnează TOATE elementele cu clasa "product-card"

    let visibleCount = 0;
    // Urmărim câte carduri sunt încă vizibile (pentru mesajul de niciun rezultat)

    // Parcurgem fiecare card de produs
    cards.forEach(card => {
        // Obt̆inem atributul data-name al acestui card (setat în Razor/HTML)
        const name = card.getAttribute('data-name') || '';
        // || '' furnizează string gol de rezervă dacă atributul lipsește

        // Obt̆inem categoria pentru potrivire mai largă
        const category = card.getAttribute('data-category') || '';

        // Verificăm dacă interogarea de căutare apare în nume SAU categorie
        if (query === '' || name.includes(query) || category.includes(query)) {
            // Interogare goală arată tot; includes() verifică dacă interogarea este un substring
            card.style.display = '';    // Arătăm cardul (eliminăm display:none)
            visibleCount++;
            // Inclementăm contorul cardurilor vizibile
        } else {
            card.style.display = 'none'; // Ascundem cardurile care nu corespund căutării
        }
    });

    // Arătăm sau ascundem mesajul "niciun rezultat"
    checkNoResults(visibleCount);
}

// checkNoResults() — arată sau ascunde mesajul "fără rezultate"
// Apelată după filtrare sau căutare pentru a actualiza UI-ul de stare goală
// visibleCount: suprascriere optională a contorului (dacă nu este furnizat, numără carduri vizibile)
function checkNoResults(visibleCount) {
    // Obt̆inem div-ul cu mesajul "niciun rezultat"
    const noResults = document.getElementById('noResults');
    // Dacă elementul nu există (nu suntem pe pagina de produse), oprim
    if (!noResults) return;

    // Dacă contorul nu a fost furnizat, numărăm manual cardurile vizibile
    if (visibleCount === undefined) {
        // Numărăm toate cardurile de produse care sunt încă vizibile (neascunse)
        visibleCount = Array.from(document.querySelectorAll('.product-card'))
            .filter(c => c.style.display !== 'none').length;
        // Array.from() convertește NodeList în Array
        // .filter() păstrează doar cardurile vizibile
        // .length numără câte au rămas
    }

    // Arătăm "fără rezultate" dacă contorul este zero, îl ascundem dacă există rezultate
    noResults.style.display = visibleCount === 0 ? 'block' : 'none';
    // Ternar: dacă 0 vizibile → display:block (arată); altfel display:none (ascunde)
}

// ============================================================
// 4. NOTIFICARE TOAST
// showToast() afișează un scurt mesaj de succes în colțul din jos
// ============================================================

// showToast(message) — afișează o notificare popup temporară
// message: textul de afișat în toast
function showToast(message) {
    // Găsim elementul toast în HTML (definit în _Layout.cshtml)
    const toast = document.getElementById('toast');
    const toastMessage = document.getElementById('toastMessage');

    // Dacă elementele toast nu sunt în DOM, oprim
    if (!toast || !toastMessage) return;

    // Setăm textul mesajului toast
    toastMessage.textContent = message;
    // textContent setează textul în mod sigur fără a parsa HTML (previne XSS)

    // Făcem toast-ul vizibil
    toast.style.display = 'flex';
    // display:flex arată toast-ul cu iconță și text alăturat

    // Ascundem automat toast-ul după 3 secunde
    setTimeout(() => {
        toast.style.display = 'none';
        // Funcția săgeată rulează după întârziere pentru a ascunde toast-ul
    }, 3000);
    // 3000 milisecunde = 3 secunde
}

// ============================================================
// 5. NAVIGAȚIE MOBILĂ
// toggleNav() deschide/închide meniul mobil
// ============================================================

// toggleNav() — comută meniul de navigație mobil deschis/închis
function toggleNav() {
    // Găsim elementul meniului de navigație
    const nav = document.getElementById('mainNav');
    // getElementById() obt̆ine elementul <nav id="mainNav">

    if (nav) {
        // Dacă nav există, comutăm clasa CSS 'open' activ/inactiv
        nav.classList.toggle('open');
        // classList.toggle() adaugă 'open' dacă lipsește; o elimină dacă există
        // Când 'open' este prezent, CSS arată nav-ul (vezi interogarea @media din style.css)
    }
}

// ============================================================
// 6. INIȚIALIZARE
// Cod care rulează când pagina este încărcată complet
// ============================================================

// DOMContentLoaded se declanșează după ce documentul HTML este complet parsat
// Acesta este momentul potrivit pentru a rula codul de configurare care accesează elementele DOM
document.addEventListener('DOMContentLoaded', function () {
    // Actualizăm badge-ul coșului pentru a afișa numărul curent de articole
    updateCartCount();
    // Acesta rulează la FIECARE încărcare de pagină pentru a păstra badge-ul actualizat

    // Închideți meniul mobil dacă utilizatorul apasă oriunde în afara lui
    document.addEventListener('click', function (event) {
        // event este un obiect care conține informații despre clic
        const nav = document.getElementById('mainNav');
        const toggle = document.getElementById('navbarToggle');

        if (nav && toggle) {
            // Verificăm dacă clicul a fost în AFARA atât a nav-ului cât și a butonului toggle
            if (!nav.contains(event.target) && !toggle.contains(event.target)) {
                // contains() verifică dacă ținta clicului este în interiorul elementului
                nav.classList.remove('open');
                // Eliminăm 'open' pentru a închide meniul mobil
            }
        }
    });

    // Inițializăm căutarea dacă suntem pe o pagină de produse (are un input de căutare)
    const searchInput = document.getElementById('searchInput');
    if (searchInput) {
        // Pre-completăm căutarea dacă există un parametru de interogare în URL
        const urlParams = new URLSearchParams(window.location.search);
        // URLSearchParams parsează string-ul de interogare al URL-ului
        const q = urlParams.get('q');
        // .get('q') citește valoarea ?q=xxx din URL

        if (q) {
            searchInput.value = q;    // Completăm caseta de căutare cu valoarea din URL
            searchProducts();         // Rulăm căutarea imediat
        }
    }
});

// ============================================================
// 7. SCURTĂTURĂ DE TASTATURĂ
// Apasăm tasta "/" oriunde pentru a focaliza bara de căutare
// ============================================================

// Ascultăm evenimentele keydown pe întregul document
document.addEventListener('keydown', function (event) {
    // event.key conține tasta care a fost apăsată

    if (event.key === '/' && document.activeElement.tagName !== 'INPUT' && document.activeElement.tagName !== 'TEXTAREA') {
        // Tasta '/' apăsată ŞI focusul NU este deja într-un input/textarea
        // Aceasta previne declanșarea când utilizatorul scrie îtr-un câmp de formular

        event.preventDefault();
        // Prevenim scrierea caracterului '/'

        const searchInput = document.getElementById('searchInput');
        if (searchInput) {
            searchInput.focus();
            // Mutăm cursorul focus pe input-ul de căutare
        }
    }

    if (event.key === 'Escape') {
        // Tasta Escape apăsată — închideți meniul mobil dacă este deschis
        const nav = document.getElementById('mainNav');
        if (nav) {
            nav.classList.remove('open'); // Eliminăm clasa 'open' pentru a închide meniul
        }
    }
});

// ============================================================
// 8. AJUTOARE INTERACȚIUNE CARD PRODUS
// ============================================================

// animateButton(btn) — animează scurt un buton când produsul este adăugat în coș
// btn: elementul buton care a fost apsat (perfecționare optională)
function animateButton(btn) {
    if (!btn) return;
    // Guard: dacă btn este null/undefined, nu facem nimic

    // Adăugăm o clasă CSS pentru a declanșa animatia
    btn.classList.add('btn-clicked');
    // Clasa 'btn-clicked' poate fi stilizată în CSS cu o schimbare de scară sau culoare

    // Eliminăm clasa de animatie după 300ms astfel încât poate fi declanșată din nou
    setTimeout(() => {
        btn.classList.remove('btn-clicked');
        // Eliminarea permite animatia să se repete la următorul clic
    }, 300);
}

// ============================================================
// 9. ÎNCĂRCARE LENEŞĂ A IMAGINILOR
// Gestionează fallback-ul graioas pentru imaginile lipsă ale produselor
// ============================================================

// handleImageError(img) — înlocuiește o imagine defectă cu placeholder-ul implicit
// img: elementul <img> care nu a putut fi încărcat
function handleImageError(img) {
    // Setăm src-ul la imaginea placeholder implicită
    img.src = '/images/default.png';
    // Această cale referă wwwroot/images/default.png

    // Adăugăm o clasă CSS pentru a stiliza containerul imaginii defecte
    img.classList.add('img-error');
    // 'img-error' poate fi stilizată în CSS pentru a afișa un fundal gri etc.
}
