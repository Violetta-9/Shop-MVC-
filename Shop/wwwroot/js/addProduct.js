function addProduct(productId) {
  
        $.ajax({
            type: "POST",
            url: "/Product/AddProductInCart",
            data: {
                id: productId,
                quentity: 1
            },
            

            success: function(date) {
          
                if (amount !== null) {

                    $("#amount").html(date);
                }
        },
        error: function() {
            document.location.href = "/Identity/Account/Login";
        }
    });

}

function SetCartAmount() {
    localStorage.clear();

    $.ajax({
        type: "POST",
        url: "/Cart/Quantity",



        success: function (data) {
          
            if (amount !== null) {
              
                $("#amount").html(data);
            }

        },
        error: function () {
            document.location.href = "/Identity/Account/Login";
        }
    });
}
function subProduct(productId) {

    $.ajax({
        type: "POST",
        url: "/Product/SubProductInCart",
        data: {
            id: productId,
            quentity: 1
        },


        success: function (date) {
            if (amount !== null) {

                $("#amount").html(date);
            }
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


