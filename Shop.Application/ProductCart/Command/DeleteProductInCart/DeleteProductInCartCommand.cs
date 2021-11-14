using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Shop.Application.ProductCart.Command.DeleteProductInCart
{
    public  class DeleteProductInCartCommand:IRequest<Unit>
    {
        public int ProductId { get; set; }

        public DeleteProductInCartCommand(int productId)
        {
            ProductId = productId;
        }
    }
}
