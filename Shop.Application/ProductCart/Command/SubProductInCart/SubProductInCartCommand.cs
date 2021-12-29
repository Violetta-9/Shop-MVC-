using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Shop.Application.ProductCart.Command.SubProductInCart
{
     public class SubProductInCartCommand:IRequest<Unit>
    {
        public int ProductId { get; set; }
        public int Quentity { get; set; }
        public string UserId { get; set; }

        public SubProductInCartCommand(int productId,int quentity,string user)
        {
            ProductId = productId;
            Quentity = quentity;
            UserId = user;
        }
    }
}
