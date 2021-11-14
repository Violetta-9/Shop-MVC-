using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.DataAccess;

namespace Shop.Application.ProductCart.Command.SubProductInCart
{
    public class SubProductInCartCommandHandler : IRequestHandler<SubProductInCartCommand, Unit>
    {
        private readonly ApplicationDbContext _db;
        public SubProductInCartCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Unit> Handle(SubProductInCartCommand request, CancellationToken cancellationToken)
        {
            var result = _db.Carts.Where(x => x.ProductId == request.ProductId);
            if (result is null)
            {
                //todo:исключение такого продукта нет в бд
                return Unit.Value;
            }
            else
            {
                result.FirstOrDefault().SubQuantity(request.Quentity);
                await _db.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }

        }
    }
}
