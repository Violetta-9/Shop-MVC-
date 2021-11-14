using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shop.DataAccess;

namespace Shop.Application.ProductCart.Queries
{
    public class GetCartByUserIdQueriesHandler : IRequestHandler<GetCartByUserIdQueries, GetCartInfoViewModel>
    {
        private readonly ApplicationDbContext _db;

        public GetCartByUserIdQueriesHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public Task<GetCartInfoViewModel> Handle(GetCartByUserIdQueries request, CancellationToken cancellationToken)
        {
            var result = _db.Carts.Where(x => x.UserId == request.UserId);
            return Task.FromResult(new GetCartInfoViewModel()
            {
                Cart = result.ToArray()
            });
        }
    }
}
