using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Shop.Domain.Models;

namespace Shop.Application.Categories.Command.EditCategory
{
     public class EditCategoryCommand:IRequest<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public EditCategoryCommand(string name,int id)
        {
            Id = id;
            Name = name;
        }
    }
}
