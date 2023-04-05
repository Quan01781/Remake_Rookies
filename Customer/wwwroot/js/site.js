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
//let cartIcon = document.querySelector('#cart-icon');
//let cart = document.querySelector('.cart');
//let closeCart = document.querySelector('#close-cart');

//open
//cartIcon.onclick = () => {
//    cart.classList.add("active");
//};

//close
//closeCart.onclick = () => {
//    cart.classList.remove("active");
//};


//cart-woking

//if (document.readyState == "loading") {
//    document.addEventListener("DOMContentLoaded", ready);
//} else {
//    ready();
//}

//function ready() {
//    var removeCartButton = document.getElementsByClassName("cart-remove");
//    console.log(removeCartButton);
//    for (var i = 0; i < removeCartButton.length; i++) {
//        var button = removeCartButton[i];
//        button.addEventListener("click", removeCartItem);
//    }
//    //quantity change
//    var quantityInputs = document.getElementsByClassName("cart-quantity");
//    for (var i = 0; i < quantityInputs.length; i++) {
//        var input = quantityInputs[i];
//        input.addEventListener("change", quantityChanged);
//    }
//    //add to cart
//    var addCart = document.getElementsByClassName("button-add");
//    for (var i = 0; i < addCart.length; i++) {
//        var button = addCart[i]
//        button.addEventListener("click", addCartClicked);
//    }

    //buy button work
    //document.getElementsByClassName("btn-buy")[0].addEventListener("click", buyButtonClicked);
//}

//Buy button
//function buyButtonClicked() {
//    alert("your order is placed");
//    var cartContent = document.getElementsByClassName("cart-content")[0];
//    while (cartContent.hasChildNodes()) {
//        cartContent.removeChild(cartContent.firstChild);
//    }
//    updateTotal();
//}

//remove item from cart
function removeCartItem(event) {
    var buttonClicked = event.target;
    buttonClicked.parentElement.remove();
    //updateTotal();
}

//quantity change
function quantityChanged(event) {
    var input = event.target;
    if (isNaN(input.value) || input.value <= 0) {
        input.value = 1
    }
   //updateTotal();
}

//add to cart
//function addCartClicked(event) {
//    var button = event.target;
//    var shopProducts = button.parentElement;
//    var title = shopProducts.getElementsByClassName("product-title").innerText;
//    var price = shopProducts.getElementsByClassName("amount").innerText;
//    var productImg = shopProducts.getElementsByClassName("product-img").src;
    //addProductToCart(title, price, productImg);
    //updateTotal();
//    console.log(title, price, productImg);
//}

//function addProductToCart(title, price, productImg) {
//    var cartShopBox = document.createElement('tr');
//    var cartItems = document.getElementsByClassName("cart-content");
//    console.log(cartItems)
    //var cartItemsNames = cartItems.getElementsByClassName("cart-product-title");
    //if (cartItemsNames != null) {
    //    for (var i = 0; i < cartItemsNames.length; i++) {
    //        if (cartItemsNames[i].innerText == title) {
    //            alert("this item has already been added");
    //            return;
    //        }
    //    }


    //    var cartBoxContent = `
    //        <td>
    //            <div class="cart-info">
    //                <img src="${productImg}" class="cart-img" />
    //                <div>
    //                    <p class="cart-product-title">${title}</p>
    //                    <i class="fa fa-trash cart-remove" aria-hidden="true"></i>
    //                </div>
    //            </div>
    //        </td>
    //        <td><input type="number" value="1" class="cart-quantity" /></td>
    //        <td><td><div class="cart-price">${price}</div></td></td>
    //                    `;

    //    cartShopBox.innerHTML = cartBoxContent;
    //    cartItems.append(cartShopBox);
    //    cartShopBox.getElementsByClassName("cart-remove")[0].addEventListener("click", removeCartItem);
    //    cartShopBox.getElementsByClassName("cart-quantity")[0].addEventListener("change", quantityChanged);
    //}
//}



//update total
//function updateTotal() {
//    var cartContent = document.getElementsByClassName("cart-content")[0];
//    var cartBoxes = cartContent.getElementsByClassName("cart-box");
//    var total = 0;
//    for (var i = 0; i < cartBoxes.length; i++) {
//        var cartBox = cartBoxes[i];
//        var priceElement = cartBox.getElementsByClassName("cart-price")[0];
//        var quantityElement = cartBox.getElementsByClassName("cart-quantity")[0];
//        var price = parseFloat(priceElement.innerText.replace("đ", ""));
//        var quantity = quantityElement.value;
//        total = total + (price * quantity);
//    }
//    //round number
//    total = Math.round(total * 100) / 100;

//    document.getElementsByClassName("total-price")[0].innerText = total + " đ";

//}