using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MediatR;
using Shop.Application.ProductCart.Command.DeleteProductInLikedCart;
using Shop.Application.ProductCart.Command.SubProductInCart;
using Shop.Domain.Exseption;
using Xunit;

namespace Shop.Application.Tests.ProductCart.Command
{
    public class SubProductCartTest:DateBaseTest
    {
        [Fact]
        public async void SubProductInCart_CorrectDate_ReturnTrue()
        {
            var cmd = new SubProductInCartCommand(1,2,UserId);
            var handle = new SubProductInCartCommandHandler(GetDate());
            var result = await handle.Handle(cmd, CancellationToken.None);
            Assert.IsType<Unit>(result);
           ;

        }
        [Fact]
        public async void SubProductInCart_IncorrectDate_ThrowException()
        {
            var cmd = new SubProductInCartCommand(-1, 2,UserId);
            var handle = new SubProductInCartCommandHandler(GetDate());
            await Assert.ThrowsAsync<NotFoundException>(async () => await handle.Handle(cmd, CancellationToken.None));

        }
    }
}
