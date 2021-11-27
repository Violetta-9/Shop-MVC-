using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Shop.Application.ProductCart.Command.DeleteProductInLikedCart
{
     public class DeleteProductInLikedCartCommand:IRequest<Unit>
    {
        public int CartId { get; set; }

        public DeleteProductInLikedCartCommand(int cartId)
        {
            CartId = cartId;
        }
    }
}
