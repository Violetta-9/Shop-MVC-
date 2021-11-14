using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Shop.Application.ProductCart.Command.AddProductInCart
{
     public class AddProductInCartCommand : IRequest<Unit>
    {
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public int  Quantity { get; set; }

        public AddProductInCartCommand(int productId,string userId,int quantity)
        {
            ProductId = productId;
            UserId = userId;
            Quantity = quantity;
        }
    }
}
