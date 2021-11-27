using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.DataAccess;

namespace Shop.Application.ProductCart.Command.DeleteProductInLikedCart
{
   public  class DeleteProductInLickedCartCommandHandler : IRequestHandler<DeleteProductInLikedCartCommand, Unit>
    {
        private readonly ApplicationDbContext _db;

        public DeleteProductInLickedCartCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Unit> Handle(DeleteProductInLikedCartCommand request, CancellationToken cancellationToken)
        {
            var result = await _db.Likeds.FindAsync(request.CartId);
            if (result is null)
            {
                //todo:исключение 
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
