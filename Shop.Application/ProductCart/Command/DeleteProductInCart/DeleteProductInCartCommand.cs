using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Shop.Application.ProductCart.Command.DeleteProductInCart
{
    public  class DeleteProductInCartCommand:IRequest<Unit>
    {
        public int CartId { get; set; }

        public DeleteProductInCartCommand(int cartId)
        {
            CartId = cartId;
        }
    }
}
