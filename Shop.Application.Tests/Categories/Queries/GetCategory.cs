using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Shop.Application.Categories.Queries;
using Shop.Application.Vendors.Queries;
using Xunit;

namespace Shop.Application.Tests.Categories.Queries
{
     public class GetCategory:DateBaseTest
    {
        [Fact]
        public async void GetCategory_ReturnCategories()
        {
            //Arrange
            var cmd = new GetCategoriesQueries();
            var handler = new GetCategoriesQueriesHandler(GetDate());
            //Act
            var result = await handler.Handle(cmd, CancellationToken.None);
            //assert
            Assert.IsType<CategoriesViewModel>(result);
        }
    }
}
