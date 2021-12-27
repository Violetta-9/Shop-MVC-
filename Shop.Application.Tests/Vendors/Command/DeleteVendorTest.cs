using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MediatR;
using Shop.Application.Vendors.Command.DeleteVendor;
using Shop.Domain.Exseption;
using Xunit;

namespace Shop.Application.Tests.Vendors.Command
{
    public class DeleteVendorTest : DateBaseTest
    {
        [Fact]
        public async void DeleteVendor_CorrectVendorId_ReturnsTrue()
        {
            //Arrange
            var cmd = new DeleteVendorCommand(1);
            var handler = new DeleteVendorCommandHandler(GetDate());
            //Act
            var result = await handler.Handle(cmd, CancellationToken.None);
            //Assert
            Assert.IsType<Unit>(result);

        }
        [Fact]
        public async void DeleteVendor_IncorrectVendorId_ThrowsException()
        {
            //Arrange
            var cmd = new DeleteVendorCommand(-1);
            var handler = new DeleteVendorCommandHandler(GetDate());

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(cmd, CancellationToken.None));
        }
    }
}

