function addProduct(productId) {
    $.ajax({
        type: "POST",
        url: "/Product/AddProductInCart",
        data: {
            id: productId
        },

        
        success: function() {
            var value = $("#amount").text();
            value = parseInt(value) + 1;
            $("#amount").html(value);
            localStorage.setItem("CartAmount", value);
        },
        error: function() {
            document.location.href = "/Identity/Account/Login";
        }
    });
 
}