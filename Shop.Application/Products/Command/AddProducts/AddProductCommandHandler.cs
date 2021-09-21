using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.DataAccess;
using Shop.Domain.Models;

namespace Shop.Application.Products.Command.AddProducts
{
    class AddProductCommandHandler : IRequestHandler<AddProductCommand, int>
    {
        private readonly ApplicationDbContext _db;
        public AddProductCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Description, request.Price, request.Image);
            _db.Products.Add(product);
            await _db.SaveChangesAsync(cancellationToken);
            return product.Id;

        }
    }
}
