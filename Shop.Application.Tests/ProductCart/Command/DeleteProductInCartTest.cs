using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MediatR;
using Shop.Application.Categories.Command.DeleteCategory;
using Shop.Application.ProductCart.Command.DeleteProductInCart;
using Shop.Domain.Exseption;
using Xunit;

namespace Shop.Application.Tests.ProductCart.Command
{
     public class DeleteProductInCartTest:DateBaseTest
    {
        [Fact]
        public async void DeleteProductInCart_CorrectDate_ReturnTrue()
        {
            var cmd = new DeleteProductInCartCommand(1);
            var handle = new DeleteProductInCartCommandHandler(GetDate());
            var result = await handle.Handle(cmd, CancellationToken.None);
            Assert.IsType<Unit>(result);

        }
        [Fact]
        public async void DeleteProductInCart_IncorrectDate_ThrowException()
        {
            var cmd = new DeleteProductInCartCommand(-1);
            var handle = new DeleteProductInCartCommandHandler(GetDate());

            await Assert.ThrowsAsync<NotFoundException>(async () => await handle.Handle(cmd, CancellationToken.None));

        }
    }
}
