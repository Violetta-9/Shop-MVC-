using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Shop.Domain.Models;

namespace Shop.Application.Categories.Queries.GetCategoryById
{
     public class GetCategoryByIdCommand:IRequest<Category>
    {
        public int Id { get; set; }

        public GetCategoryByIdCommand(int id)
        {
            Id = id;
        }
    }
}
