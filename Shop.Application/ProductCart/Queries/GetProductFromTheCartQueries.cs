using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Shop.Application.ProductCart.Queries
{
     public class GetProductFromTheCartQueries:IRequest<ProductInCardViewModel>
    {
        public string UserId { get; set; }

        public GetProductFromTheCartQueries(string userId)
        {
            UserId = userId;
        }
    }
}
