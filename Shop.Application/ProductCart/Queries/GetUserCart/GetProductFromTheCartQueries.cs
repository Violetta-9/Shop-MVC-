using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Shop.Application.ProductCart.Queries.GetUserCart
{
     public class GetProductFromTheCartQueries:IRequest<NewClassForProductInCartViewModel>
    {
        public string UserId { get; set; }

        public GetProductFromTheCartQueries(string userId)
        {
            UserId = userId;
        }
    }
}
