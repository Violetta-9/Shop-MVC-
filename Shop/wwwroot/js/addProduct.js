function addProduct(productId) {
  
        $.ajax({
            type: "POST",
            url: "/Product/AddProductInCart",
            data: {
                id: productId,
                quentity: 1
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

function SetCartAmount() {
    var amount = localStorage.getItem("CartAmount");
    if (amount !== null) {

        $("#amount").html(amount);
    }

}
function subProduct(productId) {

    $.ajax({
        type: "POST",
        url: "/Product/SubProductInCart",
        data: {
            id: productId,
            quentity: 1
        },


        success: function () {
            var value = $("#amount").text();
            value = parseInt(value) - 1;
            $("#amount").html(value);
            localStorage.setItem("CartAmount", value);

        },
        error: function () {
            document.location.href = "/Identity/Account/Login";
        }
    });

}
function addProductInLikedCart(productId) {

    $.ajax({
        type: "POST",
        url: "/Liked/AddProductInLikedCart",
        data: {
            id: productId
           
        },

        success: function () {
            window.location.reload();

        },
        error: function () {
            document.location.href = "/Identity/Account/Login";
        }
    });

}

function ClearProductInCart() {
    $("#amount").html(0);
    localStorage.setItem("CartAmount",0);

}
$('.rating_item li:nth-child(n+3)').addClass('nth-child-np3');