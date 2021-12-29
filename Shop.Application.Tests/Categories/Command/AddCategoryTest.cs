using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Shop.Application.Categories.Command;
using Xunit;

namespace Shop.Application.Tests.Categories
{
    public class AddCategoryTest:DateBaseTest
    {   [Fact]
        public async void AddCategory_ReturnCategoryId()
        {
            var cmd = new AddCategoryCommand("test");
            var handle = new AddCategoryCommandHandler(GetDate());
            var result =await handle.Handle(cmd, CancellationToken.None);
            Assert.IsType<int>(result);
            Assert.True(result > 0);

;        }
    }
}
