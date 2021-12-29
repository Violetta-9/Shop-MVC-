using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.DataAccess;
using Shop.Domain.Exseption;
using Shop.Domain.Models;

namespace Shop.Application.ProductCart.Command.DeleteProductInCart
{
    public class DeleteProductInCartCommandHandler : IRequestHandler<DeleteProductInCartCommand, Unit>
    {
        private readonly ApplicationDbContext _db;
        public DeleteProductInCartCommandHandler(ApplicationDbContext db)
        {
            _db = db;

        }
        public async Task<Unit> Handle(DeleteProductInCartCommand request, CancellationToken cancellationToken)
        {
            var result = await _db.Carts.FindAsync(request.CartId);
            if (result is null)
            {
                throw new NotFoundException(nameof(Cart), request.CartId);
            }
            else
            {
                _db.Remove(result);
                await _db.SaveChangesAsync(cancellationToken);
            }
            return Unit.Value;
        }
    }
}
