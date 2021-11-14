function caltCartPrice() {
    var cartItem = document.querySelectorAll(".card");
    var totalPrice = 0;

    cartItem.forEach(function(item) {
       
        var priceEl = item.querySelector(".card-text");
       
        var amountEl = item.querySelector("[data-counter]");
      
        var currentPrice = parseInt(priceEl.innerText) * parseInt(amountEl.innerText); 
        totalPrice += currentPrice;
       
    });
    return totalPrice;
}