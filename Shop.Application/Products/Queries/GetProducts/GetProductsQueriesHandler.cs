using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Shop.DataAccess;

namespace Shop.Application.Products.Queries.GetProducts
{
    class GetProductsQueriesHandler : IRequestHandler<GetProductQueries, ProductViewModel>
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger logger;
        public GetProductsQueriesHandler(ApplicationDbContext db,ILogger logg)
        {
            _db = db;
            logger = logg;
        }
        public Task<ProductViewModel> Handle(GetProductQueries request, CancellationToken cancellationToken)
        {

            return Task.FromResult(new ProductViewModel()
            {
                Products = _db.Products.ToArray()
            });
        }
    }
}
