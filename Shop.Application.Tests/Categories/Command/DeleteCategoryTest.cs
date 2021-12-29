using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MediatR;
using Shop.Application.Categories.Command.DeleteCategory;
using Shop.Domain.Exseption;
using Xunit;

namespace Shop.Application.Tests.Categories
{
    public class DeleteCategoryTest:DateBaseTest
    {
        [Fact]
        public async void DeleteCategory_CorrectDate_ReturnTrue()
        {
            var cmd = new DeleteCategoryCommand(1);
            var handle = new DeleteCategoryCommandHandler(GetDate());
            var result =await handle.Handle(cmd, CancellationToken.None);
            Assert.IsType<Unit>(result);

        }
        [Fact]
        public async void DeleteCategory_IncorrectDate_ThrowException()
        {
            var cmd = new DeleteCategoryCommand(-1);
            var handle = new DeleteCategoryCommandHandler(GetDate());
          
           await Assert.ThrowsAsync<NotFoundException>( async()=>await handle.Handle(cmd, CancellationToken.None));

        }
    }
}
