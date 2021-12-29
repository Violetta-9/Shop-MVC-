using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MediatR;
using Shop.Application.ProductCart.Command.DeleteProductInLikedCart;
using Shop.Application.ProductCart.Command.MakeOrder;
using Xunit;

namespace Shop.Application.Tests.ProductCart.Command
{
     public class MakeOrderTest:DateBaseTest
    {
        [Fact]
        public async void MakeOrder_CorrectDate_ReturnTrue()
        {
            var cmd = new MakeOrderCommand(UserId);
            var handle = new MakeOrderCommandHandler(GetDate());
            var result = await handle.Handle(cmd, CancellationToken.None);
            Assert.IsType<bool>(result);
            Assert.True(result==true);

        }
       
    }
}
