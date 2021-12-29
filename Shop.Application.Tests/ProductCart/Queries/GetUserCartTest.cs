using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MediatR;
using Shop.Application.ProductCart.Queries.GetOrder;
using Shop.Application.ProductCart.Queries.GetUserCart;
using Shop.Domain.Exseption;
using Xunit;

namespace Shop.Application.Tests.ProductCart.Queries
{
   public class GetUserCartTest:DateBaseTest
    {
        [Fact]
        public async void GetUserCart_ReturnCarts()
        {
            var cmd = new GetProductFromTheCartQueries(UserId);
            var handle = new GetProductFromCartQueriesHandler(GetDate());
            var result = await handle.Handle(cmd, CancellationToken.None);
            Assert.IsType<NewClassForProductInCartViewModel>(result);

        }
        
    }
}
