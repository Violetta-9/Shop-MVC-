using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MediatR;
using Shop.Application.Categories.Command.DeleteCategory;
using Shop.Application.Products.Command.DeleteProduct;
using Shop.Domain.Exseption;
using Xunit;

namespace Shop.Application.Tests.Products.Command
{
     public class DeleteProductTest:DateBaseTest
    {
        [Fact]
        public async void AddProduct_CorrectDate_ReturnTrue()
        {
            var cmd = new DeleteProductCommand(1);
            var handle = new DeleteProductCommandHandler(GetDate());
            var result = await handle.Handle(cmd, CancellationToken.None);
            Assert.IsType<Unit>(result);

        }
        [Fact]
        public async void DeleteProduct_IncorrectDate_ThrowException()
        {
            var cmd = new DeleteProductCommand(-1);
            var handle = new DeleteProductCommandHandler(GetDate());

            await Assert.ThrowsAsync<NotFoundException>(async () => await handle.Handle(cmd, CancellationToken.None));

        }
    }
}
