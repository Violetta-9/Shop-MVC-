using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Shop.Application.Categories.Queries.GetCategoryById;
using Shop.Domain.Exseption;
using Shop.Domain.Models;
using Xunit;

namespace Shop.Application.Tests.Categories.Queries
{
     public class CetCategoriesById:DateBaseTest
    {
        [Fact]
        public async void GetVendorById_ReturnVendor()
        {
            var cmd = new GetCategoryByIdCommand(1);
            var handle = new GetCategoryByIdCommandHandler(GetDate());
            var result = await handle.Handle(cmd, CancellationToken.None);
            Assert.IsType<Category>(result);
            Assert.Equal(cmd.Id, result.Id);


        }
        [Fact]
        public async void GetVendorById_ThrowException()
        {
            var cmd = new GetCategoryByIdCommand(-1);
            var handle = new GetCategoryByIdCommandHandler(GetDate());
           await Assert.ThrowsAsync<NotFoundException>(async () => await handle.Handle(cmd, CancellationToken.None));


        }
    }
}
