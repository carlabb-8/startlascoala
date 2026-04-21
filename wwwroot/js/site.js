function getCart() {

    const cartData = localStorage.getItem('cart');

    return cartData ? JSON.parse(cartData) : [];

}

function saveCart(cart) {

    localStorage.setItem('cart', JSON.stringify(cart));

}

function addToCart(name, price, imageUrl) {

    const cart = getCart();

    const existingItem = cart.find(item => item.name === name);

    if (existingItem) {

        existingItem.quantity += 1;

    } else {

        cart.push({ name: name, price: price, quantity: 1, imageUrl: imageUrl || '/images/default.png' });

    }

    saveCart(cart);

    updateCartCount();

    showToast(name + ' a fost adaugat in cos!');

}

function removeFromCart(name) {

    const cart = getCart();

    const updatedCart = cart.filter(item => item.name !== name);

    saveCart(updatedCart);

    showCart();

    updateCartCount();
}

function updateQuantity(name, delta) {

    const cart = getCart();

    const item = cart.find(i => i.name === name);

    if (item) {

        item.quantity += delta;

        if (item.quantity <= 0) {

            removeFromCart(name);

            return;
        }
    }

    saveCart(cart);

    showCart();

    updateCartCount();
}

function clearCart() {

    if (!confirm('Esti sigur ca vrei sa stergi tot cosul?')) {

        return;
    }

    localStorage.removeItem('cart');

    showCart();

    updateCartCount();
}

function updateCartCount() {

    const cart = getCart();

    const totalCount = cart.reduce((sum, item) => sum + item.quantity, 0);

    const badge = document.getElementById('cartCount');

    if (badge) {

        badge.textContent = totalCount;

    }
}

function showCart() {

    const emptyCart = document.getElementById('emptyCart');
    const cartLayout = document.getElementById('cartLayout');
    const cartItemsList = document.getElementById('cartItemsList');
    const cartSummary = document.getElementById('cartSummary');
    const cartItemsContent = document.getElementById('cartItemsContent');

    if (!emptyCart) return;

    const cart = getCart();

    if (cart.length === 0) {

        emptyCart.style.display = 'block';
        if (cartLayout) cartLayout.style.display = 'none';
        return;
    }

    emptyCart.style.display = 'none';
    if (cartLayout) cartLayout.style.display = 'grid';
    cartItemsList.style.display = 'block';
    cartSummary.style.display = 'block';

    let html = '';

    let subtotal = 0;

    let totalItems = 0;

    cart.forEach(item => {

        const itemTotal = item.price * item.quantity;

        subtotal += itemTotal;

        totalItems += item.quantity;

        const safeName = item.name.replace(/'/g, "\\'");

        html += `
            <div class="cart-item-row">

                <img class="cart-item-image" src="${item.imageUrl || '/images/default.png'}" alt="${item.name}" onerror="this.src='/images/default.png'" />

                <div class="cart-item-details">

                    <div class="cart-item-name">${item.name}</div>

                    <div class="cart-item-price">${item.price.toFixed(2)} Lei / buc</div>

                </div>

                <div class="cart-item-qty">

                    <button class="qty-btn" onclick="updateQuantity('${safeName}', -1)">−</button>

                    <span class="qty-number">${item.quantity}</span>

                    <button class="qty-btn" onclick="updateQuantity('${safeName}', +1)">+</button>

                </div>

                <div class="cart-item-total">

                    ${itemTotal.toFixed(2)} Lei

                </div>

                <button class="cart-item-remove" onclick="removeFromCart('${safeName}')" title="Sterge produsul">

                    <i class="fas fa-trash"></i>

                </button>

            </div>
        `;

    });

    cartItemsContent.innerHTML = html;

    document.getElementById('summaryCount').textContent = totalItems + (totalItems === 1 ? ' produs' : ' produse');

    document.getElementById('summarySubtotal').textContent = subtotal.toFixed(2) + ' Lei';

    document.getElementById('summaryTotal').textContent = subtotal.toFixed(2) + ' Lei';

}

function showToast(message) {

    const toast = document.getElementById('toast');
    const toastMessage = document.getElementById('toastMessage');

    if (!toast || !toastMessage) return;

    toastMessage.textContent = message;

    toast.style.display = 'flex';

    setTimeout(() => {
        toast.style.display = 'none';

    }, 3000);

}

function toggleNav() {

    const nav = document.getElementById('mainNav');

    if (nav) {

        nav.classList.toggle('open');

    }
}

document.addEventListener('DOMContentLoaded', function () {

    updateCartCount();

    document.addEventListener('click', function (event) {

        const nav = document.getElementById('mainNav');
        const toggle = document.getElementById('navbarToggle');

        if (nav && toggle) {

            if (!nav.contains(event.target) && !toggle.contains(event.target)) {

                nav.classList.remove('open');

            }
        }
    });

    const searchInput = document.getElementById('searchInput');
    if (searchInput) {

        const urlParams = new URLSearchParams(window.location.search);

        const q = urlParams.get('q');

        if (q) {
            searchInput.value = q;
            searchProducts();
        }
    }
});

document.addEventListener('keydown', function (event) {

    if (event.key === '/' && document.activeElement.tagName !== 'INPUT' && document.activeElement.tagName !== 'TEXTAREA') {

        event.preventDefault();

        const searchInput = document.getElementById('searchInput');
        if (searchInput) {
            searchInput.focus();

        }
    }

    if (event.key === 'Escape') {

        const nav = document.getElementById('mainNav');
        if (nav) {
            nav.classList.remove('open');
        }
    }
});

function animateButton(btn) {
    if (!btn) return;

    btn.classList.add('btn-clicked');

    setTimeout(() => {
        btn.classList.remove('btn-clicked');

    }, 300);
}

function handleImageError(img) {

    img.src = '/images/default.png';

    img.classList.add('img-error');

}
