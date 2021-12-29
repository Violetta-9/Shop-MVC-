using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Shop.Application.Categories.Queries;
using Shop.Application.Products.Queries.GetProducts;
using Xunit;

namespace Shop.Application.Tests.Products.Queries
{
     public class GetProducts:DateBaseTest
    {
        [Fact]
        public async void GetProducts_ReturnProducts()
        {
            //Arrange
            var cmd = new GetProductQueries();
            var handler = new GetProductsQueriesHandler(GetDate());
            //Act
            var result = await handler.Handle(cmd, CancellationToken.None);
            //assert
            Assert.IsType<ProductViewModel>(result);
        }
    }
}
