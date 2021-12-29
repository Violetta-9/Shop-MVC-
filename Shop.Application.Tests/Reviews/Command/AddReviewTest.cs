using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Shop.Application.Reviews.Command;
using Xunit;

namespace Shop.Application.Tests.Reviews.Command
{
   public  class AddReviewTest:DateBaseTest
    {
        [Fact]
        public async void AddReview_ReturnReview()
        {
            var cmd = new AddReviewCommand(1,"test",4,UserId);
            var handle = new AddReviewCommandHandler(GetDate());
            var result = await handle.Handle(cmd, CancellationToken.None);
            Assert.IsType<int>(result);
            Assert.True(result > 0);

        }
    }
}
