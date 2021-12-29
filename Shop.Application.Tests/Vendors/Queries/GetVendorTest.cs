using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Shop.Application.Vendors.Queries;
using Xunit;

namespace Shop.Application.Tests.Vendors.Queries
{
   public  class GetVendorTest:DateBaseTest
    {
        [Fact]
        public async void GetVendor_ReturnVendors()
        {
            //Arrange
            var cmd = new GetVendorQueries();
            var handler = new GetVendorsQueriesHandler(GetDate());
            //Act
            var result =await handler.Handle(cmd, CancellationToken.None);
            //assert
            Assert.IsType<VendorsViewModel>(result);
        }
    }
}
