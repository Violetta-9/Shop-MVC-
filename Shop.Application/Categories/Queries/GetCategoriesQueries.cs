using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Shop.Application.Categories.Queries;

using Shop.Domain.Models;

namespace Shop.Application.Categories.Queries
{
     public class GetCategoriesQueries:IRequest<CategoriesViewModel>
    {

    }
}
