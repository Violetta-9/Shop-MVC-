using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Shop.Application.ProductCart.Command.AddProductInCart;
using Shop.Application.ProductCart.Command.AddProductInLikedCart;
using Xunit;

namespace Shop.Application.Tests.ProductCart.Command
{
   public class AddProductInLikedcartTest:DateBaseTest
    {
        [Fact]
        public async void AddProductInLikedCart_ReturnTrue()
        {
            var cmd = new AddProductInLikedCartCommand(1,UserId);
            var handle = new AddProductInLikedCartCommandHandler(GetDate());
            var result = await handle.Handle(cmd, CancellationToken.None);
            Assert.IsType<int>(result);
            Assert.True(result > 0);

        }
    }
}
