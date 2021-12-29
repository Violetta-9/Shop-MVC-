using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MediatR;
using Shop.Application.Categories.Command.DeleteCategory;
using Shop.Application.Categories.Command.EditCategory;
using Shop.Domain.Exseption;
using Shop.Domain.Models;
using Xunit;

namespace Shop.Application.Tests.Categories
{
    public class EditCategoryTest:DateBaseTest
    {
        
        [Fact]
        public async void EditCategory_CorrectDate_ReturnTrue()
        {
            var cmd = new EditCategoryCommand("test",1);
            var handle = new EditCategoryCommandHandler(GetDate());
            var result = await handle.Handle(cmd, CancellationToken.None);
            Assert.IsType<Category>(result);
            Assert.Equal(cmd.Id,result.Id);
            Assert.Equal(cmd.Name, result.Name);


        }
        [Fact]
        public async void DeleteCategory_IncorrectDate_ThrowException()
        {
            var cmd = new EditCategoryCommand("test",-1);
            var handle = new EditCategoryCommandHandler(GetDate());

            await Assert.ThrowsAsync<NotFoundException>(async () => await handle.Handle(cmd, CancellationToken.None));

        }
    }
}
