using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.DataAccess;
using Shop.Domain.Models;

namespace Shop.Application.ProductCart.Queries.GetUserLikedCart
{
     public class GetProductFromLikedCartQueriesHandler : IRequestHandler<GetProductFromLikedCartQueries, NewLikedCartViewModel>
    {
        private readonly ApplicationDbContext _db;
        public GetProductFromLikedCartQueriesHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public Task<NewLikedCartViewModel> Handle(GetProductFromLikedCartQueries request, CancellationToken cancellationToken)
        {
            var result = _db.Likeds.Where(x => x.UserId == request.UserId).Select(x => new LikedCartViewModel()
            {LikedId = x.Id,
                Name = x.Products.Name,
                Price = x.Products.Price,
                Image=x.Products.Image,
                ProductId = x.ProductId
            });
            return Task.FromResult(new NewLikedCartViewModel()
            {
                ProductInLikedCart = result.ToArray()
            });
        }
    }
}
