using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Shop.Application.Products.Command.AddProducts;
using Xunit;

namespace Shop.Application.Tests.Products.Command
{
    public class AddProductTest:DateBaseTest
    {
        [Fact]
        public async void AddProduct_CorrectDate_ReturnTrue()
        {
            var cmd = new AddProductCommand("test", "test", 2, "test/test.png", 1, 1);
            var handle = new AddProductCommandHandler(GetDate());
            var result = await handle.Handle(cmd, CancellationToken.None);
            Assert.IsType<int>(result);
            Assert.True(result > 0);
;        }
    }
}
