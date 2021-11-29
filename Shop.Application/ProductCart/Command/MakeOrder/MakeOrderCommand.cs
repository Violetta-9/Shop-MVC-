using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Shop.Application.ProductCart.Command.MakeOrder
{
    public class MakeOrderCommand:IRequest<bool>
    {
        public string UserId { get; set; }

        public MakeOrderCommand(string userId)
        {
            UserId = userId;
        }
    }
}
