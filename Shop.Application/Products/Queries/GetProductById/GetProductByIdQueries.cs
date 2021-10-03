using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Shop.Domain.Models;

namespace Shop.Application.Products.Queries.GetProductById
{
    public  class GetProductByIdQueries:IRequest<Product>
    {
        public int ProductId;

        public GetProductByIdQueries(int id)
        {
            ProductId = id;
        }
    }
}
