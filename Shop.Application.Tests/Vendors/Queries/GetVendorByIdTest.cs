using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Shop.Application.Vendors.Queries.GetCategoryById;
using Shop.Domain.Models;
using Xunit;

namespace Shop.Application.Tests.Vendors.Queries
{
    public class GetVendorByIdTest:DateBaseTest
    {
        [Fact]
        public async void GetVendorById_ReturnVendor()
        {
            var cmd = new GetVendorByIdQueries(1);
            var handle = new GetVendorByIdQueriesHandler(GetDate());
            var result =await handle.Handle(cmd, CancellationToken.None);
            Assert.IsType<Vendor>(result);
            Assert.Equal(cmd.Id,result.Id);
            

        }
    }
}
