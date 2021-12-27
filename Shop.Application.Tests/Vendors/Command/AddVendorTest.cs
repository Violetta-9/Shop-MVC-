using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Shop.Application.Vendors.Command;
using Shop.Domain.Models;
using Xunit;

namespace Shop.Application.Tests.Vendors.Command
{
   public class AddVendorTest:DateBaseTest
    {
        [Fact]
        public async void AddVendor_CorrectDate_ReturtVendorId()
        {
       //Arrange
            var cmd = new AddVendorCommand("test", "test");
            var handler = new AddVendorCommandHandler(GetDate());
            //Act
            var result = await handler.Handle(cmd, CancellationToken.None);
            //Assert
            Assert.True(result>0);
        }
    }
}
