function likedMethod(productId,cartId) {
    var promise = new Promise((resolve, reject) => {
        $.ajax({
            type: "POST",
            url: "/Liked/AddProductInLikedCart",
            data: {
                id: productId

            },

            success: function() {
               
                resolve();
            },
            error: function() {
                document.location.href = "/Identity/Account/Login";
            }
        });
    });

    promise.then(result => {
        $.ajax({
            type: "POST",
            url: "/Cart/Delete",
            data: {
                id: cartId
            },


            success: function () {
                window.location.reload();

            },
            error: function () {
                document.location.href = "/Identity/Account/Login";
            }
        });
    });
}