using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Shop.Application.Categories.Queries;
using Shop.Application.Reviews.Queries.GetRatingAndReviewAboutProduct;
using Xunit;

namespace Shop.Application.Tests.Reviews.Queries
{
    public class GetReviewTest : DateBaseTest
    {
        [Fact]
        public async void GetReview_ReturnReviews()
        {
            //Arrange
            var cmd = new GetRatingAndReviewAboutProductCommand(1);
            var handler = new GetRatingAndReviewAboutProductCommandHandler(GetDate());
            //Act
            var result = await handler.Handle(cmd, CancellationToken.None);
            //assert
            Assert.IsType<ReviewViewModel>(result);

        }
    }
}
