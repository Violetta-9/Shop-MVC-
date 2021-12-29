using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Shop.Application.Categories.Queries.GetCategoryById;
using Shop.Application.Products.Queries.GetProductById;
using Shop.Domain.Exseption;
using Shop.Domain.Models;
using Xunit;

namespace Shop.Application.Tests.Products.Queries
{
   public class GetProductsById:DateBaseTest
    {
        [Fact]
        public async void GetProductById_ReturnProduct()
        {
            var cmd = new GetProductByIdQueries(1);
            var handle = new GetProductByIdQueriesHandler(GetDate());
            var result = await handle.Handle(cmd, CancellationToken.None);
            Assert.IsType<Product>(result);
            Assert.Equal(cmd.ProductId, result.Id);


        }
        [Fact]
        public async void GetProductById_ThrowException()
        {
            var cmd = new GetProductByIdQueries(-1);
            var handle = new GetProductByIdQueriesHandler(GetDate());
            await Assert.ThrowsAsync<NotFoundException>(async () => await handle.Handle(cmd, CancellationToken.None));


        }
    }
}
