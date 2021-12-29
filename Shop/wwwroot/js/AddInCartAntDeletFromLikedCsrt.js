function addInCartAndDeletFromLikedCart(productId, cartId) {
    var promise = new Promise((resolve, reject) => {
        $.ajax({
            type: "POST",
            url: "/Product/AddProductInCart",
            data: {
                id: productId,
                quentity: 1
            },


            success: function (date) {
                if (amount !== null) {

                    $("#amount").html(date);
                }
                
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
                url: "/Liked/Delete",
                data: {
                    id: cartId
                },


                success: function () {
                    
                    window.location.reload();
                

                },
                error: function() {
                    document.location.href = "/Identity/Account/Login";
                }

            });
        });
   
}