// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(window).scroll(function () {
    if ($(this).scrollTop() > 600) {
        $(".scrollup").fadeIn();
    } else {
        $(".scrollup").fadeOut();
    }
})

$(".scrollup").click(function () {
    $("html, body").animate({
        scrollTop: 0
    }, 600);
    return false;
})


//shopping-cart
let cartIcon = document.querySelector('#cart-icon');
let cart = document.querySelector('.cart');
let closeCart = document.querySelector('#close-cart');

//open
cartIcon.onclick = () => {
    cart.classList.add("active");
};

//close
closeCart.onclick = () => {
    cart.classList.add("active");
};