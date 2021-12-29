using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MediatR;
using Shop.Application.ProductCart.Command.DeleteProductInLikedCart;
using Shop.Application.ProductCart.Queries.GetOrder;
using Shop.Domain.Exseption;
using Xunit;

namespace Shop.Application.Tests.ProductCart.Queries
{
    public class GetOrderTest:DateBaseTest
    {
        [Fact]
        public async void GetOrder_ReturnOrder()
        {
            var cmd = new GetOrderQueries(UserId);
            var handle = new GetOrderQueriesHandler(GetDate());
            var result = await handle.Handle(cmd, CancellationToken.None);
            Assert.IsType<OrderViewModel>(result);

        }
       
    }
}
