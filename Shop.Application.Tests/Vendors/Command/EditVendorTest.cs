using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using MediatR;
using Shop.Application.Vendors.Command.EditVendor;
using Shop.Domain.Exseption;
using Shop.Domain.Models;
using Xunit;

namespace Shop.Application.Tests.Vendors.Command
{
    public class EditVendorTest:DateBaseTest
    {[Fact]
        public async void EditVendor_CorrectDate_ReturnTrue()
        {
            //Arrange
            var cmd = new EditVendorCommand(1, "test", "test");
            var handler = new EditVendorCommandHandler(GetDate());
            //Act
            var result = await handler.Handle(cmd, CancellationToken.None);
            //Assert
            Assert.IsType<Vendor>(result);
            Assert.Equal(cmd.Id, result.Id);
            Assert.Equal(cmd.Name, result.Name);
        }
        [Fact]
        public async void EditVendor_IncorrectDate_ThrowExseption()
        {
            //Arrange
            var cmd = new EditVendorCommand(-1, "test", "test");
            var handler = new EditVendorCommandHandler(GetDate());
            
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async ()=> await handler.Handle(cmd, CancellationToken.None));
        }
    }
}
