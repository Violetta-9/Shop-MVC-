using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.Application.ProductCart.Command;
using Shop.DataAccess;
using Shop.Domain.Models;

namespace Shop.Application.ProductCart.Command.AddProductInCart
{
    public class AddProductInCartCommandHandler : IRequestHandler<AddProductInCartCommand, Unit>
    {
        private readonly ApplicationDbContext _db;

        public AddProductInCartCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Unit> Handle(AddProductInCartCommand request, CancellationToken cancellationToken)
        {
            var result = new Cart(request.ProductId,request.UserId,request.Quantity);
            _db.Carts.Add(result);
            await _db.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
