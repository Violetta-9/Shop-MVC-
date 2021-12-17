using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Shop.Application.Reviews.Command
{
    public class AddReviewCommand:IRequest<Unit>
    {
        public int ProductId { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public int Rating { get; set; }
        public AddReviewCommand(int productId, string text, int rating,string userId)
        {
            ProductId = productId;
            Text = text;
            Rating = rating;
            UserId = userId;

        }
    }
}
