using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Shop.Application.Categories.Command.EditCategory;
using Shop.Application.Products.Command.EditProduct;
using Shop.Domain.Exseption;
using Shop.Domain.Models;
using Xunit;

namespace Shop.Application.Tests.Products.Command
{
    public class EditProductTest:DateBaseTest
    {
        [Fact]
        public async void EditProduct_CorrectDate_ReturnTrue()
        {
            var cmd = new EditProductCommand(1,"test", "test",2,1,1);
            var handle = new EditProductCommandHandler(GetDate());
            var result = await handle.Handle(cmd, CancellationToken.None);
            Assert.IsType<Product>(result);
            Assert.Equal(cmd.ProductId, result.Id);
            Assert.Equal(cmd.Name, result.Name);
            Assert.Equal(cmd.Description, result.Description);
            Assert.Equal(cmd.Price, result.Price);
            Assert.Equal(cmd.VendorId, result.VendorId);
            Assert.Equal(cmd.CategoryId, result.CategoryId);


        }
        [Fact]
        public async void DeleteProduct_IncorrectDate_ThrowException()
        {
            var cmd = new EditProductCommand(-1, "test", "test", 2, 1, 1);
            var handle = new EditProductCommandHandler(GetDate());

            await Assert.ThrowsAsync<NotFoundException>(async () => await handle.Handle(cmd, CancellationToken.None));

        }
    }
}
