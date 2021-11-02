using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Shop.Domain.Models;

namespace Shop.Application.Reviews.Queries.GetReviewByProductId
{
     public class GetReviewsByProductIdQueries:IRequest<ReviewViewModel>
    {
        public int ProductId { get; set; }

        public GetReviewsByProductIdQueries(int productId)
        {
            ProductId = productId;
        }
    }
}
