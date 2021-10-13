using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Shop.Application.Categories.Command.DeleteCategory
{
     public class DeleteCategoryCommand:IRequest<Unit>
    { 
        public int Id { get; set; }

        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
