using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MediatR;
using Shop.Application.ProductCart.Queries.GetOrder;
using Shop.Application.ProductCart.Queries.GetUserLikedCart;
using Shop.Domain.Exseption;
using Xunit;

namespace Shop.Application.Tests.ProductCart.Queries
{
   public class GetUserLikedCartTest:DateBaseTest
    {
        [Fact]
        public async void GetOrder_ReturnOrder()
        {
            var cmd = new GetProductFromLikedCartQueries(UserId);
            var handle = new GetProductFromLikedCartQueriesHandler(GetDate());
            var result = await handle.Handle(cmd, CancellationToken.None);
            Assert.IsType<NewLikedCartViewModel>(result);

        }
        
        
    }
}
