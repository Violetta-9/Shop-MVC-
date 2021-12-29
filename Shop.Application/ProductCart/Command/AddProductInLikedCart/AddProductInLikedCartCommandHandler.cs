using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.DataAccess;
using Shop.Domain.Models;

namespace Shop.Application.ProductCart.Command.AddProductInLikedCart
{
    public class AddProductInLikedCartCommandHandler:IRequestHandler<AddProductInLikedCartCommand,int>
    {
        private readonly ApplicationDbContext _db;

        public AddProductInLikedCartCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<int> Handle(AddProductInLikedCartCommand request, CancellationToken cancellationToken)
        {
            var resultFromCart = _db.Likeds.Where(x => x.ProductId == request.ProductId);
            if (resultFromCart.FirstOrDefault() is null)
            {
                var result = new Liked(request.UserId,request.ProductId);
                _db.Likeds.Add(result);
                await _db.SaveChangesAsync(cancellationToken);
                return result.Id;
            }

            return resultFromCart.FirstOrDefault().Id;

        }
    }
}
