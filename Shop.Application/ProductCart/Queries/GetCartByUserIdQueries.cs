using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Shop.Application.ProductCart.Queries
{
   public  class GetCartByUserIdQueries:IRequest<GetCartInfoViewModel>
    {
        public string UserId { get; set; }

        public GetCartByUserIdQueries(string userId)
        {
            UserId = userId;
        }
    }
}
