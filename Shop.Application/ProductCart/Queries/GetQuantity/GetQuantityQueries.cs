using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Shop.Application.ProductCart.Queries.GetQuantity
{
    public class GetQuantityQueries:IRequest<int>
    {
        public string UserId { get; set; }

        public GetQuantityQueries(string userId)
        {
            UserId = userId;
        }
    }
}
