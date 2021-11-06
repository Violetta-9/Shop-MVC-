using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shop.DataAccess;

namespace Shop.Application.ProductCart.Queries
{
    public class GetProductFromCartQueriesHandler : IRequestHandler<GetProductFromTheCartQueries, ProductInCardViewModel>
    {
        private readonly ApplicationDbContext _db;

        public GetProductFromCartQueriesHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public Task<ProductInCardViewModel> Handle(GetProductFromTheCartQueries request, CancellationToken cancellationToken)
        {
            var result =  _db.Carts.Include(x => x.Products)
                .Where(x => x.UserId == request.UserId && x.OrderId==null).Select(x => x.Products);
            return Task.FromResult(new ProductInCardViewModel()
            {
                ProductFromCart = result.ToArray()
            });
        }
    }
}
