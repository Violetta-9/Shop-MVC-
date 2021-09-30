using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Domain.Models;

namespace Shop.Application.Products.Command.DeleteProduct
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public int ProductId;

        public DeleteProductCommand(int id)
        {
            ProductId = id;
        }
    }
}
