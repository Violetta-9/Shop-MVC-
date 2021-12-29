using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MediatR;
using Shop.Application.Categories.Command.DeleteCategory;
using Shop.Application.ProductCart.Command.DeleteProductInLikedCart;
using Shop.Domain.Exseption;
using Xunit;

namespace Shop.Application.Tests.ProductCart.Command
{
    public class DeleteProductInLikedCartTest:DateBaseTest
    {
        [Fact]
        public async void DeleteProductInLikedCart_CorrectDate_ReturnTrue()
        {
            var cmd = new DeleteProductInLikedCartCommand(1);
            var handle = new DeleteProductInLickedCartCommandHandler(GetDate());
            var result = await handle.Handle(cmd, CancellationToken.None);
            Assert.IsType<Unit>(result);

        }
        [Fact]
        public async void DeleteProductInLikedCart_IncorrectDate_ThrowException()
        {
            var cmd = new DeleteProductInLikedCartCommand(-1);
            var handle = new DeleteProductInLickedCartCommandHandler(GetDate());

            await Assert.ThrowsAsync<NotFoundException>(async () => await handle.Handle(cmd, CancellationToken.None));

        }
    }
}
