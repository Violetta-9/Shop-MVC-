using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Shop.Domain.Models;

namespace Shop.Application.Reviews.Queries.GetRatingAndReviewAboutProduct
{
   public class GetRatingAndReviewAboutProductCommand:IRequest<ReviewViewModel>
    {
        public int ProductId { get; set; }

        public GetRatingAndReviewAboutProductCommand(int productId)
        {
            ProductId = productId;
        }
    }
}
