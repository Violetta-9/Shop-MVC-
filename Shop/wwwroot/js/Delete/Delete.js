
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
                    type: "POST",
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
  