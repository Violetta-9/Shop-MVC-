
    function confirmDelete(id) {
        swal({
            title: "Are you sure?",
            text: "Once deleted, you will not be able to recover this imaginary file!",
            icon: "warning",
            buttons: true,
            dangerMode: true
        }).then((willDelete) => {
            if (willDelete) {
                $.ajax({
                    url: "../Admin/Products/Delete",
                    type: "GET",
                    data: {
                        productId: id
                    },

                    success: function () {
                        window.location.reload();//перезагрузака текущей страницы 
                        //location.replace("../Admin/Products/Index");// переадресация 
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        swal("Error deleting!", "Please try again", "error");
                    }
                });
            }
        });
    }

    function confirmDeleteVendor(id) {
        swal({
            title: "Are you sure?",
            text: "Once deleted, you will not be able to recover this imaginary file!",
            icon: "warning",
            buttons: true,
            dangerMode: true
        }).then((willDelete) => {
            if (willDelete) {
                $.ajax({
                    url: "../Admin/Vendor/Delete",
                    type: "GET",
                    data: {
                        vendorId: id
                    },

                    success: function () {
                        window.location.reload();//перезагрузака текущей страницы 
                        //location.replace("../Admin/Products/Index");// переадресация 
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        swal("Error deleting!", "Please try again", "error");
                    }
                });
            }
        });
    }

    function confirmDeleteCategory(id) {
       swal({
            title: "Are you sure?",
            text: "Once deleted, you will not be able to recover this imaginary file!",
            icon: "warning",
            buttons: true,
            dangerMode: true
        }).then((willDelete) => {
            if (willDelete) {
                $.ajax({
                    url: "../Admin/Category/Delete",
                    type: "GET",
                    data: {
                        categoryId: id
                    },

                    success: function () {
                        window.location.reload();//перезагрузака текущей страницы 
                        //location.replace("../Admin/Products/Index");// переадресация 
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        swal("Error deleting!", "Please try again", "error");
                    }
                });
            }
        });
}

function deleteProductInCart(productId, quentity) {
        $.ajax({
            type: "POST",
            url: "/Cart/Delete",
            data: {
                id: productId
            },


            success: function () {
               
                var value = $("#amount").text();
                value = parseInt(value)-quentity;
                $("#amount").html(value);
                localStorage.setItem("CartAmount", value);
                window.location.reload();

            },
            error: function () {
                document.location.href = "/Identity/Account/Login";
            }
        });
    }
    function deleteProductInLikedCart(cartId) {
        $.ajax({
            type: "POST",
            url: "/Liked/Delete",
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
    }


  