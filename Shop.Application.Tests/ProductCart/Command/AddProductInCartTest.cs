using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Shop.Application.Categories.Command;
using Shop.Application.ProductCart.Command.AddProductInCart;
using Xunit;

namespace Shop.Application.Tests.ProductCart.Command
{
    public class AddProductInCartTest:DateBaseTest
    {
        [Fact]
        public async void AddProductInCart_ReturnTrue()
        {
            var cmd = new AddProductInCartCommand(1,UserId,1);
            var handle = new AddProductInCartCommandHandler(GetDate());
            var result = await handle.Handle(cmd, CancellationToken.None);
            Assert.IsType<int>(result);
            Assert.True(result > 0);

            
        }
    }
}
