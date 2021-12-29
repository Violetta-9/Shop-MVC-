using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Shop.Application.ProductCart.Command.AddProductInLikedCart
{
   public  class AddProductInLikedCartCommand:IRequest<int>
    {
        public int ProductId { get; set; }
        public string UserId { get; set; }
     

        public AddProductInLikedCartCommand(int productId, string userId)
        {
            ProductId = productId;
            UserId = userId;
         
        }
    }
}
