using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Shop.Domain.Models;

namespace Shop.Application.ProductCart.Queries.GetUserLikedCart
{
    public class GetProductFromLikedCartQueries:IRequest<NewLikedCartViewModel>
    {
        public string UserId { get; set; }

        public GetProductFromLikedCartQueries(string userId)
        {
            UserId = userId;
        }
    }
}
