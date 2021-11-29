using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Shop.Application.ProductCart.Queries.GetOrder
{
   public class GetOrderQueries:IRequest<OrderViewModel>
    {
        public string UserId { get; set; }

        public GetOrderQueries(string userId)
        {
            UserId = userId;
        }
    }
}
