using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.ProductCart.Queries.GetUserCart;
using Shop.DataAccess;

namespace Shop.Application.ProductCart.Queries.GetQuantity
{
    public class GetQuentityQuerisHandler : IRequestHandler<GetQuantityQueries, int>
    {
        private readonly ApplicationDbContext _db;

        public GetQuentityQuerisHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public Task<int> Handle(GetQuantityQueries request, CancellationToken cancellationToken)
        {
            var result =  _db.Carts.Include(x => x.Products)
                .Where(x => x.UserId == request.UserId && x.OrderId == null).Select(x=>x.Quantity).ToArray();
           int quentity = 0;
            foreach (var item in result)
            {
                quentity += item;
            }

            return Task.FromResult(quentity);
          
        }
    }
}
