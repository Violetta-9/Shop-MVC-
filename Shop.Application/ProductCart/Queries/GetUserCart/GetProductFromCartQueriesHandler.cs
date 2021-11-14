using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shop.DataAccess;

namespace Shop.Application.ProductCart.Queries.GetUserCart
{
    public class GetProductFromCartQueriesHandler : IRequestHandler<GetProductFromTheCartQueries, NewClassForProductInCartViewModel>
    {
        private readonly ApplicationDbContext _db;

        public GetProductFromCartQueriesHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public Task<NewClassForProductInCartViewModel> Handle(GetProductFromTheCartQueries request, CancellationToken cancellationToken)
        {
            //var result =  _db.Carts.Include(x => x.Products)
            //    .Where(x => x.UserId == request.UserId && x.OrderId==null).Select(x => x.Products);
            var result = _db.Carts.Include(x => x.Products)
              .Where(x => x.UserId == request.UserId && x.OrderId==null).Select(x => new ProductInCardViewModel()
            {
                CartId=x.Id,
                ProductId=x.ProductId,
                Name = x.Products.Name,
                Priece = x.Products.Price,
                Quantity=x.Quantity,
                Image = x.Products.Image,
                

            });

            return Task.FromResult(new NewClassForProductInCartViewModel()
            {
                Products = result.ToArray()
            }) ;
        }
    }
}
