using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.DataAccess;
using Shop.Domain.Exseption;
using Shop.Domain.Models;

namespace Shop.Application.ProductCart.Queries.GetOrder
{
    public class GetOrderQueriesHandler : IRequestHandler<GetOrderQueries, OrderViewModel>
    {
        private readonly ApplicationDbContext _db;

        public GetOrderQueriesHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public Task<OrderViewModel> Handle(GetOrderQueries request, CancellationToken cancellationToken)
        {
            var boughtProduct = _db.Carts.Include(x => x.Order).Include(x => x.Products)
                .Where(x => x.UserId == request.UserId && x.OrderId != null).ToArray();

            if (boughtProduct == null)
            {
                throw new NotFoundException(nameof(Cart), request.UserId);
            }

            return Task.FromResult(new OrderViewModel()
            {
                ProductInCart = boughtProduct
            });
        }
    }
}
